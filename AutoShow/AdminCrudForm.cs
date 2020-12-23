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
    public partial class AdminCrudForm : Form
    {
        private readonly AdminMainForm _adminMainForm;
        private readonly AutoShowContext _context;
        private readonly Option _option;
        public AdminCrudForm(in AutoShowContext context, in AdminMainForm adminMainForm, in Option option)
        {
            InitializeComponent();
            _context = context;
            _adminMainForm = adminMainForm;
            _option = option;
            if (_option == Option.BodyType)
            {
                HeaderLabel.Text = "Типы кузова";
                DataGridView.DataSource = _context.BodyTypes.Select(b => new { b.BodyTypeName }).ToList();
            }
            else if(_option == Option.EngineLocation)
            {
                HeaderLabel.Text = "Распол.Двигателя";
                DataGridView.DataSource = _context.EngineLocations.Select(e => new { e.EngineLocationName }).ToList();
            }
            else if(_option == Option.EngineType)
            {
                HeaderLabel.Text = "Типы двигателя";
                DataGridView.DataSource = _context.EngineTypes.Select(e => new { e.EngineTypeName }).ToList();
            }
            else if(_option == Option.TechnicalInformation)
            {
                HeaderLabel.Text = "Тех.Данные";
                DataGridView.DataSource = _context.TechnicalInformations.Select(t => new { t.BodyType.BodyTypeName,
                                                                                           t.EngineType.EngineTypeName,
                                                                                           t.EngineDisplacement,
                                                                                           t.DoorsAmount,
                                                                                           t.EngineLocation.EngineLocationName,
                                                                                           t.SeatsAmount}).ToList();
            }
            else if(_option == Option.CarBrand)
            {
                HeaderLabel.Text = "Марки";
                DataGridView.DataSource = _context.CarBrands.Select(c => new { c.CarBrandName }).ToList();
            }
            else if (_option == Option.Country)
            {
                HeaderLabel.Text = "Страны";
                DataGridView.DataSource = _context.Countries.Select(c => new { c.CountryName }).ToList();
            }
            else if(_option == Option.CarModel)
            {
                HeaderLabel.Text = "Модели";
                DataGridView.DataSource = _context.CarModels.Select(c => new
                {
                    c.CarModelName,
                    c.CarBrand.CarBrandName,
                    c.Country.CountryName,
                    c.TechnicalInformation.BodyType.BodyTypeName,
                    c.TechnicalInformation.EngineType.EngineTypeName,
                    c.TechnicalInformation.EngineDisplacement,
                    c.TechnicalInformation.DoorsAmount,
                    c.TechnicalInformation.EngineLocation.EngineLocationName,
                    c.TechnicalInformation.SeatsAmount
                }).ToList();
            }
            else if(_option == Option.Colour)
            {
                HeaderLabel.Text = "Цвета";
                DataGridView.DataSource = _context.Colours.Select(c => new { c.ColourName }).ToList();
            }
            else if(_option == Option.PaintedModel)
            {
                HeaderLabel.Text = "Окрашенные модели";
                DataGridView.DataSource = _context.PaintedModels.Select(c => new
                {
                    c.Colour.ColourName,
                    c.CarModel.CarModelName,
                    c.CarModel.CarBrand.CarBrandName,
                    c.CarModel.Country.CountryName,
                    c.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                    c.CarModel.TechnicalInformation.EngineType.EngineTypeName,
                    c.CarModel.TechnicalInformation.EngineDisplacement,
                    c.CarModel.TechnicalInformation.DoorsAmount,
                    c.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                    c.CarModel.TechnicalInformation.SeatsAmount
                }).ToList();
            }
            else if(_option == Option.Product)
            {
                HeaderLabel.Text = "Продукты";
                DataGridView.DataSource = _context.Products.Select(p => new
                {
                    p.Markup,
                    p.PaintedModel.Colour.ColourName,
                    p.PaintedModel.CarModel.CarModelName,
                    p.PaintedModel.CarModel.CarBrand.CarBrandName,
                    p.PaintedModel.CarModel.Country.CountryName,
                    p.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                    p.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName,
                    p.PaintedModel.CarModel.TechnicalInformation.EngineDisplacement,
                    p.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
                    p.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                    p.PaintedModel.CarModel.TechnicalInformation.SeatsAmount
                }).ToList();
            }
        }

        public void RefreshData()
        {
            if(_option == Option.BodyType)
            {
                DataGridView.DataSource = _context.BodyTypes.Select(b => new { b.BodyTypeName }).ToList();
            }
            else if(_option == Option.EngineLocation)
            {
                DataGridView.DataSource = _context.EngineLocations.Select(e => new { e.EngineLocationName }).ToList();
            }
            else if(_option == Option.EngineType)
            {
                DataGridView.DataSource = _context.EngineTypes.Select(e => new { e.EngineTypeName }).ToList();
            }
            else if(_option == Option.TechnicalInformation)
            {
                DataGridView.DataSource = _context.TechnicalInformations.Select(t => new {
                    t.BodyType.BodyTypeName,
                    t.EngineType.EngineTypeName,
                    t.EngineDisplacement,
                    t.DoorsAmount,
                    t.EngineLocation.EngineLocationName,
                    t.SeatsAmount
                }).ToList();
            }
            else if (_option == Option.CarBrand)
            {
                DataGridView.DataSource = _context.CarBrands.Select(c => new { c.CarBrandName }).ToList();
            }
            else if (_option == Option.Country)
            {
                DataGridView.DataSource = _context.Countries.Select(c => new { c.CountryName }).ToList();
            }
            else if (_option == Option.CarModel)
            {
                DataGridView.DataSource = _context.CarModels.Select(c => new
                {
                    c.CarModelName,
                    c.CarBrand.CarBrandName,
                    c.Country.CountryName,
                    c.TechnicalInformation.BodyType.BodyTypeName,
                    c.TechnicalInformation.EngineType.EngineTypeName,
                    c.TechnicalInformation.EngineDisplacement,
                    c.TechnicalInformation.DoorsAmount,
                    c.TechnicalInformation.EngineLocation.EngineLocationName,
                    c.TechnicalInformation.SeatsAmount
                }).ToList();
            }
            else if(_option == Option.Colour)
            {
                DataGridView.DataSource = _context.Colours.Select(c => new { c.ColourName }).ToList();
            }
            else if(_option == Option.PaintedModel)
            {
                DataGridView.DataSource = _context.PaintedModels.Select(c => new
                {
                    c.Colour.ColourName,
                    c.CarModel.CarModelName,
                    c.CarModel.CarBrand.CarBrandName,
                    c.CarModel.Country.CountryName,
                    c.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                    c.CarModel.TechnicalInformation.EngineType.EngineTypeName,
                    c.CarModel.TechnicalInformation.EngineDisplacement,
                    c.CarModel.TechnicalInformation.DoorsAmount,
                    c.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                    c.CarModel.TechnicalInformation.SeatsAmount
                }).ToList();
            }
            else if(_option == Option.Product)
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
                    p.PaintedModel.CarModel.TechnicalInformation.EngineDisplacement,
                    p.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
                    p.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                    p.PaintedModel.CarModel.TechnicalInformation.SeatsAmount
                }).ToList();
            }
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _adminMainForm.Show();
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (_option == Option.BodyType || _option == Option.EngineType || _option == Option.EngineLocation || _option == Option.CarBrand ||
                _option == Option.Country || _option == Option.Colour)
            {
                var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.TechnicalInformation)
            {
                var createUpdateAdminForm = new CU_TechnicalInformationForm(_context, this);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.CarModel)
            {
                var createUpdateAdminForm = new CU_CarModelForm(_context, this);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.PaintedModel)
            {
                var createUpdateAdminForm = new CU_PaintedModelForm(_context, this);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.Product)
            {
                var createUpdateAdminForm = new CU_ProductForm(_context, this);
                createUpdateAdminForm.Show();
            }
            this.Hide();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {    
            if (DataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите кортеж");
                return;
            }
            if(DataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выбрано слишком много кортежей");
                return;
            }
            if (_option == Option.BodyType)
            {
                string bodyTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var bodyType = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName);
                var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option, bodyType);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.EngineLocation)
            {
                string engineLocationName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var engineLocation = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName);
                var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option, engineLocation);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.EngineType)
            {
                string engineTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var engineType = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName);
                var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option, engineType);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.TechnicalInformation)
            {
                string bodyTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                string engineTypeName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
                int engineDisplacement = int.Parse(DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString());
                int doorsAmount = int.Parse(DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString());
                string engineLocationName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();
                int seatsAmount = int.Parse(DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString());

                int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName).EngineLocationId;
                int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName).BodyTypeId;
                int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName).EngineTypeId;

                var technicalInforamtion = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId &&
                t.EngineDisplacement == engineDisplacement && t.DoorsAmount == doorsAmount && t.EngineLocationId == engineLocationId && t.SeatsAmount == seatsAmount);

                var createUpdateAdminForm = new CU_TechnicalInformationForm(_context, this, technicalInforamtion);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.CarBrand)
            {
                string carBrandName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var carBrand = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == carBrandName);
                var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option, carBrand);
                createUpdateAdminForm.Show();
            }
            else if (_option == Option.Country)
            {
                string countryName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var country = _context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option, country);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.CarModel)
            {
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

                int technicalInformationId = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId &&
                t.DoorsAmount == doorsAmount && t.EngineDisplacement == engineDisplacement && t.EngineLocationId == engineLocationId &&
                t.EngineTypeId == engineTypeId && t.SeatsAmount == seatsAmount).TechnicalInformationId;

                var carModel = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.TechnicalInformationId == technicalInformationId &&
                c.CountryId == countryId && c.CarBrandId == carBrandId);
                var createUpdateAdminForm = new CU_CarModelForm(_context, this, carModel);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.Colour)
            {
                string colourName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var colour = _context.Colours.FirstOrDefault(c => c.ColourName == colourName);
                var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option, colour);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.PaintedModel)
            {
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
                t.DoorsAmount == doorsAmount && t.EngineDisplacement == engineDisplacement && t.EngineLocationId == engineLocationId &&
                t.EngineTypeId == engineTypeId && t.SeatsAmount == seatsAmount).TechnicalInformationId;

                int colourId = _context.Colours.FirstOrDefault(c => c.ColourName == colourName).ColourId;

                int carModelId = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.CarBrandId == c.CarBrandId &&
                c.CountryId == countryId && c.TechnicalInformationId == technicalInformationId).CarModelId;

                var paintedModel = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModelId && p.ColourId == colourId);
                
                var createUpdateAdminForm = new CU_PaintedModelForm(_context, this, paintedModel);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.Product)
            {
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

                int technicalInformationId = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId &&
                t.DoorsAmount == doorsAmount && t.EngineDisplacement == engineDisplacement && t.EngineLocationId == engineLocationId &&
                t.EngineTypeId == engineTypeId && t.SeatsAmount == seatsAmount).TechnicalInformationId;

                int colourId = _context.Colours.FirstOrDefault(c => c.ColourName == colourName).ColourId;

                int carModelId = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.CarBrandId == c.CarBrandId &&
                c.CountryId == countryId && c.TechnicalInformationId == technicalInformationId).CarModelId;

                int paintedModelId = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModelId && p.ColourId == colourId).PaintedModelId;

                var product = _context.Products.FirstOrDefault(p => p.PaintedModelId == paintedModelId);

                var createUpdateAdminForm = new CU_ProductForm(_context, this, product);
                createUpdateAdminForm.Show();
            }
            this.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
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
            if (_option == Option.BodyType)
            {
                string bodyTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var bodyType = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName);
                var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyType.BodyTypeId);
                if (technicalInformation != null)
                {
                    MessageBox.Show("Данный тип кузова присутсвует в технической информации,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.BodyTypes.Remove(bodyType);
            }
            else if(_option == Option.EngineLocation)
            {
                string engineLocationName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var engineLocation = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName);
                var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.EngineLocationId == engineLocation.EngineLocationId);
                if (technicalInformation != null)
                {
                    MessageBox.Show("Данное расположения двигателя присутсвует в технической информации,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.EngineLocations.Remove(engineLocation);
            }
            else if(_option == Option.EngineType)
            {
                string engineTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var engineType = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName);
                var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.EngineTypeId == engineType.EngineTypeId);
                if (technicalInformation != null)
                {
                    MessageBox.Show("Данный тип двигателя присутсвует в технической информации,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.EngineTypes.Remove(engineType);
            }
            else if(_option == Option.TechnicalInformation)
            {
                string bodyTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                string engineTypeName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
                string engineLocationName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();      
                int engineDisplacement = int.Parse(DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString());
                int doorsAmount = int.Parse(DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString());
                int seatsAmount = int.Parse(DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString());
                
                int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName).BodyTypeId;
                int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName).EngineTypeId;
                int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName).EngineLocationId;
               
                var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId && t.EngineDisplacement == engineDisplacement &&
                t.DoorsAmount == doorsAmount && t.EngineLocationId == engineLocationId && t.SeatsAmount == seatsAmount);
                var carModel = _context.CarModels.FirstOrDefault(c => c.TechnicalInformationId == technicalInformation.TechnicalInformationId);
                if (carModel != null)
                {
                    MessageBox.Show("Данная техническая информация присутствует в моделях,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.TechnicalInformations.Remove(technicalInformation);
            }
            else if(_option == Option.CarBrand)
            {
                string carBrandName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var carBrand = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == carBrandName);
                var carModel = _context.CarModels.FirstOrDefault(c => c.CarBrandId == carBrand.CarBrandId);
                if (carModel != null)
                {
                    MessageBox.Show("Данная марка присутсвует в моделях,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.CarBrands.Remove(carBrand);
            }
            else if (_option == Option.Country)
            {
                string countryName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var country = _context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                var carModel = _context.CarModels.FirstOrDefault(c => c.CountryId == country.CountryId);
                if (carModel != null)
                {
                    MessageBox.Show("Данная страна присутсвует в моделях,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.Countries.Remove(country);
            }
            else if(_option == Option.CarModel)
            {
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

                int technicalInformationId = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId &&
                t.DoorsAmount == doorsAmount && t.EngineDisplacement == engineDisplacement && t.EngineLocationId == engineLocationId &&
                t.EngineTypeId == engineTypeId && t.SeatsAmount == seatsAmount).TechnicalInformationId;

                var carModel = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.TechnicalInformationId == technicalInformationId &&
                c.CountryId == countryId && c.CarBrandId == carBrandId);
                //и это протестить
                var paintedModel = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModel.CarModelId);
                if (paintedModel != null)
                {
                    MessageBox.Show("Данная модель присутсвует в окрашеных моделях,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.CarModels.Remove(carModel);
            }
            else if(_option == Option.Colour)
            {
                string colourName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var colour = _context.Colours.FirstOrDefault(c => c.ColourName == colourName);
                var paintedModel = _context.PaintedModels.FirstOrDefault(p => p.ColourId == colour.ColourId);
                if (paintedModel != null)
                {
                    MessageBox.Show("Данный цвет присутсвует в окрашенных моделях, поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.Colours.Remove(colour);
            }
            else if(_option == Option.PaintedModel)
            {
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
                t.DoorsAmount == doorsAmount && t.EngineDisplacement == engineDisplacement && t.EngineLocationId == engineLocationId &&
                t.EngineTypeId == engineTypeId && t.SeatsAmount == seatsAmount).TechnicalInformationId;

                int colourId = _context.Colours.FirstOrDefault(c => c.ColourName == colourName).ColourId;

                int carModelId = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.CarBrandId == c.CarBrandId &&
                c.CountryId == countryId && c.TechnicalInformationId == technicalInformationId).CarModelId;

                var paintedModel = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModelId && p.ColourId == colourId);

                var product = _context.Products.FirstOrDefault(p => p.PaintedModelId == paintedModel.PaintedModelId);
                if (product != null)
                {
                    MessageBox.Show("Данная окрашенная модель присутсвуте в продуктах,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.PaintedModels.Remove(paintedModel);
            }
            else if(_option == Option.Product)
            {
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

                int technicalInformationId = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId &&
                t.DoorsAmount == doorsAmount && t.EngineDisplacement == engineDisplacement && t.EngineLocationId == engineLocationId &&
                t.EngineTypeId == engineTypeId && t.SeatsAmount == seatsAmount).TechnicalInformationId;

                int colourId = _context.Colours.FirstOrDefault(c => c.ColourName == colourName).ColourId;

                int carModelId = _context.CarModels.FirstOrDefault(c => c.CarModelName == carModelName && c.CarBrandId == c.CarBrandId &&
                c.CountryId == countryId && c.TechnicalInformationId == technicalInformationId).CarModelId;

                var paintedModelId = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModelId && p.ColourId == colourId).PaintedModelId;

                var product = _context.Products.FirstOrDefault(p => p.PaintedModelId == paintedModelId);

                var warehouse = _context.Warehouses.FirstOrDefault(w => w.ProductId == product.ProductId);
                if (warehouse != null)
                {
                    MessageBox.Show("Данный продукт есть на складе,поэтому для начала удалите все связанные данные");
                    return;
                }

                var purchase = _context.Purchases.FirstOrDefault(p => p.ProductId == product.ProductId);
                if (purchase != null)
                {
                    MessageBox.Show("Данный продукт есть в сделках,поэтому для начала удалите все связанные данные");
                    return;
                }

                var supply = _context.Supplies.FirstOrDefault(s => s.ProductId == product.ProductId);
                if (supply != null)
                {
                    MessageBox.Show("Данный продукт есть в поставках,поэтому для начала удалите все связанные данные");
                    return;
                }

                _context.Products.Remove(product);
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно удалены");
            }
            RefreshData();
        }
    }
}
