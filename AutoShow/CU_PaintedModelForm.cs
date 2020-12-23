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
    public partial class CU_PaintedModelForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly AdminCrudForm _adminCrudForm;
        private readonly PaintedModel _paintedModel;
        public CU_PaintedModelForm(in AutoShowContext context, in AdminCrudForm adminCrudForm)
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
        public CU_PaintedModelForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in PaintedModel paintedModel)
        : this(context, adminCrudForm)
        {
            _paintedModel = paintedModel;
            ColourComboBox.Text = _paintedModel.Colour.ColourName;
            BodyTypeComboBox.Text = _paintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName;
            EngineTypeComboBox.Text = _paintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName;
            EngineLocationComboBox.Text = _paintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName;
            CarBrandComboBox.Text = _paintedModel.CarModel.CarBrand.CarBrandName;
            CountryComboBox.Text = _paintedModel.CarModel.Country.CountryName;
            CarModelNameTextBox.Text = _paintedModel.CarModel.CarModelName;
            DoorsAmountNumericUpDown.Value = _paintedModel.CarModel.TechnicalInformation.DoorsAmount;
            SeatsAmountNumericUpDown.Value = _paintedModel.CarModel.TechnicalInformation.SeatsAmount;
            EngineDisplacementNumericUpDown.Value = _paintedModel.CarModel.TechnicalInformation.EngineDisplacement;
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
            if (_paintedModel != null)
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

            if (paintedModel != null)
            {
                MessageBox.Show("Такая окрашенная модель уже существует");
                return;
            }
            var newPaintedModel = new PaintedModel
            {
                CarModelId = carModel.CarModelId,
                ColourId = colourId
            };
            _context.PaintedModels.Add(newPaintedModel);
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            _adminCrudForm.RefreshData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_paintedModel == null)
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

            var existingPaintedModel = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModel.CarModelId && p.ColourId == colourId);

            if (existingPaintedModel != null)
            {
                MessageBox.Show("Такая окрашенная модель уже существует");
                return;
            }

            _paintedModel.CarModelId = carModel.CarModelId;
            _paintedModel.ColourId = colourId;

            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно обновлены");
            }
            _adminCrudForm.RefreshData();
        }
    }
}
