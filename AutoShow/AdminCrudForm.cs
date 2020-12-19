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
            if(_option == Option.BodyType)
            {
                DataGridView.DataSource = _context.BodyTypes.Select(b => new { BodyTypeName = b.BodyTypeName }).ToList();
            }
        }

        public void RefreshData()
        {
            if(_option == Option.BodyType)
            {
                DataGridView.DataSource = _context.BodyTypes.Select(b => new { BodyTypeName = b.BodyTypeName }).ToList();
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
            var createUpdateAdminForm = new CreateUpdateAdminForm(_context, this, _option);
            createUpdateAdminForm.Show();
            this.Hide();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_option == Option.BodyType)
            {
                if (DataGridView.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Выберите кортеж");
                    return;
                }
                string bodyTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var bodyType = _context.BodyTypes.Single(b => b.BodyTypeName == bodyTypeName);
                var createUpdateAdminForm = new CreateUpdateAdminForm(_context, this, _option, bodyType);
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
            if (_option == Option.BodyType)
            {
                string bodyTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                _context.BodyTypes.Remove(_context.BodyTypes.Single(b => b.BodyTypeName == bodyTypeName));
                if (_context.SaveChanges() > 0)
                {
                    MessageBox.Show("Данные успешно удалены");
                }
            }
            RefreshData();
        }
    }
}
