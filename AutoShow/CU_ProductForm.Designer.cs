namespace AutoShow
{
    partial class CU_ProductForm
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
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.MarkupNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MarkupLabel = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.BodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarkupNumericUpDown)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BodyPanel
            // 
            this.BodyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(23)))), ((int)(((byte)(29)))));
            this.BodyPanel.Controls.Add(this.DataGridView);
            this.BodyPanel.Controls.Add(this.MarkupNumericUpDown);
            this.BodyPanel.Controls.Add(this.MarkupLabel);
            this.BodyPanel.Controls.Add(this.CreateButton);
            this.BodyPanel.Controls.Add(this.UpdateButton);
            this.BodyPanel.Controls.Add(this.BackButton);
            this.BodyPanel.Controls.Add(this.HeaderPanel);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(625, 532);
            this.BodyPanel.TabIndex = 9;
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(31, 117);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.RowHeadersWidth = 51;
            this.DataGridView.RowTemplate.Height = 24;
            this.DataGridView.Size = new System.Drawing.Size(560, 198);
            this.DataGridView.TabIndex = 41;
            // 
            // MarkupNumericUpDown
            // 
            this.MarkupNumericUpDown.DecimalPlaces = 4;
            this.MarkupNumericUpDown.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MarkupNumericUpDown.Location = new System.Drawing.Point(511, 390);
            this.MarkupNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MarkupNumericUpDown.Name = "MarkupNumericUpDown";
            this.MarkupNumericUpDown.Size = new System.Drawing.Size(80, 30);
            this.MarkupNumericUpDown.TabIndex = 40;
            // 
            // MarkupLabel
            // 
            this.MarkupLabel.AutoSize = true;
            this.MarkupLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MarkupLabel.ForeColor = System.Drawing.Color.White;
            this.MarkupLabel.Location = new System.Drawing.Point(500, 353);
            this.MarkupLabel.Name = "MarkupLabel";
            this.MarkupLabel.Size = new System.Drawing.Size(91, 23);
            this.MarkupLabel.TabIndex = 39;
            this.MarkupLabel.Text = "Наценка";
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
            this.CreateButton.Location = new System.Drawing.Point(449, 457);
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
            this.UpdateButton.Location = new System.Drawing.Point(40, 389);
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
            this.BackButton.Location = new System.Drawing.Point(40, 457);
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
            this.HeaderPanel.Size = new System.Drawing.Size(625, 100);
            this.HeaderPanel.TabIndex = 1;
            // 
            // CloseLabel
            // 
            this.CloseLabel.AutoSize = true;
            this.CloseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseLabel.ForeColor = System.Drawing.Color.White;
            this.CloseLabel.Location = new System.Drawing.Point(598, 0);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(27, 25);
            this.CloseLabel.TabIndex = 1;
            this.CloseLabel.Text = "X";
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // CU_ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 532);
            this.Controls.Add(this.BodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CU_ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CU_ProductForm";
            this.BodyPanel.ResumeLayout(false);
            this.BodyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarkupNumericUpDown)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.NumericUpDown MarkupNumericUpDown;
        private System.Windows.Forms.Label MarkupLabel;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.DataGridView DataGridView;
    }
}