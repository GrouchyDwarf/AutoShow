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
            #region InputValidation
            if (FirstNameTextBox.Text.Length > 20 || LastNameTextBox.Text.Length > 20 ||
                PasswordTextBox.Text.Length > 20 || SecondPasswordTextBox.Text.Length > 20)
            {
                MessageBox.Show("Данные в полях не должны содержать больше 20 символов");
                return;
            }
            if (PasswordTextBox.Text.Length < 8 || SecondPasswordTextBox.Text.Length < 8)
            {
                MessageBox.Show("Пароль должен состоять минимум из 8 символов");
                return;
            }
            if (!InputValidator.IsValidName(FirstNameTextBox.Text, out string nameError))
            {
                MessageBox.Show(nameError);
                return;
            }
            else if (!InputValidator.IsValidName(LastNameTextBox.Text, out string lastNameError))
            {
                MessageBox.Show(nameError);
                return;
            }
            else if (!InputValidator.IsValidPassword(PasswordTextBox.Text, out string passwordError))
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
            
        }
    }
}
