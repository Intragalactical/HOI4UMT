using HOI4UMT.Library;
using HOI4UMT.Library.Common;
using HOI4UMT.Library.Common.Functional;
using HOI4UMT.Library.ModResources;
using HOI4UMT.Library.ModResources.ResourceTypes;
using LanguageExt;
using LanguageExt.Common;
using System.Drawing.Imaging;

namespace HOI4UMT.Plugin.LandInput;

public partial class LandInput : UserControl {
    private const PixelFormat LandInputPixelFormat = PixelFormat.Format24bppRgb;

    private static readonly ColorRGB[] AllowedColors = new ColorRGB[] {
        new(150, 68, 192),
        new(5, 20, 18),
        new(0, 255, 0)
    };

    private IMapperState MapperState { get; }

    private Runtime Runtime { get; }

    public LandInput(IMapperState mapperState) {
        InitializeComponent();

        Runtime = new();

        MapperState = mapperState;
        MapperState.OnResourceChanged += MapperState_OnResourceChanged;
    }

    private Unit MapperState_OnResourceChanged(string name, Option<IModResource> resource) {
        static Unit onLandInputChanged(
            PictureBox landInputImage,
            ToolStripMenuItem saveAsContextMenuItem,
            ToolStripMenuItem clearImageContextMenuItem,
            Option<IModResource> resource
        ) {
            landInputImage.Image = resource.Match(
                resource => ((IModResource<Bitmap>)resource).Raw,
                () => Properties.Resources.Draganddrop
            );

            saveAsContextMenuItem.Enabled = resource.IsSome;
            clearImageContextMenuItem.Enabled = resource.IsSome;

            return Unit.Default;
        }

        return ((Func<Unit>)(name switch {
            "LandInput" => () => onLandInputChanged(
                LandInputImage,
                SaveAsContextMenuItem,
                ClearImageContextMenuItem,
                resource
            ),
            _ => () => Unit.Default
        }))();
    }

    private static EitherAsync<Error, Bitmap> OnImageLoad(Bitmap image)
        => Task.Run(() => {
            using Bitmap copy = new(image);
            Bitmap formatCorrected = copy.Clone(new Rectangle(0, 0, copy.Width, copy.Height), PixelFormat.Format24bppRgb);

            BitmapData locked = formatCorrected.LockBits(
                new(0, 0, formatCorrected.Width, formatCorrected.Height),
                ImageLockMode.ReadOnly,
                formatCorrected.PixelFormat
            );
            int bytesPerPixel = Image.GetPixelFormatSize(formatCorrected.PixelFormat) / 8;
            int width = locked.Width;
            int heightInPixels = locked.Height;

            object syncLock = new();
            Option<Exception> loadImageException = Option<Exception>.None;

            _ = Parallel.For(0, heightInPixels, y => {
                for (int x = 0; x < width; x++) {
                    int xInBytes = x * bytesPerPixel;
                    unsafe {
                        byte* currentLine = (byte*)locked.Scan0 + (y * locked.Stride);
                        byte currentB = currentLine[xInBytes];
                        byte currentG = currentLine[xInBytes + 1];
                        byte currentR = currentLine[xInBytes + 2];
                        ColorRGB currentColor = new(currentR, currentG, currentB);

                        if (!AllowedColors.Contains(currentColor)) {
                            lock (syncLock) {
                                if (loadImageException.IsNone) {
                                    loadImageException = new Exception(
                                        string.Format("Pixel at x{0}, y{1} has wrong RGB value! {2} is not allowed!", x, y, currentColor)
                                    );
                                }
                            }
                        }

                        // @TODO: figure out the colors of the 4 surrounding pixels

                    }
                }
            });

            formatCorrected.UnlockBits(locked);

            return loadImageException.Match<Either<Error, Bitmap>>(exception => Error.New(exception), () => formatCorrected);
        }).ToAsync();

    private async void LandInputImage_MouseClick(object sender, MouseEventArgs e) {
        Bitmap newLandInputImage = (Bitmap)(e.Button == MouseButtons.Left ?
            await LoadLandInputImage(Runtime)
                .Match(
                    landInputImage => landInputImage.Match(
                        image => MessageBox<Runtime>
                            .Show(
                                $"Land Input map loaded successfully!",
                                "Land Input map loaded successfully!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            )
                            .Run(Runtime)
                            .Match(_ => image, _ => image),
                        () => LandInputImage.Image
                    ),
                    error => MessageBox<Runtime>
                        .Show(
                            $"{error.Message}\n\nLand Input Map was NOT loaded.",
                            "Error during land input map load!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        )
                        .Run(Runtime)
                        .Match(_ => LandInputImage.Image, _=> LandInputImage.Image)
                ) :
            LandInputImage.Image);

        ISaveableFile<Bitmap> resource = LandInputResource.From(newLandInputImage);
        _ = MapperState
            .SetResource(
                "LandInput",
                ImageResource<Bitmap>.From(resource, string.Empty)
            )
            .SetResource(
                "ProvinceMap",
                Option<IModResource>.None
            );
    }

    private static EitherAsync<Error, Option<Bitmap>> LoadLandInputImage(Runtime runtime) {
        using OpenFileDialog fileDialog = new OpenFileDialog() {
            Title = "Open a land input map (.BMP FILES ONLY)",
            Filter = "BMP Files (*.bmp)|*.bmp"
        };

        static EitherAsync<Error, Option<Bitmap>> load(
            Runtime runtime,
            string filePath
        ) =>
            Image<Runtime>
                .FromFile(filePath)
                .Run(runtime)
                .Match<Either<Error, Bitmap>>(image => (Bitmap)image, error => error)
                .Match(image => OnImageLoad(image), error => error)
                .Match<Either<Error, Option<Bitmap>>>(image => Option<Bitmap>.Some(image), exception => exception)
                .ToAsync();

        return CommonDialog<Runtime>
            .ShowDialog(fileDialog)
            .Run(runtime)
            .Match(
                dialogResult => ((Func<EitherAsync<Error, Option<Bitmap>>>)(dialogResult switch {
                    DialogResult.OK => () => load(runtime, fileDialog.FileName),
                    DialogResult x when x != DialogResult.OK => () => Option<Bitmap>.None,
                    _ => () => Option<Bitmap>.None
                }))(),
                error => error
            );
    }

    private void SaveAsContextMenuItem_Click(object sender, EventArgs e) {
        _ = SaveLandInputMap(Runtime, LandInputImage.Image)
            .Match(
                unit => unit.Match(
                    _ => MessageBox<Runtime>
                        .Show(
                            $"Land Input map has been saved successfully!",
                            "Land Input map saved successfully!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        )
                        .Run(Runtime)
                        .Match(_ => Unit.Default, _ => Unit.Default),
                    () => Unit.Default
                ),
                error => MessageBox<Runtime>
                    .Show(
                        error.Message,
                        "Could not save land input image!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    )
                    .Run(Runtime)
                    .Match(_ => Unit.Default, _ => Unit.Default)
            );
    }

    private static Either<Error, Option<Unit>> SaveLandInputMap(Runtime runtime, Option<Image> landInputBmp) {
        SaveFileDialog saveFileDialog = new SaveFileDialog() {
            Title = "Save Land Input Image as Bitmap...",
            Filter = "Bitmap Files (*.BMP)|*.BMP",
            FileName = "LandInput.bmp"
        };

        static Either<Error, Option<Unit>> saveBmp(Runtime runtime, Image bmp, string fileName)
            => Image<Runtime>
                .Save(bmp, fileName, ImageFormat.Bmp)
                .Run(runtime)
                .Match<Either<Error, Option<Unit>>>(unit => Option<Unit>.Some(unit), error => error);

        static Either<Error, Option<Unit>> convertAndSave(Runtime runtime, Option<Image> landInputBmp, string fileName)
            => landInputBmp
                .Match<Either<Error, Image>>(
                    landInput => PixelFormatConverter.ConvertToNonIndexed((Bitmap)landInput, PixelFormat.Format24bppRgb, false),
                    () => Error.New("No land input image has been loaded that could be saved!")
                )
                .Match(bmp => saveBmp(runtime, bmp, fileName), error => error);

        return CommonDialog<Runtime>
            .ShowDialog(saveFileDialog)
            .Run(runtime)
            .Match(
                dialogResult => ((Func<Either<Error, Option<Unit>>>)(dialogResult switch {
                    DialogResult.OK => () => convertAndSave(runtime, landInputBmp, saveFileDialog.FileName),
                    DialogResult x when x != DialogResult.OK => () => Option<Unit>.None,
                    _ => () => Option<Unit>.None
                }))(),
                error => error
            );
    }

    private void ClearImageContextMenuItem_Click(object sender, EventArgs e) {
        _ = MapperState.SetResource("LandInput", Option<IModResource>.None);
        _ = MessageBox<Runtime>
            .Show(
                "Land Input map cleared!",
                "Land Input map cleared successfully!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
            .Run(Runtime);
    }
}
