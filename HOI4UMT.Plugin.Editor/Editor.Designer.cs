namespace HOI4UMT.Plugin.Editor;

partial class Editor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.EditorToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddRailwayButton = new System.Windows.Forms.ToolStripButton();
            this.EditorToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditorToolStrip
            // 
            this.EditorToolStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.EditorToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.EditorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddRailwayButton});
            this.EditorToolStrip.Location = new System.Drawing.Point(0, 0);
            this.EditorToolStrip.Name = "EditorToolStrip";
            this.EditorToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.EditorToolStrip.Size = new System.Drawing.Size(979, 25);
            this.EditorToolStrip.TabIndex = 2;
            // 
            // AddRailwayButton
            // 
            this.AddRailwayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddRailwayButton.Image = ((System.Drawing.Image)(resources.GetObject("AddRailwayButton.Image")));
            this.AddRailwayButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddRailwayButton.Name = "AddRailwayButton";
            this.AddRailwayButton.Size = new System.Drawing.Size(23, 22);
            this.AddRailwayButton.Text = "Add Railway";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.EditorToolStrip);
            this.Name = "Editor";
            this.Size = new System.Drawing.Size(979, 585);
            this.EditorToolStrip.ResumeLayout(false);
            this.EditorToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private ToolStrip EditorToolStrip;
    private ToolStripButton AddRailwayButton;
}
