using KeywordsSoft.Library.Database;
using KeywordsSoft.Library.Helpers;
using KeywordsSoft.Library.Entities;
using KeywordsSoft.Library.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using System.Linq.Expressions;

namespace KeywordsSoft.Program
{
    public partial class MainForm : Form
    {
        public string currentCategory { get; set; }
        public string previousCategory { get; set; }
        public Parsers parserForKeysParse { get; set; }

        public List<MainTable> MainTableList { get; set; }
        public List<Parsers> ParsersList { get; set; }

        public DatabaseHelper helper = new DatabaseHelper();
        public ParsersHelper parserHelper;

        public BindingListView<MainTable> dgView { get; set; }

        private CheckBox ckBox { get; set; }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            parserHelper = new ParsersHelper();
            ParsersList = parserHelper.Select();

            LoadMenu();
            LoadMenuParsers();
            PaintDataGridViewCategoryKeys();
            LoadFilterItems();
        }

        public void LoadMenu()
        {
            this.categoryMenu.DropDownItems.Clear();
            this.actionMenu_moveItem.DropDownItems.Clear();

            ToolStripItem categoryToolStripItem;
            ToolStripItem moveToolStripItem;
            foreach (var item in helper.GetСategories())
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

            cbParserSelect.Items.Add(new ComboBoxItem() { Text = "Все", Value = (long)-1 });
            cbParserSelect.Items.AddRange(ParsersList.Select(x => new ComboBoxItem() { Text = $"{x.type}_{x.name}", Value = x.id }).OrderBy(x => x.Text).ToArray());
            cbParserSelect.SelectedIndex = 0;
        }

        public void LoadFilterItems()
        {
            tbFilterValue.Multiline = true;
            Size size = new Size(120, 24);
            tbFilterValue.MinimumSize = size;
            tbFilterValue.Size = size;
            tbFilterValue.Multiline = false;

            cbFilterField.Items.AddRange(new[] {
                new ComboBoxItem { Text = "Поле", Value = string.Empty },
                new ComboBoxItem { Text = "keyword", Value = "string" },
                new ComboBoxItem { Text = "cluster", Value = "string" },
                new ComboBoxItem { Text = "urls", Value = "int" },
                new ComboBoxItem { Text = "texts", Value = "int" },
                new ComboBoxItem { Text = "spintexts", Value = "int" },
                new ComboBoxItem { Text = "images", Value = "int" },
                new ComboBoxItem { Text = "snippets", Value = "int" },
                new ComboBoxItem { Text = "suggests", Value = "int" },
                new ComboBoxItem { Text = "videos", Value = "int" },
            });

            cbFilterField.SelectedIndex = 0;
            cbFilterOperator.SelectedIndex = 0;
        }

        public void ShowRowsCount(int count)
        {
            labelRowsCount.Text = $"Количество строк: {count}";
        }

        public void PaintDataGridViewCategoryKeys()
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

        public void LoadDataGridViewCategoryKeys(string parserId = null)
        {
            //string workTimeInSec;
            //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            //sw.Restart();
            //dgView = new BindingListView<MainTable>(helper.SelectMainTable(currentCategory, parserId));
            //sw.Stop();
            //workTimeInSec = (sw.ElapsedMilliseconds / 1000.0).ToString();


            //sw.Restart();
            dgView = new BindingListView<MainTable>(helper.Select(currentCategory, parserId));
            //sw.Stop();
            //workTimeInSec = (sw.ElapsedMilliseconds / 1000.0).ToString();

            
            dataGridViewCategoryKeys.DataSource = dgView;

            ShowRowsCount(dgView.Count);
        }

        public void ResetForm()
        {
            currentCategory = null;

            CategoryChangeReset(false);

            LoadMenu();
            LoadDataGridViewCategoryKeys();
        }

        public void CategoryChangeReset(bool state)
        {
            actionMenu_moveItem.Enabled = state;
            actionMenu_parseItem.Enabled = state;
            actionMenu_deleteItem.Enabled = state;
            cbParserSelect.Enabled = state;

            cbFilterField.Enabled = state;

            btnDeleteCategory.Visible = state;

            cbFilterField.SelectedIndex = 0;
            cbFilterOperator.SelectedIndex = 0;
            cbParserSelect.SelectedIndex = 0;

            labelCategorySelected.Text = currentCategory;
            tbFilterValue.Text = string.Empty;

            cbFilterOperator.Enabled = false;
            tbFilterValue.Enabled = false;
            btnFilter.Enabled = false;

            ckBox.Checked = false;
            progressBar1.Visible = state;
            progressBar1.Value = 0;
            labelPercent.Text = string.Empty;

            GC.Collect();
        }

        private void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            //dataGridViewCategoryKeys.Rows.Cast<DataGridViewRow>().Select(x => x.SetValues(ckBox.Checked)).ToArray();
            var test = dataGridViewCategoryKeys.Rows.Cast<DataGridViewRow>().ToList();
            test.ForEach(x => x.SetValues(ckBox.Checked));

            test = null;
            //GC.Collect();

            this.dataGridViewCategoryKeys.EndEdit();
        }

        private void categoryMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            previousCategory = currentCategory;
            if (!string.IsNullOrEmpty(previousCategory))
                this.actionMenu_moveItem.DropDownItems[$"actionMenu_moveItem_{previousCategory}"].Enabled = true;

            if (item.Name == "AddCategory")
            {
                var formAddCategory = new AddCategory();
                formAddCategory.ShowDialog(this);

                LoadMenu();
            }
            else
            {
                currentCategory = item.Text;
            }

            CategoryChangeReset(true);

            this.actionMenu_moveItem.DropDownItems[$"actionMenu_moveItem_{currentCategory}"].Enabled = false;

            LoadDataGridViewCategoryKeys();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show($"Вы уверены, что хотите удалить категорию '{currentCategory}'?", "Удаление категории!", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                helper.DeleteCategoryDatabases(currentCategory);
                ResetForm();
            }
        }

        //private void actionMenu_Click(object sender, EventArgs e)
        //{
        //    bool enabled = false;
        //    if (GetCheckedKeysIds().Any())
        //    {
        //        enabled = true;
        //    }
        //    actionMenu_moveItem.Enabled = enabled;
        //    actionMenu_parseItem.Enabled = enabled;
        //    actionMenu_deleteItem.Enabled = enabled;
        //}

        private void actionMenu_addKeys_Click(object sender, EventArgs e)
        {
            var formAddKeys = new AddKeys();
            formAddKeys.ShowDialog(this);
        }

        private void actionMenu_deleteItem_Click(object sender, EventArgs e)
        {
            var ids = GetCheckedKeysIds();

            if (ids.Any() && helper.DeleteKeysWithRelationships(currentCategory, ids))
            {
                LoadDataGridViewCategoryKeys();
                ckBox.Checked = false;
            }
        }

        private void actionMenu_moveItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            var moveTo = item.Text;
            var ids = GetCheckedKeysIds();

            if (ids.Any() && helper.MoveKeysToAnotherDatabase(currentCategory, moveTo, ids))
            {
                this.actionMenu_moveItem.DropDownItems[$"actionMenu_moveItem_{currentCategory}"].Enabled = true;
                currentCategory = moveTo;
                this.actionMenu_moveItem.DropDownItems[$"actionMenu_moveItem_{currentCategory}"].Enabled = false;

                CategoryChangeReset(true);
                LoadDataGridViewCategoryKeys();
            }
        }

        private void actionMenuParserItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            if (item != null && item.Text != "All...")
            {
                parserForKeysParse = ParsersList.FirstOrDefault(p => p.name == item.Text && p.type == item.OwnerItem.Text);

                var ids = GetCheckedKeysIds();
                if (ids.Any())
                {
                    progressBar1.Value = 0;
                    progressBar1.Visible = true;

                    this.Enabled = false;
                    backgroundWorker1.RunWorkerAsync(ids);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool result = true;

            var ids = e.Argument as List<string>;

            for(int i = 1; i <= ids.Count; i++)
                {
                result &= parserHelper.Parse(currentCategory, ids[i - 1], parserForKeysParse);
                backgroundWorker1.ReportProgress(100 * i / ids.Count);
            }

            ids.Clear();
            ids = null;
            e.Result = result;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            labelPercent.Text = e.ProgressPercentage + "%";
            if (e.ProgressPercentage == 100)
            {
                progressBar1.Maximum = 101;
                progressBar1.Value = 101;
                progressBar1.Maximum = 100;
                progressBar1.Value = 100;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            if ((bool)e.Result)
            {
                parserHelper.Vacuum(currentCategory, parserForKeysParse);

                var confirmResult = MessageBox.Show($"Информация по выбранным ключам по типу {parserForKeysParse.type} спарсена парсером {parserForKeysParse.name}.", "Парсинг завершен", MessageBoxButtons.OK);
                if (confirmResult == DialogResult.OK)
                {
                    LoadDataGridViewCategoryKeys();
                    CategoryChangeReset(true);
                    ckBox.Checked = false;
                }
            }

            this.Enabled = true;
            GC.Collect();
        }

        private void cbParserSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cbParserSelect.SelectedItem;
            if (item != null && currentCategory != null)
            {
                var sortProperty = dgView.SortProperty;
                var sortDirection = dgView.SortDirection;

                if ((long)item.Value == -1)
                {
                    LoadDataGridViewCategoryKeys();
                }
                else
                {
                    LoadDataGridViewCategoryKeys(item.Value.ToString());
                }

                btnFilter.PerformClick();

                if (sortProperty != null)
                {
                    dgView.ApplySort(sortProperty, sortDirection);
                }

                ckBox.Checked = false;
            }
        }

        private void cbFilterField_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cbFilterField.SelectedItem;
            if (item != null && !string.IsNullOrEmpty((string)item.Value))
            {
                if ((string)item.Value == "int")
                {
                    cbFilterOperator.Enabled = true;
                }
                else
                {
                    cbFilterOperator.SelectedIndex = 0;
                    cbFilterOperator.Enabled = false;
                }

                tbFilterValue.Enabled = true;
                btnFilter.Enabled = true;
                btnFilterRemove.Enabled = true;
            }
        }

        private List<string> GetCheckedKeysIds()
        {
            dataGridViewCategoryKeys.EndEdit();

            return dataGridViewCategoryKeys.Rows
                .Cast<DataGridViewRow>()
                .Where(r => (bool?)r.Cells[0].Value == true)
                .Select(x => x.Cells[1].Value.ToString())
                .ToList();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ComboBoxItem fieldItem = (ComboBoxItem)cbFilterField.SelectedItem;
            switch (fieldItem.Text)
            {
                case "keyword":
                    dgView.ApplyFilter(x => x.name.ToLower().Contains(tbFilterValue.Text.ToLower()));
                    break;
                case "cluster":
                    dgView.ApplyFilter(x => x.cluster.ToLower().Contains(tbFilterValue.Text.ToLower()));
                    break;
                case "urls":
                case "texts":
                case "spintexts":
                case "images":
                case "snippets":
                case "suggests":
                case "videos":
                    Expression<Func<MainTable, bool>> func = Extentions.strToFunc<MainTable>(fieldItem.Text, cbFilterOperator.Text, tbFilterValue.Text);
                    Predicate<MainTable> pred = func.ExpressionToFunc().Invoke;
                    dgView.ApplyFilter(pred);
                    break;
                    //default:
                    //    dgView.RemoveFilter();
                    //    break;
            }

            ShowRowsCount(dgView.Count);
        }

        private void btnFilterRemove_Click(object sender, EventArgs e)
        {
            dgView.RemoveFilter();
            ShowRowsCount(dgView.Count);

            cbFilterField.SelectedIndex = 0;
            cbFilterOperator.SelectedIndex = 0;
            cbFilterOperator.Enabled = false;
            tbFilterValue.Text = string.Empty;
            tbFilterValue.Enabled = false;
            btnFilter.Enabled = false;
            btnFilterRemove.Enabled = false;
        }

        private void dataGridViewCategoryKeys_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCategoryKeys.CurrentCell.ColumnIndex.Equals(2) && e.RowIndex != -1)
            {
                if (dataGridViewCategoryKeys.CurrentCell != null && dataGridViewCategoryKeys.CurrentCell.Value != null)
                {
                    var keyId = dataGridViewCategoryKeys.CurrentRow.Cells[1].Value.ToString();
                    var keyName = dataGridViewCategoryKeys.CurrentCell.Value.ToString();
                    var formAboutKey = new AboutKey(currentCategory, keyId, keyName);
                    formAboutKey.ShowDialog(this);
                }
            }
        }
    }
}
