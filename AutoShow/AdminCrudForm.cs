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
                HeaderLabel.Text = "Страны";
                DataGridView.DataSource = _context.Countries.Select(c => new { c.CountryName }).ToList();
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
                _option == Option.Country)
            {
                var createUpdateAdminForm = new CU_OneField_AdminForm(_context, this, _option);
                createUpdateAdminForm.Show();
            }
            else if(_option == Option.TechnicalInformation)
            {
                var createUpdateAdminForm = new CU_TechnicalInformationForm(_context, this);
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
                string engineLocationName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();
                int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName).BodyTypeId;
                int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName).EngineTypeId;
                int engineDisplacement = int.Parse(DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString());
                int doorsAmount = int.Parse(DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString());
                int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName).EngineLocationId;
                int seatsAmount = int.Parse(DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString());
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
                var technicalInformation = _context.TechnicalInformations.Where(t => t.BodyType.BodyTypeName == bodyTypeName).FirstOrDefault();
                if (technicalInformation != null)
                {
                    MessageBox.Show("Данный тип кузова присутсвует в технической информации,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.BodyTypes.Remove(_context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName));
            }
            else if(_option == Option.EngineLocation)
            {
                string engineLocationName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var technicalInformation = _context.TechnicalInformations.Where(t => t.EngineLocation.EngineLocationName == engineLocationName).FirstOrDefault();
                if (technicalInformation != null)
                {
                    MessageBox.Show("Данное расположения двигателя присутсвует в технической информации,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.EngineLocations.Remove(_context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName));
            }
            else if(_option == Option.EngineType)
            {
                string engineTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                var technicalInformation = _context.TechnicalInformations.Where(t => t.EngineType.EngineTypeName == engineTypeName).FirstOrDefault();
                if (technicalInformation != null)
                {
                    MessageBox.Show("Данный тип двигателя присутсвует в технической информации,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.EngineTypes.Remove(_context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName));
            }
            else if(_option == Option.TechnicalInformation)
            {
                string bodyTypeName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                string engineTypeName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
                string engineLocationName = DataGridView[4, DataGridView.SelectedRows[0].Index].Value.ToString();
                int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName).BodyTypeId;
                int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName).EngineTypeId;
                int engineDisplacement = int.Parse(DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString());
                int doorsAmount = int.Parse(DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString());
                int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName).EngineLocationId;
                int seatsAmount = int.Parse(DataGridView[5, DataGridView.SelectedRows[0].Index].Value.ToString());
                //протестить эту часть
                var carModel = _context.CarModels.Where(c => c.TechnicalInformation.BodyTypeId == bodyTypeId && 
                c.TechnicalInformation.EngineTypeId == engineTypeId && c.TechnicalInformation.EngineDisplacement == engineDisplacement &&
                c.TechnicalInformation.DoorsAmount == doorsAmount && c.TechnicalInformation.EngineLocationId == engineLocationId &&
                c.TechnicalInformation.SeatsAmount == seatsAmount).FirstOrDefault();
                if (carModel != null)
                {
                    MessageBox.Show("Данная техническая информация присутствует в моделях,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.TechnicalInformations.Remove(_context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId &&
                t.EngineDisplacement == engineDisplacement && t.DoorsAmount == doorsAmount && t.EngineLocationId == engineLocationId && t.SeatsAmount == seatsAmount));
            }
            else if(_option == Option.CarBrand)
            {
                string carBrandName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                //и это протестить
                var carModel = _context.CarModels.Where(c => c.CarBrand.CarBrandName == carBrandName).FirstOrDefault();
                if (carModel != null)
                {
                    MessageBox.Show("Данная марка присутсвует в моделях,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.CarBrands.Remove(_context.CarBrands.FirstOrDefault(c => c.CarBrandName == carBrandName));
            }
            else if (_option == Option.Country)
            {
                string countryName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
                //и это протестить
                var carModel = _context.CarModels.Where(c => c.Country.CountryName == countryName).FirstOrDefault();
                if (carModel != null)
                {
                    MessageBox.Show("Данная страна присутсвует в моделях,поэтому для начала удалите все связанные данные");
                    return;
                }
                _context.Countries.Remove(_context.Countries.FirstOrDefault(c => c.CountryName == countryName));
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно удалены");
            }
            RefreshData();
        }
    }
}
