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
            RefreshData();            
        }
        private void RefreshData()
        {
            DataGridView.DataSource = _context.PaintedModels.Select(c => new
            {
                c.Colour.ColourName,
                c.CarModel.CarModelName,
                c.CarModel.CarBrand.CarBrandName,
                c.CarModel.Country.CountryName,
                c.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                c.CarModel.TechnicalInformation.EngineType.EngineTypeName,
                c.CarModel.TechnicalInformation.EnginePower,
                c.CarModel.TechnicalInformation.DoorsAmount,
                c.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                c.CarModel.TechnicalInformation.SeatsAmount
            }).ToList();
        }
        public CU_ProductForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Product product)
        : this(context, adminCrudForm)
        {
            _product = product;
            MarkupNumericUpDown.Value = _product.Markup;
            for (int i = 0; i < DataGridView.Rows.Count; ++i)
            {
                if (_product.PaintedModel.Colour.ColourName == DataGridView[0, i].Value.ToString() &&
                    _product.PaintedModel.CarModel.CarModelName == DataGridView[1, i].Value.ToString() &&
                    _product.PaintedModel.CarModel.CarBrand.CarBrandName == DataGridView[2, i].Value.ToString() &&
                    _product.PaintedModel.CarModel.Country.CountryName == DataGridView[3, i].Value.ToString() &&
                    _product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName == DataGridView[4, i].Value.ToString() &&
                    _product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName == DataGridView[5, i].Value.ToString() &&
                    _product.PaintedModel.CarModel.TechnicalInformation.EnginePower == int.Parse(DataGridView[6, i].Value.ToString()) &&
                    _product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount == int.Parse(DataGridView[7, i].Value.ToString()) &&
                    _product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName == DataGridView[8, i].Value.ToString() &&
                    _product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount == int.Parse(DataGridView[9, i].Value.ToString()))
                {
                    MessageBox.Show($"Вы выбрали окрашенную модель на {i} строке");
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
            if (DataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите окрашенную модель");
                return;
            }
            if (DataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выбрано слишком много кортежей");
                return;
            }
            decimal markup = MarkupNumericUpDown.Value;
            string colourName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
            string carModelName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
            string carBrandName = DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString();
            string countryName = DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString();
            string bodyTypeName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();
            string engineTypeName = DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString();
            int engineDisplacement = int.Parse(DataGridView[6, DataGridView.SelectedRows[0].Index].Value.ToString());
            int doorsAmount = int.Parse(DataGridView[7, DataGridView.SelectedRows[0].Index].Value.ToString());
            string engineLocationName = DataGridView[8, DataGridView.SelectedRows[0].Index].Value.ToString();
            int seatsAmount = int.Parse(DataGridView[9, DataGridView.SelectedRows[0].Index].Value.ToString());

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

            var paintedModel = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModelId && p.ColourId == colourId);

            var product = _context.Products.FirstOrDefault(p => p.PaintedModelId == paintedModel.PaintedModelId);
            if (product != null && product.Markup == markup)
            {
                MessageBox.Show("Такой продукт уже существует");
            }
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
            if (DataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите окрашенную модель");
                return;
            }
            if (DataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выбрано слишком много кортежей");
                return;
            }
            decimal markup = MarkupNumericUpDown.Value;
            string colourName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
            string carModelName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
            string carBrandName = DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString();
            string countryName = DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString();
            string bodyTypeName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();
            string engineTypeName = DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString();
            int engineDisplacement = int.Parse(DataGridView[6, DataGridView.SelectedRows[0].Index].Value.ToString());
            int doorsAmount = int.Parse(DataGridView[7, DataGridView.SelectedRows[0].Index].Value.ToString());
            string engineLocationName = DataGridView[8, DataGridView.SelectedRows[0].Index].Value.ToString();
            int seatsAmount = int.Parse(DataGridView[9, DataGridView.SelectedRows[0].Index].Value.ToString());

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

            var paintedModel = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModelId && p.ColourId == colourId);

            var product = _context.Products.FirstOrDefault(p => p.PaintedModelId == paintedModel.PaintedModelId);
            if (product != null && product.Markup == markup)
            {
                MessageBox.Show("Такой продукт уже существует");
                return;
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
