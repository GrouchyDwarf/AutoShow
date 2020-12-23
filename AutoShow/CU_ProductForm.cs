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
    public partial class CU_ProductForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly AdminCrudForm _adminCrudForm;
        private readonly Product _product;
        public CU_ProductForm(in AutoShowContext context, in AdminCrudForm adminCrudForm)
        {
            InitializeComponent();
            _context = context;
            _adminCrudForm = adminCrudForm;
            BodyTypeComboBox.Items.AddRange(_context.BodyTypes.Select(b => b.BodyTypeName).ToArray());
            EngineTypeComboBox.Items.AddRange(_context.EngineTypes.Select(en => en.EngineTypeName).ToArray());
            EngineLocationComboBox.Items.AddRange(_context.EngineLocations.Select(en => en.EngineLocationName).ToArray());
            CarBrandComboBox.Items.AddRange(_context.CarBrands.Select(c => c.CarBrandName).ToArray());
            CountryComboBox.Items.AddRange(_context.Countries.Select(c => c.CountryName).ToArray());
            ColourComboBox.Items.AddRange(_context.Colours.Select(c => c.ColourName).ToArray());
        }
        public CU_ProductForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Product product)
        : this(context, adminCrudForm)
        {
            _product = product;
            MarkupNumericUpDown.Value = _product.Markup;
            ColourComboBox.Text = _product.PaintedModel.Colour.ColourName;
            BodyTypeComboBox.Text = _product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName;
            EngineTypeComboBox.Text = _product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName;
            EngineLocationComboBox.Text = _product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName;
            CarBrandComboBox.Text = _product.PaintedModel.CarModel.CarBrand.CarBrandName;
            CountryComboBox.Text = _product.PaintedModel.CarModel.Country.CountryName;
            CarModelNameTextBox.Text = _product.PaintedModel.CarModel.CarModelName;
            DoorsAmountNumericUpDown.Value = _product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount;
            SeatsAmountNumericUpDown.Value = _product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount;
            EngineDisplacementNumericUpDown.Value = _product.PaintedModel.CarModel.TechnicalInformation.EngineDisplacement;
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            _adminCrudForm.Show();
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (_product != null)
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
            decimal markup = MarkupNumericUpDown.Value;

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
            var newProduct = new Product
            {
                PaintedModelId = paintedModel.PaintedModelId,
                Markup = markup
            };
            _context.Products.Add(newProduct);
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            _adminCrudForm.RefreshData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_product == null)
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
            decimal markup = MarkupNumericUpDown.Value;

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

            var existingProduct = _context.Products.FirstOrDefault(p => p.PaintedModelId == paintedModel.PaintedModelId && p.Markup == markup);
            if(existingProduct != null)
            {
                MessageBox.Show("Такой продукт уже существует");
            }

            _product.PaintedModelId = paintedModel.PaintedModelId;
            _product.Markup = markup;

            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно обновлены");
            }
            _adminCrudForm.RefreshData();
        }
    }
}
