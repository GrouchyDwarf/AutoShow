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
using AutoShow.Models;

namespace AutoShow
{
    public partial class RegistrationForm : Form
    {
        private readonly StartForm _startForm;
        private readonly AutoShowContext _context;
        private readonly List<TextBox> _textBoxes;
        private readonly Role _role;
        public RegistrationForm(in StartForm startForm, in AutoShowContext context, in Role role)
        {
            InitializeComponent();
            _startForm = startForm;
            _context = context;
            _role = role;
            _textBoxes = new List<TextBox>();
            #region Initialize _textBoxes
            _textBoxes.Add(FirstNameTextBox);
            _textBoxes.Add(LastNameTextBox);
            _textBoxes.Add(PasswordTextBox);
            _textBoxes.Add(SecondPasswordTextBox);
            #endregion
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
            #region InputValidation
            foreach (TextBox textBox in _textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    MessageBox.Show("Не все поля заполнены");
                    return;
                }
            }
            if (FirstNameTextBox.Text.Length > 20 || LastNameTextBox.Text.Length > 20 ||
                PasswordTextBox.Text.Length > 20 || SecondPasswordTextBox.Text.Length > 20)
            {
                MessageBox.Show("Данные в полях не должны содержать больше 20 символов");
                return;
            }           
            if (!InputValidator.IsValidName(FirstNameTextBox.Text, out string nameError))
            {
                MessageBox.Show(nameError);
                return;
            }
            if (!InputValidator.IsValidName(LastNameTextBox.Text, out string lastNameError))
            {
                MessageBox.Show(nameError);
                return;
            }
            if (PasswordTextBox.Text.Length < 8 || SecondPasswordTextBox.Text.Length < 8)
            {
                MessageBox.Show("Пароль должен состоять минимум из 8 символов");
                return;
            }
            if (!InputValidator.IsValidPassword(PasswordTextBox.Text, out string passwordError))
            {
                MessageBox.Show(passwordError);
                return;
            }
            if (PasswordTextBox.Text != SecondPasswordTextBox.Text)
            {
                MessageBox.Show("Введенные пароли не совпадают");
                return;
            }
            #endregion
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string password = PasswordTextBox.Text;
            //избавиться от повторения
            if(_role == Role.Admin)
            {   
                var admins = _context.Admins.ToList();
                foreach(Admin admin in admins)
                {
                    if(admin.FirstName == firstName && admin.LastName == lastName)
                    {
                        MessageBox.Show("Админ с таким именем и фамилией уже существует");
                        return;
                    }
                }
                var newAdmin = new Admin
                {
                    AdminId = _context.Admins.Count() + 1,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password
                };
                _context.Admins.Add(newAdmin);
            } 
            else if(_role == Role.DeliveryMan)
            {
                var providers = _context.Providers.ToList();
                foreach (Provider provider in providers)
                {
                    if (provider.FirstName == firstName && provider.LastName == lastName)
                    {
                        MessageBox.Show("Поставщик с таким именем и фамилией уже существует");
                        return;
                    }
                }
                var newProvider = new Provider
                {
                    ProviderId = _context.Providers.Count() + 1,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password
                };
                _context.Providers.Add(newProvider);
            }
            else if(_role == Role.Manager)
            {
                var managers = _context.Managers.ToList();
                foreach (Manager manager in managers)
                {
                    if (manager.FirstName == firstName && manager.LastName == lastName)
                    {
                        MessageBox.Show("Менеджер с таким именем и фамилией уже существует");
                        return;
                    }
                }
                var newManager = new Manager
                {
                    ManagerId = _context.Managers.Count() + 1,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password
                };
                _context.Managers.Add(newManager);
            }
            _context.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно");
            var loginForm = new LoginForm(_startForm, _context);
            loginForm.Show();
            this.Close();
        }
    }
}
