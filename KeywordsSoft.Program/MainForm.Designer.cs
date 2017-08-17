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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.actionMenu_parseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_moveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_deleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_parseItem_texts = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_parseItem_images = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_parseItem_videos = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_parseItem_suggests = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu_parseItem_snippets = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.actionMenu_parseItem_all = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryMenu,
            this.actionMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // categoryMenu
            // 
            this.categoryMenu.Name = "categoryMenu";
            this.categoryMenu.Size = new System.Drawing.Size(75, 20);
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
            this.actionMenu.Name = "actionMenu";
            this.actionMenu.Size = new System.Drawing.Size(70, 20);
            this.actionMenu.Text = "Действие";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
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
            this.actionMenu_parseItem.Size = new System.Drawing.Size(205, 22);
            this.actionMenu_parseItem.Text = "Спарсить информацию";
            // 
            // actionMenu_moveItem
            // 
            this.actionMenu_moveItem.Image = global::KeywordsSoft.Program.Properties.Resources.move_icon;
            this.actionMenu_moveItem.Name = "actionMenu_moveItem";
            this.actionMenu_moveItem.Size = new System.Drawing.Size(205, 22);
            this.actionMenu_moveItem.Text = "Перенести";
            // 
            // actionMenu_deleteItem
            // 
            this.actionMenu_deleteItem.Image = global::KeywordsSoft.Program.Properties.Resources.delete_icon;
            this.actionMenu_deleteItem.Name = "actionMenu_deleteItem";
            this.actionMenu_deleteItem.Size = new System.Drawing.Size(205, 22);
            this.actionMenu_deleteItem.Text = "Удалить";
            // 
            // actionMenu_parseItem_texts
            // 
            this.actionMenu_parseItem_texts.Name = "actionMenu_parseItem_texts";
            this.actionMenu_parseItem_texts.Size = new System.Drawing.Size(152, 22);
            this.actionMenu_parseItem_texts.Text = "texts";
            // 
            // actionMenu_parseItem_images
            // 
            this.actionMenu_parseItem_images.Name = "actionMenu_parseItem_images";
            this.actionMenu_parseItem_images.Size = new System.Drawing.Size(152, 22);
            this.actionMenu_parseItem_images.Text = "images";
            // 
            // actionMenu_parseItem_videos
            // 
            this.actionMenu_parseItem_videos.Name = "actionMenu_parseItem_videos";
            this.actionMenu_parseItem_videos.Size = new System.Drawing.Size(152, 22);
            this.actionMenu_parseItem_videos.Text = "videos";
            // 
            // actionMenu_parseItem_suggests
            // 
            this.actionMenu_parseItem_suggests.Name = "actionMenu_parseItem_suggests";
            this.actionMenu_parseItem_suggests.Size = new System.Drawing.Size(152, 22);
            this.actionMenu_parseItem_suggests.Text = "suggests";
            // 
            // actionMenu_parseItem_snippets
            // 
            this.actionMenu_parseItem_snippets.Name = "actionMenu_parseItem_snippets";
            this.actionMenu_parseItem_snippets.Size = new System.Drawing.Size(152, 22);
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
            this.actionMenu_parseItem_all.Size = new System.Drawing.Size(152, 22);
            this.actionMenu_parseItem_all.Text = "All...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(938, 578);
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
    }
}

