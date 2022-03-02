using HOI4UMT.Library.ModResources;
using LanguageExt;

namespace HOI4UMT.Plugin.LandInput;

internal class LandInputResource : ISaveableFile<Bitmap>, ISaveableFileCreator<Bitmap> {
    public Bitmap Raw { get; }

    private LandInputResource(Bitmap raw) {
        Raw = raw;
    }

    public FileSaveResult Save(string fullPath) {
        // Custom handling this save for a mod tool file
        return new(false, Option<string>.None, Option<Exception>.None);
    }

    public static ISaveableFile<Bitmap> From(Bitmap raw)
        => new LandInputResource(raw);
}
