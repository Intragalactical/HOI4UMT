using LanguageExt;

namespace HOI4UMT.Library.ModResources.ResourceTypes;

public class ImageResource<T> : IModResource<T> where T : Image {
    public ISaveableFile<T> SaveableFile { get; }
    public T Raw => SaveableFile.Raw;
    public string RelativePath { get; }

    private ImageResource(ISaveableFile<T> saveableFile, string relativePath) {
        SaveableFile = saveableFile;
        RelativePath = relativePath;
    }

    public FileSaveResult Save(string modRoot)
        => SaveableFile.Save(Path.Combine(modRoot, RelativePath));

    public static Option<IModResource> From(ISaveableFile<T> saveableFile, string relativePath)
        => new ImageResource<T>(saveableFile, relativePath);
}
