namespace AutoShow
{
    partial class CreatePurchaseForm
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
            this.PaymentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.DeliveryCheckBox = new System.Windows.Forms.CheckBox();
            this.PaymentDateLabel = new System.Windows.Forms.Label();
            this.PurchaseDateLabel = new System.Windows.Forms.Label();
            this.PaymentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.PurchaseDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CreateButton = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.BackButton = new System.Windows.Forms.Button();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.BodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BodyPanel
            // 
            this.BodyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(23)))), ((int)(((byte)(29)))));
            this.BodyPanel.Controls.Add(this.PaymentTypeLabel);
            this.BodyPanel.Controls.Add(this.PaymentTypeComboBox);
            this.BodyPanel.Controls.Add(this.DeliveryCheckBox);
            this.BodyPanel.Controls.Add(this.PaymentDateLabel);
            this.BodyPanel.Controls.Add(this.PurchaseDateLabel);
            this.BodyPanel.Controls.Add(this.PaymentDateTimePicker);
            this.BodyPanel.Controls.Add(this.PurchaseDateTimePicker);
            this.BodyPanel.Controls.Add(this.CreateButton);
            this.BodyPanel.Controls.Add(this.DataGridView);
            this.BodyPanel.Controls.Add(this.BackButton);
            this.BodyPanel.Controls.Add(this.HeaderPanel);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(848, 548);
            this.BodyPanel.TabIndex = 8;
            // 
            // PaymentTypeLabel
            // 
            this.PaymentTypeLabel.AutoSize = true;
            this.PaymentTypeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PaymentTypeLabel.ForeColor = System.Drawing.Color.White;
            this.PaymentTypeLabel.Location = new System.Drawing.Point(649, 392);
            this.PaymentTypeLabel.Name = "PaymentTypeLabel";
            this.PaymentTypeLabel.Size = new System.Drawing.Size(133, 23);
            this.PaymentTypeLabel.TabIndex = 46;
            this.PaymentTypeLabel.Text = "Виды оплаты";
            // 
            // PaymentTypeComboBox
            // 
            this.PaymentTypeComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PaymentTypeComboBox.FormattingEnabled = true;
            this.PaymentTypeComboBox.Location = new System.Drawing.Point(635, 426);
            this.PaymentTypeComboBox.Name = "PaymentTypeComboBox";
            this.PaymentTypeComboBox.Size = new System.Drawing.Size(172, 31);
            this.PaymentTypeComboBox.TabIndex = 45;
            // 
            // DeliveryCheckBox
            // 
            this.DeliveryCheckBox.AutoSize = true;
            this.DeliveryCheckBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeliveryCheckBox.ForeColor = System.Drawing.Color.White;
            this.DeliveryCheckBox.Location = new System.Drawing.Point(490, 430);
            this.DeliveryCheckBox.Name = "DeliveryCheckBox";
            this.DeliveryCheckBox.Size = new System.Drawing.Size(117, 27);
            this.DeliveryCheckBox.TabIndex = 44;
            this.DeliveryCheckBox.Text = "Доставка";
            this.DeliveryCheckBox.UseVisualStyleBackColor = true;
            // 
            // PaymentDateLabel
            // 
            this.PaymentDateLabel.AutoSize = true;
            this.PaymentDateLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PaymentDateLabel.ForeColor = System.Drawing.Color.White;
            this.PaymentDateLabel.Location = new System.Drawing.Point(264, 392);
            this.PaymentDateLabel.Name = "PaymentDateLabel";
            this.PaymentDateLabel.Size = new System.Drawing.Size(142, 23);
            this.PaymentDateLabel.TabIndex = 43;
            this.PaymentDateLabel.Text = "Дата поставки";
            // 
            // PurchaseDateLabel
            // 
            this.PurchaseDateLabel.AutoSize = true;
            this.PurchaseDateLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PurchaseDateLabel.ForeColor = System.Drawing.Color.White;
            this.PurchaseDateLabel.Location = new System.Drawing.Point(46, 392);
            this.PurchaseDateLabel.Name = "PurchaseDateLabel";
            this.PurchaseDateLabel.Size = new System.Drawing.Size(137, 23);
            this.PurchaseDateLabel.TabIndex = 42;
            this.PurchaseDateLabel.Text = "Дата покупки";
            // 
            // PaymentDateTimePicker
            // 
            this.PaymentDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PaymentDateTimePicker.Location = new System.Drawing.Point(268, 429);
            this.PaymentDateTimePicker.Name = "PaymentDateTimePicker";
            this.PaymentDateTimePicker.Size = new System.Drawing.Size(199, 30);
            this.PaymentDateTimePicker.TabIndex = 41;
            // 
            // PurchaseDateTimePicker
            // 
            this.PurchaseDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PurchaseDateTimePicker.Location = new System.Drawing.Point(40, 429);
            this.PurchaseDateTimePicker.Name = "PurchaseDateTimePicker";
            this.PurchaseDateTimePicker.Size = new System.Drawing.Size(199, 30);
            this.PurchaseDateTimePicker.TabIndex = 40;
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
            this.CreateButton.Location = new System.Drawing.Point(669, 477);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(138, 41);
            this.CreateButton.TabIndex = 14;
            this.CreateButton.Text = "Создать";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(40, 106);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.RowHeadersWidth = 51;
            this.DataGridView.RowTemplate.Height = 24;
            this.DataGridView.Size = new System.Drawing.Size(767, 267);
            this.DataGridView.TabIndex = 13;
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
            this.BackButton.Location = new System.Drawing.Point(40, 477);
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
            this.HeaderPanel.Controls.Add(this.CloseLabel);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(848, 100);
            this.HeaderPanel.TabIndex = 1;
            // 
            // CloseLabel
            // 
            this.CloseLabel.AutoSize = true;
            this.CloseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseLabel.ForeColor = System.Drawing.Color.White;
            this.CloseLabel.Location = new System.Drawing.Point(821, 0);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(27, 25);
            this.CloseLabel.TabIndex = 1;
            this.CloseLabel.Text = "X";
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // CreatePurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 548);
            this.Controls.Add(this.BodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreatePurchaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreatePurchaseForm";
            this.BodyPanel.ResumeLayout(false);
            this.BodyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.DateTimePicker PaymentDateTimePicker;
        private System.Windows.Forms.DateTimePicker PurchaseDateTimePicker;
        private System.Windows.Forms.CheckBox DeliveryCheckBox;
        private System.Windows.Forms.Label PaymentDateLabel;
        private System.Windows.Forms.Label PurchaseDateLabel;
        private System.Windows.Forms.Label PaymentTypeLabel;
        private System.Windows.Forms.ComboBox PaymentTypeComboBox;
    }
}