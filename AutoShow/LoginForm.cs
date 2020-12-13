using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoShow;

namespace AutoShow
{
    public partial class LoginForm : Form
    {
        StartForm _startForm;
        public LoginForm(StartForm startForm)
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
    }
}
