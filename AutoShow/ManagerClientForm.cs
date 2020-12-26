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
    }
}
