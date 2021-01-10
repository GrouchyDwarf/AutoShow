namespace AutoShow
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BodyPanel = new System.Windows.Forms.Panel();
            this.ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ToLabel = new System.Windows.Forms.Label();
            this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ClientLabel = new System.Windows.Forms.Label();
            this.CarBrandLabel = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.CarModelLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.ChartLabel = new System.Windows.Forms.Label();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.ModelChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BrandChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ClientChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BodyPanel.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModelChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrandChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientChart)).BeginInit();
            this.SuspendLayout();
            // 
            // BodyPanel
            // 
            this.BodyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(23)))), ((int)(((byte)(29)))));
            this.BodyPanel.Controls.Add(this.ClientChart);
            this.BodyPanel.Controls.Add(this.BrandChart);
            this.BodyPanel.Controls.Add(this.ModelChart);
            this.BodyPanel.Controls.Add(this.ToDateTimePicker);
            this.BodyPanel.Controls.Add(this.ToLabel);
            this.BodyPanel.Controls.Add(this.FromDateTimePicker);
            this.BodyPanel.Controls.Add(this.FromLabel);
            this.BodyPanel.Controls.Add(this.ClientLabel);
            this.BodyPanel.Controls.Add(this.CarBrandLabel);
            this.BodyPanel.Controls.Add(this.SearchButton);
            this.BodyPanel.Controls.Add(this.CarModelLabel);
            this.BodyPanel.Controls.Add(this.BackButton);
            this.BodyPanel.Controls.Add(this.HeaderPanel);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(989, 802);
            this.BodyPanel.TabIndex = 11;
            // 
            // ToDateTimePicker
            // 
            this.ToDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToDateTimePicker.Location = new System.Drawing.Point(778, 451);
            this.ToDateTimePicker.Name = "ToDateTimePicker";
            this.ToDateTimePicker.Size = new System.Drawing.Size(199, 30);
            this.ToDateTimePicker.TabIndex = 57;
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
            // FromDateTimePicker
            // 
            this.FromDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FromDateTimePicker.Location = new System.Drawing.Point(84, 451);
            this.FromDateTimePicker.Name = "FromDateTimePicker";
            this.FromDateTimePicker.Size = new System.Drawing.Size(199, 30);
            this.FromDateTimePicker.TabIndex = 55;
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
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(5)))), ((int)(((byte)(227)))));
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchButton.ForeColor = System.Drawing.Color.White;
            this.SearchButton.Location = new System.Drawing.Point(800, 716);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(177, 41);
            this.SearchButton.TabIndex = 49;
            this.SearchButton.Text = "Посчитать";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
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
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(5)))), ((int)(((byte)(227)))));
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(84, 716);
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
            this.HeaderPanel.Controls.Add(this.ChartLabel);
            this.HeaderPanel.Controls.Add(this.CloseLabel);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(989, 100);
            this.HeaderPanel.TabIndex = 1;
            // 
            // ChartLabel
            // 
            this.ChartLabel.AutoSize = true;
            this.ChartLabel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChartLabel.ForeColor = System.Drawing.Color.White;
            this.ChartLabel.Location = new System.Drawing.Point(435, 39);
            this.ChartLabel.Name = "ChartLabel";
            this.ChartLabel.Size = new System.Drawing.Size(175, 35);
            this.ChartLabel.TabIndex = 47;
            this.ChartLabel.Text = "Диаграммы";
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
            // ModelChart
            // 
            chartArea6.Name = "ChartArea1";
            this.ModelChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.ModelChart.Legends.Add(legend6);
            this.ModelChart.Location = new System.Drawing.Point(100, 141);
            this.ModelChart.Name = "ModelChart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Покупки";
            this.ModelChart.Series.Add(series6);
            this.ModelChart.Size = new System.Drawing.Size(300, 300);
            this.ModelChart.TabIndex = 58;
            this.ModelChart.Text = "ModelChart";
            // 
            // BrandChart
            // 
            chartArea5.Name = "ChartArea1";
            this.BrandChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.BrandChart.Legends.Add(legend5);
            this.BrandChart.Location = new System.Drawing.Point(632, 141);
            this.BrandChart.Name = "BrandChart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Покупки";
            this.BrandChart.Series.Add(series5);
            this.BrandChart.Size = new System.Drawing.Size(300, 300);
            this.BrandChart.TabIndex = 59;
            this.BrandChart.Text = "chart1";
            // 
            // ClientChart
            // 
            chartArea4.Name = "ChartArea1";
            this.ClientChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.ClientChart.Legends.Add(legend4);
            this.ClientChart.Location = new System.Drawing.Point(377, 457);
            this.ClientChart.Name = "ClientChart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Покупки";
            this.ClientChart.Series.Add(series4);
            this.ClientChart.Size = new System.Drawing.Size(300, 300);
            this.ClientChart.TabIndex = 60;
            this.ClientChart.Text = "chart2";
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 802);
            this.Controls.Add(this.BodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChartForm";
            this.BodyPanel.ResumeLayout(false);
            this.BodyPanel.PerformLayout();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModelChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrandChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.DateTimePicker ToDateTimePicker;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.DateTimePicker FromDateTimePicker;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.Label ClientLabel;
        private System.Windows.Forms.Label CarBrandLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label CarModelLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label ChartLabel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart ModelChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ClientChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart BrandChart;
    }
}