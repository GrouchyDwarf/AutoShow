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
            RefreshData();
        }
        private void RefreshData()
        {
            DataGridView.DataSource = _context.Products.Select(p => new
            {
                p.Markup,
                p.PaintedModel.Colour.ColourName,
                p.PaintedModel.CarModel.CarModelName,
                p.PaintedModel.CarModel.CarBrand.CarBrandName,
                p.PaintedModel.CarModel.Country.CountryName,
                p.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                p.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName,
                p.PaintedModel.CarModel.TechnicalInformation.EnginePower,
                p.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
                p.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                p.PaintedModel.CarModel.TechnicalInformation.SeatsAmount
            }).ToList();
        }
        public CU_SupplyForm(in AutoShowContext context, in ProviderCrudForm providerCrudForm, in Supply supply)
        : this(context, providerCrudForm, supply.Provider)
        {
            _supply = supply;
            DateTimePicker.Value = _supply.SupplyDate;
            QuantityNumericUpDown.Value = _supply.Quantity;
            PriceNumericUpDown.Value = _supply.Price;
            for (int i = 0; i < DataGridView.Rows.Count; ++i)
            {
                if (_supply.Product.Markup == decimal.Parse(DataGridView[0, i].Value.ToString()) &&
                    _supply.Product.PaintedModel.Colour.ColourName == DataGridView[1, i].Value.ToString() &&
                    _supply.Product.PaintedModel.CarModel.CarModelName == DataGridView[2, i].Value.ToString() &&
                    _supply.Product.PaintedModel.CarModel.CarBrand.CarBrandName == DataGridView[3, i].Value.ToString() &&
                    _supply.Product.PaintedModel.CarModel.Country.CountryName == DataGridView[4, i].Value.ToString() &&
                    _supply.Product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName == DataGridView[5, i].Value.ToString() &&
                    _supply.Product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName == DataGridView[6, i].Value.ToString() &&
                    _supply.Product.PaintedModel.CarModel.TechnicalInformation.EnginePower == int.Parse(DataGridView[7, i].Value.ToString()) &&
                    _supply.Product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount == int.Parse(DataGridView[8, i].Value.ToString()) &&
                    _supply.Product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName == DataGridView[9, i].Value.ToString() &&
                    _supply.Product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount == int.Parse(DataGridView[10, i].Value.ToString()))
                {
                    MessageBox.Show($"Вы выбрали продукт на {i} строке");
                }
            }
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
            if (DataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите продукт");
                return;
            }
            if (DataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выбрано продукт");
                return;
            }
            DateTime supplyDate = DateTimePicker.Value;
            decimal price = PriceNumericUpDown.Value;
            int quantity = (int)QuantityNumericUpDown.Value;
            decimal markup = decimal.Parse(DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString());
            string colourName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
            string carModelName = DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString();
            string carBrandName = DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString();
            string countryName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();
            string bodyTypeName = DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString();
            string engineTypeName = DataGridView[6, DataGridView.SelectedRows[0].Index].Value.ToString();
            int engineDisplacement = int.Parse(DataGridView[7, DataGridView.SelectedRows[0].Index].Value.ToString());
            int doorsAmount = int.Parse(DataGridView[8, DataGridView.SelectedRows[0].Index].Value.ToString());
            string engineLocationName = DataGridView[9, DataGridView.SelectedRows[0].Index].Value.ToString();
            int seatsAmount = int.Parse(DataGridView[10, DataGridView.SelectedRows[0].Index].Value.ToString());

            int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName).BodyTypeId;
            int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName).EngineTypeId;
            int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName).EngineLocationId;
            int carBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == carBrandName).CarBrandId;
            int countryId = _context.Countries.FirstOrDefault(c => c.CountryName == countryName).CountryId;
            int colourId = _context.Colours.FirstOrDefault(c => c.ColourName == colourName).ColourId;

            var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId
            && t.EngineLocationId == engineLocationId && t.DoorsAmount == doorsAmount && t.SeatsAmount == seatsAmount &&
            t.EnginePower == engineDisplacement);

            var carModel = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.CarBrandId == carBrandId &&
            c.CountryId == countryId && c.TechnicalInformationId == technicalInformation.TechnicalInformationId);

            var paintedModel = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModel.CarModelId && p.ColourId == colourId);

            var product = _context.Products.FirstOrDefault(p => p.PaintedModelId == paintedModel.PaintedModelId);

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
                    Price = newSupply.Price * (1 + newSupply.Product.Markup),
                    Quantity = newSupply.Quantity
                };
                _context.Warehouses.Add(newWarehouse);
            }
            else
            {
                warehouse.Price = (warehouse.Quantity * warehouse.Price + newSupply.Quantity * newSupply.Price * (1 + newSupply.Product.Markup))
                    / (warehouse.Quantity + newSupply.Quantity);   
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
            /*if (_supply == null)
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
            t.EnginePower == engineDisplacement);

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
            _providerCrudForm.RefreshData();*/
        }
    }
}
