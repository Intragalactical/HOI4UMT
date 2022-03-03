using LanguageExt;

namespace HOI4UMT.Library.Common.Functional.Interfaces;

public interface IHasImage<RT> where RT : struct, IHasImage<RT> {
    Eff<RT, IImageIO> ImageEff { get; }
}
