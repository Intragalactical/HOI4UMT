namespace HOI4UMT.Plugin.LandInput;

partial class LandInput {
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.LandInputImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LandInputImage)).BeginInit();
            this.SuspendLayout();
            // 
            // LandInputImage
            // 
            this.LandInputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LandInputImage.Image = global::HOI4UMT.Plugin.LandInput.Properties.Resources.Draganddrop;
            this.LandInputImage.Location = new System.Drawing.Point(0, 0);
            this.LandInputImage.Name = "LandInputImage";
            this.LandInputImage.Size = new System.Drawing.Size(819, 558);
            this.LandInputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LandInputImage.TabIndex = 0;
            this.LandInputImage.TabStop = false;
            this.LandInputImage.Click += new System.EventHandler(this.LandInputImage_Click);
            // 
            // LandInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.LandInputImage);
            this.Name = "LandInput";
            this.Size = new System.Drawing.Size(819, 558);
            ((System.ComponentModel.ISupportInitialize)(this.LandInputImage)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private PictureBox LandInputImage;
}
