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
    public partial class PurchasesForm : Form
    {
        private readonly ManagerCrudForm _managerCrudForm;
        private readonly AutoShowContext _context;
        public PurchasesForm(in AutoShowContext context, in ManagerCrudForm managerCrudForm)
        {
            InitializeComponent();
            _managerCrudForm = managerCrudForm;
            _context = context;
            CarBrandComboBox.Items.AddRange(_context.CarBrands.Select(b => b.CarBrandName).ToArray());
            RefreshData();
        }

        private void RefreshData()
        {
            DataGridView.DataSource = _context.Purchases.Select(p => new
            {
                ClientFirstName = p.Client.FirstName,
                ClientLastName = p.Client.LastName,
                p.Price,
                p.PurchaseDate,
                p.PaymentDate,
                p.Delivery,
                ManagerFirstName = p.Manager.FirstName,
                ManagerLastName = p.Manager.LastName,
                p.PaymentType.PaymentTypeName,
                p.Product.Markup,
                p.Product.PaintedModel.Colour.ColourName,
                p.Product.PaintedModel.CarModel.CarModelName,
                p.Product.PaintedModel.CarModel.CarBrand.CarBrandName,
                p.Product.PaintedModel.CarModel.Country.CountryName,
                p.Product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                p.Product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName,
                p.Product.PaintedModel.CarModel.TechnicalInformation.EnginePower,
                p.Product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
                p.Product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                p.Product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount
            }).Where(p => (p.PurchaseDate.Year >= FromDateTimePicker.Value.Year && p.PurchaseDate.Month >= FromDateTimePicker.Value.Month &&
                     p.PurchaseDate.Day >= FromDateTimePicker.Value.Day) && (p.PurchaseDate.Year <= ToDateTimePicker.Value.Year &&
                     p.PurchaseDate.Month <= ToDateTimePicker.Value.Month && p.PurchaseDate.Day <= ToDateTimePicker.Value.Day) &&
                     (CarBrandComboBox.SelectedItem == null || p.CarBrandName == CarBrandComboBox.Text) &&
                     (CarModelComboBox.SelectedItem == null || p.CarModelName == CarModelComboBox.Text)).ToList();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _managerCrudForm.Show();
            this.Close();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void CarBrandComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            CarModelComboBox.Items.Clear();
            CarModelComboBox.Text = "";
            string carBrandName = CarBrandComboBox.Text;
            int carBrandId = _context.CarBrands.FirstOrDefault(c => c.CarBrandName == carBrandName).CarBrandId;
            var modelsName = _context.CarModels.Where(c => c.CarBrandId == carBrandId).Select(c => c.CarModelName);
            CarModelComboBox.Items.AddRange(modelsName.ToArray());
        }
        public class GroupSumer
        {
            public readonly string _groupName;
            public readonly decimal _sum;

            public string GroupName => _groupName;
            public decimal Sum => _sum;
            public GroupSumer(string groupName, decimal sum)
            {
                _groupName = groupName;
                _sum = sum;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
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
                DateTime purchaseDate = DateTime.Parse(DataGridView[3, DataGridView.SelectedRows[0].Index].Value.ToString());
                decimal markup = decimal.Parse(DataGridView[9, DataGridView.SelectedRows[0].Index].Value.ToString());
                string colourName = DataGridView[10, DataGridView.SelectedRows[0].Index].Value.ToString();
                string carModelName = DataGridView[11, DataGridView.SelectedRows[0].Index].Value.ToString();
                string carBrandName = DataGridView[12, DataGridView.SelectedRows[0].Index].Value.ToString();
                string countryName = DataGridView[13, DataGridView.SelectedRows[0].Index].Value.ToString();
                string bodyTypeName = DataGridView[14, DataGridView.SelectedRows[0].Index].Value.ToString();
                string engineTypeName = DataGridView[15, DataGridView.SelectedRows[0].Index].Value.ToString();
                int engineDisplacement = int.Parse(DataGridView[16, DataGridView.SelectedRows[0].Index].Value.ToString());
                int doorsAmount = int.Parse(DataGridView[17, DataGridView.SelectedRows[0].Index].Value.ToString());
                string engineLocationName = DataGridView[18, DataGridView.SelectedRows[0].Index].Value.ToString();
                int seatsAmount = int.Parse(DataGridView[19, DataGridView.SelectedRows[0].Index].Value.ToString());

                var client = _context.Clients.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

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

                int paintedModelId = _context.PaintedModels.FirstOrDefault(p => p.CarModelId == carModelId && p.ColourId == colourId).PaintedModelId;

                var product = _context.Products.FirstOrDefault(p => p.PaintedModelId == paintedModelId);

                var purchase = _context.Purchases.FirstOrDefault(p => p.ClientId == client.ClientId && p.PurchaseDate == purchaseDate &&
                p.ProductId == product.ProductId);

                _context.Purchases.Remove(purchase);

                if (_context.SaveChanges() > 0)
                {
                    MessageBox.Show("Данные успешно удалены");
                }
                RefreshData();
            }
        }
    }
}
