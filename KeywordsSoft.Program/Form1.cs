using KeywordsSoft.Library.Database;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var repo = new DatabaseRepository();
            repo.CreateDatabaseFile(@"D:\FreeLance\Программа для работы с ключами\KeywordsSoft\KeywordsSoft.Program\bin\Debug\test\test.db");
        }
    }
}
