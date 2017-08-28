namespace KeywordsSoft.Program
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.categoryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_addKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.actionMenu_parseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_parseItem_texts = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_parseItem_images = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_parseItem_videos = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_parseItem_suggests = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_parseItem_snippets = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.actionMenu_parseItem_all = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_moveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.actionMenu_deleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelCategorySelected = new System.Windows.Forms.Label();
            this.labelParser = new System.Windows.Forms.Label();
            this.cbParserSelect = new System.Windows.Forms.ComboBox();
            this.dataGridViewCategoryKeys = new System.Windows.Forms.DataGridView();
            this.colKeyCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCluster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUrls = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTexts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpintexts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSnippets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuggests = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVideos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategoryKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryMenu,
            this.actionMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // categoryMenu
            // 
            this.categoryMenu.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.categoryMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.categoryMenu.Name = "categoryMenu";
            this.categoryMenu.Size = new System.Drawing.Size(93, 24);
            this.categoryMenu.Text = "Категория";
            // 
            // actionMenu
            // 
            this.actionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionMenu_addKeys,
            this.toolStripSeparator3,
            this.actionMenu_parseItem,
            this.actionMenu_moveItem,
            this.toolStripSeparator1,
            this.actionMenu_deleteItem});
            this.actionMenu.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.actionMenu.Name = "actionMenu";
            this.actionMenu.Size = new System.Drawing.Size(87, 24);
            this.actionMenu.Text = "Действие";
            // 
            // actionMenu_addKeys
            // 
            this.actionMenu_addKeys.Image = global::KeywordsSoft.Program.Properties.Resources.add_key_icon;
            this.actionMenu_addKeys.Name = "actionMenu_addKeys";
            this.actionMenu_addKeys.Size = new System.Drawing.Size(238, 24);
            this.actionMenu_addKeys.Text = "Добавить ключи";
            this.actionMenu_addKeys.Click += new System.EventHandler(this.actionMenu_addKeys_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(235, 6);
            // 
            // actionMenu_parseItem
            // 
            this.actionMenu_parseItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionMenu_parseItem_texts,
            this.actionMenu_parseItem_images,
            this.actionMenu_parseItem_videos,
            this.actionMenu_parseItem_suggests,
            this.actionMenu_parseItem_snippets,
            this.toolStripSeparator2,
            this.actionMenu_parseItem_all});
            this.actionMenu_parseItem.Enabled = false;
            this.actionMenu_parseItem.Image = global::KeywordsSoft.Program.Properties.Resources.parse_icon;
            this.actionMenu_parseItem.Name = "actionMenu_parseItem";
            this.actionMenu_parseItem.Size = new System.Drawing.Size(238, 24);
            this.actionMenu_parseItem.Text = "Спарсить информацию";
            // 
            // actionMenu_parseItem_texts
            // 
            this.actionMenu_parseItem_texts.Name = "actionMenu_parseItem_texts";
            this.actionMenu_parseItem_texts.Size = new System.Drawing.Size(134, 24);
            this.actionMenu_parseItem_texts.Text = "texts";
            // 
            // actionMenu_parseItem_images
            // 
            this.actionMenu_parseItem_images.Name = "actionMenu_parseItem_images";
            this.actionMenu_parseItem_images.Size = new System.Drawing.Size(134, 24);
            this.actionMenu_parseItem_images.Text = "images";
            // 
            // actionMenu_parseItem_videos
            // 
            this.actionMenu_parseItem_videos.Name = "actionMenu_parseItem_videos";
            this.actionMenu_parseItem_videos.Size = new System.Drawing.Size(134, 24);
            this.actionMenu_parseItem_videos.Text = "videos";
            // 
            // actionMenu_parseItem_suggests
            // 
            this.actionMenu_parseItem_suggests.Name = "actionMenu_parseItem_suggests";
            this.actionMenu_parseItem_suggests.Size = new System.Drawing.Size(134, 24);
            this.actionMenu_parseItem_suggests.Text = "suggests";
            // 
            // actionMenu_parseItem_snippets
            // 
            this.actionMenu_parseItem_snippets.Name = "actionMenu_parseItem_snippets";
            this.actionMenu_parseItem_snippets.Size = new System.Drawing.Size(134, 24);
            this.actionMenu_parseItem_snippets.Text = "snippets";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(131, 6);
            // 
            // actionMenu_parseItem_all
            // 
            this.actionMenu_parseItem_all.Name = "actionMenu_parseItem_all";
            this.actionMenu_parseItem_all.Size = new System.Drawing.Size(134, 24);
            this.actionMenu_parseItem_all.Text = "All...";
            // 
            // actionMenu_moveItem
            // 
            this.actionMenu_moveItem.Enabled = false;
            this.actionMenu_moveItem.Image = global::KeywordsSoft.Program.Properties.Resources.move_icon;
            this.actionMenu_moveItem.Name = "actionMenu_moveItem";
            this.actionMenu_moveItem.Size = new System.Drawing.Size(238, 24);
            this.actionMenu_moveItem.Text = "Перенести";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(235, 6);
            // 
            // actionMenu_deleteItem
            // 
            this.actionMenu_deleteItem.Enabled = false;
            this.actionMenu_deleteItem.Image = global::KeywordsSoft.Program.Properties.Resources.delete_icon;
            this.actionMenu_deleteItem.Name = "actionMenu_deleteItem";
            this.actionMenu_deleteItem.Size = new System.Drawing.Size(238, 24);
            this.actionMenu_deleteItem.Text = "Удалить ключи";
            this.actionMenu_deleteItem.Click += new System.EventHandler(this.actionMenu_deleteItem_Click);
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCategory.Location = new System.Drawing.Point(12, 41);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(79, 16);
            this.labelCategory.TabIndex = 2;
            this.labelCategory.Text = "Категория:";
            // 
            // labelCategorySelected
            // 
            this.labelCategorySelected.AutoSize = true;
            this.labelCategorySelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCategorySelected.Location = new System.Drawing.Point(131, 41);
            this.labelCategorySelected.Name = "labelCategorySelected";
            this.labelCategorySelected.Size = new System.Drawing.Size(0, 16);
            this.labelCategorySelected.TabIndex = 3;
            // 
            // labelParser
            // 
            this.labelParser.AutoSize = true;
            this.labelParser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParser.Location = new System.Drawing.Point(12, 71);
            this.labelParser.Name = "labelParser";
            this.labelParser.Size = new System.Drawing.Size(57, 16);
            this.labelParser.TabIndex = 4;
            this.labelParser.Text = "Парсер";
            // 
            // cbParserSelect
            // 
            this.cbParserSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbParserSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParserSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbParserSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbParserSelect.FormattingEnabled = true;
            this.cbParserSelect.Location = new System.Drawing.Point(100, 68);
            this.cbParserSelect.Name = "cbParserSelect";
            this.cbParserSelect.Size = new System.Drawing.Size(177, 24);
            this.cbParserSelect.TabIndex = 5;
            this.cbParserSelect.SelectedValueChanged += new System.EventHandler(this.cbParserSelect_SelectedValueChanged);
            // 
            // dataGridViewCategoryKeys
            // 
            this.dataGridViewCategoryKeys.AllowUserToAddRows = false;
            this.dataGridViewCategoryKeys.AllowUserToDeleteRows = false;
            this.dataGridViewCategoryKeys.AllowUserToResizeColumns = false;
            this.dataGridViewCategoryKeys.AllowUserToResizeRows = false;
            this.dataGridViewCategoryKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCategoryKeys.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCategoryKeys.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCategoryKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategoryKeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKeyCheck,
            this.colID,
            this.colKeyword,
            this.colGood,
            this.colCluster,
            this.colUrls,
            this.colTexts,
            this.colSpintexts,
            this.colImages,
            this.colSnippets,
            this.colSuggests,
            this.colVideos});
            this.dataGridViewCategoryKeys.Location = new System.Drawing.Point(15, 109);
            this.dataGridViewCategoryKeys.MultiSelect = false;
            this.dataGridViewCategoryKeys.Name = "dataGridViewCategoryKeys";
            this.dataGridViewCategoryKeys.RowHeadersVisible = false;
            this.dataGridViewCategoryKeys.Size = new System.Drawing.Size(900, 422);
            this.dataGridViewCategoryKeys.TabIndex = 6;
            // 
            // colKeyCheck
            // 
            this.colKeyCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colKeyCheck.DataPropertyName = "isChecked";
            this.colKeyCheck.FillWeight = 39.0863F;
            this.colKeyCheck.Frozen = true;
            this.colKeyCheck.HeaderText = "";
            this.colKeyCheck.Name = "colKeyCheck";
            this.colKeyCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colKeyCheck.Width = 32;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colID.DataPropertyName = "id";
            this.colID.HeaderText = "id";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colID.Visible = false;
            this.colID.Width = 5;
            // 
            // colKeyword
            // 
            this.colKeyword.DataPropertyName = "name";
            this.colKeyword.FillWeight = 225.0424F;
            this.colKeyword.HeaderText = "keyword";
            this.colKeyword.Name = "colKeyword";
            this.colKeyword.ReadOnly = true;
            // 
            // colGood
            // 
            this.colGood.DataPropertyName = "good";
            this.colGood.FillWeight = 92.87463F;
            this.colGood.HeaderText = "good";
            this.colGood.Name = "colGood";
            this.colGood.ReadOnly = true;
            // 
            // colCluster
            // 
            this.colCluster.DataPropertyName = "cluster";
            this.colCluster.FillWeight = 92.87463F;
            this.colCluster.HeaderText = "cluster";
            this.colCluster.Name = "colCluster";
            this.colCluster.ReadOnly = true;
            // 
            // colUrls
            // 
            this.colUrls.DataPropertyName = "urls";
            this.colUrls.FillWeight = 92.87463F;
            this.colUrls.HeaderText = "urls";
            this.colUrls.Name = "colUrls";
            this.colUrls.ReadOnly = true;
            // 
            // colTexts
            // 
            this.colTexts.DataPropertyName = "texts";
            this.colTexts.FillWeight = 92.87463F;
            this.colTexts.HeaderText = "texts";
            this.colTexts.Name = "colTexts";
            this.colTexts.ReadOnly = true;
            // 
            // colSpintexts
            // 
            this.colSpintexts.DataPropertyName = "spintexts";
            this.colSpintexts.FillWeight = 92.87463F;
            this.colSpintexts.HeaderText = "spintexts";
            this.colSpintexts.Name = "colSpintexts";
            this.colSpintexts.ReadOnly = true;
            // 
            // colImages
            // 
            this.colImages.DataPropertyName = "images";
            this.colImages.FillWeight = 92.87463F;
            this.colImages.HeaderText = "images";
            this.colImages.Name = "colImages";
            this.colImages.ReadOnly = true;
            // 
            // colSnippets
            // 
            this.colSnippets.DataPropertyName = "snippets";
            this.colSnippets.FillWeight = 92.87463F;
            this.colSnippets.HeaderText = "snippets";
            this.colSnippets.Name = "colSnippets";
            this.colSnippets.ReadOnly = true;
            // 
            // colSuggests
            // 
            this.colSuggests.DataPropertyName = "suggests";
            this.colSuggests.FillWeight = 92.87463F;
            this.colSuggests.HeaderText = "suggests";
            this.colSuggests.Name = "colSuggests";
            this.colSuggests.ReadOnly = true;
            // 
            // colVideos
            // 
            this.colVideos.DataPropertyName = "videos";
            this.colVideos.FillWeight = 92.87463F;
            this.colVideos.HeaderText = "videos";
            this.colVideos.Name = "colVideos";
            this.colVideos.ReadOnly = true;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCategory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeleteCategory.FlatAppearance.BorderSize = 0;
            this.btnDeleteCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCategory.ForeColor = System.Drawing.Color.Transparent;
            this.btnDeleteCategory.Image = global::KeywordsSoft.Program.Properties.Resources.delete_button_25;
            this.btnDeleteCategory.Location = new System.Drawing.Point(100, 37);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteCategory.TabIndex = 0;
            this.btnDeleteCategory.UseVisualStyleBackColor = false;
            this.btnDeleteCategory.Visible = false;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(938, 578);
            this.Controls.Add(this.dataGridViewCategoryKeys);
            this.Controls.Add(this.cbParserSelect);
            this.Controls.Add(this.labelParser);
            this.Controls.Add(this.labelCategorySelected);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keywords Soft";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategoryKeys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionMenu;
        private System.Windows.Forms.ToolStripMenuItem actionMenu_parseItem;
        private System.Windows.Forms.ToolStripMenuItem actionMenu_moveItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem actionMenu_deleteItem;
        private System.Windows.Forms.ToolStripMenuItem actionMenu_parseItem_texts;
        private System.Windows.Forms.ToolStripMenuItem actionMenu_parseItem_images;
        private System.Windows.Forms.ToolStripMenuItem actionMenu_parseItem_videos;
        private System.Windows.Forms.ToolStripMenuItem actionMenu_parseItem_suggests;
        private System.Windows.Forms.ToolStripMenuItem actionMenu_parseItem_snippets;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem actionMenu_parseItem_all;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelCategorySelected;
        private System.Windows.Forms.Label labelParser;
        private System.Windows.Forms.ComboBox cbParserSelect;
        private System.Windows.Forms.DataGridView dataGridViewCategoryKeys;
        private System.Windows.Forms.ToolStripMenuItem actionMenu_addKeys;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colKeyCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGood;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCluster;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUrls;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTexts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpintexts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImages;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSnippets;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSuggests;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVideos;
        public System.Windows.Forms.ToolStripMenuItem categoryMenu;
    }
}

