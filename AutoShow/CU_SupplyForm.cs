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
    public partial class CU_SupplyForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly ProviderCrudForm _providerCrudForm;
        private readonly Supply _supply;
        private readonly Provider _provider;
        public CU_SupplyForm(in AutoShowContext context, in ProviderCrudForm providerCrudForm, in Provider provider)
        {
            InitializeComponent();
            _context = context;
            _providerCrudForm = providerCrudForm;
            _provider = provider;
            BodyTypeComboBox.Items.AddRange(_context.BodyTypes.Select(b => b.BodyTypeName).ToArray());
            EngineTypeComboBox.Items.AddRange(_context.EngineTypes.Select(en => en.EngineTypeName).ToArray());
            EngineLocationComboBox.Items.AddRange(_context.EngineLocations.Select(en => en.EngineLocationName).ToArray());
            CarBrandComboBox.Items.AddRange(_context.CarBrands.Select(c => c.CarBrandName).ToArray());
            CountryComboBox.Items.AddRange(_context.Countries.Select(c => c.CountryName).ToArray());
            ColourComboBox.Items.AddRange(_context.Colours.Select(c => c.ColourName).ToArray());
        }
        public CU_SupplyForm(in AutoShowContext context, in ProviderCrudForm providerCrudForm, in Supply supply)
        : this(context, providerCrudForm, supply.Provider)
        {
            _supply = supply;
            DateTimePicker.Value = _supply.SupplyDate;
            QuantityNumericUpDown.Value = _supply.Quantity;
            PriceNumericUpDown.Value = _supply.Price;
            ColourComboBox.Text = _supply.Product.PaintedModel.Colour.ColourName;
            BodyTypeComboBox.Text = _supply.Product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName;
            EngineTypeComboBox.Text = _supply.Product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName;
            EngineLocationComboBox.Text = _supply.Product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName;
            CarBrandComboBox.Text = _supply.Product.PaintedModel.CarModel.CarBrand.CarBrandName;
            CountryComboBox.Text = _supply.Product.PaintedModel.CarModel.Country.CountryName;
            CarModelNameTextBox.Text = _supply.Product.PaintedModel.CarModel.CarModelName;
            DoorsAmountNumericUpDown.Value = _supply.Product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount;
            SeatsAmountNumericUpDown.Value = _supply.Product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount;
            EngineDisplacementNumericUpDown.Value = _supply.Product.PaintedModel.CarModel.TechnicalInformation.EngineDisplacement;
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _providerCrudForm.Show();
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (_supply != null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            if (string.IsNullOrWhiteSpace(CarModelNameTextBox.Text) || BodyTypeComboBox.SelectedItem == null || EngineLocationComboBox.SelectedItem == null ||
                EngineTypeComboBox.SelectedItem == null || CarBrandComboBox.SelectedItem == null || CountryComboBox.SelectedItem == null ||
                ColourComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == BodyTypeComboBox.Text).BodyTypeId;
            int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == EngineTypeComboBox.Text).EngineTypeId;
            int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == EngineLocationComboBox.Text).EngineLocationId;
            int doorsAmount = (int)DoorsAmountNumericUpDown.Value;
            int seatsAmount = (int)SeatsAmountNumericUpDown.Value;
            int engineDisplacement = (int)EngineDisplacementNumericUpDown.Value;
            string carModelName = CarModelNameTextBox.Text;
            int carBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == CarBrandComboBox.Text).CarBrandId;
            int countryId = _context.Countries.FirstOrDefault(c => c.CountryName == CountryComboBox.Text).CountryId;
            int colourId = _context.Colours.FirstOrDefault(c => c.ColourName == ColourComboBox.Text).ColourId;
            DateTime supplyDate = DateTimePicker.Value;
            int quantity = (int)QuantityNumericUpDown.Value;
            decimal price = PriceNumericUpDown.Value;

            var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId
            && t.EngineLocationId == engineLocationId && t.DoorsAmount == doorsAmount && t.SeatsAmount == seatsAmount &&
            t.EngineDisplacement == engineDisplacement);

            if (technicalInformation == null)
            {
                MessageBox.Show("Таких тех данных нет");
                return;
            }

            var carModel = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.CarBrandId == carBrandId &&
            c.CountryId == countryId && c.TechnicalInformationId == technicalInformation.TechnicalInformationId);

            if (carModel == null)
            {
                MessageBox.Show("Таких моделей нет");
                return;
            }

            var paintedModel = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModel.CarModelId && p.ColourId == colourId);

            if (paintedModel == null)
            {
                MessageBox.Show("Такой окрашенной модели не существует");
                return;
            }
            var product = _context.Products.FirstOrDefault(p => p.PaintedModelId == paintedModel.PaintedModelId);

            if(product == null)
            {
                MessageBox.Show("Такого продукта не существует");
                return;
            }

            var supply = _context.Supplies.FirstOrDefault(s => s.ProviderId == _provider.ProviderId && s.SupplyDate.Year == supplyDate.Year &&
            s.SupplyDate.Month == supplyDate.Month && s.SupplyDate.Day == supplyDate.Day);
            if (supply != null)
            {
                MessageBox.Show("Вам нельзя совершать более одной поставки в день");
                return;
            }

            var newSupply = new Supply
            {
                Price = price,
                ProductId = product.ProductId,
                ProviderId = _provider.ProviderId,
                Quantity = quantity,
                SupplyDate = supplyDate
            };
            _context.Supplies.Add(newSupply);

            int productId = product.ProductId;

            var warehouse = _context.Warehouses.FirstOrDefault(w => w.ProductId == productId);

            if(warehouse == null)
            {
                var newWarehouse = new Warehouse
                {
                    ProductId = productId,
                    Price = newSupply.Price * newSupply.Product.Markup,
                    Quantity = newSupply.Quantity
                };
                _context.Warehouses.Add(newWarehouse);
            }
            else
            {
                warehouse.Price = (warehouse.Quantity * warehouse.Price + newSupply.Quantity * newSupply.Price) / (warehouse.Quantity + newSupply.Quantity);   
                warehouse.Quantity += newSupply.Quantity;
            }

            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            _providerCrudForm.RefreshData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_supply == null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            if (string.IsNullOrWhiteSpace(CarModelNameTextBox.Text) || BodyTypeComboBox.SelectedItem == null || EngineLocationComboBox.SelectedItem == null ||
                EngineTypeComboBox.SelectedItem == null || CarBrandComboBox.SelectedItem == null || CountryComboBox.SelectedItem == null ||
                ColourComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == BodyTypeComboBox.Text).BodyTypeId;
            int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == EngineTypeComboBox.Text).EngineTypeId;
            int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == EngineLocationComboBox.Text).EngineLocationId;
            int doorsAmount = (int)DoorsAmountNumericUpDown.Value;
            int seatsAmount = (int)SeatsAmountNumericUpDown.Value;
            int engineDisplacement = (int)EngineDisplacementNumericUpDown.Value;
            string carModelName = CarModelNameTextBox.Text;
            int carBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == CarBrandComboBox.Text).CarBrandId;
            int countryId = _context.Countries.FirstOrDefault(c => c.CountryName == CountryComboBox.Text).CountryId;
            int colourId = _context.Colours.FirstOrDefault(c => c.ColourName == ColourComboBox.Text).ColourId;
            DateTime supplyDate = DateTimePicker.Value;
            int quantity = (int)QuantityNumericUpDown.Value;
            decimal price = PriceNumericUpDown.Value;

            var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId
            && t.EngineLocationId == engineLocationId && t.DoorsAmount == doorsAmount && t.SeatsAmount == seatsAmount &&
            t.EngineDisplacement == engineDisplacement);

            if (technicalInformation == null)
            {
                MessageBox.Show("Таких тех данных нет");
                return;
            }

            var carModel = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.CarBrandId == carBrandId &&
            c.CountryId == countryId && c.TechnicalInformationId == technicalInformation.TechnicalInformationId);

            if (carModel == null)
            {
                MessageBox.Show("Таких моделей нет");
                return;
            }

            var paintedModel = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModel.CarModelId && p.ColourId == colourId);

            if (paintedModel == null)
            {
                MessageBox.Show("Такой окрашенной модели не существует");
                return;
            }
            var product = _context.Products.FirstOrDefault(p => p.PaintedModelId == paintedModel.PaintedModelId);

            if (product == null)
            {
                MessageBox.Show("Такого продукта не существует");
                return;
            }

            var supply = _context.Supplies.FirstOrDefault(s => s.ProviderId == _provider.ProviderId && s.SupplyDate.Year == supplyDate.Year &&
            s.SupplyDate.Month == supplyDate.Month && s.SupplyDate.Day == supplyDate.Day);
            if (supply != null)
            {
                MessageBox.Show("Вам нельзя совершать более одной поставки в день");
                return;
            }
            _supply.Price = price;
            _supply.ProductId = product.ProductId;
            _supply.ProviderId = _provider.ProviderId;
            _supply.Quantity = quantity;
            _supply.SupplyDate = supplyDate;

            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            _providerCrudForm.RefreshData();
        }
    }
}
