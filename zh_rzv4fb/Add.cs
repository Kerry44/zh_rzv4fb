using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zh_rzv4fb
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Nincs kitöltve!!!");
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, string.Empty);
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{2}$");
            if (!regex.IsMatch(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Nem megfelelő formátum!!!");
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox2, string.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() == true)
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("A bevitt elemet a Datagridview-ban találod.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
