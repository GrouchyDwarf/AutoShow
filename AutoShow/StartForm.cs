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
    public partial class StartForm : Form
    {
        private readonly List<Label> _labels = new List<Label>();
        public StartForm()
        {
            InitializeComponent();
            #region InitializeLabelsList
            _labels.Add(ManagerLabel);
            _labels.Add(AdminLabel);
            _labels.Add(DeliveryManLabel);
            _labels.Add(UserLabel);
            #endregion
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChangeLabelColor(List<Label> labels, Label chosenLabel)
        {
            for(var i = 0; i < labels.Count; ++i)
            {
                if(labels[i] == chosenLabel)
                {
                    labels[i].ForeColor = Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(5)))), ((int)(((byte)(247)))));
                    continue;
                }
                labels[i].ForeColor = Color.White;
            }
        }

        private void ManagerLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, ManagerLabel);
        }

        private void AdminLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, AdminLabel);
        }

        private void DeliveryManLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, DeliveryManLabel);
        }

        private void UserLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, UserLabel);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm(this);
            loginForm.Show();
        }

        private void CheckInButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registrationForm = new RegistrationForm(this);
            registrationForm.Show();
        }
    }
}