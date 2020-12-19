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
using AutoShow.Models;

namespace AutoShow
{
    public partial class LoginForm : Form
    {
        private readonly StartForm _startForm;
        private readonly AutoShowContext _context;
        private readonly Role _role;
        public LoginForm(in StartForm startForm, in AutoShowContext context, in Role role)
        {
            InitializeComponent();
            _startForm = startForm;
            _context = context;
            _role = role;
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _startForm.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string password = PasswordTextBox.Text;
            if(_role == Role.Client)
            {
                var clients = _context.Clients.Where(_client => _client.FirstName.Equals(firstName) &&
                                                               _client.LastName.Equals(lastName)    &&
                                                               _client.Password.Equals(password));
                if(clients.Count() == 1)
                {
                    MessageBox.Show("Успешная авторизация");
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль");
                }
            } 
            else if(_role == Role.Manager)
            {
                var managers = _context.Managers.Where(_manager => _manager.FirstName.Equals(firstName) &&
                                                                   _manager.LastName.Equals(lastName) &&
                                                                   _manager.Password.Equals(password));
                if (managers.Count() > 0)
                {
                    MessageBox.Show("Успешная авторизация");
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль");
                }
            }
            else if(_role == Role.DeliveryMan) 
            {
                var providers = _context.Providers.Where(_provider => _provider.FirstName.Equals(firstName) &&
                                                                      _provider.LastName.Equals(lastName) &&
                                                                      _provider.Password.Equals(password));
                if (providers.Count() > 0)
                {
                    MessageBox.Show("Успешная авторизация");
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль");
                }
            }
            else if(_role == Role.Admin)
            {
                var admins = _context.Admins.Where(_admin => _admin.FirstName.Equals(firstName) &&
                                                               _admin.LastName.Equals(lastName) &&
                                                               _admin.Password.Equals(password));
                if (admins.Count() == 1)
                {
                    var adminMainForm = new AdminMainForm(firstName, lastName, _startForm, _context);
                    adminMainForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль");
                }
            }
        }
    }
}
