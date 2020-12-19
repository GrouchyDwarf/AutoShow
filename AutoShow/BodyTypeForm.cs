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
    public partial class BodyTypeForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly StartForm _startForm;
        private readonly string _firstName;
        private readonly string _lastName;
        public BodyTypeForm(in string firstName, in string lastName, in AutoShowContext context, StartForm startForm)
        {
            InitializeComponent();
            _context = context;
            _startForm = startForm;
            _firstName = firstName;
            _lastName = lastName;
            bodyTypeDataGridView.DataSource = _context.BodyTypes.Select(b => new { BodyTypeName =  b.BodyTypeName}).ToList();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var adminMainForm = new AdminMainForm(_firstName, _lastName, _startForm,_context);
            adminMainForm.Show();
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var createUpdateBodyType = new CreateUpdateBodyTypeForm(_firstName, _lastName, _context, _startForm);
            createUpdateBodyType.Show();
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if(bodyTypeDataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите кортеж");
                return;
            }
            string bodyTypeName = bodyTypeDataGridView[0, bodyTypeDataGridView.SelectedRows[0].Index].Value.ToString();
            var bodyType = _context.BodyTypes.Single(b => b.BodyTypeName == bodyTypeName);
            var createUpdateBodyType = new CreateUpdateBodyTypeForm(_firstName, _lastName, _context, _startForm, bodyType);
            createUpdateBodyType.Show();
            this.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (bodyTypeDataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите кортеж");
                return;
            }
            string bodyTypeName = bodyTypeDataGridView[0, bodyTypeDataGridView.SelectedRows[0].Index].Value.ToString();
            _context.BodyTypes.Remove(_context.BodyTypes.Single(b => b.BodyTypeName == bodyTypeName));
            if(_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно удалены");
            }
            bodyTypeDataGridView.DataSource = _context.BodyTypes.Select(b => new { BodyTypeName = b.BodyTypeName }).ToList();
        }
    }
}
