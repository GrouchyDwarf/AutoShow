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
    public partial class CreateUpdateBodyTypeForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly StartForm _startForm;
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly BodyType _bodyType;
        public CreateUpdateBodyTypeForm(in string firstName, in string lastName, in AutoShowContext context, StartForm startForm)
        {
            InitializeComponent();
            _context = context;
            _startForm = startForm;
            _firstName = firstName;
            _lastName = lastName;
        }
        public CreateUpdateBodyTypeForm(in string firstName, in string lastName, in AutoShowContext context, StartForm startForm, BodyType bodyType)
        {
            InitializeComponent();
            _context = context;
            _startForm = startForm;
            _firstName = firstName;
            _lastName = lastName;
            _bodyType = bodyType;
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var bodyTypeForm = new BodyTypeForm(_firstName, _lastName, _context, _startForm);
            bodyTypeForm.Show();
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string bodyTypeName = BodyTypeTextBox.Text;
            var bodyTypes = _context.BodyTypes.ToList();
            foreach (BodyType bodyType in bodyTypes)
            {
                if (bodyType.BodyTypeName == bodyTypeName)
                {
                    MessageBox.Show("Такой тип кузова уже существует");
                    return;
                }
            }
            var newBodyType = new BodyType
            {
                BodyTypeName = bodyTypeName
            };
            _context.BodyTypes.Add(newBodyType);
            if(_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }

        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var bodyType = _context.BodyTypes.Where(b => b.BodyTypeName == _bodyType.BodyTypeName).FirstOrDefault();
            bodyType.BodyTypeName = BodyTypeTextBox.Text;
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно обновлены");
            }
        }
    }
}
