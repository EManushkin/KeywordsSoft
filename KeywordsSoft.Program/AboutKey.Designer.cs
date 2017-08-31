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
            this.tabTexts = new System.Windows.Forms.TabPage();
            this.tabImages = new System.Windows.Forms.TabPage();
            this.tabVideos = new System.Windows.Forms.TabPage();
            this.tabSuggests = new System.Windows.Forms.TabPage();
            this.tabSnippets = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelKeyName = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.dataGridViewTexts = new System.Windows.Forms.DataGridView();
            this.tabControlAboutKey.SuspendLayout();
            this.tabTexts.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTexts)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAboutKey
            // 
            this.tabControlAboutKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAboutKey.Controls.Add(this.tabTexts);
            this.tabControlAboutKey.Controls.Add(this.tabImages);
            this.tabControlAboutKey.Controls.Add(this.tabVideos);
            this.tabControlAboutKey.Controls.Add(this.tabSuggests);
            this.tabControlAboutKey.Controls.Add(this.tabSnippets);
            this.tabControlAboutKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlAboutKey.Location = new System.Drawing.Point(0, 50);
            this.tabControlAboutKey.Name = "tabControlAboutKey";
            this.tabControlAboutKey.SelectedIndex = 0;
            this.tabControlAboutKey.Size = new System.Drawing.Size(851, 450);
            this.tabControlAboutKey.TabIndex = 0;
            // 
            // tabTexts
            // 
            this.tabTexts.BackColor = System.Drawing.Color.LightCyan;
            this.tabTexts.Controls.Add(this.dataGridViewTexts);
            this.tabTexts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabTexts.Location = new System.Drawing.Point(4, 25);
            this.tabTexts.Name = "tabTexts";
            this.tabTexts.Padding = new System.Windows.Forms.Padding(3);
            this.tabTexts.Size = new System.Drawing.Size(843, 421);
            this.tabTexts.TabIndex = 0;
            this.tabTexts.Text = "Texts";
            // 
            // tabImages
            // 
            this.tabImages.BackColor = System.Drawing.Color.LightCyan;
            this.tabImages.Location = new System.Drawing.Point(4, 25);
            this.tabImages.Name = "tabImages";
            this.tabImages.Padding = new System.Windows.Forms.Padding(3);
            this.tabImages.Size = new System.Drawing.Size(843, 421);
            this.tabImages.TabIndex = 1;
            this.tabImages.Text = "Images";
            // 
            // tabVideos
            // 
            this.tabVideos.BackColor = System.Drawing.Color.LightCyan;
            this.tabVideos.Location = new System.Drawing.Point(4, 25);
            this.tabVideos.Name = "tabVideos";
            this.tabVideos.Padding = new System.Windows.Forms.Padding(3);
            this.tabVideos.Size = new System.Drawing.Size(843, 421);
            this.tabVideos.TabIndex = 2;
            this.tabVideos.Text = "Videos";
            // 
            // tabSuggests
            // 
            this.tabSuggests.BackColor = System.Drawing.Color.LightCyan;
            this.tabSuggests.Location = new System.Drawing.Point(4, 22);
            this.tabSuggests.Name = "tabSuggests";
            this.tabSuggests.Padding = new System.Windows.Forms.Padding(3);
            this.tabSuggests.Size = new System.Drawing.Size(843, 424);
            this.tabSuggests.TabIndex = 3;
            this.tabSuggests.Text = "Suggests";
            // 
            // tabSnippets
            // 
            this.tabSnippets.BackColor = System.Drawing.Color.LightCyan;
            this.tabSnippets.Location = new System.Drawing.Point(4, 22);
            this.tabSnippets.Name = "tabSnippets";
            this.tabSnippets.Padding = new System.Windows.Forms.Padding(3);
            this.tabSnippets.Size = new System.Drawing.Size(843, 424);
            this.tabSnippets.TabIndex = 4;
            this.tabSnippets.Text = "Snippets";
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
            // labelKeyName
            // 
            this.labelKeyName.AutoSize = true;
            this.labelKeyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKeyName.ForeColor = System.Drawing.Color.White;
            this.labelKeyName.Location = new System.Drawing.Point(58, 16);
            this.labelKeyName.Name = "labelKeyName";
            this.labelKeyName.Size = new System.Drawing.Size(0, 24);
            this.labelKeyName.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.Transparent;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(10, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(42, 35);
            this.btnBack.TabIndex = 11;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dataGridViewTexts
            // 
            this.dataGridViewTexts.AllowUserToAddRows = false;
            this.dataGridViewTexts.AllowUserToDeleteRows = false;
            this.dataGridViewTexts.AllowUserToResizeColumns = false;
            this.dataGridViewTexts.AllowUserToResizeRows = false;
            this.dataGridViewTexts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTexts.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dataGridViewTexts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTexts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTexts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTexts.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTexts.MultiSelect = false;
            this.dataGridViewTexts.Name = "dataGridViewTexts";
            this.dataGridViewTexts.ReadOnly = true;
            this.dataGridViewTexts.RowHeadersVisible = false;
            this.dataGridViewTexts.Size = new System.Drawing.Size(837, 415);
            this.dataGridViewTexts.TabIndex = 0;
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
            this.tabTexts.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTexts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAboutKey;
        private System.Windows.Forms.TabPage tabTexts;
        private System.Windows.Forms.TabPage tabImages;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelKeyName;
        private System.Windows.Forms.TabPage tabVideos;
        private System.Windows.Forms.TabPage tabSuggests;
        private System.Windows.Forms.TabPage tabSnippets;
        private System.Windows.Forms.Button btnBack;
        public System.Windows.Forms.DataGridView dataGridViewTexts;
    }
}