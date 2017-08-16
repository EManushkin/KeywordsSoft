using KeywordsSoft.Library.Database;
using KeywordsSoft.Library.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeywordsSoft.Program
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            LoadСategoriesMenu();

        }

        private void LoadСategoriesMenu()
        {
            this.категорияToolStripMenuItem.DropDownItems.Clear();

            ToolStripItem toolStripItem;
            foreach (var item in new DatabaseHelper().GetСategories())
            {
                toolStripItem = new ToolStripMenuItem();
                toolStripItem.Name = $"categoryMenu_{item}";
                toolStripItem.Text = item;
                toolStripItem.Click += new EventHandler(categoryMenuItem_Click);

                this.категорияToolStripMenuItem.DropDownItems.Add(toolStripItem);
            }

            this.категорияToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());

            toolStripItem = new ToolStripMenuItem();
            toolStripItem.Name = "AddCategory";
            toolStripItem.Text = "Добавить категорию...";
            toolStripItem.Click += new EventHandler(categoryMenuItem_Click);

            this.категорияToolStripMenuItem.DropDownItems.Add(toolStripItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new KeysHelper().CreateCategoryDatabases("ru_test");

            //new KeysHelper().DeleteCategoryDatabases("ru_test");

        }

        private void categoryMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem toolStripItem = sender as ToolStripItem;

            if (toolStripItem.Name == "AddCategory")
            {

            }
            else
            {

            }
        }
    }
}
