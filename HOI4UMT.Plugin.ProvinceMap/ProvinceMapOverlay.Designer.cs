namespace HOI4UMT.Plugin.ProvinceMap;

partial class ProvinceMapOverlay {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.ProvinceMapOverlayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProvinceMapOverlayLabel
            // 
            this.ProvinceMapOverlayLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProvinceMapOverlayLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProvinceMapOverlayLabel.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProvinceMapOverlayLabel.ForeColor = System.Drawing.Color.White;
            this.ProvinceMapOverlayLabel.Location = new System.Drawing.Point(0, 0);
            this.ProvinceMapOverlayLabel.Name = "ProvinceMapOverlayLabel";
            this.ProvinceMapOverlayLabel.Size = new System.Drawing.Size(800, 450);
            this.ProvinceMapOverlayLabel.TabIndex = 0;
            this.ProvinceMapOverlayLabel.Text = "Set a Land Input Map first\r\nbefore generating a Province Map!";
            this.ProvinceMapOverlayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProvinceMapOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.ProvinceMapOverlayLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProvinceMapOverlay";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.ResumeLayout(false);

    }

    #endregion

    private Label ProvinceMapOverlayLabel;
}
