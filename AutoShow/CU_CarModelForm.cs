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
            CarBrandComboBox.Items.AddRange(_context.CarBrands.Select(c => c.CarBrandName).ToArray());
            CountryComboBox.Items.AddRange(_context.Countries.Select(c => c.CountryName).ToArray());
            RefreshData();
        }

        private void RefreshData()
        {
            DataGridView.DataSource = _context.TechnicalInformations.Select(t => new {
                t.BodyType.BodyTypeName,
                t.EngineType.EngineTypeName,
                t.EnginePower,
                t.DoorsAmount,
                t.EngineLocation.EngineLocationName,
                t.SeatsAmount
            }).ToList();
        }
        public CU_CarModelForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in CarModel carModel)
        : this(context, adminCrudForm)
        {
            _carModel = carModel;
            CarBrandComboBox.Text = carModel.CarBrand.CarBrandName;
            CountryComboBox.Text = carModel.Country.CountryName;
            CarModelNameTextBox.Text = carModel.CarModelName;
            for (int i = 0; i < DataGridView.Rows.Count; ++i)
            {
                if (_carModel.TechnicalInformation.BodyType.BodyTypeName == DataGridView[0, i].Value.ToString() &&
                    _carModel.TechnicalInformation.EngineType.EngineTypeName == DataGridView[1, i].Value.ToString() &&
                    _carModel.TechnicalInformation.EngineLocation.EngineLocationName == DataGridView[4, i].Value.ToString() &&
                    _carModel.TechnicalInformation.DoorsAmount == int.Parse(DataGridView[3, i].Value.ToString()) &&
                    _carModel.TechnicalInformation.EnginePower == int.Parse(DataGridView[2, i].Value.ToString()) &&
                    _carModel.TechnicalInformation.SeatsAmount == int.Parse(DataGridView[5, i].Value.ToString()))
                {
                    MessageBox.Show($"Вы выбрали тех.данные на {i} строке");
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
            if (_carModel != null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            if (DataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите тех. данные");
                return;
            }
            if (DataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выбрано слишком много кортежей");
                return;
            }
            if (string.IsNullOrWhiteSpace(CarModelNameTextBox.Text) || CarBrandComboBox.SelectedItem == null ||
                CountryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            string bodyTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
            string engineTypeName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
            string engineLocationName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();

            int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName).BodyTypeId;
            int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName).EngineTypeId;
            int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName).EngineLocationId;
            int doorsAmount = int.Parse(DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString());
            int seatsAmount = int.Parse(DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString());
            int enginePower = int.Parse(DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString());
            string carModelName = CarModelNameTextBox.Text;
            int carBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == CarBrandComboBox.Text).CarBrandId;
            int countryId = _context.Countries.FirstOrDefault(c => c.CountryName == CountryComboBox.Text).CountryId;

            var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId
            && t.EngineLocationId == engineLocationId && t.DoorsAmount == doorsAmount && t.SeatsAmount == seatsAmount && t.EnginePower == enginePower);
            
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
            if (DataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите тех. данные");
                return;
            }
            if (DataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выбрано слишком много кортежей");
                return;
            }
            if (string.IsNullOrWhiteSpace(CarModelNameTextBox.Text) || CarBrandComboBox.SelectedItem == null ||
                CountryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            string bodyTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
            string engineTypeName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
            string engineLocationName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();

            int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName).BodyTypeId;
            int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName).EngineTypeId;
            int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName).EngineLocationId;
            int doorsAmount = int.Parse(DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString());
            int seatsAmount = int.Parse(DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString());
            int engineDisplacement = int.Parse(DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString());
            string carModelName = CarModelNameTextBox.Text;
            int carBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == CarBrandComboBox.Text).CarBrandId;
            int countryId = _context.Countries.FirstOrDefault(c => c.CountryName == CountryComboBox.Text).CountryId;

            var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId
            && t.EngineLocationId == engineLocationId && t.DoorsAmount == doorsAmount && t.SeatsAmount == seatsAmount && t.EnginePower == engineDisplacement);

            var carModel = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.TechnicalInformationId == technicalInformation.TechnicalInformationId &&
            c.CarBrandId == carBrandId && c.CountryId == countryId);
            if (carModel != null)
            {
                MessageBox.Show("Такая модель уже существует");
                return;
            }

            _carModel.CarModelName = carModelName;
            _carModel.CarBrandId = carBrandId;
            _carModel.CountryId = countryId;
            _carModel.TechnicalInformationId = technicalInformation.TechnicalInformationId;

            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно обновлены");
            }
            _adminCrudForm.RefreshData();
        }
    }
}
