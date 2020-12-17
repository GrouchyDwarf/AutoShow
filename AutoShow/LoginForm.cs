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
using AutoShow.Data;

namespace AutoShow
{
    public partial class LoginForm : Form
    {
        private readonly StartForm _startForm;
        private readonly AutoShowContext _context;
        public LoginForm(in StartForm startForm, in AutoShowContext context)
        {
            InitializeComponent();
            _startForm = startForm;
            _context = context;
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
