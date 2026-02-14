namespace PPR
{
    partial class FormStaff
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
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.lblPassportSeries = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPassportNumber = new System.Windows.Forms.Label();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtSearchStaff = new System.Windows.Forms.TextBox();
            this.btnDeleteStaff = new System.Windows.Forms.Button();
            this.btnEditStaff = new System.Windows.Forms.Button();
            this.lbldetails = new System.Windows.Forms.Label();
            this.txtStaffFio = new System.Windows.Forms.TextBox();
            this.lblGuestFio = new System.Windows.Forms.Label();
            this.pnlStaffDetails = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.pnlStaffDetails.SuspendLayout();
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
            this.btnBack.TabIndex = 65;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.BackColor = System.Drawing.Color.LightSalmon;
            this.btnAddStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStaff.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddStaff.ForeColor = System.Drawing.Color.Sienna;
            this.btnAddStaff.Location = new System.Drawing.Point(8, 331);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(217, 48);
            this.btnAddStaff.TabIndex = 64;
            this.btnAddStaff.Text = "Добавить сотрудника";
            this.btnAddStaff.UseVisualStyleBackColor = false;
            this.btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
            // 
            // lblPassportSeries
            // 
            this.lblPassportSeries.AutoSize = true;
            this.lblPassportSeries.ForeColor = System.Drawing.Color.Sienna;
            this.lblPassportSeries.Location = new System.Drawing.Point(3, 86);
            this.lblPassportSeries.Name = "lblPassportSeries";
            this.lblPassportSeries.Size = new System.Drawing.Size(78, 16);
            this.lblPassportSeries.TabIndex = 6;
            this.lblPassportSeries.Text = "Должность";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(121, 108);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.ReadOnly = true;
            this.txtLogin.Size = new System.Drawing.Size(240, 22);
            this.txtLogin.TabIndex = 5;
            // 
            // lblPassportNumber
            // 
            this.lblPassportNumber.AutoSize = true;
            this.lblPassportNumber.ForeColor = System.Drawing.Color.Sienna;
            this.lblPassportNumber.Location = new System.Drawing.Point(3, 114);
            this.lblPassportNumber.Name = "lblPassportNumber";
            this.lblPassportNumber.Size = new System.Drawing.Size(46, 16);
            this.lblPassportNumber.TabIndex = 4;
            this.lblPassportNumber.Text = "Логин";
            // 
            // dgvStaff
            // 
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            this.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.GridColor = System.Drawing.Color.Peru;
            this.dgvStaff.Location = new System.Drawing.Point(8, 80);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.ReadOnly = true;
            this.dgvStaff.RowHeadersVisible = false;
            this.dgvStaff.RowHeadersWidth = 51;
            this.dgvStaff.RowTemplate.Height = 24;
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.Size = new System.Drawing.Size(217, 244);
            this.dgvStaff.TabIndex = 62;
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(121, 80);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.ReadOnly = true;
            this.txtPosition.Size = new System.Drawing.Size(240, 22);
            this.txtPosition.TabIndex = 7;
            // 
            // txtSearchStaff
            // 
            this.txtSearchStaff.Location = new System.Drawing.Point(8, 52);
            this.txtSearchStaff.Name = "txtSearchStaff";
            this.txtSearchStaff.Size = new System.Drawing.Size(217, 22);
            this.txtSearchStaff.TabIndex = 61;
            this.txtSearchStaff.TextChanged += new System.EventHandler(this.txtSearchStaff_TextChanged);
            // 
            // btnDeleteStaff
            // 
            this.btnDeleteStaff.BackColor = System.Drawing.Color.LightSalmon;
            this.btnDeleteStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteStaff.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteStaff.ForeColor = System.Drawing.Color.Sienna;
            this.btnDeleteStaff.Location = new System.Drawing.Point(3, 298);
            this.btnDeleteStaff.Name = "btnDeleteStaff";
            this.btnDeleteStaff.Size = new System.Drawing.Size(364, 28);
            this.btnDeleteStaff.TabIndex = 44;
            this.btnDeleteStaff.Text = "Удалить";
            this.btnDeleteStaff.UseVisualStyleBackColor = false;
            this.btnDeleteStaff.Click += new System.EventHandler(this.btnDeleteStaff_Click);
            // 
            // btnEditStaff
            // 
            this.btnEditStaff.AutoEllipsis = true;
            this.btnEditStaff.BackColor = System.Drawing.Color.LightSalmon;
            this.btnEditStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditStaff.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditStaff.ForeColor = System.Drawing.Color.Sienna;
            this.btnEditStaff.Location = new System.Drawing.Point(3, 263);
            this.btnEditStaff.Name = "btnEditStaff";
            this.btnEditStaff.Size = new System.Drawing.Size(364, 29);
            this.btnEditStaff.TabIndex = 45;
            this.btnEditStaff.Text = "Редактировать";
            this.btnEditStaff.UseVisualStyleBackColor = false;
            this.btnEditStaff.Click += new System.EventHandler(this.btnEditStaff_Click);
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
            // txtStaffFio
            // 
            this.txtStaffFio.Location = new System.Drawing.Point(121, 52);
            this.txtStaffFio.Name = "txtStaffFio";
            this.txtStaffFio.ReadOnly = true;
            this.txtStaffFio.Size = new System.Drawing.Size(240, 22);
            this.txtStaffFio.TabIndex = 11;
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
            // pnlStaffDetails
            // 
            this.pnlStaffDetails.BackColor = System.Drawing.Color.PapayaWhip;
            this.pnlStaffDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStaffDetails.Controls.Add(this.label4);
            this.pnlStaffDetails.Controls.Add(this.label3);
            this.pnlStaffDetails.Controls.Add(this.label1);
            this.pnlStaffDetails.Controls.Add(this.txtEmail);
            this.pnlStaffDetails.Controls.Add(this.txtAddress);
            this.pnlStaffDetails.Controls.Add(this.txtPhone);
            this.pnlStaffDetails.Controls.Add(this.btnDeleteStaff);
            this.pnlStaffDetails.Controls.Add(this.btnEditStaff);
            this.pnlStaffDetails.Controls.Add(this.lbldetails);
            this.pnlStaffDetails.Controls.Add(this.txtStaffFio);
            this.pnlStaffDetails.Controls.Add(this.lblGuestFio);
            this.pnlStaffDetails.Controls.Add(this.txtPosition);
            this.pnlStaffDetails.Controls.Add(this.lblPassportSeries);
            this.pnlStaffDetails.Controls.Add(this.txtLogin);
            this.pnlStaffDetails.Controls.Add(this.lblPassportNumber);
            this.pnlStaffDetails.Location = new System.Drawing.Point(244, 52);
            this.pnlStaffDetails.Name = "pnlStaffDetails";
            this.pnlStaffDetails.Size = new System.Drawing.Size(372, 327);
            this.pnlStaffDetails.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Yu Gothic Light", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Sienna;
            this.label2.Location = new System.Drawing.Point(152, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 36);
            this.label2.TabIndex = 60;
            this.label2.Text = "Тех. персонал";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(121, 136);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(240, 22);
            this.txtPhone.TabIndex = 46;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(121, 192);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(240, 22);
            this.txtAddress.TabIndex = 47;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(121, 164);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(240, 22);
            this.txtEmail.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Sienna;
            this.label1.Location = new System.Drawing.Point(3, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "Номер телефона";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Sienna;
            this.label3.Location = new System.Drawing.Point(3, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 50;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Sienna;
            this.label4.Location = new System.Drawing.Point(3, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "Адресс";
            // 
            // FormStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PPR.Properties.Resources._5465662569738603782_120;
            this.ClientSize = new System.Drawing.Size(624, 381);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddStaff);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.txtSearchStaff);
            this.Controls.Add(this.pnlStaffDetails);
            this.Controls.Add(this.label2);
            this.Name = "FormStaff";
            this.Text = "FormStaff";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.pnlStaffDetails.ResumeLayout(false);
            this.pnlStaffDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.Label lblPassportSeries;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPassportNumber;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtSearchStaff;
        private System.Windows.Forms.Button btnDeleteStaff;
        private System.Windows.Forms.Button btnEditStaff;
        private System.Windows.Forms.Label lbldetails;
        private System.Windows.Forms.TextBox txtStaffFio;
        private System.Windows.Forms.Label lblGuestFio;
        private System.Windows.Forms.Panel pnlStaffDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}