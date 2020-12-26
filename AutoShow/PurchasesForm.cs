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
    public partial class PurchasesForm : Form
    {
        private readonly ManagerCrudForm _managerCrudForm;
        private readonly AutoShowContext _context;
        public PurchasesForm(in AutoShowContext context, in ManagerCrudForm managerCrudForm)
        {
            InitializeComponent();
            _managerCrudForm = managerCrudForm;
            _context = context;

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
            }).ToList();
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
    }
}
