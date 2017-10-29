using KeywordsSoft.Library.Entities;
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
    public partial class AboutKey : Form
    {
        List<Parsers> parsers = Program.mainForm.ParsersList;
        string dbName;
        string keyId;
        string keyName;

        private System.Windows.Forms.TabControl tabControlParsers;
        private System.Windows.Forms.DataGridView parserTabDataGridView;

        public AboutKey(string _dbName, string _keyId, string _keyName)
        {
            InitializeComponent();
            InitializeTabsForParsersData();

            dbName = _dbName;
            keyId = _keyId;
            keyName = _keyName;

            Width = (int)(Program.mainForm.Width * 0.95);
            Height = (int)(Program.mainForm.Height * 0.95);

            labelKeyName.Text = keyName;

            btnBack.FlatAppearance.MouseOverBackColor = btnBack.BackColor;
            btnBack.BackColorChanged += (s, e) => { btnBack.FlatAppearance.MouseOverBackColor = btnBack.BackColor; };

            TabLoad(tabControlAboutKey.TabPages[0].Name);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControlAboutKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabLoad((sender as TabControl).SelectedTab.Name);
        }

        private void tabControlParsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = tabControlAboutKey.TabPages[tabControlAboutKey.SelectedIndex].Name.Replace("Tab", string.Empty);
            TabParserLoad((sender as TabControl).SelectedTab.Name, type);
        }

        private void ParserTabDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var value = (sender as DataGridView)[e.ColumnIndex, e.RowIndex].Value.ToString();
            MessageBox.Show(value, "Полный текст выбранного элемента", MessageBoxButtons.OK);
        }

        private void TabLoad(string tabName)
        {
            tabControlParsers.Parent = tabControlAboutKey.TabPages[tabName];
            tabControlParsers.SelectedIndex = 0;
            TabParserLoad(tabControlParsers.TabPages[0].Name, tabName.Replace("Tab", string.Empty));
        }

        private void TabParserLoad(string tabName, string parserType)
        {
            parserTabDataGridView.ColumnCount = 1;
            parserTabDataGridView.Rows.Clear();
            parserTabDataGridView.Refresh();
            parserTabDataGridView.ColumnHeadersVisible = false;

            parserTabDataGridView.Parent = tabControlParsers.TabPages[tabName];

            var parserName = tabName.Replace("ParserTab", string.Empty);

            var filteredParser = parsers.Where(p => p.type == parserType && p.name == parserName).ToList();

            var filter = $"key_id = {keyId} and parser_id in ({string.Join(", ", filteredParser.Select(x => x.id))})";

            IEnumerable<object> data = null;

            switch (parserType)
            {
                case Parsers.type_texts:
                    data = new TextsHelper().Select(dbName, filter).Select(x => new string[] { x.text, x.spin, x.url });
                    if (data != null && data.Any())
                    {
                        parserTabDataGridView.ColumnHeadersVisible = true;
                        parserTabDataGridView.ColumnCount = 3;
                        parserTabDataGridView.Columns[0].Name = "text";
                        parserTabDataGridView.Columns[1].Name = "spin";
                        parserTabDataGridView.Columns[2].Name = "url";

                        foreach (string[] item in data)
                        {
                            parserTabDataGridView.Rows.Add(item);
                        }
                    }
                    break;
                case Parsers.type_images:
                    DataGridViewRow row1 = new DataGridViewRow();
                    data = new ImagesHelper().Select(dbName, filter).Select(x => x.text).ToArray();
                    break;
                case Parsers.type_videos:
                    data = new VideosHelper().Select(dbName, filter).Select(x => x.text).ToArray();
                    break;
                case Parsers.type_snippets:
                    data = new SnippetsHelper().Select(dbName, filter).Select(x => x.text).ToArray();
                    break;
                case Parsers.type_suggests:
                    data = new SuggestsHelper().Select(dbName, filter).Select(x => x.text).ToArray();
                    break;
            }

            if (parserTabDataGridView.RowCount == 0 && data != null)
            {
                foreach (var item in data)
                {
                    parserTabDataGridView.Rows.Add(item);
                }
            }
        }

        private void InitializeTabsForParsersData()
        {
            //Initialize parserTabDataGridView
            this.parserTabDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.parserTabDataGridView)).BeginInit();
            this.parserTabDataGridView.AllowUserToAddRows = false;
            this.parserTabDataGridView.AllowUserToDeleteRows = false;
            this.parserTabDataGridView.AllowUserToResizeColumns = false;
            this.parserTabDataGridView.AllowUserToResizeRows = false;
            this.parserTabDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.parserTabDataGridView.BackgroundColor = System.Drawing.Color.LightCyan;
            this.parserTabDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.parserTabDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parserTabDataGridView.ColumnHeadersVisible = false;
            this.parserTabDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parserTabDataGridView.Location = new System.Drawing.Point(3, 3);
            this.parserTabDataGridView.MultiSelect = false;
            this.parserTabDataGridView.Name = "parserTabDataGridView";
            this.parserTabDataGridView.ReadOnly = true;
            this.parserTabDataGridView.RowHeadersVisible = false;
            this.parserTabDataGridView.Size = new System.Drawing.Size(823, 380);
            this.parserTabDataGridView.TabIndex = 0;
            this.parserTabDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ParserTabDataGridView_CellContentDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.parserTabDataGridView)).EndInit();
            //End of Initialize parserTabDataGridView


            //Initialize tabControlParsers
            this.tabControlParsers = new System.Windows.Forms.TabControl();
            this.tabControlParsers.SuspendLayout();
            this.tabControlParsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlParsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlParsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlParsers.Location = new System.Drawing.Point(3, 3);
            this.tabControlParsers.Name = "tabControlParsers";
            this.tabControlParsers.SelectedIndex = 0;
            this.tabControlParsers.Size = new System.Drawing.Size(837, 415);
            this.tabControlParsers.TabIndex = 0;

            foreach (var parser in parsers.Select(x => x.name).Distinct())
            {
                this.tabControlParsers.Controls.Add(CreateNewTab($"{parser}ParserTab", parser));
            }

            this.tabControlParsers.SelectedIndexChanged += new System.EventHandler(this.tabControlParsers_SelectedIndexChanged);
            this.tabControlParsers.ResumeLayout(false);
            //End of Initialize tabControlParsers
        }

        private TabPage CreateNewTab(string name, string text)
        {
            var tab = new System.Windows.Forms.TabPage();

            tab.SuspendLayout();
            tab.BackColor = System.Drawing.Color.LightCyan;
            tab.ForeColor = System.Drawing.SystemColors.ControlText;
            tab.Location = new System.Drawing.Point(4, 25);
            tab.Name = name;
            tab.Padding = new System.Windows.Forms.Padding(3);
            tab.Size = new System.Drawing.Size(829, 386);
            tab.TabIndex = 0;
            tab.Text = text;
            tab.ResumeLayout(false);

            return tab;
        }

    }
}
