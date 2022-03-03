using HOI4UMT.Library.ModResources;
using LanguageExt;
using System.Drawing.Imaging;

namespace HOI4UMT.Plugin.RiverMap;

internal class RiverMapResource : ISaveableFile<Bitmap>, ISaveableFileCreator<Bitmap> {
    public Bitmap Raw { get; }

    private RiverMapResource(Bitmap raw) {
        Raw = raw;
    }

    public FileSaveResult Save(string fullPath) {
        try {
            Raw.Save(fullPath, ImageFormat.Bmp);
            return new(true, fullPath, Option<Exception>.None);
        } catch (Exception ex) {
            return new(false, Option<string>.None, ex);
        }
    }

    public static ISaveableFile<Bitmap> From(Bitmap raw)
        => new RiverMapResource(raw);
}
