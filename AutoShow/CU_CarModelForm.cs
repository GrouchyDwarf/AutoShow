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
    public partial class CU_CarModelForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly AdminCrudForm _adminCrudForm;
        private readonly CarModel _carModel;
        public CU_CarModelForm(in AutoShowContext context, in AdminCrudForm adminCrudForm)
        {
            InitializeComponent();
            _context = context;
            _adminCrudForm = adminCrudForm;
            BodyTypeComboBox.Items.AddRange(_context.BodyTypes.Select(b => b.BodyTypeName).ToArray());
            EngineTypeComboBox.Items.AddRange(_context.EngineTypes.Select(en => en.EngineTypeName).ToArray());
            EngineLocationComboBox.Items.AddRange(_context.EngineLocations.Select(en => en.EngineLocationName).ToArray());
            CarBrandComboBox.Items.AddRange(_context.CarBrands.Select(c => c.CarBrandName).ToArray());
            CountryComboBox.Items.AddRange(_context.Countries.Select(c => c.CountryName).ToArray());
        }
        public CU_CarModelForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in CarModel carModel)
        :this(context,adminCrudForm)
        {
            _carModel = carModel;
            BodyTypeComboBox.Text = carModel.TechnicalInformation.BodyType.BodyTypeName;
            EngineTypeComboBox.Text = carModel.TechnicalInformation.EngineType.EngineTypeName;
            EngineLocationComboBox.Text = carModel.TechnicalInformation.EngineLocation.EngineLocationName;
            CarBrandComboBox.Text = carModel.CarBrand.CarBrandName;
            CountryComboBox.Text = carModel.Country.CountryName;
            CarModelNameTextBox.Text = carModel.CarModelName;
            DoorsAmountNumericUpDown.Value = carModel.TechnicalInformation.DoorsAmount;
            SeatsAmountNumericUpDown.Value = carModel.TechnicalInformation.SeatsAmount;
            EngineDisplacementNumericUpDown.Value = carModel.TechnicalInformation.EngineDisplacement;
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
            if (_carModel != null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            if (string.IsNullOrWhiteSpace(CarModelNameTextBox.Text)|| BodyTypeComboBox.SelectedItem == null || EngineLocationComboBox.SelectedItem == null ||
                EngineTypeComboBox.SelectedItem == null || CarBrandComboBox.SelectedItem == null || CountryComboBox.SelectedItem == null)
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

            var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId
            && t.EngineLocationId == engineLocationId && t.DoorsAmount == doorsAmount && t.SeatsAmount == seatsAmount && t.EngineDisplacement == engineDisplacement);
            if(technicalInformation == null)
            {
                MessageBox.Show("Таких тех.данных нет");
                return;
            }
            string carModelName = CarModelNameTextBox.Text;
            int carBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == CarBrandComboBox.Text).CarBrandId;
            int countryId = _context.Countries.FirstOrDefault(c => c.CountryName == CountryComboBox.Text).CountryId;
            var carModel = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.TechnicalInformationId == technicalInformation.TechnicalInformationId &&
            c.CarBrandId == carBrandId && c.CountryId == countryId);
            if (carModel != null)
            {
                MessageBox.Show("Такая модель уже существует");
                return;
            }
            var newCarModel = new CarModel
            {
                CarModelName = carModelName,
                TechnicalInformationId = technicalInformation.TechnicalInformationId,
                CarBrandId = carBrandId,
                CountryId = countryId
        };
            _context.CarModels.Add(newCarModel);
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            _adminCrudForm.RefreshData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_carModel == null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            var carModel = _context.CarModels.FirstOrDefault(c => c.CarModelName == _carModel.CarModelName &&
            c.TechnicalInformationId == _carModel.TechnicalInformationId && c.CarBrandId == _carModel.CarBrandId && c.CountryId == _carModel.CountryId);


            var existingTI = _context.TechnicalInformations.FirstOrDefault(t => t.BodyType.BodyTypeName == BodyTypeComboBox.Text &&
            t.DoorsAmount == (int)DoorsAmountNumericUpDown.Value && t.EngineDisplacement == (int)EngineDisplacementNumericUpDown.Value &&
            t.EngineLocation.EngineLocationName == EngineLocationComboBox.Text && t.EngineType.EngineTypeName == EngineTypeComboBox.Text &&
            t.SeatsAmount == (int)SeatsAmountNumericUpDown.Value);
            if(existingTI == null)
            {
                MessageBox.Show("Таких тех данных нет");
                return;
            }
            var existingTuple = _context.CarModels.FirstOrDefault(c => c.CarModelName == CarModelNameTextBox.Text && c.TechnicalInformationId == existingTI.TechnicalInformationId
            && c.Country.CountryName == CountryComboBox.Text && c.CarBrand.CarBrandName == CarBrandComboBox.Text);
            if (existingTuple != null)
            {
                MessageBox.Show("Такие тех данные уже существуют");
                return;
            }

            carModel.CarModelName = CarModelNameTextBox.Text;
            carModel.TechnicalInformationId = existingTI.TechnicalInformationId;
            carModel.CountryId = _context.Countries.FirstOrDefault(c => c.CountryName == CountryComboBox.Text).CountryId;
            carModel.CarBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == CarBrandComboBox.Text).CarBrandId;

            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно обновлены");
            }
            _adminCrudForm.RefreshData();
        }
    }
}
