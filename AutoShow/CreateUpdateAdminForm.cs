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
    public partial class CreateUpdateAdminForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly AdminCrudForm _adminCrudForm;
        private readonly BodyType _bodyType;
        private readonly Option _option;
        public CreateUpdateAdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option)
        {
            InitializeComponent();
            _context = context;
            _adminCrudForm = adminCrudForm;
            _option = option;
        }
        public CreateUpdateAdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option, in BodyType bodyType)
        {
            InitializeComponent();
            _context = context;
            _adminCrudForm = adminCrudForm;
            _option = option;
            _bodyType = bodyType;
        }
        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            _adminCrudForm.Show();
            this.Close();
        }
        
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (_option == Option.BodyType)
            {
                if (_bodyType != null)
                {
                    MessageBox.Show("Вы перепутали обновление и создание");
                    return;
                }
                string bodyTypeName = TextBox.Text;
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
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            _adminCrudForm.RefreshData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_option == Option.BodyType)
            {
                if (_bodyType == null)
                {
                    MessageBox.Show("Вы перепутали обновление и создание");
                    return;
                }
                var bodyType = _context.BodyTypes.Where(b => b.BodyTypeName == _bodyType.BodyTypeName).FirstOrDefault();
                bodyType.BodyTypeName = TextBox.Text;
                
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно обновлены");
            }
            _adminCrudForm.RefreshData();
        }
    }
}
