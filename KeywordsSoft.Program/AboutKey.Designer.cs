namespace KeywordsSoft.Program
{
    partial class AboutKey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutKey));
            this.tabControlAboutKey = new System.Windows.Forms.TabControl();
            this.textsTab = new System.Windows.Forms.TabPage();
            this.videosTab = new System.Windows.Forms.TabPage();
            this.suggestsTab = new System.Windows.Forms.TabPage();
            this.snippetsTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.labelKeyName = new System.Windows.Forms.Label();
            this.imagesTab = new System.Windows.Forms.TabPage();
            this.tabControlAboutKey.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAboutKey
            // 
            this.tabControlAboutKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAboutKey.Controls.Add(this.textsTab);
            this.tabControlAboutKey.Controls.Add(this.imagesTab);
            this.tabControlAboutKey.Controls.Add(this.videosTab);
            this.tabControlAboutKey.Controls.Add(this.suggestsTab);
            this.tabControlAboutKey.Controls.Add(this.snippetsTab);
            this.tabControlAboutKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlAboutKey.Location = new System.Drawing.Point(0, 50);
            this.tabControlAboutKey.Name = "tabControlAboutKey";
            this.tabControlAboutKey.SelectedIndex = 0;
            this.tabControlAboutKey.Size = new System.Drawing.Size(851, 450);
            this.tabControlAboutKey.TabIndex = 0;
            this.tabControlAboutKey.SelectedIndexChanged += new System.EventHandler(this.tabControlAboutKey_SelectedIndexChanged);
            // 
            // textsTab
            // 
            this.textsTab.BackColor = System.Drawing.Color.LightCyan;
            this.textsTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textsTab.Location = new System.Drawing.Point(4, 25);
            this.textsTab.Name = "textsTab";
            this.textsTab.Padding = new System.Windows.Forms.Padding(3);
            this.textsTab.Size = new System.Drawing.Size(843, 421);
            this.textsTab.TabIndex = 0;
            this.textsTab.Text = "Texts";
            // 
            // videosTab
            // 
            this.videosTab.BackColor = System.Drawing.Color.LightCyan;
            this.videosTab.Location = new System.Drawing.Point(4, 25);
            this.videosTab.Name = "videosTab";
            this.videosTab.Padding = new System.Windows.Forms.Padding(3);
            this.videosTab.Size = new System.Drawing.Size(843, 421);
            this.videosTab.TabIndex = 2;
            this.videosTab.Text = "Videos";
            // 
            // suggestsTab
            // 
            this.suggestsTab.BackColor = System.Drawing.Color.LightCyan;
            this.suggestsTab.Location = new System.Drawing.Point(4, 25);
            this.suggestsTab.Name = "suggestsTab";
            this.suggestsTab.Padding = new System.Windows.Forms.Padding(3);
            this.suggestsTab.Size = new System.Drawing.Size(843, 421);
            this.suggestsTab.TabIndex = 3;
            this.suggestsTab.Text = "Suggests";
            // 
            // snippetsTab
            // 
            this.snippetsTab.BackColor = System.Drawing.Color.LightCyan;
            this.snippetsTab.Location = new System.Drawing.Point(4, 25);
            this.snippetsTab.Name = "snippetsTab";
            this.snippetsTab.Padding = new System.Windows.Forms.Padding(3);
            this.snippetsTab.Size = new System.Drawing.Size(843, 421);
            this.snippetsTab.TabIndex = 4;
            this.snippetsTab.Text = "Snippets";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.labelKeyName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 45);
            this.panel1.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.Transparent;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(8, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(42, 35);
            this.btnBack.TabIndex = 11;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // labelKeyName
            // 
            this.labelKeyName.AutoSize = true;
            this.labelKeyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKeyName.ForeColor = System.Drawing.Color.White;
            this.labelKeyName.Location = new System.Drawing.Point(66, 13);
            this.labelKeyName.Name = "labelKeyName";
            this.labelKeyName.Size = new System.Drawing.Size(0, 24);
            this.labelKeyName.TabIndex = 0;
            // 
            // imagesTab
            // 
            this.imagesTab.BackColor = System.Drawing.Color.LightCyan;
            this.imagesTab.Location = new System.Drawing.Point(4, 25);
            this.imagesTab.Name = "imagesTab";
            this.imagesTab.Padding = new System.Windows.Forms.Padding(3);
            this.imagesTab.Size = new System.Drawing.Size(843, 421);
            this.imagesTab.TabIndex = 1;
            this.imagesTab.Text = "Images";
            // 
            // AboutKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlAboutKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutKey";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutKey";
            this.tabControlAboutKey.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAboutKey;
        private System.Windows.Forms.TabPage textsTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelKeyName;
        private System.Windows.Forms.TabPage videosTab;
        private System.Windows.Forms.TabPage suggestsTab;
        private System.Windows.Forms.TabPage snippetsTab;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TabPage imagesTab;
    }
}