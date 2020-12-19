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
    public partial class CarBrandForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly StartForm _startForm;
        private readonly string _firstName;
        private readonly string _lastName;
        public CarBrandForm(in string firstName, in string lastName, in AutoShowContext context, StartForm startForm)
        {
            InitializeComponent();
            _context = context;
            _startForm = startForm;
            _firstName = firstName;
            _lastName = lastName;
            carBrandDataGridView.DataSource = _context.CarBrands.Select(c => new { CarBrandName = c.CarBrandName }).ToList();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }
    }
}
