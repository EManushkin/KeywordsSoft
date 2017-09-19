using KeywordsSoft.Library.Helpers;
using KeywordsSoft.Library.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeywordsSoft.Program
{
    public partial class AddKeys : Form
    {
        private Color labelBorderColor { get; set; }

        public AddKeys()
        {
            InitializeComponent();

            cbCategorySelect.Items.AddRange(Program.mainForm.helper.GetСategories());
            cbCategorySelect.SelectedIndex = 0;
        }

        private void Validation(string message, Color color)
        {
            labelBorderColor = color;
            labelActionMessage.ForeColor = color;
            labelActionMessage.Visible = true;
            labelActionMessage.Text = message;
            labelActionMessage.Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var category = cbCategorySelect.SelectedItem.ToString();
            if (category == "Выбор категории")
            {
                Validation("Выберите категорию из выпадающего списка!", Color.Red);
                return;
            }

            List<string> values = new List<string>();
            using (StringReader reader = new StringReader(rtbKeys.Text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    values.Add($"('{line}', '{true}')");
                }
            }

            if (new KeysHelper().Add(category, string.Join(",", values)))
            {
                Validation($"Ключи добавлены", Color.Green);

                btnAdd.Visible = false;
                btnCancel.Visible = false;

                Thread.Sleep(1000);

                Program.mainForm.LoadDataGridViewCategoryKeys();

                this.Close();
            }
            else
            {
                Validation("Произошла ошибка при добавлении ключей. Попробуйте снова.", Color.Red);
                return;
            }
        }

        private void labelActionMessage_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, labelActionMessage.DisplayRectangle, labelBorderColor, ButtonBorderStyle.Solid);
        }
    }
}
