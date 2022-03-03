namespace HOI4UMT.Plugin.RiverMap;

partial class RiverMap {
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
            this.GenerateFromLandInputButton = new System.Windows.Forms.Button();
            this.RiverMapImage = new System.Windows.Forms.PictureBox();
            this.RiverMapImageContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveAsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadRiverMapButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RiverMapImage)).BeginInit();
            this.RiverMapImageContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenerateFromLandInputButton
            // 
            this.GenerateFromLandInputButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GenerateFromLandInputButton.Enabled = false;
            this.GenerateFromLandInputButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GenerateFromLandInputButton.Location = new System.Drawing.Point(0, 495);
            this.GenerateFromLandInputButton.Name = "GenerateFromLandInputButton";
            this.GenerateFromLandInputButton.Size = new System.Drawing.Size(807, 25);
            this.GenerateFromLandInputButton.TabIndex = 0;
            this.GenerateFromLandInputButton.Text = "GENERATE BASE FROM LAND INPUT";
            this.GenerateFromLandInputButton.UseVisualStyleBackColor = true;
            this.GenerateFromLandInputButton.Click += new System.EventHandler(this.GenerateFromLandInputButton_Click);
            // 
            // RiverMapImage
            // 
            this.RiverMapImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RiverMapImage.ContextMenuStrip = this.RiverMapImageContextMenu;
            this.RiverMapImage.Image = global::HOI4UMT.Plugin.RiverMap.Properties.Resources.Draganddrop;
            this.RiverMapImage.Location = new System.Drawing.Point(0, 0);
            this.RiverMapImage.Name = "RiverMapImage";
            this.RiverMapImage.Size = new System.Drawing.Size(807, 466);
            this.RiverMapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RiverMapImage.TabIndex = 1;
            this.RiverMapImage.TabStop = false;
            this.RiverMapImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RiverMapImage_MouseClick);
            // 
            // RiverMapImageContextMenu
            // 
            this.RiverMapImageContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAsContextMenuItem});
            this.RiverMapImageContextMenu.Name = "RiverMapImageContextMenu";
            this.RiverMapImageContextMenu.Size = new System.Drawing.Size(124, 26);
            // 
            // SaveAsContextMenuItem
            // 
            this.SaveAsContextMenuItem.Name = "SaveAsContextMenuItem";
            this.SaveAsContextMenuItem.Size = new System.Drawing.Size(123, 22);
            this.SaveAsContextMenuItem.Text = "Save As...";
            this.SaveAsContextMenuItem.Click += new System.EventHandler(this.SaveAsContextMenuItem_Click);
            // 
            // LoadRiverMapButton
            // 
            this.LoadRiverMapButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LoadRiverMapButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoadRiverMapButton.Location = new System.Drawing.Point(0, 470);
            this.LoadRiverMapButton.Name = "LoadRiverMapButton";
            this.LoadRiverMapButton.Size = new System.Drawing.Size(807, 25);
            this.LoadRiverMapButton.TabIndex = 2;
            this.LoadRiverMapButton.Text = "LOAD RIVER MAP";
            this.LoadRiverMapButton.UseVisualStyleBackColor = true;
            this.LoadRiverMapButton.Click += new System.EventHandler(this.LoadRiverMapButton_Click);
            // 
            // RiverMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.LoadRiverMapButton);
            this.Controls.Add(this.RiverMapImage);
            this.Controls.Add(this.GenerateFromLandInputButton);
            this.Name = "RiverMap";
            this.Size = new System.Drawing.Size(807, 520);
            ((System.ComponentModel.ISupportInitialize)(this.RiverMapImage)).EndInit();
            this.RiverMapImageContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private Button GenerateFromLandInputButton;
    private PictureBox RiverMapImage;
    private ContextMenuStrip RiverMapImageContextMenu;
    private ToolStripMenuItem SaveAsContextMenuItem;
    private Button LoadRiverMapButton;
}
