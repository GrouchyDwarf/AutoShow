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
    public partial class ClientForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly StartForm _startForm;
        public ClientForm(in AutoShowContext context, in StartForm startForm)
        {
            InitializeComponent();
            _context = context;
            _startForm = startForm;
            RefreshData();
            CarBrandComboBox.Items.AddRange(_context.CarBrands.Select(b => b.CarBrandName).ToArray());
        }

        public void RefreshData()
        {
            DataGridView.DataSource = _context.Warehouses.Select(w => new
            {
                w.Quantity,
                w.Price,
                w.Product.PaintedModel.Colour.ColourName,
                w.Product.PaintedModel.CarModel.CarModelName,
                w.Product.PaintedModel.CarModel.CarBrand.CarBrandName,
                w.Product.PaintedModel.CarModel.Country.CountryName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.EnginePower,
                w.Product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
                w.Product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount
            }).Where(w => w.Quantity > 0).ToList();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _startForm.Show();
            this.Close();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DataGridView.DataSource = _context.Warehouses.Select(w => new
            {
                w.Quantity,
                w.Price,
                w.Product.PaintedModel.Colour.ColourName,
                w.Product.PaintedModel.CarModel.CarModelName,
                w.Product.PaintedModel.CarModel.CarBrand.CarBrandName,
                w.Product.PaintedModel.CarModel.Country.CountryName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.EnginePower,
                w.Product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
                w.Product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount
            }).Where(w => w.Quantity > 0 && 
                     (CarBrandComboBox.SelectedItem == null || w.CarBrandName == CarBrandComboBox.Text) && 
                     (CarModelComboBox.SelectedItem == null || w.CarModelName == CarModelComboBox.Text)).ToList();
        }

        private void CarBrandComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            CarModelComboBox.Items.Clear();
            CarModelComboBox.Text = "";
            string carBrandName = CarBrandComboBox.Text;
            int carBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == carBrandName).CarBrandId;
            var modelsName = _context.CarModels.Where(c => c.CarBrandId == carBrandId).Select(c => c.CarModelName);
            CarModelComboBox.Items.AddRange(modelsName.ToArray());
        }
    }
}
