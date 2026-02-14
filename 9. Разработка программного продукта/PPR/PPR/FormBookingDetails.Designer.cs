namespace PPR
{
    partial class FormBookingDetails
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
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.cmbBookingStatus = new System.Windows.Forms.ComboBox();
            this.cmbGuest = new System.Windows.Forms.ComboBox();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnSaveBooking = new System.Windows.Forms.Button();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblPassportNumber = new System.Windows.Forms.Label();
            this.dtpCheckInDate = new System.Windows.Forms.DateTimePicker();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.dtpCheckOutDate = new System.Windows.Forms.DateTimePicker();
            this.lblPatronymic = new System.Windows.Forms.Label();
            this.lblPassportSeries = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbRoom
            // 
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(185, 135);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(240, 24);
            this.cmbRoom.TabIndex = 80;
            // 
            // cmbBookingStatus
            // 
            this.cmbBookingStatus.FormattingEnabled = true;
            this.cmbBookingStatus.Location = new System.Drawing.Point(185, 163);
            this.cmbBookingStatus.Name = "cmbBookingStatus";
            this.cmbBookingStatus.Size = new System.Drawing.Size(240, 24);
            this.cmbBookingStatus.TabIndex = 79;
            // 
            // cmbGuest
            // 
            this.cmbGuest.AllowDrop = true;
            this.cmbGuest.FormattingEnabled = true;
            this.cmbGuest.Location = new System.Drawing.Point(185, 49);
            this.cmbGuest.Name = "cmbGuest";
            this.cmbGuest.Size = new System.Drawing.Size(240, 24);
            this.cmbGuest.TabIndex = 78;
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.BackColor = System.Drawing.Color.LightSalmon;
            this.btnCancelBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBooking.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancelBooking.ForeColor = System.Drawing.Color.Sienna;
            this.btnCancelBooking.Location = new System.Drawing.Point(256, 251);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(217, 48);
            this.btnCancelBooking.TabIndex = 77;
            this.btnCancelBooking.Text = "Отменить";
            this.btnCancelBooking.UseVisualStyleBackColor = false;
            // 
            // btnSaveBooking
            // 
            this.btnSaveBooking.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSaveBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBooking.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveBooking.ForeColor = System.Drawing.Color.Sienna;
            this.btnSaveBooking.Location = new System.Drawing.Point(22, 251);
            this.btnSaveBooking.Name = "btnSaveBooking";
            this.btnSaveBooking.Size = new System.Drawing.Size(217, 48);
            this.btnSaveBooking.TabIndex = 76;
            this.btnSaveBooking.Text = "Сохранить";
            this.btnSaveBooking.UseVisualStyleBackColor = false;
            this.btnSaveBooking.Click += new System.EventHandler(this.btnSaveBooking_Click);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.ForeColor = System.Drawing.Color.Sienna;
            this.lblLastName.Location = new System.Drawing.Point(67, 54);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(87, 16);
            this.lblLastName.TabIndex = 75;
            this.lblLastName.Text = "Выбор гостя";
            // 
            // lblPassportNumber
            // 
            this.lblPassportNumber.AutoSize = true;
            this.lblPassportNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblPassportNumber.ForeColor = System.Drawing.Color.Sienna;
            this.lblPassportNumber.Location = new System.Drawing.Point(67, 166);
            this.lblPassportNumber.Name = "lblPassportNumber";
            this.lblPassportNumber.Size = new System.Drawing.Size(96, 16);
            this.lblPassportNumber.TabIndex = 74;
            this.lblPassportNumber.Text = "Статус брони";
            // 
            // dtpCheckInDate
            // 
            this.dtpCheckInDate.Location = new System.Drawing.Point(185, 79);
            this.dtpCheckInDate.Name = "dtpCheckInDate";
            this.dtpCheckInDate.Size = new System.Drawing.Size(240, 22);
            this.dtpCheckInDate.TabIndex = 73;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.ForeColor = System.Drawing.Color.Sienna;
            this.lblFirstName.Location = new System.Drawing.Point(67, 85);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(90, 16);
            this.lblFirstName.TabIndex = 72;
            this.lblFirstName.Text = "Дата заезда";
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.Location = new System.Drawing.Point(185, 107);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(240, 22);
            this.dtpCheckOutDate.TabIndex = 71;
            // 
            // lblPatronymic
            // 
            this.lblPatronymic.AutoSize = true;
            this.lblPatronymic.BackColor = System.Drawing.Color.Transparent;
            this.lblPatronymic.ForeColor = System.Drawing.Color.Sienna;
            this.lblPatronymic.Location = new System.Drawing.Point(67, 113);
            this.lblPatronymic.Name = "lblPatronymic";
            this.lblPatronymic.Size = new System.Drawing.Size(91, 16);
            this.lblPatronymic.TabIndex = 70;
            this.lblPatronymic.Text = "Дата выезда";
            // 
            // lblPassportSeries
            // 
            this.lblPassportSeries.AutoSize = true;
            this.lblPassportSeries.BackColor = System.Drawing.Color.Transparent;
            this.lblPassportSeries.ForeColor = System.Drawing.Color.Sienna;
            this.lblPassportSeries.Location = new System.Drawing.Point(67, 138);
            this.lblPassportSeries.Name = "lblPassportSeries";
            this.lblPassportSeries.Size = new System.Drawing.Size(101, 16);
            this.lblPassportSeries.TabIndex = 69;
            this.lblPassportSeries.Text = "Выбор номера";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(185, 191);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(240, 22);
            this.txtTotalAmount.TabIndex = 68;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblPhoneNumber.ForeColor = System.Drawing.Color.Sienna;
            this.lblPhoneNumber.Location = new System.Drawing.Point(67, 194);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(77, 16);
            this.lblPhoneNumber.TabIndex = 67;
            this.lblPhoneNumber.Text = "Стоимость";
            // 
            // FormBookingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PPR.Properties.Resources._5465662569738603782_120;
            this.ClientSize = new System.Drawing.Size(494, 328);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.cmbBookingStatus);
            this.Controls.Add(this.cmbGuest);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.btnSaveBooking);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblPassportNumber);
            this.Controls.Add(this.dtpCheckInDate);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.dtpCheckOutDate);
            this.Controls.Add(this.lblPatronymic);
            this.Controls.Add(this.lblPassportSeries);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblPhoneNumber);
            this.Name = "FormBookingDetails";
            this.Text = "FormBookingDetails";
            this.Load += new System.EventHandler(this.FormBookingDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.ComboBox cmbBookingStatus;
        private System.Windows.Forms.ComboBox cmbGuest;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnSaveBooking;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblPassportNumber;
        private System.Windows.Forms.DateTimePicker dtpCheckInDate;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.DateTimePicker dtpCheckOutDate;
        private System.Windows.Forms.Label lblPatronymic;
        private System.Windows.Forms.Label lblPassportSeries;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblPhoneNumber;
    }
}