namespace PPR
{
    partial class FormGuests
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAddGuest = new System.Windows.Forms.Button();
            this.btnDeleteGuest = new System.Windows.Forms.Button();
            this.btnEditGuest = new System.Windows.Forms.Button();
            this.lbldetails = new System.Windows.Forms.Label();
            this.txtGuestFio = new System.Windows.Forms.TextBox();
            this.lblGuestFio = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.dgvGuests = new System.Windows.Forms.DataGridView();
            this.txtSearchGuest = new System.Windows.Forms.TextBox();
            this.txtPassportSeries = new System.Windows.Forms.TextBox();
            this.lblPassportSeries = new System.Windows.Forms.Label();
            this.txtPassportNumber = new System.Windows.Forms.TextBox();
            this.lblPassportNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.pnlGuestDetails = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).BeginInit();
            this.pnlGuestDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.Color.Sienna;
            this.btnBack.Location = new System.Drawing.Point(8, 1);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(101, 43);
            this.btnBack.TabIndex = 59;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.BackColor = System.Drawing.Color.LightSalmon;
            this.btnAddGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGuest.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddGuest.ForeColor = System.Drawing.Color.Sienna;
            this.btnAddGuest.Location = new System.Drawing.Point(8, 331);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(217, 48);
            this.btnAddGuest.TabIndex = 58;
            this.btnAddGuest.Text = "Добавить нового гостя";
            this.btnAddGuest.UseVisualStyleBackColor = false;
            this.btnAddGuest.Click += new System.EventHandler(this.btnAddGuest_Click);
            // 
            // btnDeleteGuest
            // 
            this.btnDeleteGuest.BackColor = System.Drawing.Color.LightSalmon;
            this.btnDeleteGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteGuest.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteGuest.ForeColor = System.Drawing.Color.Sienna;
            this.btnDeleteGuest.Location = new System.Drawing.Point(3, 298);
            this.btnDeleteGuest.Name = "btnDeleteGuest";
            this.btnDeleteGuest.Size = new System.Drawing.Size(364, 28);
            this.btnDeleteGuest.TabIndex = 44;
            this.btnDeleteGuest.Text = "Удалить";
            this.btnDeleteGuest.UseVisualStyleBackColor = false;
            this.btnDeleteGuest.Click += new System.EventHandler(this.btnDeleteGuest_Click);
            // 
            // btnEditGuest
            // 
            this.btnEditGuest.AutoEllipsis = true;
            this.btnEditGuest.BackColor = System.Drawing.Color.LightSalmon;
            this.btnEditGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditGuest.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditGuest.ForeColor = System.Drawing.Color.Sienna;
            this.btnEditGuest.Location = new System.Drawing.Point(3, 263);
            this.btnEditGuest.Name = "btnEditGuest";
            this.btnEditGuest.Size = new System.Drawing.Size(364, 29);
            this.btnEditGuest.TabIndex = 45;
            this.btnEditGuest.Text = "Редактировать";
            this.btnEditGuest.UseVisualStyleBackColor = false;
            this.btnEditGuest.Click += new System.EventHandler(this.btnEditGuest_Click);
            // 
            // lbldetails
            // 
            this.lbldetails.AutoSize = true;
            this.lbldetails.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbldetails.ForeColor = System.Drawing.Color.Sienna;
            this.lbldetails.Location = new System.Drawing.Point(69, 17);
            this.lbldetails.Name = "lbldetails";
            this.lbldetails.Size = new System.Drawing.Size(201, 21);
            this.lbldetails.TabIndex = 12;
            this.lbldetails.Text = "Полная информация";
            // 
            // txtGuestFio
            // 
            this.txtGuestFio.Location = new System.Drawing.Point(121, 52);
            this.txtGuestFio.Name = "txtGuestFio";
            this.txtGuestFio.ReadOnly = true;
            this.txtGuestFio.Size = new System.Drawing.Size(240, 22);
            this.txtGuestFio.TabIndex = 11;
            // 
            // lblGuestFio
            // 
            this.lblGuestFio.AutoSize = true;
            this.lblGuestFio.ForeColor = System.Drawing.Color.Sienna;
            this.lblGuestFio.Location = new System.Drawing.Point(3, 55);
            this.lblGuestFio.Name = "lblGuestFio";
            this.lblGuestFio.Size = new System.Drawing.Size(38, 16);
            this.lblGuestFio.TabIndex = 10;
            this.lblGuestFio.Text = "ФИО";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(121, 164);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(240, 22);
            this.txtEmail.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.Sienna;
            this.lblEmail.Location = new System.Drawing.Point(3, 167);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 16);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            // 
            // dgvGuests
            // 
            this.dgvGuests.AllowUserToAddRows = false;
            this.dgvGuests.AllowUserToDeleteRows = false;
            this.dgvGuests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGuests.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvGuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuests.GridColor = System.Drawing.Color.Peru;
            this.dgvGuests.Location = new System.Drawing.Point(8, 80);
            this.dgvGuests.Name = "dgvGuests";
            this.dgvGuests.ReadOnly = true;
            this.dgvGuests.RowHeadersVisible = false;
            this.dgvGuests.RowHeadersWidth = 51;
            this.dgvGuests.RowTemplate.Height = 24;
            this.dgvGuests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGuests.Size = new System.Drawing.Size(217, 244);
            this.dgvGuests.TabIndex = 56;
            // 
            // txtSearchGuest
            // 
            this.txtSearchGuest.Location = new System.Drawing.Point(8, 52);
            this.txtSearchGuest.Name = "txtSearchGuest";
            this.txtSearchGuest.Size = new System.Drawing.Size(217, 22);
            this.txtSearchGuest.TabIndex = 55;
            // 
            // txtPassportSeries
            // 
            this.txtPassportSeries.Location = new System.Drawing.Point(121, 80);
            this.txtPassportSeries.Name = "txtPassportSeries";
            this.txtPassportSeries.ReadOnly = true;
            this.txtPassportSeries.Size = new System.Drawing.Size(240, 22);
            this.txtPassportSeries.TabIndex = 7;
            // 
            // lblPassportSeries
            // 
            this.lblPassportSeries.AutoSize = true;
            this.lblPassportSeries.ForeColor = System.Drawing.Color.Sienna;
            this.lblPassportSeries.Location = new System.Drawing.Point(3, 86);
            this.lblPassportSeries.Name = "lblPassportSeries";
            this.lblPassportSeries.Size = new System.Drawing.Size(112, 16);
            this.lblPassportSeries.TabIndex = 6;
            this.lblPassportSeries.Text = "Серия паспорта";
            // 
            // txtPassportNumber
            // 
            this.txtPassportNumber.Location = new System.Drawing.Point(121, 108);
            this.txtPassportNumber.Name = "txtPassportNumber";
            this.txtPassportNumber.ReadOnly = true;
            this.txtPassportNumber.Size = new System.Drawing.Size(240, 22);
            this.txtPassportNumber.TabIndex = 5;
            // 
            // lblPassportNumber
            // 
            this.lblPassportNumber.AutoSize = true;
            this.lblPassportNumber.ForeColor = System.Drawing.Color.Sienna;
            this.lblPassportNumber.Location = new System.Drawing.Point(3, 114);
            this.lblPassportNumber.Name = "lblPassportNumber";
            this.lblPassportNumber.Size = new System.Drawing.Size(115, 16);
            this.lblPassportNumber.TabIndex = 4;
            this.lblPassportNumber.Text = "Номер паспорта";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(121, 136);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.ReadOnly = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(240, 22);
            this.txtPhoneNumber.TabIndex = 3;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.ForeColor = System.Drawing.Color.Sienna;
            this.lblPhoneNumber.Location = new System.Drawing.Point(3, 139);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(67, 16);
            this.lblPhoneNumber.TabIndex = 2;
            this.lblPhoneNumber.Text = "Телефон";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(121, 192);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(240, 22);
            this.txtAddress.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.ForeColor = System.Drawing.Color.Sienna;
            this.lblAddress.Location = new System.Drawing.Point(3, 195);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(47, 16);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Адрес";
            // 
            // pnlGuestDetails
            // 
            this.pnlGuestDetails.BackColor = System.Drawing.Color.PapayaWhip;
            this.pnlGuestDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGuestDetails.Controls.Add(this.btnDeleteGuest);
            this.pnlGuestDetails.Controls.Add(this.btnEditGuest);
            this.pnlGuestDetails.Controls.Add(this.lbldetails);
            this.pnlGuestDetails.Controls.Add(this.txtGuestFio);
            this.pnlGuestDetails.Controls.Add(this.lblGuestFio);
            this.pnlGuestDetails.Controls.Add(this.txtEmail);
            this.pnlGuestDetails.Controls.Add(this.lblEmail);
            this.pnlGuestDetails.Controls.Add(this.txtPassportSeries);
            this.pnlGuestDetails.Controls.Add(this.lblPassportSeries);
            this.pnlGuestDetails.Controls.Add(this.txtPassportNumber);
            this.pnlGuestDetails.Controls.Add(this.lblPassportNumber);
            this.pnlGuestDetails.Controls.Add(this.txtPhoneNumber);
            this.pnlGuestDetails.Controls.Add(this.lblPhoneNumber);
            this.pnlGuestDetails.Controls.Add(this.txtAddress);
            this.pnlGuestDetails.Controls.Add(this.lblAddress);
            this.pnlGuestDetails.Location = new System.Drawing.Point(244, 52);
            this.pnlGuestDetails.Name = "pnlGuestDetails";
            this.pnlGuestDetails.Size = new System.Drawing.Size(372, 327);
            this.pnlGuestDetails.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Yu Gothic Light", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Sienna;
            this.label2.Location = new System.Drawing.Point(219, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 36);
            this.label2.TabIndex = 54;
            this.label2.Text = "Гости";
            // 
            // FormGuests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PPR.Properties.Resources._5465662569738603782_120;
            this.ClientSize = new System.Drawing.Size(624, 381);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddGuest);
            this.Controls.Add(this.dgvGuests);
            this.Controls.Add(this.txtSearchGuest);
            this.Controls.Add(this.pnlGuestDetails);
            this.Controls.Add(this.label2);
            this.Name = "FormGuests";
            this.Text = "FormGuests";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).EndInit();
            this.pnlGuestDetails.ResumeLayout(false);
            this.pnlGuestDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAddGuest;
        private System.Windows.Forms.Button btnDeleteGuest;
        private System.Windows.Forms.Button btnEditGuest;
        private System.Windows.Forms.Label lbldetails;
        private System.Windows.Forms.TextBox txtGuestFio;
        private System.Windows.Forms.Label lblGuestFio;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.DataGridView dgvGuests;
        private System.Windows.Forms.TextBox txtSearchGuest;
        private System.Windows.Forms.TextBox txtPassportSeries;
        private System.Windows.Forms.Label lblPassportSeries;
        private System.Windows.Forms.TextBox txtPassportNumber;
        private System.Windows.Forms.Label lblPassportNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Panel pnlGuestDetails;
        private System.Windows.Forms.Label label2;
    }
}