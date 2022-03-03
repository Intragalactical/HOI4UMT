namespace HOI4UMT.Library.Common.Functional.Interfaces;

public interface IMessageBoxIO {
    DialogResult Show(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
}
