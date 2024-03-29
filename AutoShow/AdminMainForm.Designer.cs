﻿namespace AutoShow
{
    partial class AdminMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BodyPanel = new System.Windows.Forms.Panel();
            this.PaymentTypeLabel = new System.Windows.Forms.Label();
            this.ProductLabel = new System.Windows.Forms.Label();
            this.PaintedModelLabel = new System.Windows.Forms.Label();
            this.ColourLabel = new System.Windows.Forms.Label();
            this.CountryLabel = new System.Windows.Forms.Label();
            this.TechnicalInformationLabel = new System.Windows.Forms.Label();
            this.EngineTypeLabel = new System.Windows.Forms.Label();
            this.EngineLocationLabel = new System.Windows.Forms.Label();
            this.CarModelLabel = new System.Windows.Forms.Label();
            this.CarBrandLabel = new System.Windows.Forms.Label();
            this.BodyTypeLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.AdminInfoLabel = new System.Windows.Forms.Label();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.BodyPanel.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BodyPanel
            // 
            this.BodyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(23)))), ((int)(((byte)(29)))));
            this.BodyPanel.Controls.Add(this.PaymentTypeLabel);
            this.BodyPanel.Controls.Add(this.ProductLabel);
            this.BodyPanel.Controls.Add(this.PaintedModelLabel);
            this.BodyPanel.Controls.Add(this.ColourLabel);
            this.BodyPanel.Controls.Add(this.CountryLabel);
            this.BodyPanel.Controls.Add(this.TechnicalInformationLabel);
            this.BodyPanel.Controls.Add(this.EngineTypeLabel);
            this.BodyPanel.Controls.Add(this.EngineLocationLabel);
            this.BodyPanel.Controls.Add(this.CarModelLabel);
            this.BodyPanel.Controls.Add(this.CarBrandLabel);
            this.BodyPanel.Controls.Add(this.BodyTypeLabel);
            this.BodyPanel.Controls.Add(this.StatusLabel);
            this.BodyPanel.Controls.Add(this.NextButton);
            this.BodyPanel.Controls.Add(this.BackButton);
            this.BodyPanel.Controls.Add(this.HeaderPanel);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(669, 503);
            this.BodyPanel.TabIndex = 2;
            // 
            // PaymentTypeLabel
            // 
            this.PaymentTypeLabel.AutoSize = true;
            this.PaymentTypeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PaymentTypeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PaymentTypeLabel.ForeColor = System.Drawing.Color.White;
            this.PaymentTypeLabel.Location = new System.Drawing.Point(213, 351);
            this.PaymentTypeLabel.Name = "PaymentTypeLabel";
            this.PaymentTypeLabel.Size = new System.Drawing.Size(133, 23);
            this.PaymentTypeLabel.TabIndex = 28;
            this.PaymentTypeLabel.Text = "Виды оплаты";
            this.PaymentTypeLabel.Click += new System.EventHandler(this.PaymentTypeLabel_Click);
            // 
            // ProductLabel
            // 
            this.ProductLabel.AutoSize = true;
            this.ProductLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductLabel.ForeColor = System.Drawing.Color.White;
            this.ProductLabel.Location = new System.Drawing.Point(12, 351);
            this.ProductLabel.Name = "ProductLabel";
            this.ProductLabel.Size = new System.Drawing.Size(101, 23);
            this.ProductLabel.TabIndex = 27;
            this.ProductLabel.Text = "Продукты";
            this.ProductLabel.Click += new System.EventHandler(this.ProductLabel_Click);
            // 
            // PaintedModelLabel
            // 
            this.PaintedModelLabel.AutoSize = true;
            this.PaintedModelLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PaintedModelLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PaintedModelLabel.ForeColor = System.Drawing.Color.White;
            this.PaintedModelLabel.Location = new System.Drawing.Point(430, 286);
            this.PaintedModelLabel.Name = "PaintedModelLabel";
            this.PaintedModelLabel.Size = new System.Drawing.Size(199, 23);
            this.PaintedModelLabel.TabIndex = 26;
            this.PaintedModelLabel.Text = "Окрашенная модель";
            this.PaintedModelLabel.Click += new System.EventHandler(this.PaintedModelLabel_Click);
            // 
            // ColourLabel
            // 
            this.ColourLabel.AutoSize = true;
            this.ColourLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColourLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColourLabel.ForeColor = System.Drawing.Color.White;
            this.ColourLabel.Location = new System.Drawing.Point(213, 286);
            this.ColourLabel.Name = "ColourLabel";
            this.ColourLabel.Size = new System.Drawing.Size(65, 23);
            this.ColourLabel.TabIndex = 25;
            this.ColourLabel.Text = "Цвета";
            this.ColourLabel.Click += new System.EventHandler(this.ColourLabel_Click);
            // 
            // CountryLabel
            // 
            this.CountryLabel.AutoSize = true;
            this.CountryLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CountryLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountryLabel.ForeColor = System.Drawing.Color.White;
            this.CountryLabel.Location = new System.Drawing.Point(430, 224);
            this.CountryLabel.Name = "CountryLabel";
            this.CountryLabel.Size = new System.Drawing.Size(81, 23);
            this.CountryLabel.TabIndex = 24;
            this.CountryLabel.Text = "Страны";
            this.CountryLabel.Click += new System.EventHandler(this.CountryLabel_Click);
            // 
            // TechnicalInformationLabel
            // 
            this.TechnicalInformationLabel.AutoSize = true;
            this.TechnicalInformationLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TechnicalInformationLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TechnicalInformationLabel.ForeColor = System.Drawing.Color.White;
            this.TechnicalInformationLabel.Location = new System.Drawing.Point(12, 224);
            this.TechnicalInformationLabel.Name = "TechnicalInformationLabel";
            this.TechnicalInformationLabel.Size = new System.Drawing.Size(121, 23);
            this.TechnicalInformationLabel.TabIndex = 23;
            this.TechnicalInformationLabel.Text = "Тех.Данные";
            this.TechnicalInformationLabel.Click += new System.EventHandler(this.TechnicalInformationLabel_Click);
            // 
            // EngineTypeLabel
            // 
            this.EngineTypeLabel.AutoSize = true;
            this.EngineTypeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EngineTypeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineTypeLabel.ForeColor = System.Drawing.Color.White;
            this.EngineTypeLabel.Location = new System.Drawing.Point(430, 160);
            this.EngineTypeLabel.Name = "EngineTypeLabel";
            this.EngineTypeLabel.Size = new System.Drawing.Size(160, 23);
            this.EngineTypeLabel.TabIndex = 22;
            this.EngineTypeLabel.Text = "Типы двигателя";
            this.EngineTypeLabel.Click += new System.EventHandler(this.EngineTypeLabel_Click);
            // 
            // EngineLocationLabel
            // 
            this.EngineLocationLabel.AutoSize = true;
            this.EngineLocationLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EngineLocationLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineLocationLabel.ForeColor = System.Drawing.Color.White;
            this.EngineLocationLabel.Location = new System.Drawing.Point(213, 160);
            this.EngineLocationLabel.Name = "EngineLocationLabel";
            this.EngineLocationLabel.Size = new System.Drawing.Size(158, 23);
            this.EngineLocationLabel.TabIndex = 21;
            this.EngineLocationLabel.Text = "Располож. Двиг.";
            this.EngineLocationLabel.Click += new System.EventHandler(this.EngineLocationLabel_Click);
            // 
            // CarModelLabel
            // 
            this.CarModelLabel.AutoSize = true;
            this.CarModelLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CarModelLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarModelLabel.ForeColor = System.Drawing.Color.White;
            this.CarModelLabel.Location = new System.Drawing.Point(12, 286);
            this.CarModelLabel.Name = "CarModelLabel";
            this.CarModelLabel.Size = new System.Drawing.Size(80, 23);
            this.CarModelLabel.TabIndex = 20;
            this.CarModelLabel.Text = "Модели";
            this.CarModelLabel.Click += new System.EventHandler(this.CarModelLabel_Click);
            // 
            // CarBrandLabel
            // 
            this.CarBrandLabel.AutoSize = true;
            this.CarBrandLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CarBrandLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarBrandLabel.ForeColor = System.Drawing.Color.White;
            this.CarBrandLabel.Location = new System.Drawing.Point(213, 224);
            this.CarBrandLabel.Name = "CarBrandLabel";
            this.CarBrandLabel.Size = new System.Drawing.Size(72, 23);
            this.CarBrandLabel.TabIndex = 19;
            this.CarBrandLabel.Text = "Марки";
            this.CarBrandLabel.Click += new System.EventHandler(this.CarBrandLabel_Click);
            // 
            // BodyTypeLabel
            // 
            this.BodyTypeLabel.AutoSize = true;
            this.BodyTypeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BodyTypeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BodyTypeLabel.ForeColor = System.Drawing.Color.White;
            this.BodyTypeLabel.Location = new System.Drawing.Point(12, 160);
            this.BodyTypeLabel.Name = "BodyTypeLabel";
            this.BodyTypeLabel.Size = new System.Drawing.Size(129, 23);
            this.BodyTypeLabel.TabIndex = 18;
            this.BodyTypeLabel.Text = "Типы кузова";
            this.BodyTypeLabel.Click += new System.EventHandler(this.BodyTypeLabel_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(264, 115);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(197, 26);
            this.StatusLabel.TabIndex = 17;
            this.StatusLabel.Text = "Выберите опцию";
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.NextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextButton.FlatAppearance.BorderSize = 0;
            this.NextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(5)))), ((int)(((byte)(227)))));
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextButton.ForeColor = System.Drawing.Color.White;
            this.NextButton.Location = new System.Drawing.Point(491, 402);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(138, 41);
            this.NextButton.TabIndex = 12;
            this.NextButton.Text = "Далее";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(5)))), ((int)(((byte)(227)))));
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(40, 402);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(138, 41);
            this.BackButton.TabIndex = 11;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.HeaderPanel.Controls.Add(this.AdminInfoLabel);
            this.HeaderPanel.Controls.Add(this.CloseLabel);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(669, 100);
            this.HeaderPanel.TabIndex = 1;
            // 
            // AdminInfoLabel
            // 
            this.AdminInfoLabel.AutoSize = true;
            this.AdminInfoLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdminInfoLabel.ForeColor = System.Drawing.Color.White;
            this.AdminInfoLabel.Location = new System.Drawing.Point(36, 27);
            this.AdminInfoLabel.Name = "AdminInfoLabel";
            this.AdminInfoLabel.Size = new System.Drawing.Size(142, 23);
            this.AdminInfoLabel.TabIndex = 2;
            this.AdminInfoLabel.Text = "Имя Фамилия";
            // 
            // CloseLabel
            // 
            this.CloseLabel.AutoSize = true;
            this.CloseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseLabel.ForeColor = System.Drawing.Color.White;
            this.CloseLabel.Location = new System.Drawing.Point(642, 0);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(27, 25);
            this.CloseLabel.TabIndex = 1;
            this.CloseLabel.Text = "X";
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 503);
            this.Controls.Add(this.BodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMainForm";
            this.BodyPanel.ResumeLayout(false);
            this.BodyPanel.PerformLayout();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.Label CarModelLabel;
        private System.Windows.Forms.Label CarBrandLabel;
        private System.Windows.Forms.Label BodyTypeLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.Label AdminInfoLabel;
        private System.Windows.Forms.Label EngineTypeLabel;
        private System.Windows.Forms.Label EngineLocationLabel;
        private System.Windows.Forms.Label TechnicalInformationLabel;
        private System.Windows.Forms.Label CountryLabel;
        private System.Windows.Forms.Label ColourLabel;
        private System.Windows.Forms.Label PaintedModelLabel;
        private System.Windows.Forms.Label ProductLabel;
        private System.Windows.Forms.Label PaymentTypeLabel;
    }
}