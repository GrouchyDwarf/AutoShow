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
    public partial class StatisticsForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly ManagerCrudForm _managerCrudForm;
        public StatisticsForm(in AutoShowContext context, in ManagerCrudForm managerCrudForm)
        {
            InitializeComponent();
            _context = context;
            _managerCrudForm = managerCrudForm;
            RefreshData();
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

        private void RefreshData()
        {
            CarModelDataGridView.DataSource = _context.Purchases.Where(p => 
            (p.PurchaseDate.Year >= FromDateTimePicker.Value.Year && 
             p.PurchaseDate.Month >= FromDateTimePicker.Value.Month &&
             p.PurchaseDate.Day >= FromDateTimePicker.Value.Day) && 
            (p.PurchaseDate.Year <= ToDateTimePicker.Value.Year &&
             p.PurchaseDate.Month <= ToDateTimePicker.Value.Month && 
             p.PurchaseDate.Day <= ToDateTimePicker.Value.Day)).GroupBy(p => 
           new {p.Product.PaintedModel.CarModel.CarModelName,
                p.Product.PaintedModel.CarModel.Country.CountryName,
                p.Product.PaintedModel.CarModel.CarBrand.CarBrandName,
                p.Product.PaintedModel.CarModel.TechnicalInformation.BodyType.BodyTypeName,
                p.Product.PaintedModel.CarModel.TechnicalInformation.DoorsAmount,
                p.Product.PaintedModel.CarModel.TechnicalInformation.EngineLocation.EngineLocationName,
                p.Product.PaintedModel.CarModel.TechnicalInformation.EnginePower,
                p.Product.PaintedModel.CarModel.TechnicalInformation.SeatsAmount,
                p.Product.PaintedModel.CarModel.TechnicalInformation.EngineType.EngineTypeName}).Select(p =>
           new
           {
               Model = p.Key.CarModelName,
               Country = p.Key.CountryName,
               Brand = p.Key.CarBrandName,
               BodyType = p.Key.BodyTypeName,
               DoorsAmount = p.Key.DoorsAmount,
               EngineLocation = p.Key.EngineLocationName,
               EnginePower = p.Key.EnginePower,
               SeatsAmount = p.Key.SeatsAmount,
               EngineType = p.Key.EngineTypeName,
               Count = p.Count(),
               Sum = p.Sum(s => s.Price),
               Avg = p.Average(s => s.Price),
               Min = p.Min(s => s.Price),
               Max = p.Max(s => s.Price)
           }).ToList();

            CarBrandDataGridView.DataSource = _context.Purchases.Where(p =>
            (p.PurchaseDate.Year >= FromDateTimePicker.Value.Year &&
             p.PurchaseDate.Month >= FromDateTimePicker.Value.Month &&
             p.PurchaseDate.Day >= FromDateTimePicker.Value.Day) &&
            (p.PurchaseDate.Year <= ToDateTimePicker.Value.Year &&
             p.PurchaseDate.Month <= ToDateTimePicker.Value.Month &&
             p.PurchaseDate.Day <= ToDateTimePicker.Value.Day)).GroupBy(p => p.Product.PaintedModel.CarModel.CarBrand.CarBrandName).Select(p =>
             new
             {
                 Brand = p.Key,
                 Count = p.Count(),
                 Sum = p.Sum(s => s.Price),
                 Avg = p.Average(s => s.Price),
                 Min = p.Min(s => s.Price),
                 Max = p.Max(s => s.Price)
             }).ToList();

            ClientDataGridView.DataSource = _context.Purchases.Where(p =>
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
                 Count = p.Count(),
                 Sum = p.Sum(s => s.Price),
                 Avg = p.Average(s => s.Price),
                 Min = p.Min(s => s.Price),
                 Max = p.Max(s => s.Price)
             }).ToList();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
