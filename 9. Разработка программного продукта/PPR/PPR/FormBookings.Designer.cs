namespace PPR
{
    partial class FormBookings
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
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.txtSearchBooking = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoomTypeDisplay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteBooking = new System.Windows.Forms.Button();
            this.btnEditBooking = new System.Windows.Forms.Button();
            this.lbldetails = new System.Windows.Forms.Label();
            this.txtGuestName = new System.Windows.Forms.TextBox();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.txtBookingStatus = new System.Windows.Forms.TextBox();
            this.lblFloor = new System.Windows.Forms.Label();
            this.txtRoomDetails = new System.Windows.Forms.TextBox();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.txtCheckInDate = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.txtCheckOutDate = new System.Windows.Forms.TextBox();
            this.lblPricePerNight = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnBackBookings = new System.Windows.Forms.Button();
            this.btnAddBooking = new System.Windows.Forms.Button();
            this.pnlRoomsDetails = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.pnlRoomsDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBookings
            // 
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookings.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.GridColor = System.Drawing.Color.Peru;
            this.dgvBookings.Location = new System.Drawing.Point(8, 80);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.RowHeadersVisible = false;
            this.dgvBookings.RowHeadersWidth = 51;
            this.dgvBookings.RowTemplate.Height = 24;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.Size = new System.Drawing.Size(217, 244);
            this.dgvBookings.TabIndex = 58;
            this.dgvBookings.SelectionChanged += new System.EventHandler(this.dgvBookings_SelectionChanged);
            // 
            // txtSearchBooking
            // 
            this.txtSearchBooking.Location = new System.Drawing.Point(8, 52);
            this.txtSearchBooking.Name = "txtSearchBooking";
            this.txtSearchBooking.Size = new System.Drawing.Size(217, 22);
            this.txtSearchBooking.TabIndex = 56;
            this.txtSearchBooking.TextChanged += new System.EventHandler(this.txtSearchBooking_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Yu Gothic Light", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Sienna;
            this.label2.Location = new System.Drawing.Point(145, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 36);
            this.label2.TabIndex = 55;
            this.label2.Text = "Бронирования";
            // 
            // txtRoomTypeDisplay
            // 
            this.txtRoomTypeDisplay.Location = new System.Drawing.Point(121, 222);
            this.txtRoomTypeDisplay.Name = "txtRoomTypeDisplay";
            this.txtRoomTypeDisplay.ReadOnly = true;
            this.txtRoomTypeDisplay.Size = new System.Drawing.Size(240, 22);
            this.txtRoomTypeDisplay.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Sienna;
            this.label1.Location = new System.Drawing.Point(3, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "Тип номера";
            // 
            // btnDeleteBooking
            // 
            this.btnDeleteBooking.BackColor = System.Drawing.Color.LightSalmon;
            this.btnDeleteBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBooking.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteBooking.ForeColor = System.Drawing.Color.Sienna;
            this.btnDeleteBooking.Location = new System.Drawing.Point(3, 298);
            this.btnDeleteBooking.Name = "btnDeleteBooking";
            this.btnDeleteBooking.Size = new System.Drawing.Size(364, 28);
            this.btnDeleteBooking.TabIndex = 44;
            this.btnDeleteBooking.Text = "Удалить";
            this.btnDeleteBooking.UseVisualStyleBackColor = false;
            this.btnDeleteBooking.Click += new System.EventHandler(this.btnDeleteBooking_Click);
            // 
            // btnEditBooking
            // 
            this.btnEditBooking.AutoEllipsis = true;
            this.btnEditBooking.BackColor = System.Drawing.Color.LightSalmon;
            this.btnEditBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBooking.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditBooking.ForeColor = System.Drawing.Color.Sienna;
            this.btnEditBooking.Location = new System.Drawing.Point(3, 263);
            this.btnEditBooking.Name = "btnEditBooking";
            this.btnEditBooking.Size = new System.Drawing.Size(364, 29);
            this.btnEditBooking.TabIndex = 45;
            this.btnEditBooking.Text = "Редактировать";
            this.btnEditBooking.UseVisualStyleBackColor = false;
            this.btnEditBooking.Click += new System.EventHandler(this.btnEditBooking_Click);
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
            // txtGuestName
            // 
            this.txtGuestName.Location = new System.Drawing.Point(121, 52);
            this.txtGuestName.Name = "txtGuestName";
            this.txtGuestName.ReadOnly = true;
            this.txtGuestName.Size = new System.Drawing.Size(240, 22);
            this.txtGuestName.TabIndex = 11;
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.ForeColor = System.Drawing.Color.Sienna;
            this.lblRoomNumber.Location = new System.Drawing.Point(3, 55);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(76, 16);
            this.lblRoomNumber.TabIndex = 10;
            this.lblRoomNumber.Text = "ФИО гостя";
            // 
            // txtBookingStatus
            // 
            this.txtBookingStatus.Location = new System.Drawing.Point(121, 164);
            this.txtBookingStatus.Name = "txtBookingStatus";
            this.txtBookingStatus.ReadOnly = true;
            this.txtBookingStatus.Size = new System.Drawing.Size(240, 22);
            this.txtBookingStatus.TabIndex = 9;
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.ForeColor = System.Drawing.Color.Sienna;
            this.lblFloor.Location = new System.Drawing.Point(3, 167);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(96, 16);
            this.lblFloor.TabIndex = 8;
            this.lblFloor.Text = "Статус брони";
            // 
            // txtRoomDetails
            // 
            this.txtRoomDetails.Location = new System.Drawing.Point(121, 80);
            this.txtRoomDetails.Name = "txtRoomDetails";
            this.txtRoomDetails.ReadOnly = true;
            this.txtRoomDetails.Size = new System.Drawing.Size(240, 22);
            this.txtRoomDetails.TabIndex = 7;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.ForeColor = System.Drawing.Color.Sienna;
            this.lblRoomType.Location = new System.Drawing.Point(3, 86);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(109, 16);
            this.lblRoomType.TabIndex = 6;
            this.lblRoomType.Text = "Номер комнаты";
            // 
            // txtCheckInDate
            // 
            this.txtCheckInDate.Location = new System.Drawing.Point(121, 108);
            this.txtCheckInDate.Name = "txtCheckInDate";
            this.txtCheckInDate.ReadOnly = true;
            this.txtCheckInDate.Size = new System.Drawing.Size(240, 22);
            this.txtCheckInDate.TabIndex = 5;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.ForeColor = System.Drawing.Color.Sienna;
            this.lblCapacity.Location = new System.Drawing.Point(3, 114);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(90, 16);
            this.lblCapacity.TabIndex = 4;
            this.lblCapacity.Text = "Дата заезда";
            // 
            // txtCheckOutDate
            // 
            this.txtCheckOutDate.Location = new System.Drawing.Point(121, 136);
            this.txtCheckOutDate.Name = "txtCheckOutDate";
            this.txtCheckOutDate.ReadOnly = true;
            this.txtCheckOutDate.Size = new System.Drawing.Size(240, 22);
            this.txtCheckOutDate.TabIndex = 3;
            // 
            // lblPricePerNight
            // 
            this.lblPricePerNight.AutoSize = true;
            this.lblPricePerNight.ForeColor = System.Drawing.Color.Sienna;
            this.lblPricePerNight.Location = new System.Drawing.Point(3, 139);
            this.lblPricePerNight.Name = "lblPricePerNight";
            this.lblPricePerNight.Size = new System.Drawing.Size(91, 16);
            this.lblPricePerNight.TabIndex = 2;
            this.lblPricePerNight.Text = "Дата выезда";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(121, 192);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(240, 22);
            this.txtTotalAmount.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Sienna;
            this.lblStatus.Location = new System.Drawing.Point(3, 195);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(77, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Стоимость";
            // 
            // btnBackBookings
            // 
            this.btnBackBookings.BackColor = System.Drawing.Color.Transparent;
            this.btnBackBookings.FlatAppearance.BorderSize = 0;
            this.btnBackBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackBookings.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBackBookings.ForeColor = System.Drawing.Color.Sienna;
            this.btnBackBookings.Location = new System.Drawing.Point(17, 1);
            this.btnBackBookings.Name = "btnBackBookings";
            this.btnBackBookings.Size = new System.Drawing.Size(101, 43);
            this.btnBackBookings.TabIndex = 57;
            this.btnBackBookings.Text = "Назад";
            this.btnBackBookings.UseVisualStyleBackColor = false;
            this.btnBackBookings.Click += new System.EventHandler(this.btnBackBookings_Click);
            // 
            // btnAddBooking
            // 
            this.btnAddBooking.BackColor = System.Drawing.Color.LightSalmon;
            this.btnAddBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBooking.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddBooking.ForeColor = System.Drawing.Color.Sienna;
            this.btnAddBooking.Location = new System.Drawing.Point(8, 331);
            this.btnAddBooking.Name = "btnAddBooking";
            this.btnAddBooking.Size = new System.Drawing.Size(217, 48);
            this.btnAddBooking.TabIndex = 60;
            this.btnAddBooking.Text = "Добавить бронирование";
            this.btnAddBooking.UseVisualStyleBackColor = false;
            this.btnAddBooking.Click += new System.EventHandler(this.btnAddBooking_Click);
            // 
            // pnlRoomsDetails
            // 
            this.pnlRoomsDetails.BackColor = System.Drawing.Color.PapayaWhip;
            this.pnlRoomsDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRoomsDetails.Controls.Add(this.txtRoomTypeDisplay);
            this.pnlRoomsDetails.Controls.Add(this.label1);
            this.pnlRoomsDetails.Controls.Add(this.btnDeleteBooking);
            this.pnlRoomsDetails.Controls.Add(this.btnEditBooking);
            this.pnlRoomsDetails.Controls.Add(this.lbldetails);
            this.pnlRoomsDetails.Controls.Add(this.txtGuestName);
            this.pnlRoomsDetails.Controls.Add(this.lblRoomNumber);
            this.pnlRoomsDetails.Controls.Add(this.txtBookingStatus);
            this.pnlRoomsDetails.Controls.Add(this.lblFloor);
            this.pnlRoomsDetails.Controls.Add(this.txtRoomDetails);
            this.pnlRoomsDetails.Controls.Add(this.lblRoomType);
            this.pnlRoomsDetails.Controls.Add(this.txtCheckInDate);
            this.pnlRoomsDetails.Controls.Add(this.lblCapacity);
            this.pnlRoomsDetails.Controls.Add(this.txtCheckOutDate);
            this.pnlRoomsDetails.Controls.Add(this.lblPricePerNight);
            this.pnlRoomsDetails.Controls.Add(this.txtTotalAmount);
            this.pnlRoomsDetails.Controls.Add(this.lblStatus);
            this.pnlRoomsDetails.Location = new System.Drawing.Point(244, 52);
            this.pnlRoomsDetails.Name = "pnlRoomsDetails";
            this.pnlRoomsDetails.Size = new System.Drawing.Size(372, 327);
            this.pnlRoomsDetails.TabIndex = 59;
            // 
            // FormBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PPR.Properties.Resources._5465662569738603782_120;
            this.ClientSize = new System.Drawing.Size(624, 381);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.txtSearchBooking);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBackBookings);
            this.Controls.Add(this.btnAddBooking);
            this.Controls.Add(this.pnlRoomsDetails);
            this.Name = "FormBookings";
            this.Text = "FormBookings";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.pnlRoomsDetails.ResumeLayout(false);
            this.pnlRoomsDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.TextBox txtSearchBooking;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRoomTypeDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteBooking;
        private System.Windows.Forms.Button btnEditBooking;
        private System.Windows.Forms.Label lbldetails;
        private System.Windows.Forms.TextBox txtGuestName;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtBookingStatus;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.TextBox txtRoomDetails;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.TextBox txtCheckInDate;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox txtCheckOutDate;
        private System.Windows.Forms.Label lblPricePerNight;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnBackBookings;
        private System.Windows.Forms.Button btnAddBooking;
        private System.Windows.Forms.Panel pnlRoomsDetails;
    }
}