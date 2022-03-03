using System.Data;
using System.Drawing.Imaging;
using HOI4UMT.Library;
using HOI4UMT.Library.Common;
using HOI4UMT.Library.ModResources;
using HOI4UMT.Library.ModResources.ResourceTypes;
using Newtonsoft.Json;
using LanguageExt;
using HOI4UMT.Library.Common.Functional;

namespace HOI4UMT.Plugin.RiverMap;

public partial class RiverMap : UserControl {
    private IMapperState MapperState { get; }

    private Option<Bitmap> landInput = Option<Bitmap>.None;
    private Option<Bitmap> LandInput {
        get => landInput;
        set {
            if (landInput != value) {
                _ = landInput.Iter(landInput => landInput.Dispose());

                GenerateFromLandInputButton.Enabled = value.IsSome;

                landInput = value;
            }
        }
    }

    private Option<Bitmap> riverMapBmp = Option<Bitmap>.None;
    private Option<Bitmap> RiverMapBmp {
        get => riverMapBmp;
        set {
            if (riverMapBmp != value) {
                _ = riverMapBmp.Iter(riverMapBmp => riverMapBmp.Dispose());

                riverMapBmp = value;

                RiverMapImage.Image = riverMapBmp.Match(
                    riverMap => riverMap,
                    () => Properties.Resources.Draganddrop
                );

                Option<ISaveableFile<Bitmap>> resource = riverMapBmp.Match(
                    riverMap => Option<ISaveableFile<Bitmap>>.Some(RiverMapResource.From(riverMap)),
                    Option<ISaveableFile<Bitmap>>.None
                );
                MapperState.SetResource(
                    "RiverMap",
                    resource.Match(
                        res => ImageResource<Bitmap>.From(res, string.Empty),
                        Option<IModResource>.None
                    )
                );
            }
        }
    }

    private RiverMapGeneratingOverlay GeneratingOverlay { get; }

    private ColorRGB[] ColorPalette { get; }

    private static IReadOnlyDictionary<ColorRGB, ColorRGB> LandInputToRiverMap { get; } = new Dictionary<ColorRGB, ColorRGB>() {
        { new(150, 68, 192), new(255, 255, 255) },
        { new(5, 20, 18), new(122, 122, 122) },
        { new(0, 255, 0), new(122, 122, 122) }
    };

    public RiverMap(IMapperState mapperState, string subfolder) {
        InitializeComponent();

        GeneratingOverlay = new(this, Color.Black, 0.75);

        string jsonFileContent = File<Runtime>
            .ReadAllText($"{subfolder}/palette.json")
            .Run(new Runtime())
            .Match(s => s, _ => "[]");

        ColorPalette = (
            JsonConvert.DeserializeObject<Color[]>(jsonFileContent) ??
            Enumerable.Range(0, 255).Select(_ => Color.Fuchsia).ToArray()
        )
            .Select(color => new ColorRGB(color))
            .ToArray();

        MapperState = mapperState;
        MapperState.OnResourceChanged += MapperState_OnResourceChanged;
    }

    private Unit MapperState_OnResourceChanged(string name, Option<IModResource> resource) {
        Func<Unit> action = name switch {
            "LandInput" => () => {
                LandInput = resource.Match(
                    resource => ((IModResource<Bitmap>)resource).Raw,
                    () => Option<Bitmap>.None
                );

                return Unit.Default;
            },
            _ => () => Unit.Default
        };
        return action();
    }

    private async void RiverMapImage_MouseClick(object sender, MouseEventArgs e) {
        RiverMapBmp = e.Button == MouseButtons.Left ?
            await SelectAndLoadRiverMap(ColorPalette, RiverMapBmp) :
            RiverMapBmp;
    }

    private static async Task<Option<Bitmap>> SelectAndLoadRiverMap(ColorRGB[] colorPalette, Option<Bitmap> currentRiverMap) {
        OpenFileDialog openFileDialog = new() {
            Title = "Open a River Map Image",
            Filter = "Bitmap File (*.BMP)|*.BMP"
        };

        async Task<Option<Bitmap>> load() {
            Bitmap bmp = await LoadRiverMap(openFileDialog.FileName, colorPalette);
            _ = MessageBox.Show(
                $"River map loaded from {openFileDialog.FileName}!",
                "River map loaded successfully!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return bmp;
        }

        async Task<Option<Bitmap>> current()
            => await Task.FromResult(currentRiverMap);

        Func<Task<Option<Bitmap>>> action = openFileDialog.ShowDialog() switch {
            DialogResult.OK => load,
            DialogResult x when x != DialogResult.OK => current,
            _ => current
        };

        return await action();
    }

    private static async Task<Bitmap> LoadRiverMap(string fileName, ColorRGB[] colorPalette)
        => await Task.Run(() => PixelFormatConverter.ConvertToIndexed(
            (Bitmap)Image.FromFile(fileName),
            PixelFormat.Format8bppIndexed,
            colorPalette
        ));

    private async void GenerateFromLandInputButton_Click(object sender, EventArgs e) {
        GeneratingOverlay.Show("Generating River Map...");
        RiverMapBmp = await LandInput.MatchAsync(
            landInput => GenerateFromLandInput(landInput, ColorPalette),
            () => Properties.Resources.Draganddrop
        );
        GeneratingOverlay.Hide();
    }

    private static async Task<Bitmap> GenerateFromLandInput(Bitmap landInput, ColorRGB[] colorPalette)
        => await Task.Run(() => {
            Bitmap newBitmap = new(landInput.Width, landInput.Height, PixelFormat.Format8bppIndexed);

            ColorPalette newPalette = newBitmap.Palette;
            for (int i = 0; i < colorPalette.Length; i++)
                newPalette.Entries[i] = colorPalette[i].ToDrawingColor();
            newBitmap.Palette = newPalette;

            BitmapData locked = landInput.LockBits(
                new(0, 0, landInput.Width, landInput.Height),
                ImageLockMode.ReadOnly,
                landInput.PixelFormat
            );
            BitmapData lockedNew = newBitmap.LockBits(
                new(0, 0, newBitmap.Width, newBitmap.Height),
                ImageLockMode.WriteOnly,
                newBitmap.PixelFormat
            );

            int bytesPerPixelImage = Image.GetPixelFormatSize(locked.PixelFormat) / 8;
            int bytesPerPixelNew = Image.GetPixelFormatSize(lockedNew.PixelFormat) / 8;
            int widthImage = locked.Width;
            int heightInPixelsImage = locked.Height;

            List<ColorRGB> paletteList = colorPalette.ToList();

            _ = Parallel.For(0, heightInPixelsImage, y => {
                for (int x = 0; x < widthImage; x++) {
                    int xInBytesImage = x * bytesPerPixelImage;
                    int xInBytesNew = x * bytesPerPixelNew;

                    unsafe {
                        byte* currentLineImage = (byte*)locked.Scan0 + (y * locked.Stride);
                        byte* currentLineNew = (byte*)lockedNew.Scan0 + (y * lockedNew.Stride);

                        byte currentBImage = currentLineImage[xInBytesImage];
                        byte currentGImage = currentLineImage[xInBytesImage + 1];
                        byte currentRImage = currentLineImage[xInBytesImage + 2];

                        ColorRGB currentColor = new(currentRImage, currentGImage, currentBImage);
                        ColorRGB newColor = LandInputToRiverMap[currentColor];

                        currentLineNew[xInBytesNew] = (byte)Math.Min(255, Math.Max(0, paletteList.IndexOf(newColor)));
                    }
                }
            });

            landInput.UnlockBits(locked);
            newBitmap.UnlockBits(lockedNew);

            return newBitmap;
        });

    private async void SaveAsContextMenuItem_Click(object sender, EventArgs e) {
        SaveFileDialog saveFileDialog = new() {
            Title = "Save River Map as a Bitmap Image...",
            FileName = "rivers.bmp",
            Filter = "Bitmap File (*.BMP)|*.BMP"
        };

        async Task<Unit> save()
            => await Task.Run(() => {
                using Bitmap inCorrectFormat = PixelFormatConverter.ConvertToIndexed(
                    (Bitmap)RiverMapImage.Image,
                    PixelFormat.Format8bppIndexed,
                    ColorPalette,
                    false
                );
                inCorrectFormat.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                _ = MessageBox.Show(
                    $"River Map Image saved to {saveFileDialog.FileName}!",
                    "River Map saved!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return Unit.Default;
            });

        async Task<Unit> none()
            => await Task.FromResult(Unit.Default);

        Func<Task<Unit>> action = saveFileDialog.ShowDialog() switch {
            DialogResult.OK => save,
            DialogResult x when x != DialogResult.OK => none,
            _ => none
        };

        _ = await action();
    }

    private async void LoadRiverMapButton_Click(object sender, EventArgs e) {
        RiverMapBmp = await SelectAndLoadRiverMap(ColorPalette, RiverMapBmp);
    }
}
