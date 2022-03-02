using HOI4UMT.Library;
using HOI4UMT.Library.Common;
using HOI4UMT.Library.ModResources;
using HOI4UMT.Library.ModResources.ResourceTypes;
using LanguageExt;
using System.Drawing.Imaging;

namespace HOI4UMT.Plugin.LandInput;

public partial class LandInput : UserControl {
    private IMapperState MapperState { get; }

    private const PixelFormat LandInputPixelFormat = PixelFormat.Format24bppRgb;

    private static readonly ColorRGB[] AllowedColors = new ColorRGB[] {
        new(150, 68, 192),
        new(5, 20, 18),
        new(0, 255, 0)
    };

    public LandInput(IMapperState mapperState) {
        InitializeComponent();

        MapperState = mapperState;
        MapperState.OnResourceChanged += MapperState_OnResourceChanged;
    }

    private void MapperState_OnResourceChanged(string name, Option<IModResource> resource) {
        Action action = name switch {
            "LandInput" => () => {
                LandInputImage.Image = resource.Match(
                    resource => ((IModResource<Bitmap>)resource).Raw,
                    () => Properties.Resources.Draganddrop
                );
            },
            _ => () => { }
        };
        action();
    }

    private static Task<Either<Exception, Image>> OnImageLoad(Bitmap image)
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

            return loadImageException.Match<Either<Exception, Image>>(exception => exception, () => formatCorrected);
        });

    private async void LandInputImage_Click(object sender, EventArgs e) {
        using OpenFileDialog fileDialog = new OpenFileDialog() {
            Title = "Open a land input map (.BMP FILES ONLY)",
            Filter = "BMP Files (*.bmp)|*.bmp"
        };
        DialogResult result = fileDialog.ShowDialog();

        if (result == DialogResult.OK) {
            Either<Exception, Image> loadedImage = await OnImageLoad((Bitmap)Image.FromFile(fileDialog.FileName));
            _ = loadedImage.Match(
                image => {
                    ISaveableFile<Bitmap> resource = LandInputResource.From((Bitmap)image);
                    MapperState.SetResource(
                        "LandInput",
                        ImageResource<Bitmap>.From(resource, string.Empty)
                    );
                    MapperState.SetResource(
                        "ProvinceMap",
                        Option<IModResource>.None
                    );
                },
                exception => MessageBox.Show(exception.Message, "Error during land input map load!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            );
        }
    }
}
