using KeywordsSoft.Library.Database;
using KeywordsSoft.Library.Helpers;
using KeywordsSoft.Library.Entities;
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
        public string currentCategory { get; set; }
        public string previousCategory { get; set; }

        public string categoryFilter { get; set; }

        public MainForm()
        {
            InitializeComponent();

            LoadMenu();
            LoadMenuParsers();
        }

        public void LoadMenu()
        {
            this.categoryMenu.DropDownItems.Clear();
            this.actionMenu_moveItem.DropDownItems.Clear();

            ToolStripItem categoryToolStripItem;
            ToolStripItem moveToolStripItem;
            foreach (var item in new DatabaseHelper().GetСategories())
            {
                categoryToolStripItem = new ToolStripMenuItem();
                categoryToolStripItem.Name = $"categoryMenu_{item}";
                categoryToolStripItem.Text = item;
                categoryToolStripItem.Click += new EventHandler(categoryMenuItem_Click);
                this.categoryMenu.DropDownItems.Add(categoryToolStripItem);


                moveToolStripItem = new ToolStripMenuItem();
                moveToolStripItem.Name = $"actionMenu_moveItem_{item}";
                moveToolStripItem.Text = item;
                moveToolStripItem.Click += new EventHandler(actionMenu_moveItem_Click);
                this.actionMenu_moveItem.DropDownItems.Add(moveToolStripItem);
            }

            this.categoryMenu.DropDownItems.Add(new ToolStripSeparator());

            categoryToolStripItem = new ToolStripMenuItem();
            categoryToolStripItem.Name = "AddCategory";
            categoryToolStripItem.Text = "Добавить категорию...";
            categoryToolStripItem.Image = Properties.Resources.add_icon;
            categoryToolStripItem.Click += new EventHandler(categoryMenuItem_Click);

            this.categoryMenu.DropDownItems.Add(categoryToolStripItem);
        }

        public void LoadMenuParsers()
        {
            var parsers = new ParsersHelper().Select();
            if (parsers == null)
            {
                return;
            }

            foreach (var type in Parsers.types)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)this.actionMenu.DropDownItems.Find($"actionMenu_parseItem_{type}", true).FirstOrDefault();
                menuItem.DropDownItems.Clear();

                ToolStripItem troolStripItem;
                foreach (var item in parsers.Where(x => x.type == type))
                {
                    troolStripItem = new ToolStripMenuItem();
                    troolStripItem.Name = $"actionMenu_parseItem_{type}_parser_{item.name}";
                    troolStripItem.Text = item.name;
                    troolStripItem.Click += new EventHandler(actionMenuParserItem_Click);
                    menuItem.DropDownItems.Add(troolStripItem);
                }

                menuItem.DropDownItems.Add(new ToolStripSeparator());

                troolStripItem = new ToolStripMenuItem();
                troolStripItem.Name = $"actionMenu_parseItem_{type}_parser_all";
                troolStripItem.Text = "All...";
                troolStripItem.Click += new EventHandler(actionMenuParserItem_Click);

                menuItem.DropDownItems.Add(troolStripItem);
            }

            cbParserSelect.Items.AddRange(parsers.Select(x => $"{x.name}_{x.type}").OrderBy(x => x).ToArray());
            cbParserSelect.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
            }
            else
            {
                // If 'No', do something here.
            }
        }

        private void categoryMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            if (item.Name == "AddCategory")
            {
                var formAddCategory = new AddCategory();
                formAddCategory.ShowDialog(this);
            }
            else
            {
                previousCategory = currentCategory;
                currentCategory = item.Text;

                actionMenu.Enabled = true;
                if (!string.IsNullOrEmpty(previousCategory))
                    this.actionMenu_moveItem.DropDownItems[$"actionMenu_moveItem_{previousCategory}"].Enabled = true;
                this.actionMenu_moveItem.DropDownItems[$"actionMenu_moveItem_{currentCategory}"].Enabled = false;

                categoryFilter = item.Text;
                labelCategorySelected.Text = categoryFilter;
            }
        }

        private void actionMenuParserItem_Click(object sender, EventArgs e)
        {
            
        }

        private void actionMenu_moveItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            
        }
    }
}
