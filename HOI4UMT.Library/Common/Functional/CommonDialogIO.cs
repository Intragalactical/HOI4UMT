using HOI4UMT.Library.Common.Functional.Interfaces;

namespace HOI4UMT.Library.Common.Functional;

public struct CommonDialogIO : ICommonDialogIO {
    public static readonly ICommonDialogIO Default = new CommonDialogIO();

    public DialogResult ShowDialog(CommonDialog dialog)
        => dialog.ShowDialog();
}
