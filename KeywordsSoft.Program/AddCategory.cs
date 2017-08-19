using KeywordsSoft.Library.Helpers;
using KeywordsSoft.Program;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeywordsSoft.Program
{
    public partial class AddCategory : Form
    {
        private Color labelBorderColor { get; set; }

        public AddCategory()
        {
            InitializeComponent();

            tbCategoryName.Multiline = true;
            Size size = new Size(240, 24);
            tbCategoryName.MinimumSize = size;
            tbCategoryName.Size = size;
            tbCategoryName.Multiline = false;

            cbLanguageSelect.SelectedIndex = 0;
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
            if (string.IsNullOrEmpty(tbCategoryName.Text))
            {
                Validation("Введите название категории!", Color.Red);
                return;
            }

            var language = cbLanguageSelect.SelectedItem.ToString();
            if (language == "Язык")
            {
                Validation("Выберите язык из выпадающего списка!", Color.Red);
                return;
            }

            if (!new DatabaseHelper().CreateCategoryDatabases($"{language}_{tbCategoryName.Text}"))
            {
                Validation("Категория с таким названием и языком уже существует!", Color.Red);
                return;
            }
            else
            {
                Validation($"Категория {language}_{tbCategoryName.Text} добавлена.", Color.Green);

                btnAdd.Visible = false;
                btnCancel.Visible = false;

                Thread.Sleep(2500);

                Program.mainForm.LoadMenu();
                this.Close();
            }
        }

        private void labelActionMessage_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, labelActionMessage.DisplayRectangle, labelBorderColor, ButtonBorderStyle.Solid);
        }
    }
}
