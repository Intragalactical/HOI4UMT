using HOI4UMT.Library.Common.Functional.Interfaces;
using LanguageExt;

namespace HOI4UMT.Library.Common.Functional;

public static class MessageBox<RT> where RT : struct, IHasMessageBox<RT> {
    public static Eff<RT, DialogResult> Show(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        => default(RT).MessageBoxEff.Map(rt => rt.Show(message, caption, buttons, icon));
}
