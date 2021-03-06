using HOI4UMT.Library.Common;

namespace HOI4UMT.Plugin.ProvinceMap;

public partial class ProvinceMapGeneratingOverlay : Form {
    private bool Initialized { get; set; } = false;
    private Control ParentControl { get; }
    private double ShowOpacity { get; }

    public ProvinceMapGeneratingOverlay(Control parent, Color backColor, double showOpacity) {
        InitializeComponent();

        Dock = DockStyle.Fill;
        BackColor = backColor;

        ShowOpacity = showOpacity;

        ParentControl = parent;
        parent.SizeChanged += Parent_SizeChanged;
    }

    public new void Show() {
        base.Show();

        Initialized = true;

        _ = WinAPI.SetParent(Handle, ParentControl.Handle);
        _ = WinAPI.SetWindowPos(Handle, new IntPtr(1), 0, 0, ParentControl.Width, ParentControl.Height, WinAPI.SetWindowPosFlags.SWP_SHOWWINDOW);
        _ = WinAPI.SetWindowLongA(Handle, -16, 0x10000000);

        Opacity = ShowOpacity;
    }

    public void Show(string message) {
        Show();

        SetStatus(message);
    }

    public new void Hide() {
        base.Hide();

        Opacity = 0;
    }

    public void SetStatus(string status) {
        _ = Invoke(new MethodInvoker(() => GeneratingStatusLabel.Text = status));
    }

    private void Parent_SizeChanged(object? sender, EventArgs e) {
        if (Initialized) {
            _ = WinAPI.SetWindowPos(
                Handle,
                new IntPtr(1),
                0,
                0,
                ParentControl.Width,
                ParentControl.Height,
                WinAPI.SetWindowPosFlags.SWP_NOACTIVATE
            );
        }
    }
}
