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
            ColourComboBox.Items.AddRange(_context.Colours.Select(c => c.ColourName).ToArray());
            RefreshData();
        }
        private void RefreshData()
        {
            DataGridView.DataSource = _context.CarModels.Select(c => new
            {
                c.CarModelName,
                c.CarBrand.CarBrandName,
                c.Country.CountryName,
                c.TechnicalInformation.BodyType.BodyTypeName,
                c.TechnicalInformation.EngineType.EngineTypeName,
                c.TechnicalInformation.EnginePower,
                c.TechnicalInformation.DoorsAmount,
                c.TechnicalInformation.EngineLocation.EngineLocationName,
                c.TechnicalInformation.SeatsAmount
            }).ToList();
        }
        public CU_PaintedModelForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in PaintedModel paintedModel)
        : this(context, adminCrudForm)
        {
            _paintedModel = paintedModel;
            ColourComboBox.Text = _paintedModel.Colour.ColourName;
            for(int i = 0; i < DataGridView.Rows.Count; ++i)
            {
                if(_paintedModel.CarModel.CarModelName == DataGridView[0, i].Value.ToString() &&
                    _paintedModel.CarModel.CarBrand.CarBrandName == DataGridView[1, i].Value.ToString() &&
                    _paintedModel.CarModel.Country.CountryName == DataGridView[2, i].Value.ToString() &&
                    _paintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName == DataGridView[3, i].Value.ToString() &&
                    _paintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName == DataGridView[4, i].Value.ToString() &&
                    _paintedModel.CarModel.TechnicalInformation.EnginePower == int.Parse(DataGridView[5, i].Value.ToString()) &&
                    _paintedModel.CarModel.TechnicalInformation.DoorsAmount == int.Parse(DataGridView[6,i].Value.ToString()) &&
                    _paintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName == DataGridView[7, i].Value.ToString() &&
                    _paintedModel.CarModel.TechnicalInformation.SeatsAmount == int.Parse(DataGridView[8, i].Value.ToString()))
                {
                    MessageBox.Show($"Вы выбрали модель на {i} строке");
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
            if (_paintedModel != null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            if (DataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите модель");
                return;
            }
            if (DataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выбрано слишком много кортежей");
                return;
            }

            if (ColourComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            string carModelName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
            string carBrandName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
            string countryName = DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString();
            string bodyTypeName = DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString();
            string engineTypeName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();
            int enginePower = int.Parse(DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString());
            int doorsAmount = int.Parse(DataGridView[6, DataGridView.SelectedRows[0].Index].Value.ToString());
            string engineLocationName = DataGridView[7, DataGridView.SelectedRows[0].Index].Value.ToString();
            int seatsAmount = int.Parse(DataGridView[8, DataGridView.SelectedRows[0].Index].Value.ToString());

            int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName).BodyTypeId;
            int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName).EngineTypeId;
            int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName).EngineLocationId;
            int carBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == carBrandName).CarBrandId;
            int countryId = _context.Countries.FirstOrDefault(c => c.CountryName == countryName).CountryId;
            int colourId = _context.Colours.FirstOrDefault(c => c.ColourName == ColourComboBox.Text).ColourId;

            var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId
            && t.EngineLocationId == engineLocationId && t.DoorsAmount == doorsAmount && t.SeatsAmount == seatsAmount &&
            t.EnginePower == enginePower);

            var carModel = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.CarBrandId == carBrandId &&
            c.CountryId == countryId && c.TechnicalInformationId == technicalInformation.TechnicalInformationId);

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
            if (DataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите модель");
                return;
            }
            if (DataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выбрано слишком много кортежей");
                return;
            }
            if (ColourComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            string carModelName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
            string carBrandName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
            string countryName = DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString();
            string bodyTypeName = DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString();
            string engineTypeName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();
            int engineDisplacement = int.Parse(DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString());
            int doorsAmount = int.Parse(DataGridView[6, DataGridView.SelectedRows[0].Index].Value.ToString());
            string engineLocationName = DataGridView[7, DataGridView.SelectedRows[0].Index].Value.ToString();
            int seatsAmount = int.Parse(DataGridView[8, DataGridView.SelectedRows[0].Index].Value.ToString());

            int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName).BodyTypeId;
            int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName).EngineTypeId;
            int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName).EngineLocationId;
            int carBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == carBrandName).CarBrandId;
            int countryId = _context.Countries.FirstOrDefault(c => c.CountryName == countryName).CountryId;
            int colourId = _context.Colours.FirstOrDefault(c => c.ColourName == ColourComboBox.Text).ColourId;

            var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId
            && t.EngineLocationId == engineLocationId && t.DoorsAmount == doorsAmount && t.SeatsAmount == seatsAmount &&
            t.EnginePower == engineDisplacement);

            var carModel = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.CarBrandId == carBrandId &&
            c.CountryId == countryId && c.TechnicalInformationId == technicalInformation.TechnicalInformationId);

            var paintedModel = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModel.CarModelId && p.ColourId == colourId);

            

            if (paintedModel != null)
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
