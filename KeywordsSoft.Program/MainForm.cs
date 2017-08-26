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

        public List<MainTable> MainTableList { get; set; }
        public List<Parsers> ParsersList { get; set; }

        private CheckBox ckBox { get; set; }

        public MainForm()
        {
            InitializeComponent();

            ParsersList = new ParsersHelper().Select();

            LoadMenu();
            LoadMenuParsers();
            LoadDataGridViewCategoryKeys();
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
            if (ParsersList == null)
            {
                return;
            }

            foreach (var type in Parsers.types)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)this.actionMenu.DropDownItems.Find($"actionMenu_parseItem_{type}", true).FirstOrDefault();
                menuItem.DropDownItems.Clear();

                ToolStripItem troolStripItem;
                foreach (var item in ParsersList.Where(x => x.type == type))
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

            cbParserSelect.Items.AddRange(ParsersList.Select(x => $"{x.name}_{x.type}").OrderBy(x => x).ToArray());
            cbParserSelect.SelectedIndex = 0;
        }

        public void LoadDataGridViewCategoryKeys()
        {
            this.dataGridViewCategoryKeys.AutoGenerateColumns = false;

            ckBox = new CheckBox();
            Rectangle rect = this.dataGridViewCategoryKeys.GetCellDisplayRectangle(0, -1, true);
            ckBox.Size = new Size(18, 18);
            ckBox.BackColor = Color.Transparent;
            ckBox.Location = new Point() { X = rect.Location.X + 11, Y = rect.Location.Y + 3 };
            ckBox.CheckedChanged += new EventHandler(ckBox_CheckedChanged);
            this.dataGridViewCategoryKeys.Controls.Add(ckBox);
        }

        public void ResetForm()
        {
            labelCategorySelected.Text = null;
            currentCategory = null;
            btnDeleteCategory.Visible = false;
            cbParserSelect.SelectedIndex = 0;
            LoadMenu();
        }

        public void KeysActionEnabled(bool state)
        {
            actionMenu_moveItem.Enabled = state;
            actionMenu_parseItem.Enabled = state;
            actionMenu_deleteItem.Enabled = state;
        }

        private void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < this.dataGridViewCategoryKeys.RowCount; j++)
            {
                this.dataGridViewCategoryKeys[0, j].Value = this.ckBox.Checked;
            }
            this.dataGridViewCategoryKeys.EndEdit();
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
                KeysActionEnabled(true);

                previousCategory = currentCategory;
                if (!string.IsNullOrEmpty(previousCategory))
                    this.actionMenu_moveItem.DropDownItems[$"actionMenu_moveItem_{previousCategory}"].Enabled = true;

                currentCategory = item.Text;
                this.actionMenu_moveItem.DropDownItems[$"actionMenu_moveItem_{currentCategory}"].Enabled = false;

                labelCategorySelected.Text = currentCategory;
                btnDeleteCategory.Visible = true;

                MainTableList = new DatabaseHelper().Select(currentCategory);

                dataGridViewCategoryKeys.DataSource = MainTableList;
            }
        }

        private void actionMenu_addKeys_Click(object sender, EventArgs e)
        {
            var formAddKeys = new AddKeys();
            formAddKeys.ShowDialog(this);
        }

        private void actionMenuParserItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            var parser = ParsersList.FirstOrDefault(p => p.name == item.Text && p.type == item.OwnerItem.Text);
            var testKeyIdsList = new List<string>() { "1", "2", "3", "4" };
            new ParsersHelper().Parse(testKeyIdsList, parser, currentCategory);
        }

        private void actionMenu_moveItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show($"Вы уверены, что хотите удалить категорию '{currentCategory}'?", "Удаление категории!", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                new DatabaseHelper().DeleteCategoryDatabases(currentCategory);
                ResetForm();
            }
        }

        
    }
}
