using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOI4UMT.Library.ModResources;

public interface IModResource {
    string RelativePath { get; }
    FileSaveResult Save(string modRoot);
}

public interface IModResource<T> : IModResource where T : class {
    ISaveableFile<T> SaveableFile { get; }
    T Raw { get; }

    static abstract Option<IModResource> From(ISaveableFile<T> saveableFile, string relativeFilePath);
}
