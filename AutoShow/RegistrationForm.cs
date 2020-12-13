using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoShow
{
    public partial class RegistrationForm : Form
    {
        StartForm _startForm;
        public RegistrationForm(StartForm startForm)
        {
            InitializeComponent();
            _startForm = startForm;
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _startForm.Show();
            this.Close();
        }

        private void CheckInButton_Click(object sender, EventArgs e)
        {
            bool filled = this.Controls.OfType<TextBox>().Any(textBox => textBox.TextLength == 0);
            if (filled)
            {
                MessageBox.Show("Дыбил");
            }
        }
    }
}
