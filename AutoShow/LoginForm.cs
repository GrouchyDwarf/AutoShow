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
                var client = _context.Clients.FirstOrDefault(_client => _client.FirstName.Equals(firstName) &&
                                                               _client.LastName.Equals(lastName)    &&
                                                               _client.Password.Equals(password));
                if(client != null)
                {
                    var clientForm = new ClientForm(_context, _startForm);
                    clientForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль");
                }
            } 
            else if(_role == Role.Manager)
            {
                var manager = _context.Managers.FirstOrDefault(_manager => _manager.FirstName.Equals(firstName) &&
                                                                   _manager.LastName.Equals(lastName) &&
                                                                   _manager.Password.Equals(password));
                if (manager != null)
                {
                    var managerCrudForm = new ManagerCrudForm(firstName, lastName, _startForm, _context);
                    managerCrudForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль");
                }
            }
            else if(_role == Role.Provider) 
            {
                var provider = _context.Providers.FirstOrDefault(_provider => _provider.FirstName.Equals(firstName) &&
                                                                      _provider.LastName.Equals(lastName) &&
                                                                      _provider.Password.Equals(password));
                if (provider != null)
                {
                    var providerCrudForm = new ProviderCrudForm(firstName, lastName, _startForm, _context);
                    providerCrudForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль");
                }
            }
            else if(_role == Role.Admin)
            {
                var admin = _context.Admins.FirstOrDefault(_admin => _admin.FirstName.Equals(firstName) &&
                                                               _admin.LastName.Equals(lastName) &&
                                                               _admin.Password.Equals(password));
                if (admin != null)
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
