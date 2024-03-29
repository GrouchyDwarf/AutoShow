﻿using System;
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
    public enum Option
    {
        Undefined,
        BodyType,
        EngineLocation,
        EngineType,
        TechnicalInformation,
        CarBrand,
        Country,
        CarModel,
        Colour,
        PaintedModel,
        Product,
        PaymentType
    };
    public partial class AdminMainForm : Form
    {
        private readonly StartForm _startForm;
        private readonly List<Label> _labels;
        private readonly AutoShowContext _context;
        private readonly string _firstName;
        private readonly string _lastName;
        private Option _option;
        public AdminMainForm(in string firstName, in string lastName, StartForm startForm, in AutoShowContext context)
        {
            InitializeComponent();
            _firstName = firstName;
            _lastName = lastName;
            AdminInfoLabel.Text = "Вы вошли как администратор: " + _firstName + " " + _lastName;
            _startForm = startForm;
            _context = context;
            _labels = new List<Label>();
            #region InitializeLabelsList
            _labels.Add(BodyTypeLabel);
            _labels.Add(EngineLocationLabel);
            _labels.Add(EngineTypeLabel);
            _labels.Add(TechnicalInformationLabel);
            _labels.Add(CarBrandLabel);
            _labels.Add(CountryLabel);
            _labels.Add(CarModelLabel);
            _labels.Add(ColourLabel);
            _labels.Add(PaintedModelLabel);
            _labels.Add(ProductLabel);
            _labels.Add(PaymentTypeLabel);
            #endregion

        }
        private void ChangeLabelColor(List<Label> labels, in Label chosenLabel)
        {
            for (var i = 0; i < labels.Count; ++i)
            {
                if (labels[i] == chosenLabel)
                {
                    labels[i].ForeColor = Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(5)))), ((int)(((byte)(247)))));
                    continue;
                }
                labels[i].ForeColor = Color.White;
            }
        }
        private void CloseLabel_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Application.Exit();
        }

        private void BodyTypeLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, BodyTypeLabel);
            _option = Option.BodyType;
        }

        private void CarBrandLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, CarBrandLabel);
            _option = Option.CarBrand;
        }
        private void EngineLocationLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, EngineLocationLabel);
            _option = Option.EngineLocation;
        }
        private void EngineTypeLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, EngineTypeLabel);
            _option = Option.EngineType;
        }
        private void TechnicalInformationLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, TechnicalInformationLabel);
            _option = Option.TechnicalInformation;
        }
        private void CountryLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, CountryLabel);
            _option = Option.Country;
        }
        private void CarModelLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, CarModelLabel);
            _option = Option.CarModel;
        }
        private void ColourLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, ColourLabel);
            _option = Option.Colour;
        }
        private void PaintedModelLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, PaintedModelLabel);
            _option = Option.PaintedModel;
        }
        private void ProductLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, ProductLabel);
            _option = Option.Product;
        }
        private void PaymentTypeLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, PaymentTypeLabel);
            _option = Option.PaymentType;
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            _startForm.Show();
            this.Close();
        }
        
        private void NextButton_Click(object sender, EventArgs e)
        {
            if(_option == Option.Undefined)
            {
                MessageBox.Show("Вы не выбрали опцию");
                return;
            }
            var adminCrudForm = new AdminCrudForm(_context, this, _option);
            adminCrudForm.Show();
            this.Hide();
        }

        
    }
}
