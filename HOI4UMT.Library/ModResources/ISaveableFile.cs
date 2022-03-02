namespace HOI4UMT.Library.ModResources;

public interface ISaveableFile<T> where T : class {
    T Raw { get; }
    FileSaveResult Save(string fullPath);
}

public interface ISaveableFileCreator<T> where T : class {
    static abstract ISaveableFile<T> From(T raw);
}
