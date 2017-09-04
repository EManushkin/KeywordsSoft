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
        public AboutKey(string dbName, string keyId, string keyName)
        {
            InitializeComponent();

            labelKeyName.Text = keyName;

            btnBack.FlatAppearance.MouseOverBackColor = btnBack.BackColor;
            btnBack.BackColorChanged += (s, e) => { btnBack.FlatAppearance.MouseOverBackColor = btnBack.BackColor; };

            var dgvTexts = tabControlAboutKey.TabPages["tabTexts"].Controls.Find("dataGridViewTexts", true)[0] as DataGridView;

            var parsers = new ParsersHelper().Select();

            var TextsParser = parsers.Where(p => p.type == Parsers.type_texts).ToList();
            dgvTexts.ColumnCount = TextsParser.Count;
            for (int i = 0; i < TextsParser.Count; i++)
            {
                dgvTexts.Columns[i].Name = TextsParser[i].name;
            }

            var texts = new TextsHelper().Select(dbName, $"key_id = {keyId} and parser_id in ({string.Join(", ", TextsParser.Select(x => x.id))})");

            var max = 0;
            var c = 0;
            foreach (var p in TextsParser)
            {


                c = texts.Count(x => x.parser_id == p.id);
                max = c > max ? c : max;

            }

            for (int i = 0; i < max; i++)
            {
                List<string> row = new List<string>();
                for (int j = 0; j < TextsParser.Count; j++)
                {
                    var itemArray = texts.Where(x => x.parser_id == TextsParser[j].id).ToArray();
                    if (itemArray != null && itemArray.Length > i)
                    {
                        row.Add(itemArray[i].text);
                    }
                    else
                    {
                        row.Add(null);
                    }

                }
                dgvTexts.Rows.Add(row.ToArray());

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
