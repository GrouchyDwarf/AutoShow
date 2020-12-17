namespace AutoShow
{
    partial class StartForm
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
            this.ClientLabel = new System.Windows.Forms.Label();
            this.DeliveryManLabel = new System.Windows.Forms.Label();
            this.AdminLabel = new System.Windows.Forms.Label();
            this.ManagerLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ManagerPictureBox = new System.Windows.Forms.PictureBox();
            this.AdminPictureBox = new System.Windows.Forms.PictureBox();
            this.ClientPictureBox = new System.Windows.Forms.PictureBox();
            this.DeliveryManPictureBox = new System.Windows.Forms.PictureBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.CheckInButton = new System.Windows.Forms.Button();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.AutoShowLabel = new System.Windows.Forms.Label();
            this.BodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManagerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdminPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryManPictureBox)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BodyPanel
            // 
            this.BodyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(23)))), ((int)(((byte)(29)))));
            this.BodyPanel.Controls.Add(this.ClientLabel);
            this.BodyPanel.Controls.Add(this.DeliveryManLabel);
            this.BodyPanel.Controls.Add(this.AdminLabel);
            this.BodyPanel.Controls.Add(this.ManagerLabel);
            this.BodyPanel.Controls.Add(this.StatusLabel);
            this.BodyPanel.Controls.Add(this.ManagerPictureBox);
            this.BodyPanel.Controls.Add(this.AdminPictureBox);
            this.BodyPanel.Controls.Add(this.ClientPictureBox);
            this.BodyPanel.Controls.Add(this.DeliveryManPictureBox);
            this.BodyPanel.Controls.Add(this.LoginButton);
            this.BodyPanel.Controls.Add(this.CheckInButton);
            this.BodyPanel.Controls.Add(this.HeaderPanel);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(501, 503);
            this.BodyPanel.TabIndex = 1;
            // 
            // ClientLabel
            // 
            this.ClientLabel.AutoSize = true;
            this.ClientLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClientLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientLabel.ForeColor = System.Drawing.Color.White;
            this.ClientLabel.Location = new System.Drawing.Point(378, 366);
            this.ClientLabel.Name = "ClientLabel";
            this.ClientLabel.Size = new System.Drawing.Size(79, 23);
            this.ClientLabel.TabIndex = 21;
            this.ClientLabel.Text = "Клиент";
            this.ClientLabel.Click += new System.EventHandler(this.ClientLabel_Click);
            // 
            // DeliveryManLabel
            // 
            this.DeliveryManLabel.AutoSize = true;
            this.DeliveryManLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeliveryManLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeliveryManLabel.ForeColor = System.Drawing.Color.White;
            this.DeliveryManLabel.Location = new System.Drawing.Point(36, 366);
            this.DeliveryManLabel.Name = "DeliveryManLabel";
            this.DeliveryManLabel.Size = new System.Drawing.Size(114, 23);
            this.DeliveryManLabel.TabIndex = 20;
            this.DeliveryManLabel.Text = "Доставщик";
            this.DeliveryManLabel.Click += new System.EventHandler(this.DeliveryManLabel_Click);
            // 
            // AdminLabel
            // 
            this.AdminLabel.AutoSize = true;
            this.AdminLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdminLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdminLabel.ForeColor = System.Drawing.Color.White;
            this.AdminLabel.Location = new System.Drawing.Point(385, 215);
            this.AdminLabel.Name = "AdminLabel";
            this.AdminLabel.Size = new System.Drawing.Size(72, 23);
            this.AdminLabel.TabIndex = 19;
            this.AdminLabel.Text = "Админ";
            this.AdminLabel.Click += new System.EventHandler(this.AdminLabel_Click);
            // 
            // ManagerLabel
            // 
            this.ManagerLabel.AutoSize = true;
            this.ManagerLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ManagerLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ManagerLabel.ForeColor = System.Drawing.Color.White;
            this.ManagerLabel.Location = new System.Drawing.Point(36, 215);
            this.ManagerLabel.Name = "ManagerLabel";
            this.ManagerLabel.Size = new System.Drawing.Size(105, 23);
            this.ManagerLabel.TabIndex = 18;
            this.ManagerLabel.Text = "Менеджер";
            this.ManagerLabel.Click += new System.EventHandler(this.ManagerLabel_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(162, 112);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(191, 26);
            this.StatusLabel.TabIndex = 17;
            this.StatusLabel.Text = "Выберите статус";
            // 
            // ManagerPictureBox
            // 
            this.ManagerPictureBox.Image = global::AutoShow.Properties.Resources.Manager;
            this.ManagerPictureBox.InitialImage = global::AutoShow.Properties.Resources.Manager;
            this.ManagerPictureBox.Location = new System.Drawing.Point(40, 103);
            this.ManagerPictureBox.Name = "ManagerPictureBox";
            this.ManagerPictureBox.Size = new System.Drawing.Size(100, 100);
            this.ManagerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ManagerPictureBox.TabIndex = 16;
            this.ManagerPictureBox.TabStop = false;
            // 
            // AdminPictureBox
            // 
            this.AdminPictureBox.Image = global::AutoShow.Properties.Resources.Admin;
            this.AdminPictureBox.InitialImage = global::AutoShow.Properties.Resources.Admin;
            this.AdminPictureBox.Location = new System.Drawing.Point(369, 103);
            this.AdminPictureBox.Name = "AdminPictureBox";
            this.AdminPictureBox.Size = new System.Drawing.Size(100, 100);
            this.AdminPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AdminPictureBox.TabIndex = 15;
            this.AdminPictureBox.TabStop = false;
            // 
            // ClientPictureBox
            // 
            this.ClientPictureBox.Image = global::AutoShow.Properties.Resources.User;
            this.ClientPictureBox.InitialImage = global::AutoShow.Properties.Resources.User;
            this.ClientPictureBox.Location = new System.Drawing.Point(369, 251);
            this.ClientPictureBox.Name = "ClientPictureBox";
            this.ClientPictureBox.Size = new System.Drawing.Size(100, 100);
            this.ClientPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ClientPictureBox.TabIndex = 14;
            this.ClientPictureBox.TabStop = false;
            // 
            // DeliveryManPictureBox
            // 
            this.DeliveryManPictureBox.Image = global::AutoShow.Properties.Resources.DeliveryMan;
            this.DeliveryManPictureBox.InitialImage = global::AutoShow.Properties.Resources.DeliveryMan;
            this.DeliveryManPictureBox.Location = new System.Drawing.Point(40, 251);
            this.DeliveryManPictureBox.Name = "DeliveryManPictureBox";
            this.DeliveryManPictureBox.Size = new System.Drawing.Size(100, 100);
            this.DeliveryManPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeliveryManPictureBox.TabIndex = 13;
            this.DeliveryManPictureBox.TabStop = false;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(5)))), ((int)(((byte)(227)))));
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(331, 402);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(138, 41);
            this.LoginButton.TabIndex = 12;
            this.LoginButton.Text = "Вход";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // CheckInButton
            // 
            this.CheckInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.CheckInButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckInButton.FlatAppearance.BorderSize = 0;
            this.CheckInButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(5)))), ((int)(((byte)(227)))));
            this.CheckInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckInButton.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckInButton.ForeColor = System.Drawing.Color.White;
            this.CheckInButton.Location = new System.Drawing.Point(40, 402);
            this.CheckInButton.Name = "CheckInButton";
            this.CheckInButton.Size = new System.Drawing.Size(217, 41);
            this.CheckInButton.TabIndex = 11;
            this.CheckInButton.Text = "Регистрация";
            this.CheckInButton.UseVisualStyleBackColor = false;
            this.CheckInButton.Click += new System.EventHandler(this.CheckInButton_Click);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(4)))), ((int)(((byte)(92)))));
            this.HeaderPanel.Controls.Add(this.CloseLabel);
            this.HeaderPanel.Controls.Add(this.AutoShowLabel);
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
            // AutoShowLabel
            // 
            this.AutoShowLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoShowLabel.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutoShowLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.AutoShowLabel.Location = new System.Drawing.Point(0, 0);
            this.AutoShowLabel.Name = "AutoShowLabel";
            this.AutoShowLabel.Size = new System.Drawing.Size(501, 100);
            this.AutoShowLabel.TabIndex = 0;
            this.AutoShowLabel.Text = "Автосалон";
            this.AutoShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 503);
            this.Controls.Add(this.BodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartForm";
            this.BodyPanel.ResumeLayout(false);
            this.BodyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManagerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdminPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryManPictureBox)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.Label AutoShowLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button CheckInButton;
        private System.Windows.Forms.PictureBox DeliveryManPictureBox;
        private System.Windows.Forms.PictureBox ClientPictureBox;
        private System.Windows.Forms.PictureBox AdminPictureBox;
        private System.Windows.Forms.PictureBox ManagerPictureBox;
        private System.Windows.Forms.Label AdminLabel;
        private System.Windows.Forms.Label ManagerLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label ClientLabel;
        private System.Windows.Forms.Label DeliveryManLabel;
    }
}