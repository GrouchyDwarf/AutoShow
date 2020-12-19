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
    public enum Option
    {
        Undefined,
        BodyType,
        EngineLocation,
        EngineType,
        CarBrand,
        CarModel
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
            _labels.Add(CarBrandLabel);
            _labels.Add(CarModelLabel);
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

        private void CarModelLabel_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(_labels, CarModelLabel);
            _option = Option.CarModel;
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
