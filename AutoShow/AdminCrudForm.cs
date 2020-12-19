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
    public partial class AdminCrudForm : Form
    {
        private readonly AdminMainForm _adminMainForm;
        private readonly AutoShowContext _context;
        private readonly Option _option;
        public AdminCrudForm(in AutoShowContext context, in AdminMainForm adminMainForm, in Option option)
        {
            InitializeComponent();
            _context = context;
            _adminMainForm = adminMainForm;
            _option = option;
            if (_option == Option.BodyType)
            {
                HeaderLabel.Text = "Типы кузова";
                DataGridView.DataSource = _context.BodyTypes.Select(b => new { b.BodyTypeName }).ToList();
            }
            else if(_option == Option.EngineLocation)
            {
                HeaderLabel.Text = "Распол.двиг.";
                DataGridView.DataSource = _context.EngineLocations.Select(e => new { e.EngineLocationName }).ToList();
            }
            else if(_option == Option.EngineType)
            {
                HeaderLabel.Text = "Типы двигателя";
                DataGridView.DataSource = _context.EngineTypes.Select(e => new { e.EngineTypeName }).ToList();
            }
        }

        public void RefreshData()
        {
            if(_option == Option.BodyType)
            {
                DataGridView.DataSource = _context.BodyTypes.Select(b => new { b.BodyTypeName }).ToList();
            }
            else if(_option == Option.EngineLocation)
            {
                DataGridView.DataSource = _context.EngineLocations.Select(e => new { e.EngineLocationName }).ToList();
            }
            else if(_option == Option.EngineType)
            {
                DataGridView.DataSource = _context.EngineTypes.Select(e => new { e.EngineTypeName }).ToList();
            }
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _adminMainForm.Show();
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option);
            createUpdateAdminForm.Show();
            this.Hide();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {    
            if (DataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите кортеж");
                return;
            }
            if(DataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выбрано слишком много кортежей");
                return;
            }
            if (_option == Option.BodyType)
            {
                string bodyTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var bodyType = _context.BodyTypes.Single(b => b.BodyTypeName == bodyTypeName);
                var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option, bodyType);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.EngineLocation)
            {
                string engineLocationName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var engineLocation = _context.EngineLocations.Single(en => en.EngineLocationName == engineLocationName);
                var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option, engineLocation);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.EngineType)
            {
                string engineTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var engineType = _context.EngineTypes.Single(en => en.EngineTypeName == engineTypeName);
                var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option, engineType);
                createUpdateAdminForm.Show();
            }
            this.Hide();
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите кортеж");
                return;
            }
            if (DataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выбрано слишком много кортежей");
                return;
            }
            if (_option == Option.BodyType)
            {
                string bodyTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                _context.BodyTypes.Remove(_context.BodyTypes.Single(b => b.BodyTypeName == bodyTypeName));
            }
            else if(_option == Option.EngineLocation)
            {
                string engineLocationName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                _context.EngineLocations.Remove(_context.EngineLocations.Single(en => en.EngineLocationName == engineLocationName));
            }
            else if(_option == Option.EngineType)
            {
                string engineTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                _context.EngineTypes.Remove(_context.EngineTypes.Single(en => en.EngineTypeName == engineTypeName));
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно удалены");
            }
            RefreshData();
        }
    }
}
