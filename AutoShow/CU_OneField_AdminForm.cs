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
    public partial class CU_OneField_AdminForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly AdminCrudForm _adminCrudForm;
        private readonly BodyType _bodyType;
        private readonly EngineLocation _engineLocation;
        private readonly EngineType _engineType;
        private readonly CarBrand _carBrand;
        private readonly Country _country;
        private readonly Option _option;
        public CU_OneField_AdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option)
        {
            InitializeComponent();
            _context = context;
            _adminCrudForm = adminCrudForm;
            _option = option;
        }
        public CU_OneField_AdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option, in BodyType bodyType)
        :this(context,adminCrudForm,option)
        {
            _bodyType = bodyType;
            TextBox.Text = _bodyType.BodyTypeName;
        }
        public CU_OneField_AdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option, in EngineLocation engineLocation)
        : this(context, adminCrudForm, option)
        {
            _engineLocation = engineLocation;
            TextBox.Text = _engineLocation.EngineLocationName;
        }
        public CU_OneField_AdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option, in EngineType engineType)
        : this(context, adminCrudForm, option)
        {
            _engineType = engineType;
            TextBox.Text = _engineType.EngineTypeName;
        }
        public CU_OneField_AdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option, in CarBrand carBrand)
        : this(context, adminCrudForm, option)
        {
            _carBrand = carBrand;
            TextBox.Text = _carBrand.CarBrandName;
        }
        public CU_OneField_AdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option, in Country country)
        : this(context, adminCrudForm, option)
        {
            _country = country;
            TextBox.Text = _country.CountryName;
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
            if (_bodyType != null || _engineLocation != null || _engineType != null || _carBrand != null || _country != null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            if(string.IsNullOrWhiteSpace(TextBox.Text))
            {
                MessageBox.Show("Заполните поле");
                return;
            }
            if (_option == Option.BodyType)
            {
                string bodyTypeName = TextBox.Text;
                var bodyType = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName);
                if (bodyType != null)
                {
                    MessageBox.Show("Такой тип кузова уже существует");
                    return;
                }
                var newBodyType = new BodyType
                {
                    BodyTypeName = bodyTypeName
                };
                _context.BodyTypes.Add(newBodyType);
            }
            else if(_option == Option.EngineLocation)
            {
                string engineLocationName = TextBox.Text;
                var engineLocation = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName);
                if (engineLocation != null)
                {
                    MessageBox.Show("Такое расположение уже существует");
                    return;
                }
                var newEngineLocation = new EngineLocation
                {
                    EngineLocationName = engineLocationName
                };
                _context.EngineLocations.Add(newEngineLocation);
            }
            else if(_option == Option.EngineType)
            {
                string engineTypeName = TextBox.Text;
                var engineType = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName);
                if (engineType != null)
                {
                    MessageBox.Show("Такой тип двигателя уже существует");
                    return;
                }
                var newEngineType = new EngineType
                {
                    EngineTypeName = engineTypeName
                };
                _context.EngineTypes.Add(newEngineType);
            }
            else if(_option == Option.CarBrand)
            {
                string carBrandName = TextBox.Text;
                var carBrand = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == carBrandName);
                if (carBrand != null)
                {
                    MessageBox.Show("Такая марка уже существует");
                    return;
                }
                var newCarBrand = new CarBrand
                {
                    CarBrandName = carBrandName
                };
                _context.CarBrands.Add(newCarBrand);
            }
            else if (_option == Option.Country)
            {
                string countryName = TextBox.Text;
                var country = _context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                if (country != null)
                {
                    MessageBox.Show("Такая страна уже существует");
                    return;
                }
                var newCountry = new Country
                {
                    CountryName = countryName
                };
                _context.Countries.Add(newCountry);
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            _adminCrudForm.RefreshData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_bodyType == null && _engineLocation == null && _engineType == null && _carBrand == null && _country == null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            if (_option == Option.BodyType)
            {
                var bodyType = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == _bodyType.BodyTypeName);
                var existingTuple = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == TextBox.Text);
                if(existingTuple != null)
                {
                    MessageBox.Show("Такой тип кузова уже существует");
                    return;
                }
                bodyType.BodyTypeName = TextBox.Text;
            }
            else if(_option == Option.EngineLocation)
            {
                var engineLocation = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == _engineLocation.EngineLocationName);
                var existingTuple = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == TextBox.Text);
                if (existingTuple != null)
                {
                    MessageBox.Show("Такой тип кузова уже существует");
                    return;
                }
                engineLocation.EngineLocationName = TextBox.Text;
            }
            else if(_option == Option.EngineType)
            {
                var engineType = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == _engineType.EngineTypeName);
                var existingTuple = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == TextBox.Text);
                if (existingTuple != null)
                {
                    MessageBox.Show("Такой тип кузова уже существует");
                    return;
                }
                engineType.EngineTypeName = TextBox.Text;
            }
            else if (_option == Option.CarBrand)
            {
                var carBrand = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == _carBrand.CarBrandName);
                var existingTuple = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == TextBox.Text);
                if (existingTuple != null)
                {
                    MessageBox.Show("Такой тип кузова уже существует");
                    return;
                }
                carBrand.CarBrandName = TextBox.Text;
            }
            else if (_option == Option.Country)
            {
                var country = _context.Countries.FirstOrDefault(c => c.CountryName == _country.CountryName);
                var existingTuple = _context.Countries.FirstOrDefault(c => c.CountryName == TextBox.Text);
                if (existingTuple != null)
                {
                    MessageBox.Show("Такой тип кузова уже существует");
                    return;
                }
                country.CountryName = TextBox.Text;
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно обновлены");
            }
            _adminCrudForm.RefreshData();
        }
    }
}
