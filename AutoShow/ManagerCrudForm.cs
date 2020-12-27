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
                w.Product.PaintedModel.CarModel.TechnicalInformation.EnginePower,
                w.Product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
                w.Product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                w.Product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount
            }).ToList();
        }

        public void RefreshData()
        {
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
                w.Product.PaintedModel.CarModel.TechnicalInformation.EnginePower,
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

        private void PurchaseButton_Click(object sender, EventArgs e)
        {
            var purchasesForm = new PurchasesForm(_context, this);
            purchasesForm.Show();
        }

        private void CreatePurchaseButton_Click(object sender, EventArgs e)
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
            decimal markup = decimal.Parse(DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString());
            string colourName = DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString();
            string carModelName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();
            string carBrandName = DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString();
            string countryName = DataGridView[6, DataGridView.SelectedRows[0].Index].Value.ToString();
            string bodyTypeName = DataGridView[7, DataGridView.SelectedRows[0].Index].Value.ToString();
            string engineTypeName = DataGridView[8, DataGridView.SelectedRows[0].Index].Value.ToString();
            int engineDisplacement = int.Parse(DataGridView[9, DataGridView.SelectedRows[0].Index].Value.ToString());
            int doorsAmount = int.Parse(DataGridView[10, DataGridView.SelectedRows[0].Index].Value.ToString());
            string engineLocationName = DataGridView[11, DataGridView.SelectedRows[0].Index].Value.ToString();
            int seatsAmount = int.Parse(DataGridView[12, DataGridView.SelectedRows[0].Index].Value.ToString());

            int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName).BodyTypeId;
            int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName).EngineTypeId;
            int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName).EngineLocationId;

            int carBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == carBrandName).CarBrandId;
            int countryId = _context.Countries.FirstOrDefault(c => c.CountryName == countryName).CountryId;

            int technicalInformationId = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId &&
            t.DoorsAmount == doorsAmount && t.EnginePower == engineDisplacement && t.EngineLocationId == engineLocationId &&
            t.EngineTypeId == engineTypeId && t.SeatsAmount == seatsAmount).TechnicalInformationId;

            int colourId = _context.Colours.FirstOrDefault(c => c.ColourName == colourName).ColourId;

            int carModelId = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.CarBrandId == c.CarBrandId &&
            c.CountryId == countryId && c.TechnicalInformationId == technicalInformationId).CarModelId;

            int paintedModelId = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModelId && p.ColourId == colourId).PaintedModelId;

            var product = _context.Products.FirstOrDefault(p => p.PaintedModelId == paintedModelId);

            var warehouse = _context.Warehouses.FirstOrDefault(w => w.ProductId == product.ProductId);

            var manager = _context.Managers.FirstOrDefault(m => m.FirstName == _firstName && m.LastName == _lastName);

            if (warehouse.Quantity > 0)
            {

                var createPurchaseForm = new CreatePurchaseForm(_context, this, warehouse, manager);
                createPurchaseForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Недостаточно товара на складе");
                return;
            }
    }

        private void ClientButton_Click(object sender, EventArgs e)
        {
            var managerClientForm = new ManagerClientForm(_context, this);
            managerClientForm.Show();
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            var statisticsForm = new StatisticsForm(_context, this);
            statisticsForm.Show();
        }
    }
}
