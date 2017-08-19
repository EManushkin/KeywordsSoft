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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.categoryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.actionMenu_parseItem,
            this.actionMenu_moveItem,
            this.toolStripSeparator1,
            this.actionMenu_deleteItem});
            this.actionMenu.Enabled = false;
            this.actionMenu.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.actionMenu.Name = "actionMenu";
            this.actionMenu.Size = new System.Drawing.Size(87, 24);
            this.actionMenu.Text = "Действие";
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
            this.actionMenu_parseItem.Image = global::KeywordsSoft.Program.Properties.Resources.parse_icon;
            this.actionMenu_parseItem.Name = "actionMenu_parseItem";
            this.actionMenu_parseItem.Size = new System.Drawing.Size(238, 24);
            this.actionMenu_parseItem.Text = "Спарсить информацию";
            // 
            // actionMenu_parseItem_texts
            // 
            this.actionMenu_parseItem_texts.Name = "actionMenu_parseItem_texts";
            this.actionMenu_parseItem_texts.Size = new System.Drawing.Size(152, 24);
            this.actionMenu_parseItem_texts.Text = "texts";
            // 
            // actionMenu_parseItem_images
            // 
            this.actionMenu_parseItem_images.Name = "actionMenu_parseItem_images";
            this.actionMenu_parseItem_images.Size = new System.Drawing.Size(152, 24);
            this.actionMenu_parseItem_images.Text = "images";
            // 
            // actionMenu_parseItem_videos
            // 
            this.actionMenu_parseItem_videos.Name = "actionMenu_parseItem_videos";
            this.actionMenu_parseItem_videos.Size = new System.Drawing.Size(152, 24);
            this.actionMenu_parseItem_videos.Text = "videos";
            // 
            // actionMenu_parseItem_suggests
            // 
            this.actionMenu_parseItem_suggests.Name = "actionMenu_parseItem_suggests";
            this.actionMenu_parseItem_suggests.Size = new System.Drawing.Size(152, 24);
            this.actionMenu_parseItem_suggests.Text = "suggests";
            // 
            // actionMenu_parseItem_snippets
            // 
            this.actionMenu_parseItem_snippets.Name = "actionMenu_parseItem_snippets";
            this.actionMenu_parseItem_snippets.Size = new System.Drawing.Size(152, 24);
            this.actionMenu_parseItem_snippets.Text = "snippets";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // actionMenu_parseItem_all
            // 
            this.actionMenu_parseItem_all.Name = "actionMenu_parseItem_all";
            this.actionMenu_parseItem_all.Size = new System.Drawing.Size(152, 24);
            this.actionMenu_parseItem_all.Text = "All...";
            // 
            // actionMenu_moveItem
            // 
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
            this.actionMenu_deleteItem.Image = global::KeywordsSoft.Program.Properties.Resources.delete_icon;
            this.actionMenu_deleteItem.Name = "actionMenu_deleteItem";
            this.actionMenu_deleteItem.Size = new System.Drawing.Size(238, 24);
            this.actionMenu_deleteItem.Text = "Удалить";
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
            this.labelCategorySelected.Location = new System.Drawing.Point(97, 41);
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
            this.cbParserSelect.Items.AddRange(new object[] {
            "Все"});
            this.cbParserSelect.Location = new System.Drawing.Point(100, 68);
            this.cbParserSelect.Name = "cbParserSelect";
            this.cbParserSelect.Size = new System.Drawing.Size(177, 24);
            this.cbParserSelect.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(938, 578);
            this.Controls.Add(this.cbParserSelect);
            this.Controls.Add(this.labelParser);
            this.Controls.Add(this.labelCategorySelected);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keywords Soft";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem categoryMenu;
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
    }
}

