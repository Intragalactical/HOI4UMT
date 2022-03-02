using HOI4UMT.Library;
using HOI4UMT.Library.Common;
using LanguageExt;
using System.Drawing.Imaging;
using ComputeSharp;
using System.Numerics;
using HOI4UMT.Library.ModResources;
using HOI4UMT.Library.ModResources.ResourceTypes;

namespace HOI4UMT.Plugin.ProvinceMap;

public partial class ProvinceMap : UserControl {
    private readonly record struct VoronoiGenerationResult(ReadWriteTexture2D<Rgba32, float4> Texture, IEnumerable<ColorRGB> ColorsUsed);

    private const PixelFormat CorrectPixelFormat = PixelFormat.Format24bppRgb;
    private const int MaxColor = 16777215;

    private enum DistanceFunction {
        Euclidean,
        Manhattan
    }

    private IMapperState MapperState { get; }
    private Option<Bitmap> LandInput { get; set; }
    private ProvinceMapOverlay Overlay { get; }
    private ProvinceMapGeneratingOverlay GeneratingOverlay { get; }

    private IEnumerable<ColorRGB>? HighContrastColors { get; set; } = null;
    private IEnumerable<ColorRGB>? LowContrastColors { get; set; } = null;

    private readonly ColorRGB[] ReservedColors = new ColorRGB[] {
        new(150, 68, 192),
        new(5, 20, 18),
        new(0, 255, 0)
    };

    public ProvinceMap(IMapperState mapperState) {
        InitializeComponent();

        MapperState = mapperState;
        MapperState.OnResourceChanged += MapperState_OnResourceChanged;

        Overlay = new(this, Color.Black, 0.75);
        GeneratingOverlay = new(this, Color.Black, 0.75);

        Overlay.Show();
        Enabled = false;

        _ = GenerateAllColors().ContinueWith(colors => {
            HighContrastColors = colors.Result.HighContrast;
            LowContrastColors = colors.Result.LowContrast;
        });
    }

    private static async Task<(
        IEnumerable<ColorRGB> HighContrast,
        IEnumerable<ColorRGB> LowContrast
    )> GenerateAllColors() {
        IEnumerable<ColorRGB> highContrast = await GenerateColors(100, 255);
        IEnumerable<ColorRGB> lowContrast = await GenerateColors(0, 75);
        return (highContrast, lowContrast);
    }

    private static async Task<IEnumerable<ColorRGB>> GenerateColors(byte minContrast, byte maxContrast)
        => await Task.Run(() =>
            ParallelEnumerable
                .Range(0, MaxColor)
                .Select(c => new ColorRGB(c))
                .Filter(c =>
                    c.R >= minContrast && c.R <= maxContrast &&
                    c.G >= minContrast && c.G <= maxContrast &&
                    c.B >= minContrast && c.B <= maxContrast
                )
        );

    private void MapperState_OnResourceChanged(string name, Option<IModResource> resource) {
        void onLandInputChanged() {
            LandInput = resource.Match(
                resource => ((IModResource<Bitmap>)resource).Raw,
                () => Option<Bitmap>.None
            );
            Overlay.Hide();
            Enabled = true;
        }

        void onProvinceMapChanged() {
            ProvinceMapImage.Image?.Dispose();
            ProvinceMapImage.Image = resource.Match(
                resource => ((IModResource<Bitmap>)resource).Raw,
                () => Properties.Resources.regenerateprovincemap
            );
        }

        Action action = name switch {
            "LandInput" => onLandInputChanged,
            "ProvinceMap" => onProvinceMapChanged,
            _ => () => { }
        };
        action();
    }

    #region NumericUpDown Validators
    private void LandProvinceSizeLowerLimitNUD_ValueChanged(object sender, EventArgs e) {
        if (LandProvinceSizeLowerLimitNUD.Value > LandProvinceSizeUpperLimitNUD.Value)
            LandProvinceSizeLowerLimitNUD.Value = LandProvinceSizeUpperLimitNUD.Value;
    }

    private void LandProvinceSizeUpperLimitNUD_ValueChanged(object sender, EventArgs e) {
        if (LandProvinceSizeUpperLimitNUD.Value < LandProvinceSizeLowerLimitNUD.Value)
            LandProvinceSizeUpperLimitNUD.Value = LandProvinceSizeLowerLimitNUD.Value;
    }

    private void SeaProvinceSizeLowerLimitNUD_ValueChanged(object sender, EventArgs e) {
        if (SeaProvinceSizeLowerLimitNUD.Value > SeaProvinceSizeUpperLimitNUD.Value)
            SeaProvinceSizeLowerLimitNUD.Value = SeaProvinceSizeUpperLimitNUD.Value;
    }

    private void SeaProvinceSizeUpperLimitNUD_ValueChanged(object sender, EventArgs e) {
        if (SeaProvinceSizeUpperLimitNUD.Value < SeaProvinceSizeLowerLimitNUD.Value)
            SeaProvinceSizeUpperLimitNUD.Value = SeaProvinceSizeLowerLimitNUD.Value;
    }

    private void LakeProvinceSizeLowerLimitNUD_ValueChanged(object sender, EventArgs e) {
        if (LakeProvinceSizeLowerLimitNUD.Value > LakeProvinceSizeUpperLimitNUD.Value)
            LakeProvinceSizeLowerLimitNUD.Value = LakeProvinceSizeUpperLimitNUD.Value;
    }

    private void LakeProvinceSizeUpperLimitNUD_ValueChanged(object sender, EventArgs e) {
        if (LakeProvinceSizeUpperLimitNUD.Value < LakeProvinceSizeLowerLimitNUD.Value)
            LakeProvinceSizeUpperLimitNUD.Value = LakeProvinceSizeLowerLimitNUD.Value;
    }
    #endregion

    private async void GenerateProvinceMapButton_Click(object sender, EventArgs e) {
        if (HighContrastColors == null || LowContrastColors == null) {
            _ = MessageBox.Show(
                "Color generation hasn't finished yet, or it might be stuck. Wait a bit and try again, and if that doesn't work, please restart HOI4 UMT and inform the developer about this!",
                "Color generation has not finished!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            return;
        }

        Enabled = false;
        GeneratingOverlay.Show("Starting province map generation...");

        DistanceFunction distanceFunction = DistanceFunctionComboBox.SelectedText == "Euclidean" ?
            DistanceFunction.Euclidean :
            DistanceFunction.Manhattan;

        ColorRGB landColor = new(150, 68, 192);
        ColorRGB seaColor = new(5, 20, 18);
        ColorRGB lakeColor = new(0, 255, 0);

        Option<Bitmap> landInputClone = LandInput.Match(
            landInput => landInput.Clone(new Rectangle(0, 0, landInput.Width, landInput.Height), CorrectPixelFormat),
            Option<Bitmap>.None
        );

        GeneratingOverlay.SetStatus("Generating land provinces...");

        int landProvinceSize = (int)(LandProvinceSizeLowerLimitNUD.Value + LandProvinceSizeUpperLimitNUD.Value) / 2;
        int landProvinceRandomness = (int)LandProvinceSizeUpperLimitNUD.Value - landProvinceSize;
        int seaProvinceSize = (int)(SeaProvinceSizeLowerLimitNUD.Value + SeaProvinceSizeUpperLimitNUD.Value) / 2;
        int seaProvinceRandomness = (int)SeaProvinceSizeUpperLimitNUD.Value - seaProvinceSize;
        int lakeProvinceSize = (int)(LakeProvinceSizeLowerLimitNUD.Value + LakeProvinceSizeUpperLimitNUD.Value) / 2;
        int lakeProvinceRandomness = (int)LakeProvinceSizeUpperLimitNUD.Value - lakeProvinceSize;

        Either<Exception, VoronoiGenerationResult> landProvinceGenerationResultOrException =
            await landInputClone.MatchAsync(
                landInputClone => GenerateVoronoi(
                    GetTextureFromBitmap(landInputClone),
                    landProvinceSize,
                    landProvinceRandomness,
                    landColor,
                    HighContrastColors,
                    distanceFunction
                ),
                () => new Exception("Land Input Map has not been set! This should not happen, please report to the developer! :-)")
            );

        GeneratingOverlay.SetStatus("Generating sea provinces...");

        Either<Exception, VoronoiGenerationResult> seaProvinceGenerationResultOrException =
            await landProvinceGenerationResultOrException.MatchAsync(
                landProvinceGenerationResult => {
                    (ReadWriteTexture2D<Rgba32, float4> texture, _) = landProvinceGenerationResult;
                    return GenerateVoronoi(
                        texture,
                        seaProvinceSize,
                        seaProvinceRandomness,
                        seaColor,
                        LowContrastColors
                            .Except(ReservedColors),
                        distanceFunction
                    );
                },
                exception => exception
            );

        GeneratingOverlay.SetStatus("Generating lake provinces...");

        Either<Exception, VoronoiGenerationResult> provinceMapGenerationResultOrException =
            await seaProvinceGenerationResultOrException.MatchAsync(
                seaProvinceGenerationResult =>
                    GenerateVoronoi(
                        seaProvinceGenerationResult.Texture,
                        lakeProvinceSize,
                        lakeProvinceRandomness,
                        lakeColor,
                        LowContrastColors
                            .Except(ReservedColors.ConcatFast(seaProvinceGenerationResult.ColorsUsed)),
                        distanceFunction
                    ),
                exception => exception
            );

        GeneratingOverlay.SetStatus("Post-Processing Province Map...");

        Either<Exception, ReadWriteTexture2D<Rgba32, float4>> postProcessedTextureOrException =
            await provinceMapGenerationResultOrException.MatchAsync(
                provinceMapGenerationResult => PostProcess(provinceMapGenerationResult.Texture),
                exception => exception
            );

        GeneratingOverlay.SetStatus("Finishing...");

        Unit setProvinceMapResource(ReadWriteTexture2D<Rgba32, float4> postProcessedTexture) {
            Bitmap provinceMap = GetBitmapFromTexture(postProcessedTexture);
            ISaveableFile<Bitmap> resource = ProvinceMapResource.From(provinceMap);

            MapperState.SetResource(
                "ProvinceMap",
                ImageResource<Bitmap>.From(resource, "map/provinces.bmp")
            );

            return Unit.Default;
        }

        Unit onError(Exception exception) {
            _ = MessageBox.Show(exception.Message, "Exception during province map generation!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return Unit.Default;
        }

        _ = postProcessedTextureOrException.Match(
            setProvinceMapResource,
            onError
        );

        GeneratingOverlay.Hide();
        Enabled = true;
    }

    // @TODO: Move these following 2 functions somewhere else
    // Utils class? Extension Methods?

    private static Bitmap GetBitmapFromTexture(in ReadWriteTexture2D<Rgba32, float4> texture) {
        using MemoryStream textureStream = new();
        textureStream.Position = 0;
        texture.Save(textureStream, ComputeSharp.ImageFormat.Bmp);

        Bitmap finalBmp = (Bitmap)Image.FromStream(textureStream);
        return PixelFormatConverter.ConvertRGB(finalBmp, PixelFormat.Format24bppRgb);
    }

    private static ReadWriteTexture2D<Rgba32, float4> GetTextureFromBitmap(in Bitmap bmp) {
        using MemoryStream bmpImageStream = new();
        bmp.Save(bmpImageStream, System.Drawing.Imaging.ImageFormat.Bmp);
        bmpImageStream.Position = 0;

        bmp.Dispose();

        return GraphicsDevice.Default.LoadReadWriteTexture2D<Rgba32, float4>(bmpImageStream);
    }

    private static async Task<Either<Exception, ReadWriteTexture2D<Rgba32, float4>>> PostProcess(
        ReadWriteTexture2D<Rgba32, float4> texture
    )
        => await Task.Run(() => {
            GraphicsDevice.Default.For(
                texture.Width,
                texture.Height,
                new PostProcessorShader(texture)
            );

            return texture;
        });

    // @TODO: make sure that from (the parameter) does not get directly modified!
    // As it is, it does, and that makes this NOT a pure function!!!
    private static async Task<Either<Exception, VoronoiGenerationResult>> GenerateVoronoi(
        ReadWriteTexture2D<Rgba32, float4> from, // @TODO: add "in" when possible
        int size,
        int randomness,
        ColorRGB colorToDrawOn,
        IEnumerable<ColorRGB> colorsToUse,
        DistanceFunction distanceFunction
    )
        => await Task.Run<Either<Exception, VoronoiGenerationResult>>(() => {
            int bmpWidth = from.Width;
            int bmpHeight = from.Height;

            int cells = ((bmpWidth / size) + 1) * ((bmpHeight / size) + 1);

            ColorRGB[] colors = colorsToUse
                .OrderBy(_ => ThreadSafeRandom.Next())
                .Take(cells)
                .ToArray();

            IDictionary<Point2D, ColorRGB> Points = new Dictionary<Point2D, ColorRGB>();

            int colorIndex = 0;
            for (int y = 0; y < bmpHeight; y += size) {
                for (int x = 0; x < bmpWidth; x += size) {
                    int randomX = ThreadSafeRandom.Next(-randomness, randomness + 1);
                    int randomY = ThreadSafeRandom.Next(-randomness, randomness + 1);
                    // Here, it is okay to fail. We don't necessarily need every single cell.
                    // But, @TODO: see if there's a cleaner way to handle this.
                    bool addedPoint = Points.TryAdd(new Point2D(x + randomX, randomY + y), colors[colorIndex]);

                    if (addedPoint)
                        colorIndex++;
                }
            }

            using ReadWriteBuffer<Vector2> pointsBuffer = GraphicsDevice.Default.AllocateReadWriteBuffer(
                Points.Keys.Select(p => p.ToVector2()).ToArray()
            );
            using ReadWriteBuffer<float3> colorsBuffer = GraphicsDevice.Default.AllocateReadWriteBuffer(
                Points.Values.Select(v => v.ToFloat3()).ToArray()
            );
            GraphicsDevice.Default.For(
                bmpWidth,
                bmpHeight,
                new VoronoiShader(
                    from,
                    pointsBuffer,
                    colorsBuffer,
                    colorToDrawOn.ToFloat3(),
                    distanceFunction == DistanceFunction.Euclidean
                )
            );

            // @TODO: see if we can use colorIndex here for performance reasons.
            return new VoronoiGenerationResult(from, colors);
        });

    private void ProvinceMap_Resize(object sender, EventArgs e) {
    }

    private void ImageSaveMenuItem_Click(object sender, EventArgs e) {
        if (ProvinceMapImage.Image != null) {
            SaveFileDialog saveImageDialog = new() {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Filter = "Bitmap File (*.bmp)|*.bmp",
                Title = "Save the current province map image as a bitmap"
            };
            if (saveImageDialog.ShowDialog() == DialogResult.OK) {
                ProvinceMapImage.Image.Save(saveImageDialog.FileName);
                _ = MessageBox.Show($"Image saved to {saveImageDialog.FileName} successfully!", "Image saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void ProvinceMap_Load(object sender, EventArgs e) {
        DistanceFunctionComboBox.SelectedIndex = 0;
        MainToolTip.SetToolTip(UseDX12ComputeShadersCheckBox, "With this option enabled, the GPU will generate the province map instead of the CPU, and will be a lot faster.\nEnabled by default, please keep enabled if you have a compatible GPU and drivers.");
    }

    /*
    private async void GenerateProvinceMapButton_Click(object sender, EventArgs e) {
        if (LandInput != null) {
            Func<Point2D, Point2D, double> distanceFunction = DistanceFunctionComboBox.SelectedText == "Euclidean" ?
                DistanceFunctions[DistanceFunction.Euclidean] :
                DistanceFunctions[DistanceFunction.Manhattan];

            ColorRGB landColor = new(150, 68, 192);
            ColorRGB seaColor = new(5, 20, 18);
            ColorRGB lakeColor = new(0, 255, 0);

            int landProvinceSize = (int)(LandProvinceSizeLowerLimitNUD.Value + LandProvinceSizeUpperLimitNUD.Value) / 2;
            int landProvinceRandomness = (int)LandProvinceSizeUpperLimitNUD.Value - landProvinceSize;
            Either<Exception, Bitmap> landProvincesOrException =
                await CreateVoronoiDiagram(LandInput, landProvinceSize, landProvinceRandomness, distanceFunction, landColor);

            int seaProvinceSize = (int)(SeaProvinceSizeLowerLimitNUD.Value + SeaProvinceSizeUpperLimitNUD.Value) / 2;
            int seaProvinceRandomness = (int)SeaProvinceSizeUpperLimitNUD.Value - seaProvinceSize;
            Either<Exception, Bitmap> landAndSeaProvincesOrException = await landProvincesOrException.MatchAsync(
                landProvinces => {
                    Task<Either<Exception, Bitmap>> result =
                        CreateVoronoiDiagram(landProvinces, seaProvinceSize, seaProvinceRandomness, distanceFunction, seaColor);
                    landProvinces.Dispose();
                    return result;
                },
                exception => exception
            );

            int lakeProvinceSize = (int)(LakeProvinceSizeLowerLimitNUD.Value + LakeProvinceSizeUpperLimitNUD.Value) / 2;
            int lakeProvinceRandomness = (int)LakeProvinceSizeUpperLimitNUD.Value - lakeProvinceSize;
            Either<Exception, Bitmap> provinceMapOrException = await landAndSeaProvincesOrException.MatchAsync(
                landAndSeaProvinces => {
                    Task<Either<Exception, Bitmap>> result =
                        CreateVoronoiDiagram(landAndSeaProvinces, lakeProvinceSize, lakeProvinceRandomness, distanceFunction, lakeColor);
                    landAndSeaProvinces.Dispose();
                    return result;
                },
                exception => exception
            );

            _ = provinceMapOrException.Match(
                MapperState.SetProvinceMap,
                exception => MessageBox.Show(exception.Message, "Exception during province map generation!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            );
        }
    }

    private Task<Either<Exception, Bitmap>> CreateVoronoiDiagram(
        Bitmap from,
        int size,
        int randomness,
        Func<Point2D, Point2D, double> distanceFunction,
        ColorRGB onColor
    ) => Task.Run<Either<Exception, Bitmap>>(() => {
        Bitmap bmp = from.Clone(new Rectangle(0, 0, from.Width, from.Height), PixelFormat.Format24bppRgb);

        int cells = ((bmp.Width / size) + 1) * ((bmp.Height / size) + 1);

        ColorRGB[] colors = ParallelEnumerable
            .Range(0, MaxColor)
            .Select(value => new ColorRGB(value))
            .Filter(value => !ReservedColors.Contains(value))
            .OrderBy(_ => ThreadSafeRandom.Next())
            .Take(cells)
            .ToArray();

        ConcurrentDictionary<Point2D, ColorRGB> Points = new();
        bool couldNotAddOne = false;

        // For asynchronous operation
        int bmpHeight = bmp.Height;
        int bmpWidth = bmp.Width;

        int i = 0;
        _ = Parallel.For(0, bmpHeight, y => {
            if (y % size == 0) {
                for (int x = 0; x < bmpWidth; x += size) {
                    int randomX = ThreadSafeRandom.Next(-randomness, randomness + 1);
                    int randomY = ThreadSafeRandom.Next(-randomness, randomness + 1);
                    couldNotAddOne = !Points.TryAdd(new Point2D(x + randomX, randomY + y), colors[i]) || couldNotAddOne;
                    i++;
                }
            }
        });

        if (couldNotAddOne) {
            return new Exception("Error: could not add a province cell during province map generation!\nPlease tell the developer about this!");
        }

        BitmapData locked = bmp.LockBits(
            new(0, 0, bmp.Width, bmp.Height),
            ImageLockMode.ReadWrite,
            bmp.PixelFormat
        );

        int bytesPerPixel = Image.GetPixelFormatSize(locked.PixelFormat) / 8;
        int width = locked.Width;
        int heightInPixels = locked.Height;

        _ = Parallel.For(0, heightInPixels, y => {
            for (int x = 0; x < width; x++) {
                Point2D closestPoint = GetClosestPoint(new(x, y), Points.Keys, distanceFunction);
                bool success = Points.TryGetValue(closestPoint, out ColorRGB color);

                if (success) {
                    var (r, g, b) = color;

                    int xInBytes = x * bytesPerPixel;
                    unsafe {
                        byte* currentLine = (byte*)locked.Scan0 + (y * locked.Stride);
                        byte currentB = currentLine[xInBytes];
                        byte currentG = currentLine[xInBytes + 1];
                        byte currentR = currentLine[xInBytes + 2];
                        ColorRGB currentColor = new(currentR, currentG, currentB);

                        if (currentColor.R == onColor.R && currentColor.G == onColor.G && currentColor.B == onColor.B) {
                            currentLine[xInBytes] = b;
                            currentLine[xInBytes + 1] = g;
                            currentLine[xInBytes + 2] = r;
                        }
                    }
                }
            }
        });

        bmp.UnlockBits(locked);

        GC.Collect();
        GC.Collect();

        return bmp;
    });

    private static Point2D GetClosestPoint(Point2D source, IEnumerable<Point2D> points, Func<Point2D, Point2D, double> distanceFunction) {
        Point2D closest = points.OrderBy(destination => distanceFunction(source, destination)).First();
        return closest;
    }

    private static double GetEuclideanDistance(Point2D source, Point2D destination)
        => Math.Sqrt(
            ((source.X - destination.X) * (source.X - destination.X)) +
            ((source.Y - destination.Y) * (source.Y - destination.Y))
        );

    private static double GetManhattanDistance(Point2D source, Point2D destination)
        => Math.Abs(source.X - destination.X) + Math.Abs(source.Y - destination.Y);*/
}
