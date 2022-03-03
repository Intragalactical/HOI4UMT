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
            this.components = new System.ComponentModel.Container();
            this.LandInputImage = new System.Windows.Forms.PictureBox();
            this.LandInputContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveAsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearImageContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.LandInputImage)).BeginInit();
            this.LandInputContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LandInputImage
            // 
            this.LandInputImage.ContextMenuStrip = this.LandInputContextMenu;
            this.LandInputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LandInputImage.Image = global::HOI4UMT.Plugin.LandInput.Properties.Resources.Draganddrop;
            this.LandInputImage.Location = new System.Drawing.Point(0, 0);
            this.LandInputImage.Name = "LandInputImage";
            this.LandInputImage.Size = new System.Drawing.Size(819, 558);
            this.LandInputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LandInputImage.TabIndex = 0;
            this.LandInputImage.TabStop = false;
            this.LandInputImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LandInputImage_MouseClick);
            // 
            // LandInputContextMenu
            // 
            this.LandInputContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAsContextMenuItem,
            this.ClearImageContextMenuItem});
            this.LandInputContextMenu.Name = "LandInputContextMenu";
            this.LandInputContextMenu.Size = new System.Drawing.Size(138, 48);
            // 
            // SaveAsContextMenuItem
            // 
            this.SaveAsContextMenuItem.Enabled = false;
            this.SaveAsContextMenuItem.Name = "SaveAsContextMenuItem";
            this.SaveAsContextMenuItem.Size = new System.Drawing.Size(137, 22);
            this.SaveAsContextMenuItem.Text = "Save As...";
            this.SaveAsContextMenuItem.Click += new System.EventHandler(this.SaveAsContextMenuItem_Click);
            // 
            // ClearImageContextMenuItem
            // 
            this.ClearImageContextMenuItem.Enabled = false;
            this.ClearImageContextMenuItem.Name = "ClearImageContextMenuItem";
            this.ClearImageContextMenuItem.Size = new System.Drawing.Size(137, 22);
            this.ClearImageContextMenuItem.Text = "Clear Image";
            this.ClearImageContextMenuItem.Click += new System.EventHandler(this.ClearImageContextMenuItem_Click);
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
            this.LandInputContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private PictureBox LandInputImage;
    private ContextMenuStrip LandInputContextMenu;
    private ToolStripMenuItem SaveAsContextMenuItem;
    private ToolStripMenuItem ClearImageContextMenuItem;
}
