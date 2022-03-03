using HOI4UMT.Library.Common.Functional.Interfaces;

namespace HOI4UMT.Library.Common.Functional;

public struct FileIO : IFileIO {
    public static readonly IFileIO Default = new FileIO();

    public string ReadAllText(string path)
        => File.ReadAllText(path);
}
