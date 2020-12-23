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
    public partial class CU_TechnicalInformationForm : Form
    {
        private readonly AutoShowContext _context;
        private readonly AdminCrudForm _adminCrudForm;
        private readonly TechnicalInformation _technicalInformation;
        public CU_TechnicalInformationForm(in AutoShowContext context, in AdminCrudForm adminCrudForm)
        {
            InitializeComponent();
            _context = context;
            _adminCrudForm = adminCrudForm;
            BodyTypeComboBox.Items.AddRange(_context.BodyTypes.Select(b => b.BodyTypeName).ToArray());
            EngineTypeComboBox.Items.AddRange(_context.EngineTypes.Select(en => en.EngineTypeName).ToArray());
            EngineLocationComboBox.Items.AddRange(_context.EngineLocations.Select(en => en.EngineLocationName).ToArray());
            
        }
        public CU_TechnicalInformationForm(in AutoShowContext context, in AdminCrudForm adminCrudForm, in TechnicalInformation technicalInformation)
        :this(context, adminCrudForm)
        {
            _technicalInformation = technicalInformation;
            BodyTypeComboBox.Text = _technicalInformation.BodyType.BodyTypeName;
            EngineTypeComboBox.Text = _technicalInformation.EngineType.EngineTypeName;
            EngineLocationComboBox.Text = _technicalInformation.EngineLocation.EngineLocationName;
            DoorsAmountNumericUpDown.Value = _technicalInformation.DoorsAmount;
            SeatsAmountNumericUpDown.Value = _technicalInformation.SeatsAmount;
            EngineDisplacementNumericUpDown.Value = _technicalInformation.EngineDisplacement;
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
            if(_technicalInformation != null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }
            if(BodyTypeComboBox.SelectedItem == null || EngineLocationComboBox.SelectedItem == null || EngineTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == BodyTypeComboBox.Text).BodyTypeId;
            int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == EngineTypeComboBox.Text).EngineTypeId;
            int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == EngineLocationComboBox.Text).EngineLocationId;
            int doorsAmount = (int)DoorsAmountNumericUpDown.Value;
            int seatsAmount = (int)SeatsAmountNumericUpDown.Value;
            int engineDisplacement = (int)EngineDisplacementNumericUpDown.Value;
            var technicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.EngineTypeId == engineTypeId &&
            t.EngineLocationId == engineLocationId && t.DoorsAmount == doorsAmount && t.SeatsAmount == seatsAmount && t.EngineDisplacement == engineDisplacement);
            if (technicalInformation != null)
            {
                MessageBox.Show("Такая техническая информация уже существует");
                return;
            }
            var newTechnicalInformation = new TechnicalInformation
            {
                BodyTypeId = bodyTypeId,
                EngineTypeId = engineTypeId,
                EngineLocationId = engineLocationId,
                DoorsAmount = doorsAmount,
                SeatsAmount = seatsAmount,
                EngineDisplacement = engineDisplacement
            };
            _context.TechnicalInformations.Add(newTechnicalInformation);
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            _adminCrudForm.RefreshData();
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_technicalInformation == null)
            {
                MessageBox.Show("Вы перепутали обновление и создание");
                return;
            }

            if (BodyTypeComboBox.SelectedItem == null || EngineLocationComboBox.SelectedItem == null || EngineTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            int bodyTypeId = _context.BodyTypes.FirstOrDefault(b => b.BodyTypeName == BodyTypeComboBox.Text).BodyTypeId;
            int engineTypeId = _context.EngineTypes.FirstOrDefault(en => en.EngineTypeName == EngineTypeComboBox.Text).EngineTypeId;
            int engineLocationId = _context.EngineLocations.FirstOrDefault(en => en.EngineLocationName == EngineLocationComboBox.Text).EngineLocationId;
            int doorsAmount = (int)DoorsAmountNumericUpDown.Value;
            int seatsAmount = (int)SeatsAmountNumericUpDown.Value;
            int engineDisplacement = (int)EngineDisplacementNumericUpDown.Value;

            var existingTechnicalInformation = _context.TechnicalInformations.FirstOrDefault(t => t.BodyTypeId == bodyTypeId && t.DoorsAmount == doorsAmount &&
            t.EngineDisplacement == engineDisplacement && t.EngineLocationId == engineLocationId && t.EngineTypeId == engineTypeId && t.SeatsAmount == seatsAmount);

            if (existingTechnicalInformation != null)
            {
                MessageBox.Show("Такие тех данные уже существуют");
                return;
            }

            _technicalInformation.BodyTypeId = bodyTypeId;
            _technicalInformation.DoorsAmount = doorsAmount;
            _technicalInformation.EngineDisplacement = engineDisplacement;
            _technicalInformation.EngineLocationId = engineLocationId;
            _technicalInformation.EngineTypeId = engineTypeId;
            _technicalInformation.SeatsAmount = seatsAmount;

            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("Данные успешно обновлены");
            }
            _adminCrudForm.RefreshData();
        }
    }
}
