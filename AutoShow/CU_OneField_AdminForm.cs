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
        private readonly Colour _colour;
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
        public CU_OneField_AdminForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in Option option, in Colour colour)
        : this(context, adminCrudForm, option)
        {
            _colour = colour;
            TextBox.Text = _colour.ColourName;
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
            if (_bodyType != null || _engineLocation != null || _engineType != null || _carBrand != null || _country != null || _colour != null)
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
                    MessageBox.Show("Такое расположение двигателя уже существует");
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
            else if(_option == Option.Colour)
            {
                string colourName = TextBox.Text;
                var colour = _context.Colours.FirstOrDefault(c => c.ColourName == colourName);
                if (colour != null)
                {
                    MessageBox.Show("Такой цвет уже существует");
                    return;
                }
                var newColour = new Colour
                {
                    ColourName = colourName
                };
                _context.Colours.Add(newColour);
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            _adminCrudForm.RefreshData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_bodyType == null && _engineLocation == null && _engineType == null && _carBrand == null && _country == null && _colour == null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            if (_option == Option.BodyType)
            {
                string bodyTypeName = TextBox.Text;
                var existingBodyType = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == bodyTypeName);
                if (existingBodyType != null)
                {
                    MessageBox.Show("Такой тип кузова уже существует");
                    return;
                }
                _bodyType.BodyTypeName = TextBox.Text;
            }
            else if(_option == Option.EngineLocation)
            {
                string engineLocationName = TextBox.Text;
                var existingEngineLocation = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == engineLocationName);
                if (existingEngineLocation != null)
                {
                    MessageBox.Show("Такое расположение двигателя уже существует");
                    return;
                }
                _engineLocation.EngineLocationName = TextBox.Text;
            }
            else if(_option == Option.EngineType)
            {
                string engineTypeName = TextBox.Text;
                var existingEngineType = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == engineTypeName);
                if (existingEngineType != null)
                {
                    MessageBox.Show("Такой тип двигателя уже существует");
                    return;
                }
                _engineType.EngineTypeName = TextBox.Text;
            }
            else if (_option == Option.CarBrand)
            {
                string carBrandName = TextBox.Text;
                var existingCarBrand = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == carBrandName);
                if (existingCarBrand != null)
                {
                    MessageBox.Show("Такая марка уже существует");
                    return;
                }
                _carBrand.CarBrandName = TextBox.Text;
            }
            else if (_option == Option.Country)
            {
                string countryName = TextBox.Text;
                var existingCountry = _context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                if (existingCountry != null)
                {
                    MessageBox.Show("Такая страна уже существует");
                    return;
                }
                _country.CountryName = TextBox.Text;
            }
            else if(_option == Option.Colour)
            {
                string colourName = TextBox.Text;
                var existingColour = _context.Colours.FirstOrDefault(c => c.ColourName == colourName);
                if (existingColour != null)
                {
                    MessageBox.Show("Такой цвет уже существует");
                    return;
                }
                _colour.ColourName = TextBox.Text;
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно обновлены");
            }
            _adminCrudForm.RefreshData();
        }
    }
}
