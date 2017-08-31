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
        public AboutKey(string keyId, string keyName)
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

            //dgvTexts.DataSource = new List<object>() { new { parser = "paresr test" } };

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
