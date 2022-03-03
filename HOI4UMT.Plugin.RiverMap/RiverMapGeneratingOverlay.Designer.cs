namespace HOI4UMT.Plugin.RiverMap;

partial class RiverMapGeneratingOverlay {
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
            this.GeneratingGif = new System.Windows.Forms.PictureBox();
            this.GeneratingStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GeneratingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // GeneratingGif
            // 
            this.GeneratingGif.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GeneratingGif.BackColor = System.Drawing.Color.Transparent;
            this.GeneratingGif.Image = global::HOI4UMT.Plugin.RiverMap.Properties.Resources.bigspinnercropped;
            this.GeneratingGif.Location = new System.Drawing.Point(403, 286);
            this.GeneratingGif.Name = "GeneratingGif";
            this.GeneratingGif.Size = new System.Drawing.Size(100, 100);
            this.GeneratingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GeneratingGif.TabIndex = 2;
            this.GeneratingGif.TabStop = false;
            // 
            // GeneratingStatusLabel
            // 
            this.GeneratingStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GeneratingStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.GeneratingStatusLabel.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GeneratingStatusLabel.ForeColor = System.Drawing.Color.White;
            this.GeneratingStatusLabel.Location = new System.Drawing.Point(42, 159);
            this.GeneratingStatusLabel.Name = "GeneratingStatusLabel";
            this.GeneratingStatusLabel.Size = new System.Drawing.Size(824, 120);
            this.GeneratingStatusLabel.TabIndex = 3;
            this.GeneratingStatusLabel.Text = "N/A";
            this.GeneratingStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RiverMapGeneratingOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 544);
            this.ControlBox = false;
            this.Controls.Add(this.GeneratingGif);
            this.Controls.Add(this.GeneratingStatusLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RiverMapGeneratingOverlay";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.GeneratingGif)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private PictureBox GeneratingGif;
    private Label GeneratingStatusLabel;
}
