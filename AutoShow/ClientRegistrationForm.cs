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
using AutoShow.Data;
using AutoShow.Models;

namespace AutoShow
{
    public partial class ClientRegistrationForm : Form
    {
        private readonly StartForm _startForm;
        private readonly AutoShowContext _context;
        private readonly List<TextBox> _textBoxes;
        public ClientRegistrationForm(in StartForm startForm, in AutoShowContext context)
        {
            InitializeComponent();
            _startForm = startForm;
            _context = context;
            _textBoxes = new List<TextBox>();
            #region Initialize _textBoxes
            _textBoxes.Add(FirstNameTextBox);
            _textBoxes.Add(LastNameTextBox);
            _textBoxes.Add(PasswordTextBox);
            _textBoxes.Add(SecondPasswordTextBox);
            _textBoxes.Add(AddressTextBox);
            _textBoxes.Add(PassportNumberSeriesTextBox);
            _textBoxes.Add(EmailTextBox);
            _textBoxes.Add(PhoneTextBox);
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
                if (string.IsNullOrEmpty(textBox.Text)) {
                    MessageBox.Show("Не все поля заполнены");
                    return;
                }
            }
            string[] passportNumberSeries = Regex.Replace(PassportNumberSeriesTextBox.Text,@"/\s +/ g", " ").Split();
            if(passportNumberSeries.Length < 2)
            {
                MessageBox.Show("Вы не ввели паспорт или серию");
                return;
            } else if(passportNumberSeries.Length > 2)
            {
                MessageBox.Show("Вы ввели что-то лишнее(в поле для паспорта)");
                return;
            }
            string passportNumber = passportNumberSeries[0];
            string passportSeries = passportNumberSeries[1];
            if (FirstNameTextBox.Text.Length > 20 || LastNameTextBox.Text.Length > 20 ||
                PasswordTextBox.Text.Length > 20 || SecondPasswordTextBox.Text.Length > 20 ||
                AddressTextBox.Text.Length > 30 || passportNumber.Length > 20 ||
                passportSeries.Length > 20 || PhoneTextBox.Text.Length > 20 || EmailTextBox.Text.Length > 30)
            {
                MessageBox.Show("Данные в полях не должны содержать больше 20 символов(адрес и почта до 30)");
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
            if(!int.TryParse(passportNumber, out _) || !int.TryParse(passportSeries, out _))
            {
                MessageBox.Show("Номер и серия паспорта должны быть числами");
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
