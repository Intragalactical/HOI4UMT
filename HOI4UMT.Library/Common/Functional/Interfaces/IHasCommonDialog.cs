using LanguageExt;

namespace HOI4UMT.Library.Common.Functional.Interfaces;

public interface IHasCommonDialog<RT> where RT : struct, IHasCommonDialog<RT> {
    Eff<RT, ICommonDialogIO> CommonDialogEff { get; }
}
