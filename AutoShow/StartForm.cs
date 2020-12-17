using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoShow.Data;

namespace AutoShow
{
    public enum Role { 
            Admin,
            Manager,
            DeliveryMan,
            Client
        };
    public partial class StartForm : Form
    {
        private readonly List<Label> _labels;
        private readonly AutoShowContext _context;  
        private Role _role;
        public StartForm()
        {
            InitializeComponent();
            _labels = new List<Label>();
            #region InitializeLabelsList
            _labels.Add(ManagerLabel);
            _labels.Add(AdminLabel);
            _labels.Add(DeliveryManLabel);
            _labels.Add(ClientLabel);
            #endregion
            _context = new AutoShowContext();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChangeLabelColor(List<Label> labels, in Label chosenLabel)
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
            _role = Role.Manager;

        }

        private void AdminLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, AdminLabel);
            _role = Role.Admin;
        }

        private void DeliveryManLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, DeliveryManLabel);
            _role = Role.DeliveryMan;
        }

        private void ClientLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, ClientLabel);
            _role = Role.Client;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm(this, _context);
            loginForm.Show();
        }

        private void CheckInButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form registrationForm;
            if(_role == Role.Client)
            {
                registrationForm = new ClientRegistrationForm(this, _context);
            } else
            {
                registrationForm = new RegistrationForm(this, _context, _role);
            }
            registrationForm.Show();
        }
    }
}