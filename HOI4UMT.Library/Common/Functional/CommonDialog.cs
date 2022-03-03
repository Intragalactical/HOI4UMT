using HOI4UMT.Library.Common.Functional.Interfaces;
using LanguageExt;

namespace HOI4UMT.Library.Common.Functional;

public static class CommonDialog<RT> where RT : struct, IHasCommonDialog<RT> {
    public static Eff<RT, DialogResult> ShowDialog(CommonDialog dialog)
        => default(RT).CommonDialogEff.Map(rt => rt.ShowDialog(dialog));
}
