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
    public partial class ManagerCrudForm : Form
    {
        private readonly StartForm _startForm;
        private readonly AutoShowContext _context;
        private readonly string _firstName;
        private readonly string _lastName;
        public ManagerCrudForm(in string firstName, in string lastName, in StartForm startForm, in AutoShowContext context)
        {
            InitializeComponent();
            _context = context;
            _startForm = startForm;
            _firstName = firstName;
            _lastName = lastName;
            ManagerInfoLabel.Text = "Вы вошли как менеджер: " + _firstName + " " + _lastName;

            DataGridView.DataSource = _context.Warehouses.Select(w => new
            {
                w.Quantity,
                w.Price,
                w.Product.Markup,
                w.Product.PaintedModel.Colour.ColourName,
                w.Product.PaintedModel.CarModel.CarModelName,
                w.Product.PaintedModel.CarModel.CarBrand.CarBrandName,
                w.Product.PaintedModel.CarModel.Country.CountryName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.EngineDisplacement,
                w.Product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
                w.Product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount
            }).ToList();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _startForm.Show();
            this.Close();
        }
    }
}
