using HOI4UMT.Library.Common.Functional.Interfaces;

namespace HOI4UMT.Library.Common.Functional;

public struct MessageBoxIO : IMessageBoxIO {
    public static readonly IMessageBoxIO Default = new MessageBoxIO();

    public DialogResult Show(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        => MessageBox.Show(message, caption, buttons, icon);
}
