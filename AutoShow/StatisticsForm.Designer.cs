namespace AutoShow
{
    partial class StatisticsForm
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.CarModelDataGridView = new System.Windows.Forms.DataGridView();
            this.BackButton = new System.Windows.Forms.Button();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.CarModelLabel = new System.Windows.Forms.Label();
            this.CarBrandDataGridView = new System.Windows.Forms.DataGridView();
            this.CarBrandLabel = new System.Windows.Forms.Label();
            this.ClientDataGridView = new System.Windows.Forms.DataGridView();
            this.ClientLabel = new System.Windows.Forms.Label();
            this.FromLabel = new System.Windows.Forms.Label();
            this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ToLabel = new System.Windows.Forms.Label();
            this.ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StatisticsLabel = new System.Windows.Forms.Label();
            this.BodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarModelDataGridView)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarBrandDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BodyPanel
            // 
            this.BodyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(23)))), ((int)(((byte)(29)))));
            this.BodyPanel.Controls.Add(this.ToDateTimePicker);
            this.BodyPanel.Controls.Add(this.ToLabel);
            this.BodyPanel.Controls.Add(this.FromDateTimePicker);
            this.BodyPanel.Controls.Add(this.FromLabel);
            this.BodyPanel.Controls.Add(this.ClientLabel);
            this.BodyPanel.Controls.Add(this.ClientDataGridView);
            this.BodyPanel.Controls.Add(this.CarBrandLabel);
            this.BodyPanel.Controls.Add(this.CarBrandDataGridView);
            this.BodyPanel.Controls.Add(this.SearchButton);
            this.BodyPanel.Controls.Add(this.CarModelLabel);
            this.BodyPanel.Controls.Add(this.CarModelDataGridView);
            this.BodyPanel.Controls.Add(this.BackButton);
            this.BodyPanel.Controls.Add(this.HeaderPanel);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(989, 650);
            this.BodyPanel.TabIndex = 10;
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(5)))), ((int)(((byte)(227)))));
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchButton.ForeColor = System.Drawing.Color.White;
            this.SearchButton.Location = new System.Drawing.Point(782, 561);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(177, 41);
            this.SearchButton.TabIndex = 49;
            this.SearchButton.Text = "Посчитать";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // CarModelDataGridView
            // 
            this.CarModelDataGridView.AllowUserToAddRows = false;
            this.CarModelDataGridView.AllowUserToDeleteRows = false;
            this.CarModelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarModelDataGridView.Location = new System.Drawing.Point(49, 156);
            this.CarModelDataGridView.Name = "CarModelDataGridView";
            this.CarModelDataGridView.ReadOnly = true;
            this.CarModelDataGridView.RowHeadersWidth = 51;
            this.CarModelDataGridView.RowTemplate.Height = 24;
            this.CarModelDataGridView.Size = new System.Drawing.Size(444, 217);
            this.CarModelDataGridView.TabIndex = 13;
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
            this.BackButton.Location = new System.Drawing.Point(49, 561);
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
            this.HeaderPanel.Controls.Add(this.StatisticsLabel);
            this.HeaderPanel.Controls.Add(this.CloseLabel);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(989, 100);
            this.HeaderPanel.TabIndex = 1;
            // 
            // CloseLabel
            // 
            this.CloseLabel.AutoSize = true;
            this.CloseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseLabel.ForeColor = System.Drawing.Color.White;
            this.CloseLabel.Location = new System.Drawing.Point(962, 0);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(27, 25);
            this.CloseLabel.TabIndex = 1;
            this.CloseLabel.Text = "X";
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // CarModelLabel
            // 
            this.CarModelLabel.AutoSize = true;
            this.CarModelLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarModelLabel.ForeColor = System.Drawing.Color.White;
            this.CarModelLabel.Location = new System.Drawing.Point(219, 115);
            this.CarModelLabel.Name = "CarModelLabel";
            this.CarModelLabel.Size = new System.Drawing.Size(119, 23);
            this.CarModelLabel.TabIndex = 46;
            this.CarModelLabel.Text = "По моделям";
            // 
            // CarBrandDataGridView
            // 
            this.CarBrandDataGridView.AllowUserToAddRows = false;
            this.CarBrandDataGridView.AllowUserToDeleteRows = false;
            this.CarBrandDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarBrandDataGridView.Location = new System.Drawing.Point(524, 156);
            this.CarBrandDataGridView.Name = "CarBrandDataGridView";
            this.CarBrandDataGridView.ReadOnly = true;
            this.CarBrandDataGridView.RowHeadersWidth = 51;
            this.CarBrandDataGridView.RowTemplate.Height = 24;
            this.CarBrandDataGridView.Size = new System.Drawing.Size(444, 217);
            this.CarBrandDataGridView.TabIndex = 50;
            // 
            // CarBrandLabel
            // 
            this.CarBrandLabel.AutoSize = true;
            this.CarBrandLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarBrandLabel.ForeColor = System.Drawing.Color.White;
            this.CarBrandLabel.Location = new System.Drawing.Point(705, 115);
            this.CarBrandLabel.Name = "CarBrandLabel";
            this.CarBrandLabel.Size = new System.Drawing.Size(110, 23);
            this.CarBrandLabel.TabIndex = 51;
            this.CarBrandLabel.Text = "По маркам";
            // 
            // ClientDataGridView
            // 
            this.ClientDataGridView.AllowUserToAddRows = false;
            this.ClientDataGridView.AllowUserToDeleteRows = false;
            this.ClientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientDataGridView.Location = new System.Drawing.Point(289, 411);
            this.ClientDataGridView.Name = "ClientDataGridView";
            this.ClientDataGridView.ReadOnly = true;
            this.ClientDataGridView.RowHeadersWidth = 51;
            this.ClientDataGridView.RowTemplate.Height = 24;
            this.ClientDataGridView.Size = new System.Drawing.Size(444, 217);
            this.ClientDataGridView.TabIndex = 52;
            // 
            // ClientLabel
            // 
            this.ClientLabel.AutoSize = true;
            this.ClientLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientLabel.ForeColor = System.Drawing.Color.White;
            this.ClientLabel.Location = new System.Drawing.Point(463, 376);
            this.ClientLabel.Name = "ClientLabel";
            this.ClientLabel.Size = new System.Drawing.Size(130, 23);
            this.ClientLabel.TabIndex = 53;
            this.ClientLabel.Text = "По клиентам";
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FromLabel.ForeColor = System.Drawing.Color.White;
            this.FromLabel.Location = new System.Drawing.Point(45, 457);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(24, 23);
            this.FromLabel.TabIndex = 54;
            this.FromLabel.Text = "С";
            // 
            // FromDateTimePicker
            // 
            this.FromDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FromDateTimePicker.Location = new System.Drawing.Point(84, 451);
            this.FromDateTimePicker.Name = "FromDateTimePicker";
            this.FromDateTimePicker.Size = new System.Drawing.Size(199, 30);
            this.FromDateTimePicker.TabIndex = 55;
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToLabel.ForeColor = System.Drawing.Color.White;
            this.ToLabel.Location = new System.Drawing.Point(739, 458);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(35, 23);
            this.ToLabel.TabIndex = 56;
            this.ToLabel.Text = "По";
            // 
            // ToDateTimePicker
            // 
            this.ToDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToDateTimePicker.Location = new System.Drawing.Point(778, 451);
            this.ToDateTimePicker.Name = "ToDateTimePicker";
            this.ToDateTimePicker.Size = new System.Drawing.Size(199, 30);
            this.ToDateTimePicker.TabIndex = 57;
            // 
            // StatisticsLabel
            // 
            this.StatisticsLabel.AutoSize = true;
            this.StatisticsLabel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatisticsLabel.ForeColor = System.Drawing.Color.White;
            this.StatisticsLabel.Location = new System.Drawing.Point(435, 39);
            this.StatisticsLabel.Name = "StatisticsLabel";
            this.StatisticsLabel.Size = new System.Drawing.Size(176, 35);
            this.StatisticsLabel.TabIndex = 47;
            this.StatisticsLabel.Text = "Статистика";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 650);
            this.Controls.Add(this.BodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatisticsForm";
            this.BodyPanel.ResumeLayout(false);
            this.BodyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarModelDataGridView)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarBrandDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView CarModelDataGridView;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.Label CarModelLabel;
        private System.Windows.Forms.Label ClientLabel;
        private System.Windows.Forms.DataGridView ClientDataGridView;
        private System.Windows.Forms.Label CarBrandLabel;
        private System.Windows.Forms.DataGridView CarBrandDataGridView;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.DateTimePicker FromDateTimePicker;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.DateTimePicker ToDateTimePicker;
        private System.Windows.Forms.Label StatisticsLabel;
    }
}