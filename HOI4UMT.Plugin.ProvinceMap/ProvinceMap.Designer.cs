namespace HOI4UMT.Plugin.ProvinceMap;

partial class ProvinceMap {
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
            this.GenerateProvinceMapButton = new System.Windows.Forms.Button();
            this.ProvinceMapGeneratorSettings = new System.Windows.Forms.GroupBox();
            this.DX12InfoLabel = new System.Windows.Forms.Label();
            this.UseDX12ComputeShadersCheckBox = new System.Windows.Forms.CheckBox();
            this.DistanceFunctionComboBox = new System.Windows.Forms.ComboBox();
            this.DistanceFunctionLabel = new System.Windows.Forms.Label();
            this.LakeProvinceSizeSeparatorLabel = new System.Windows.Forms.Label();
            this.LakeProvinceSizeUpperLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.LakeProvinceSizeLowerLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.LakeProvinceSizeLabel = new System.Windows.Forms.Label();
            this.SeaProvinceSizeSeparatorLabel = new System.Windows.Forms.Label();
            this.SeaProvinceSizeUpperLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.SeaProvinceSizeLowerLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.SeaProvinceSizeLabel = new System.Windows.Forms.Label();
            this.LandProvinceSizeSeparatorLabel = new System.Windows.Forms.Label();
            this.LandProvinceSizeUpperLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.LandProvinceSizeLowerLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.LandProvinceSizeLabel = new System.Windows.Forms.Label();
            this.ProvinceMapImage = new System.Windows.Forms.PictureBox();
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ImageContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ImageSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProvinceMapGeneratorSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LakeProvinceSizeUpperLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LakeProvinceSizeLowerLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeaProvinceSizeUpperLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeaProvinceSizeLowerLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LandProvinceSizeUpperLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LandProvinceSizeLowerLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvinceMapImage)).BeginInit();
            this.ImageContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenerateProvinceMapButton
            // 
            this.GenerateProvinceMapButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateProvinceMapButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GenerateProvinceMapButton.Location = new System.Drawing.Point(3, 670);
            this.GenerateProvinceMapButton.Name = "GenerateProvinceMapButton";
            this.GenerateProvinceMapButton.Size = new System.Drawing.Size(867, 23);
            this.GenerateProvinceMapButton.TabIndex = 7;
            this.GenerateProvinceMapButton.Text = "GENERATE";
            this.GenerateProvinceMapButton.UseVisualStyleBackColor = true;
            this.GenerateProvinceMapButton.Click += new System.EventHandler(this.GenerateProvinceMapButton_Click);
            // 
            // ProvinceMapGeneratorSettings
            // 
            this.ProvinceMapGeneratorSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProvinceMapGeneratorSettings.BackColor = System.Drawing.Color.Transparent;
            this.ProvinceMapGeneratorSettings.Controls.Add(this.DX12InfoLabel);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.UseDX12ComputeShadersCheckBox);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.DistanceFunctionComboBox);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.DistanceFunctionLabel);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.LakeProvinceSizeSeparatorLabel);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.LakeProvinceSizeUpperLimitNUD);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.LakeProvinceSizeLowerLimitNUD);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.LakeProvinceSizeLabel);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.SeaProvinceSizeSeparatorLabel);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.SeaProvinceSizeUpperLimitNUD);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.SeaProvinceSizeLowerLimitNUD);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.SeaProvinceSizeLabel);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.LandProvinceSizeSeparatorLabel);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.LandProvinceSizeUpperLimitNUD);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.LandProvinceSizeLowerLimitNUD);
            this.ProvinceMapGeneratorSettings.Controls.Add(this.LandProvinceSizeLabel);
            this.ProvinceMapGeneratorSettings.Location = new System.Drawing.Point(3, 551);
            this.ProvinceMapGeneratorSettings.Name = "ProvinceMapGeneratorSettings";
            this.ProvinceMapGeneratorSettings.Size = new System.Drawing.Size(867, 113);
            this.ProvinceMapGeneratorSettings.TabIndex = 6;
            this.ProvinceMapGeneratorSettings.TabStop = false;
            this.ProvinceMapGeneratorSettings.Text = "Settings";
            // 
            // DX12InfoLabel
            // 
            this.DX12InfoLabel.AutoSize = true;
            this.DX12InfoLabel.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.DX12InfoLabel.Location = new System.Drawing.Point(328, 73);
            this.DX12InfoLabel.Name = "DX12InfoLabel";
            this.DX12InfoLabel.Size = new System.Drawing.Size(270, 15);
            this.DX12InfoLabel.TabIndex = 15;
            this.DX12InfoLabel.Text = "* Requires DirectX 12 Compatible GPU and Drivers";
            // 
            // UseDX12ComputeShadersCheckBox
            // 
            this.UseDX12ComputeShadersCheckBox.AutoSize = true;
            this.UseDX12ComputeShadersCheckBox.Checked = true;
            this.UseDX12ComputeShadersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseDX12ComputeShadersCheckBox.Location = new System.Drawing.Point(328, 51);
            this.UseDX12ComputeShadersCheckBox.Name = "UseDX12ComputeShadersCheckBox";
            this.UseDX12ComputeShadersCheckBox.Size = new System.Drawing.Size(198, 19);
            this.UseDX12ComputeShadersCheckBox.TabIndex = 14;
            this.UseDX12ComputeShadersCheckBox.Text = "Use DirectX 12 Compute Shaders";
            this.UseDX12ComputeShadersCheckBox.UseVisualStyleBackColor = true;
            // 
            // DistanceFunctionComboBox
            // 
            this.DistanceFunctionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DistanceFunctionComboBox.FormattingEnabled = true;
            this.DistanceFunctionComboBox.Items.AddRange(new object[] {
            "Euclidean",
            "Manhattan"});
            this.DistanceFunctionComboBox.Location = new System.Drawing.Point(435, 18);
            this.DistanceFunctionComboBox.Name = "DistanceFunctionComboBox";
            this.DistanceFunctionComboBox.Size = new System.Drawing.Size(121, 23);
            this.DistanceFunctionComboBox.TabIndex = 13;
            // 
            // DistanceFunctionLabel
            // 
            this.DistanceFunctionLabel.AutoSize = true;
            this.DistanceFunctionLabel.Location = new System.Drawing.Point(324, 21);
            this.DistanceFunctionLabel.Name = "DistanceFunctionLabel";
            this.DistanceFunctionLabel.Size = new System.Drawing.Size(105, 15);
            this.DistanceFunctionLabel.TabIndex = 12;
            this.DistanceFunctionLabel.Text = "Distance Function:";
            // 
            // LakeProvinceSizeSeparatorLabel
            // 
            this.LakeProvinceSizeSeparatorLabel.AutoSize = true;
            this.LakeProvinceSizeSeparatorLabel.Location = new System.Drawing.Point(197, 78);
            this.LakeProvinceSizeSeparatorLabel.Name = "LakeProvinceSizeSeparatorLabel";
            this.LakeProvinceSizeSeparatorLabel.Size = new System.Drawing.Size(12, 15);
            this.LakeProvinceSizeSeparatorLabel.TabIndex = 11;
            this.LakeProvinceSizeSeparatorLabel.Text = "-";
            // 
            // LakeProvinceSizeUpperLimitNUD
            // 
            this.LakeProvinceSizeUpperLimitNUD.Location = new System.Drawing.Point(215, 76);
            this.LakeProvinceSizeUpperLimitNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LakeProvinceSizeUpperLimitNUD.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.LakeProvinceSizeUpperLimitNUD.Name = "LakeProvinceSizeUpperLimitNUD";
            this.LakeProvinceSizeUpperLimitNUD.Size = new System.Drawing.Size(71, 23);
            this.LakeProvinceSizeUpperLimitNUD.TabIndex = 10;
            this.LakeProvinceSizeUpperLimitNUD.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.LakeProvinceSizeUpperLimitNUD.ValueChanged += new System.EventHandler(this.LakeProvinceSizeUpperLimitNUD_ValueChanged);
            // 
            // LakeProvinceSizeLowerLimitNUD
            // 
            this.LakeProvinceSizeLowerLimitNUD.Location = new System.Drawing.Point(120, 76);
            this.LakeProvinceSizeLowerLimitNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LakeProvinceSizeLowerLimitNUD.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.LakeProvinceSizeLowerLimitNUD.Name = "LakeProvinceSizeLowerLimitNUD";
            this.LakeProvinceSizeLowerLimitNUD.Size = new System.Drawing.Size(71, 23);
            this.LakeProvinceSizeLowerLimitNUD.TabIndex = 9;
            this.LakeProvinceSizeLowerLimitNUD.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.LakeProvinceSizeLowerLimitNUD.ValueChanged += new System.EventHandler(this.LakeProvinceSizeLowerLimitNUD_ValueChanged);
            // 
            // LakeProvinceSizeLabel
            // 
            this.LakeProvinceSizeLabel.AutoSize = true;
            this.LakeProvinceSizeLabel.Location = new System.Drawing.Point(6, 78);
            this.LakeProvinceSizeLabel.Name = "LakeProvinceSizeLabel";
            this.LakeProvinceSizeLabel.Size = new System.Drawing.Size(106, 15);
            this.LakeProvinceSizeLabel.TabIndex = 8;
            this.LakeProvinceSizeLabel.Text = "Lake Province Size:";
            // 
            // SeaProvinceSizeSeparatorLabel
            // 
            this.SeaProvinceSizeSeparatorLabel.AutoSize = true;
            this.SeaProvinceSizeSeparatorLabel.Location = new System.Drawing.Point(197, 49);
            this.SeaProvinceSizeSeparatorLabel.Name = "SeaProvinceSizeSeparatorLabel";
            this.SeaProvinceSizeSeparatorLabel.Size = new System.Drawing.Size(12, 15);
            this.SeaProvinceSizeSeparatorLabel.TabIndex = 7;
            this.SeaProvinceSizeSeparatorLabel.Text = "-";
            // 
            // SeaProvinceSizeUpperLimitNUD
            // 
            this.SeaProvinceSizeUpperLimitNUD.Location = new System.Drawing.Point(215, 47);
            this.SeaProvinceSizeUpperLimitNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SeaProvinceSizeUpperLimitNUD.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.SeaProvinceSizeUpperLimitNUD.Name = "SeaProvinceSizeUpperLimitNUD";
            this.SeaProvinceSizeUpperLimitNUD.Size = new System.Drawing.Size(71, 23);
            this.SeaProvinceSizeUpperLimitNUD.TabIndex = 6;
            this.SeaProvinceSizeUpperLimitNUD.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.SeaProvinceSizeUpperLimitNUD.ValueChanged += new System.EventHandler(this.SeaProvinceSizeUpperLimitNUD_ValueChanged);
            // 
            // SeaProvinceSizeLowerLimitNUD
            // 
            this.SeaProvinceSizeLowerLimitNUD.Location = new System.Drawing.Point(120, 47);
            this.SeaProvinceSizeLowerLimitNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SeaProvinceSizeLowerLimitNUD.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.SeaProvinceSizeLowerLimitNUD.Name = "SeaProvinceSizeLowerLimitNUD";
            this.SeaProvinceSizeLowerLimitNUD.Size = new System.Drawing.Size(71, 23);
            this.SeaProvinceSizeLowerLimitNUD.TabIndex = 5;
            this.SeaProvinceSizeLowerLimitNUD.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.SeaProvinceSizeLowerLimitNUD.ValueChanged += new System.EventHandler(this.SeaProvinceSizeLowerLimitNUD_ValueChanged);
            // 
            // SeaProvinceSizeLabel
            // 
            this.SeaProvinceSizeLabel.AutoSize = true;
            this.SeaProvinceSizeLabel.Location = new System.Drawing.Point(6, 49);
            this.SeaProvinceSizeLabel.Name = "SeaProvinceSizeLabel";
            this.SeaProvinceSizeLabel.Size = new System.Drawing.Size(100, 15);
            this.SeaProvinceSizeLabel.TabIndex = 4;
            this.SeaProvinceSizeLabel.Text = "Sea Province Size:";
            // 
            // LandProvinceSizeSeparatorLabel
            // 
            this.LandProvinceSizeSeparatorLabel.AutoSize = true;
            this.LandProvinceSizeSeparatorLabel.Location = new System.Drawing.Point(197, 21);
            this.LandProvinceSizeSeparatorLabel.Name = "LandProvinceSizeSeparatorLabel";
            this.LandProvinceSizeSeparatorLabel.Size = new System.Drawing.Size(12, 15);
            this.LandProvinceSizeSeparatorLabel.TabIndex = 3;
            this.LandProvinceSizeSeparatorLabel.Text = "-";
            // 
            // LandProvinceSizeUpperLimitNUD
            // 
            this.LandProvinceSizeUpperLimitNUD.Location = new System.Drawing.Point(215, 19);
            this.LandProvinceSizeUpperLimitNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LandProvinceSizeUpperLimitNUD.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.LandProvinceSizeUpperLimitNUD.Name = "LandProvinceSizeUpperLimitNUD";
            this.LandProvinceSizeUpperLimitNUD.Size = new System.Drawing.Size(71, 23);
            this.LandProvinceSizeUpperLimitNUD.TabIndex = 2;
            this.LandProvinceSizeUpperLimitNUD.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.LandProvinceSizeUpperLimitNUD.ValueChanged += new System.EventHandler(this.LandProvinceSizeUpperLimitNUD_ValueChanged);
            // 
            // LandProvinceSizeLowerLimitNUD
            // 
            this.LandProvinceSizeLowerLimitNUD.Location = new System.Drawing.Point(120, 19);
            this.LandProvinceSizeLowerLimitNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LandProvinceSizeLowerLimitNUD.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.LandProvinceSizeLowerLimitNUD.Name = "LandProvinceSizeLowerLimitNUD";
            this.LandProvinceSizeLowerLimitNUD.Size = new System.Drawing.Size(71, 23);
            this.LandProvinceSizeLowerLimitNUD.TabIndex = 1;
            this.LandProvinceSizeLowerLimitNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LandProvinceSizeLowerLimitNUD.ValueChanged += new System.EventHandler(this.LandProvinceSizeLowerLimitNUD_ValueChanged);
            // 
            // LandProvinceSizeLabel
            // 
            this.LandProvinceSizeLabel.AutoSize = true;
            this.LandProvinceSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.LandProvinceSizeLabel.Location = new System.Drawing.Point(6, 21);
            this.LandProvinceSizeLabel.Name = "LandProvinceSizeLabel";
            this.LandProvinceSizeLabel.Size = new System.Drawing.Size(108, 15);
            this.LandProvinceSizeLabel.TabIndex = 0;
            this.LandProvinceSizeLabel.Text = "Land Province Size:";
            // 
            // ProvinceMapImage
            // 
            this.ProvinceMapImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProvinceMapImage.BackColor = System.Drawing.SystemColors.Control;
            this.ProvinceMapImage.ContextMenuStrip = this.ImageContextMenu;
            this.ProvinceMapImage.Location = new System.Drawing.Point(3, 3);
            this.ProvinceMapImage.Name = "ProvinceMapImage";
            this.ProvinceMapImage.Size = new System.Drawing.Size(867, 539);
            this.ProvinceMapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProvinceMapImage.TabIndex = 5;
            this.ProvinceMapImage.TabStop = false;
            // 
            // ImageContextMenu
            // 
            this.ImageContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImageSaveMenuItem});
            this.ImageContextMenu.Name = "ImageContextMenu";
            this.ImageContextMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // ImageSaveMenuItem
            // 
            this.ImageSaveMenuItem.Name = "ImageSaveMenuItem";
            this.ImageSaveMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ImageSaveMenuItem.Text = "Save As...";
            this.ImageSaveMenuItem.Click += new System.EventHandler(this.ImageSaveMenuItem_Click);
            // 
            // ProvinceMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.GenerateProvinceMapButton);
            this.Controls.Add(this.ProvinceMapGeneratorSettings);
            this.Controls.Add(this.ProvinceMapImage);
            this.DoubleBuffered = true;
            this.Name = "ProvinceMap";
            this.Size = new System.Drawing.Size(873, 698);
            this.Load += new System.EventHandler(this.ProvinceMap_Load);
            this.Resize += new System.EventHandler(this.ProvinceMap_Resize);
            this.ProvinceMapGeneratorSettings.ResumeLayout(false);
            this.ProvinceMapGeneratorSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LakeProvinceSizeUpperLimitNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LakeProvinceSizeLowerLimitNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeaProvinceSizeUpperLimitNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeaProvinceSizeLowerLimitNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LandProvinceSizeUpperLimitNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LandProvinceSizeLowerLimitNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvinceMapImage)).EndInit();
            this.ImageContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private Button GenerateProvinceMapButton;
    private GroupBox ProvinceMapGeneratorSettings;
    private ComboBox DistanceFunctionComboBox;
    private Label DistanceFunctionLabel;
    private Label LakeProvinceSizeSeparatorLabel;
    private NumericUpDown LakeProvinceSizeUpperLimitNUD;
    private NumericUpDown LakeProvinceSizeLowerLimitNUD;
    private Label LakeProvinceSizeLabel;
    private Label SeaProvinceSizeSeparatorLabel;
    private NumericUpDown SeaProvinceSizeUpperLimitNUD;
    private NumericUpDown SeaProvinceSizeLowerLimitNUD;
    private Label SeaProvinceSizeLabel;
    private Label LandProvinceSizeSeparatorLabel;
    private NumericUpDown LandProvinceSizeUpperLimitNUD;
    private NumericUpDown LandProvinceSizeLowerLimitNUD;
    private Label LandProvinceSizeLabel;
    private PictureBox ProvinceMapImage;
    private Label DX12InfoLabel;
    private CheckBox UseDX12ComputeShadersCheckBox;
    private ToolTip MainToolTip;
    private ContextMenuStrip ImageContextMenu;
    private ToolStripMenuItem ImageSaveMenuItem;
}
