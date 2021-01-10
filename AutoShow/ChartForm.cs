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
    public partial class ChartForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly ManagerCrudForm _managerCrudForm;
        public ChartForm(in AutoShowContext context, in ManagerCrudForm managerCrudForm)
        {
            InitializeComponent();
            _context = context;
            _managerCrudForm = managerCrudForm;

            ModelChart.Titles.Add("Сумма");
            BrandChart.Titles.Add("Сумма");
            ClientChart.Titles.Add("Сумма");
            RefreshData();
        }

        private void RefreshData()
        {
            ModelChart.Series["Покупки"].Points.Clear();
            BrandChart.Series["Покупки"].Points.Clear();
            ClientChart.Series["Покупки"].Points.Clear();
            var models = _context.Purchases.Where(p =>
            (p.PurchaseDate.Year >= FromDateTimePicker.Value.Year &&
             p.PurchaseDate.Month >= FromDateTimePicker.Value.Month &&
             p.PurchaseDate.Day >= FromDateTimePicker.Value.Day) &&
            (p.PurchaseDate.Year <= ToDateTimePicker.Value.Year &&
             p.PurchaseDate.Month <= ToDateTimePicker.Value.Month &&
             p.PurchaseDate.Day <= ToDateTimePicker.Value.Day)).GroupBy(p =>
           new {
               p.Product.PaintedModel.CarModel.CarModelName,
               p.Product.PaintedModel.CarModel.Country.CountryName,
               p.Product.PaintedModel.CarModel.CarBrand.CarBrandName,
               p.Product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName,
               p.Product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
               p.Product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
               p.Product.PaintedModel.CarModel.TechnicalInformation.EnginePower,
               p.Product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount,
               p.Product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName
           }).Select(p =>
           new
           {
               Model = p.Key.CarModelName,
               Sum = p.Sum(s => s.Price),
           }).ToList();

            var brands = _context.Purchases.Where(p =>
            (p.PurchaseDate.Year >= FromDateTimePicker.Value.Year &&
             p.PurchaseDate.Month >= FromDateTimePicker.Value.Month &&
             p.PurchaseDate.Day >= FromDateTimePicker.Value.Day) &&
            (p.PurchaseDate.Year <= ToDateTimePicker.Value.Year &&
             p.PurchaseDate.Month <= ToDateTimePicker.Value.Month &&
             p.PurchaseDate.Day <= ToDateTimePicker.Value.Day)).GroupBy(p => p.Product.PaintedModel.CarModel.CarBrand.CarBrandName).Select(p =>
             new
             {
                 Brand = p.Key,
                 Sum = p.Sum(s => s.Price),
             }).ToList();

            var clients = _context.Purchases.Where(p =>
            (p.PurchaseDate.Year >= FromDateTimePicker.Value.Year &&
             p.PurchaseDate.Month >= FromDateTimePicker.Value.Month &&
             p.PurchaseDate.Day >= FromDateTimePicker.Value.Day) &&
            (p.PurchaseDate.Year <= ToDateTimePicker.Value.Year &&
             p.PurchaseDate.Month <= ToDateTimePicker.Value.Month &&
             p.PurchaseDate.Day <= ToDateTimePicker.Value.Day)).GroupBy(p => new { p.Client.FirstName, p.Client.LastName }).Select(p =>
             new
             {
                 FirstName = p.Key.FirstName,
                 LastName = p.Key.LastName,
                 Sum = p.Sum(s => s.Price),
             }).ToList();

            ModelChart.Series["Покупки"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            foreach (var model in models)
            {
                ModelChart.Series["Покупки"].Points.AddXY(model.Model, model.Sum);
            }
            foreach (var brand in brands)
            {
                BrandChart.Series["Покупки"].Points.AddXY(brand.Brand, brand.Sum);
            }
            foreach (var client in clients)
            {
                ClientChart.Series["Покупки"].Points.AddXY(client.FirstName + " " + client.LastName, client.Sum);
            }
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
    }
}
