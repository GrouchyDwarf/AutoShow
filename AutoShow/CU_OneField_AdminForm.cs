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
    public partial class CU_OneField_AdminForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly AdminCrudForm _adminCrudForm;
        private readonly BodyType _bodyType;
        private readonly EngineLocation _engineLocation;
        private readonly EngineType _engineType;
        private readonly Option _option;
        public CU_OneField_AdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option)
        {
            InitializeComponent();
            _context = context;
            _adminCrudForm = adminCrudForm;
            _option = option;
        }
        public CU_OneField_AdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option, in BodyType bodyType)
        {
            InitializeComponent();
            _context = context;
            _adminCrudForm = adminCrudForm;
            _option = option;
            _bodyType = bodyType;
            TextBox.Text = _bodyType.BodyTypeName;
        }
        public CU_OneField_AdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option, in EngineLocation engineLocation)
        {
            InitializeComponent();
            _context = context;
            _adminCrudForm = adminCrudForm;
            _option = option;
            _engineLocation = engineLocation;
            TextBox.Text = _engineLocation.EngineLocationName;
        }
        public CU_OneField_AdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option, in EngineType engineType)
        {
            InitializeComponent();
            _context = context;
            _adminCrudForm = adminCrudForm;
            _option = option;
            _engineType = engineType;
            TextBox.Text = _engineType.EngineTypeName;
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
            if (_bodyType != null || _engineLocation != null || _engineType != null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            if(string.IsNullOrWhiteSpace(TextBox.Text))
            {
                MessageBox.Show("Заполните поле");
                return;
            }
            if (_option == Option.BodyType)
            {
                string bodyTypeName = TextBox.Text;
                var bodyType = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName);
                if (bodyType != null)
                {
                    MessageBox.Show("Такой тип кузова уже существует");
                    return;
                }
                var newBodyType = new BodyType
                {
                    BodyTypeName = bodyTypeName
                };
                _context.BodyTypes.Add(newBodyType);
            }
            else if(_option == Option.EngineLocation)
            {
                string engineLocationName = TextBox.Text;
                var engineLocation = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName);
                if (engineLocation != null)
                {
                    MessageBox.Show("Такое расположение уже существует");
                    return;
                }
                var newEngineLocation = new EngineLocation
                {
                    EngineLocationName = engineLocationName
                };
                _context.EngineLocations.Add(newEngineLocation);
            }
            else if(_option == Option.EngineType)
            {
                string engineTypeName = TextBox.Text;
                var engineType = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName);
                if (engineType != null)
                {
                    MessageBox.Show("Такое расположение уже существует");
                    return;
                }
                var newEngineType = new EngineType
                {
                    EngineTypeName = engineTypeName
                };
                _context.EngineTypes.Add(newEngineType);
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            _adminCrudForm.RefreshData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_bodyType == null && _engineLocation == null && _engineType == null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            if (_option == Option.BodyType)
            {
                var bodyType = _context.BodyTypes.Where(b => b.BodyTypeName == _bodyType.BodyTypeName).FirstOrDefault();
                bodyType.BodyTypeName = TextBox.Text;
            }
            else if(_option == Option.EngineLocation)
            {
                var engineLocation = _context.EngineLocations.Where(en => en.EngineLocationName == _engineLocation.EngineLocationName).FirstOrDefault();
                engineLocation.EngineLocationName = TextBox.Text;
            }
            else if(_option == Option.EngineType)
            {
                var engineType = _context.EngineTypes.Where(en => en.EngineTypeName == _engineType.EngineTypeName).FirstOrDefault();
                engineType.EngineTypeName = TextBox.Text;
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно обновлены");
            }
            _adminCrudForm.RefreshData();
        }
    }
}
