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
    public partial class ManagerClientForm : Form
    {   
        private readonly AutoShowContext _context;
        private readonly ManagerCrudForm _managerCrudForm;
        public ManagerClientForm(in AutoShowContext context, in ManagerCrudForm managerCrudForm)
        {
            InitializeComponent();
            _context = context;
            _managerCrudForm = managerCrudForm;
            RefreshData();
        }

        private void RefreshData()
        {
            DataGridView.DataSource = _context.Clients.Select(c => new
            {
                c.FirstName,
                c.LastName,
                c.Discount,
                c.Phone,
                c.Email,
                c.Address,
                c.PassportId,
                c.PassportSeries
            }).ToList();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            _managerCrudForm.Show();
            this.Close();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
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
            string firstName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
            string lastName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
            var client = _context.Clients.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
            var purchase = _context.Purchases.FirstOrDefault(p => p.ClientId == client.ClientId);
            if (purchase != null)
            {
                MessageBox.Show("Данный клиент присутствует в сделках,поэтому для начала удалите все связанные данные");
                return;
            }
            _context.Clients.Remove(client);
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно удалены");
            }
            RefreshData();
        }
    }
}
