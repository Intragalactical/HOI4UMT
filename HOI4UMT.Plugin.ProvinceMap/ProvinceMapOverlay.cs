using HOI4UMT.Library.Common;
using System;
namespace HOI4UMT.Plugin.ProvinceMap;

public partial class ProvinceMapOverlay : Form {
    private bool Initialized { get; set; } = false;
    private Control ParentControl { get; }
    private double ShowOpacity { get; }

    public ProvinceMapOverlay(Control parent, Color backColor, double showOpacity) {
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
