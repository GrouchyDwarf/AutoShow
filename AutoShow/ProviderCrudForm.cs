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

namespace AutoShow
{
    public partial class ProviderCrudForm : Form
    {
        private readonly StartForm _startForm;
        private readonly AutoShowContext _context;
        private readonly string _firstName;
        private readonly string _lastName;
        public ProviderCrudForm(in string firstName, in string lastName, StartForm startForm, in AutoShowContext context)
        {
            InitializeComponent();
            _firstName = firstName;
            _lastName = lastName;
            ProviderInfoLabel.Text = "Вы вошли как поставщик: " + _firstName + " " + _lastName;
            _startForm = startForm;
            _context = context;

            DataGridView.DataSource = _context.Supplies.Select(s => new
            {
                s.Provider.FirstName,
                s.Provider.LastName,
                s.SupplyDate,
                s.Quantity,
                s.Price,
                s.Product.Markup,
                s.Product.PaintedModel.Colour.ColourName,
                s.Product.PaintedModel.CarModel.CarModelName,
                s.Product.PaintedModel.CarModel.CarBrand.CarBrandName,
                s.Product.PaintedModel.CarModel.Country.CountryName,
                s.Product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                s.Product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName,
                s.Product.PaintedModel.CarModel.TechnicalInformation.EnginePower,
                s.Product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
                s.Product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                s.Product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount
            }).ToList();
        }

        public void RefreshData()
        {
            DataGridView.DataSource = _context.Supplies.Select(s => new
            {
                s.Provider.FirstName,
                s.Provider.LastName,
                s.SupplyDate,
                s.Quantity,
                s.Price,
                s.Product.Markup,
                s.Product.PaintedModel.Colour.ColourName,
                s.Product.PaintedModel.CarModel.CarModelName,
                s.Product.PaintedModel.CarModel.CarBrand.CarBrandName,
                s.Product.PaintedModel.CarModel.Country.CountryName,
                s.Product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                s.Product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName,
                s.Product.PaintedModel.CarModel.TechnicalInformation.EnginePower,
                s.Product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
                s.Product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                s.Product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount
            }).ToList();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _startForm.Show();
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var provider = _context.Providers.FirstOrDefault(p => p.FirstName == _firstName && p.LastName == _lastName);
            var createUpdateAdminForm = new CU_SupplyForm(_context, this, provider);
            createUpdateAdminForm.Show();
            this.Hide();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
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
            string firstName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
            string lastName= DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
            DateTime supplyDate = DateTime.Parse(DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString());

            var provider = _context.Providers.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);

            var supply = _context.Supplies.FirstOrDefault(s => s.ProviderId == provider.ProviderId && s.SupplyDate == supplyDate);

            var createUpdateAdminForm = new CU_SupplyForm(_context, this, supply);
            createUpdateAdminForm.Show();
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

            string firstName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
            string lastName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
            DateTime supplyDate = DateTime.Parse(DataGridView[2, DataGridView.SelectedRows[0].Index].Value.ToString());

            var provider = _context.Providers.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);

            var supply = _context.Supplies.FirstOrDefault(s => s.ProviderId == provider.ProviderId && s.SupplyDate == supplyDate);

            _context.Supplies.Remove(supply);

            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно удалены");
            }
            RefreshData();
        }
    }
}
