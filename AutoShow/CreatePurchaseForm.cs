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
    public partial class CreatePurchaseForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly ManagerCrudForm _managerCrudForm;
        private readonly Warehouse _warehouse;
        private readonly Manager _manager;
        public CreatePurchaseForm(in AutoShowContext context, in ManagerCrudForm managerCrudForm, in Warehouse warehouse, in Manager manager)
        {
            InitializeComponent();
            _context = context;
            _managerCrudForm = managerCrudForm;
            _warehouse = warehouse;
            _manager = manager;
            DataGridView.DataSource = _context.Clients.Select(c => new 
            { 
                c.FirstName,
                c.LastName
            }).ToList();
            PaymentTypeComboBox.Items.AddRange(_context.PaymentTypes.Select(p => p.PaymentTypeName).ToArray());
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

        private void CreateButton_Click(object sender, EventArgs e)
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
            if (PaymentTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (_warehouse.Quantity < 1)
            {
                MessageBox.Show("Недостаточно товара на складе");
                return;
            }
            string firstName = DataGridView[0, DataGridView.SelectedRows[0].Index].Value.ToString();
            string lastName = DataGridView[1, DataGridView.SelectedRows[0].Index].Value.ToString();
            int paymentTypeId = _context.PaymentTypes.FirstOrDefault(p => p.PaymentTypeName == PaymentTypeComboBox.Text).PaymentTypeId;
            DateTime purchaseDate = PurchaseDateTimePicker.Value;
            DateTime paymentDate = PaymentDateTimePicker.Value;
            bool delivery = DeliveryCheckBox.Checked;

            var client = _context.Clients.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            var purchase = _context.Purchases.FirstOrDefault(p => p.PurchaseDate.Year == purchaseDate.Year && p.PurchaseDate.Month == purchaseDate.Month &&
            p.PurchaseDate.Day == purchaseDate.Day && p.ProductId == _warehouse.ProductId && p.ClientId == client.ClientId);
            if(purchase != null)
            {
                MessageBox.Show("Данный клиент не может покупать два и более раз один и тот же продукт в день");
                return;
            }
            bool firstTime = false;
            if (client.Discount < (decimal)0.01)
            {
                client.Discount += (decimal)0.01;
                firstTime = true;
            }
            var newPurchase = new Purchase
            {
                PurchaseDate = purchaseDate,
                Delivery = delivery,
                PaymentTypeId = paymentTypeId,
                PaymentDate = paymentDate,
                ClientId = client.ClientId,
                Price = _warehouse.Price * (1 - client.Discount),
                ManagerId = _manager.ManagerId,
                ProductId = _warehouse.ProductId
            };
            if(client.Discount < (decimal)0.1 && !firstTime)
            {
                client.Discount += (decimal)0.01;
            }
            --_warehouse.Quantity;
            _context.Purchases.Add(newPurchase);
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            _managerCrudForm.RefreshData();
        }
    }
}
