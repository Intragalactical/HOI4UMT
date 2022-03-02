using HOI4UMT.Library.ModResources;
using LanguageExt;

namespace HOI4UMT.Plugin.ProvinceMap;

internal class ProvinceMapResource : ISaveableFile<Bitmap>, ISaveableFileCreator<Bitmap> {
    public Bitmap Raw { get; }

    private ProvinceMapResource(Bitmap raw) {
        Raw = raw;
    }

    public FileSaveResult Save(string fullPath) {
        try {
            Raw.Save(fullPath);
            return new(true, fullPath, Option<Exception>.None);
        } catch (Exception ex) {
            return new(false, Option<string>.None, ex);
        }
    }

    public static ISaveableFile<Bitmap> From(Bitmap raw)
        => new ProvinceMapResource(raw);
}
