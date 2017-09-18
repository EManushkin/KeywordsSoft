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

        public AboutKey(string _dbName, string _keyId, string _keyName)
        {
            InitializeComponent();

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

        private void TabDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var value = (sender as DataGridView)[e.ColumnIndex, e.RowIndex].Value.ToString();
            MessageBox.Show(value, "Полный текст выбранного элемента", MessageBoxButtons.OK);
        }

        private void TabLoad(string tabName)
        {
            var dgv = tabControlAboutKey.TabPages[tabName].Controls.Find($"{tabName}DataGridView", true)[0] as DataGridView;

            if (dgv.ColumnCount == 0)
            {
                var type = tabName.Replace("Tab", string.Empty);

                var filteredParser = parsers.Where(p => p.type == type).ToList();

                dgv.ColumnCount = filteredParser.Count;
                for (int i = 0; i < filteredParser.Count; i++)
                {
                    dgv.Columns[i].Name = filteredParser[i].name;
                }

                var filter = $"key_id = {keyId} and parser_id in ({string.Join(", ", filteredParser.Select(x => x.id))})";
                var max = 0;
                var c = 0;
                List<string> row = new List<string>();
                List<BasePostfixType> keysData = new List<BasePostfixType>();

                switch (type)
                {
                    case Parsers.type_texts:
                        keysData = new TextsHelper().Select(dbName, filter).Select(x => new BasePostfixType()
                        {
                            id = x.id,
                            key_id = x.key_id,
                            parser_id = x.parser_id,
                            text = x.text
                        }).ToList();
                        break;
                    case Parsers.type_images:
                        keysData = new ImagesHelper().Select(dbName, filter).Select(x => new BasePostfixType()
                        {
                            id = x.id,
                            key_id = x.key_id,
                            parser_id = x.parser_id,
                            text = x.text
                        }).ToList();
                        break;
                    case Parsers.type_videos:
                        keysData = new VideosHelper().Select(dbName, filter).Select(x => new BasePostfixType()
                        {
                            id = x.id,
                            key_id = x.key_id,
                            parser_id = x.parser_id,
                            text = x.text
                        }).ToList();
                        break;
                    case Parsers.type_snippets:
                        keysData = new SnippetsHelper().Select(dbName, filter).Select(x => new BasePostfixType()
                        {
                            id = x.id,
                            key_id = x.key_id,
                            parser_id = x.parser_id,
                            text = x.text
                        }).ToList();
                        break;
                    case Parsers.type_suggests:
                        keysData = new SuggestsHelper().Select(dbName, filter).Select(x => new BasePostfixType()
                        {
                            id = x.id,
                            key_id = x.key_id,
                            parser_id = x.parser_id,
                            text = x.text
                        }).ToList();
                        break;
                }

                foreach (var p in filteredParser)
                {
                    c = keysData.Count(x => x.parser_id == p.id);
                    max = c > max ? c : max;
                }

                for (int i = 0; i < max; i++)
                {
                    row.Clear();
                    for (int j = 0; j < filteredParser.Count; j++)
                    {
                        var itemArray = keysData.Where(x => x.parser_id == filteredParser[j].id).ToArray();
                        if (itemArray != null && itemArray.Length > i)
                        {
                            row.Add(itemArray[i].text);
                        }
                        else
                        {
                            row.Add(null);
                        }

                    }
                    dgv.Rows.Add(row.ToArray());
                }
            }
        }

        
    }
}
