using LanguageExt;

namespace HOI4UMT.Library.Common.Functional.Interfaces;

public interface IHasFile<RT> where RT : struct, IHasFile<RT> {
    Eff<RT, IFileIO> FileEff { get; }
}
