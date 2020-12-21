namespace AutoShow
{
    partial class CU_TechnicalInformationForm
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
            this.EngineDisplacementLabel = new System.Windows.Forms.Label();
            this.SeatsAmountLabel = new System.Windows.Forms.Label();
            this.DoorsAmountLabel = new System.Windows.Forms.Label();
            this.EngineDisplacementNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SeatsAmountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DoorsAmountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.EngineLocationLabel = new System.Windows.Forms.Label();
            this.EngineTypeLabel = new System.Windows.Forms.Label();
            this.EngineLocationComboBox = new System.Windows.Forms.ComboBox();
            this.EngineTypeComboBox = new System.Windows.Forms.ComboBox();
            this.BodyTypeLabel = new System.Windows.Forms.Label();
            this.BodyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.BodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EngineDisplacementNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatsAmountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoorsAmountNumericUpDown)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BodyPanel
            // 
            this.BodyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(23)))), ((int)(((byte)(29)))));
            this.BodyPanel.Controls.Add(this.EngineDisplacementLabel);
            this.BodyPanel.Controls.Add(this.SeatsAmountLabel);
            this.BodyPanel.Controls.Add(this.DoorsAmountLabel);
            this.BodyPanel.Controls.Add(this.EngineDisplacementNumericUpDown);
            this.BodyPanel.Controls.Add(this.SeatsAmountNumericUpDown);
            this.BodyPanel.Controls.Add(this.DoorsAmountNumericUpDown);
            this.BodyPanel.Controls.Add(this.EngineLocationLabel);
            this.BodyPanel.Controls.Add(this.EngineTypeLabel);
            this.BodyPanel.Controls.Add(this.EngineLocationComboBox);
            this.BodyPanel.Controls.Add(this.EngineTypeComboBox);
            this.BodyPanel.Controls.Add(this.BodyTypeLabel);
            this.BodyPanel.Controls.Add(this.BodyTypeComboBox);
            this.BodyPanel.Controls.Add(this.CreateButton);
            this.BodyPanel.Controls.Add(this.UpdateButton);
            this.BodyPanel.Controls.Add(this.BackButton);
            this.BodyPanel.Controls.Add(this.HeaderPanel);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(501, 503);
            this.BodyPanel.TabIndex = 6;
            // 
            // EngineDisplacementLabel
            // 
            this.EngineDisplacementLabel.AutoSize = true;
            this.EngineDisplacementLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineDisplacementLabel.ForeColor = System.Drawing.Color.White;
            this.EngineDisplacementLabel.Location = new System.Drawing.Point(296, 263);
            this.EngineDisplacementLabel.Name = "EngineDisplacementLabel";
            this.EngineDisplacementLabel.Size = new System.Drawing.Size(169, 23);
            this.EngineDisplacementLabel.TabIndex = 28;
            this.EngineDisplacementLabel.Text = "Объем двигателя";
            // 
            // SeatsAmountLabel
            // 
            this.SeatsAmountLabel.AutoSize = true;
            this.SeatsAmountLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SeatsAmountLabel.ForeColor = System.Drawing.Color.White;
            this.SeatsAmountLabel.Location = new System.Drawing.Point(12, 263);
            this.SeatsAmountLabel.Name = "SeatsAmountLabel";
            this.SeatsAmountLabel.Size = new System.Drawing.Size(244, 23);
            this.SeatsAmountLabel.TabIndex = 27;
            this.SeatsAmountLabel.Text = "Количество сидячих мест";
            // 
            // DoorsAmountLabel
            // 
            this.DoorsAmountLabel.AutoSize = true;
            this.DoorsAmountLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DoorsAmountLabel.ForeColor = System.Drawing.Color.White;
            this.DoorsAmountLabel.Location = new System.Drawing.Point(290, 184);
            this.DoorsAmountLabel.Name = "DoorsAmountLabel";
            this.DoorsAmountLabel.Size = new System.Drawing.Size(185, 23);
            this.DoorsAmountLabel.TabIndex = 26;
            this.DoorsAmountLabel.Text = "Количество дверей";
            // 
            // EngineDisplacementNumericUpDown
            // 
            this.EngineDisplacementNumericUpDown.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineDisplacementNumericUpDown.Location = new System.Drawing.Point(300, 299);
            this.EngineDisplacementNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.EngineDisplacementNumericUpDown.Name = "EngineDisplacementNumericUpDown";
            this.EngineDisplacementNumericUpDown.Size = new System.Drawing.Size(161, 30);
            this.EngineDisplacementNumericUpDown.TabIndex = 25;
            // 
            // SeatsAmountNumericUpDown
            // 
            this.SeatsAmountNumericUpDown.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SeatsAmountNumericUpDown.Location = new System.Drawing.Point(40, 299);
            this.SeatsAmountNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.SeatsAmountNumericUpDown.Name = "SeatsAmountNumericUpDown";
            this.SeatsAmountNumericUpDown.Size = new System.Drawing.Size(172, 30);
            this.SeatsAmountNumericUpDown.TabIndex = 24;
            // 
            // DoorsAmountNumericUpDown
            // 
            this.DoorsAmountNumericUpDown.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DoorsAmountNumericUpDown.Location = new System.Drawing.Point(300, 219);
            this.DoorsAmountNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DoorsAmountNumericUpDown.Name = "DoorsAmountNumericUpDown";
            this.DoorsAmountNumericUpDown.Size = new System.Drawing.Size(161, 30);
            this.DoorsAmountNumericUpDown.TabIndex = 23;
            // 
            // EngineLocationLabel
            // 
            this.EngineLocationLabel.AutoSize = true;
            this.EngineLocationLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineLocationLabel.ForeColor = System.Drawing.Color.White;
            this.EngineLocationLabel.Location = new System.Drawing.Point(36, 184);
            this.EngineLocationLabel.Name = "EngineLocationLabel";
            this.EngineLocationLabel.Size = new System.Drawing.Size(176, 23);
            this.EngineLocationLabel.TabIndex = 22;
            this.EngineLocationLabel.Text = "Распол. двигателя";
            // 
            // EngineTypeLabel
            // 
            this.EngineTypeLabel.AutoSize = true;
            this.EngineTypeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineTypeLabel.ForeColor = System.Drawing.Color.White;
            this.EngineTypeLabel.Location = new System.Drawing.Point(306, 103);
            this.EngineTypeLabel.Name = "EngineTypeLabel";
            this.EngineTypeLabel.Size = new System.Drawing.Size(144, 23);
            this.EngineTypeLabel.TabIndex = 21;
            this.EngineTypeLabel.Text = "Тип двигателя";
            // 
            // EngineLocationComboBox
            // 
            this.EngineLocationComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineLocationComboBox.FormattingEnabled = true;
            this.EngineLocationComboBox.Location = new System.Drawing.Point(40, 219);
            this.EngineLocationComboBox.Name = "EngineLocationComboBox";
            this.EngineLocationComboBox.Size = new System.Drawing.Size(172, 31);
            this.EngineLocationComboBox.TabIndex = 20;
            // 
            // EngineTypeComboBox
            // 
            this.EngineTypeComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineTypeComboBox.FormattingEnabled = true;
            this.EngineTypeComboBox.Location = new System.Drawing.Point(294, 137);
            this.EngineTypeComboBox.Name = "EngineTypeComboBox";
            this.EngineTypeComboBox.Size = new System.Drawing.Size(167, 31);
            this.EngineTypeComboBox.TabIndex = 19;
            // 
            // BodyTypeLabel
            // 
            this.BodyTypeLabel.AutoSize = true;
            this.BodyTypeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BodyTypeLabel.ForeColor = System.Drawing.Color.White;
            this.BodyTypeLabel.Location = new System.Drawing.Point(63, 103);
            this.BodyTypeLabel.Name = "BodyTypeLabel";
            this.BodyTypeLabel.Size = new System.Drawing.Size(113, 23);
            this.BodyTypeLabel.TabIndex = 18;
            this.BodyTypeLabel.Text = "Тип кузова";
            // 
            // BodyTypeComboBox
            // 
            this.BodyTypeComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BodyTypeComboBox.FormattingEnabled = true;
            this.BodyTypeComboBox.Location = new System.Drawing.Point(40, 137);
            this.BodyTypeComboBox.Name = "BodyTypeComboBox";
            this.BodyTypeComboBox.Size = new System.Drawing.Size(172, 31);
            this.BodyTypeComboBox.TabIndex = 17;
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.CreateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateButton.FlatAppearance.BorderSize = 0;
            this.CreateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(5)))), ((int)(((byte)(227)))));
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateButton.ForeColor = System.Drawing.Color.White;
            this.CreateButton.Location = new System.Drawing.Point(310, 357);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(151, 41);
            this.CreateButton.TabIndex = 15;
            this.CreateButton.Text = "Создать";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.UpdateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateButton.FlatAppearance.BorderSize = 0;
            this.UpdateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(5)))), ((int)(((byte)(227)))));
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.Location = new System.Drawing.Point(40, 357);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(161, 41);
            this.UpdateButton.TabIndex = 14;
            this.UpdateButton.Text = "Обновить";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
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
            this.BackButton.Location = new System.Drawing.Point(40, 426);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(161, 41);
            this.BackButton.TabIndex = 11;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.HeaderPanel.Controls.Add(this.CloseLabel);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(501, 100);
            this.HeaderPanel.TabIndex = 1;
            // 
            // CloseLabel
            // 
            this.CloseLabel.AutoSize = true;
            this.CloseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseLabel.ForeColor = System.Drawing.Color.White;
            this.CloseLabel.Location = new System.Drawing.Point(474, 0);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(27, 25);
            this.CloseLabel.TabIndex = 1;
            this.CloseLabel.Text = "X";
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // CU_TechnicalInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 503);
            this.Controls.Add(this.BodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CU_TechnicalInformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CU_TechnicalInformationForm";
            this.BodyPanel.ResumeLayout(false);
            this.BodyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EngineDisplacementNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatsAmountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoorsAmountNumericUpDown)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.ComboBox BodyTypeComboBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.Label BodyTypeLabel;
        private System.Windows.Forms.Label EngineLocationLabel;
        private System.Windows.Forms.Label EngineTypeLabel;
        private System.Windows.Forms.ComboBox EngineLocationComboBox;
        private System.Windows.Forms.ComboBox EngineTypeComboBox;
        private System.Windows.Forms.Label EngineDisplacementLabel;
        private System.Windows.Forms.Label SeatsAmountLabel;
        private System.Windows.Forms.Label DoorsAmountLabel;
        private System.Windows.Forms.NumericUpDown EngineDisplacementNumericUpDown;
        private System.Windows.Forms.NumericUpDown SeatsAmountNumericUpDown;
        private System.Windows.Forms.NumericUpDown DoorsAmountNumericUpDown;
    }
}