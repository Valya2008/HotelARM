namespace PPR
{
    partial class FormRooms
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
            this.btnBackRooms = new System.Windows.Forms.Button();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.btnEditRoom = new System.Windows.Forms.Button();
            this.lbldetails = new System.Windows.Forms.Label();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.lblFloor = new System.Windows.Forms.Label();
            this.txtRoomType = new System.Windows.Forms.TextBox();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.pnlRoomsDetails = new System.Windows.Forms.Panel();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.txtPricePerNight = new System.Windows.Forms.TextBox();
            this.lblPricePerNight = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.txtSearchRoom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRoomTypeFilter = new System.Windows.Forms.ComboBox();
            this.pnlRoomsDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBackRooms
            // 
            this.btnBackRooms.BackColor = System.Drawing.Color.Transparent;
            this.btnBackRooms.FlatAppearance.BorderSize = 0;
            this.btnBackRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackRooms.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBackRooms.ForeColor = System.Drawing.Color.Sienna;
            this.btnBackRooms.Location = new System.Drawing.Point(17, 2);
            this.btnBackRooms.Name = "btnBackRooms";
            this.btnBackRooms.Size = new System.Drawing.Size(101, 34);
            this.btnBackRooms.TabIndex = 52;
            this.btnBackRooms.Text = "Назад";
            this.btnBackRooms.UseVisualStyleBackColor = false;
            this.btnBackRooms.Click += new System.EventHandler(this.btnBackRooms_Click_1);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.BackColor = System.Drawing.Color.LightSalmon;
            this.btnDeleteRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRoom.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteRoom.ForeColor = System.Drawing.Color.Sienna;
            this.btnDeleteRoom.Location = new System.Drawing.Point(3, 306);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(364, 28);
            this.btnDeleteRoom.TabIndex = 44;
            this.btnDeleteRoom.Text = "Удалить";
            this.btnDeleteRoom.UseVisualStyleBackColor = false;
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
            // 
            // btnEditRoom
            // 
            this.btnEditRoom.AutoEllipsis = true;
            this.btnEditRoom.BackColor = System.Drawing.Color.LightSalmon;
            this.btnEditRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditRoom.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditRoom.ForeColor = System.Drawing.Color.Sienna;
            this.btnEditRoom.Location = new System.Drawing.Point(3, 271);
            this.btnEditRoom.Name = "btnEditRoom";
            this.btnEditRoom.Size = new System.Drawing.Size(364, 29);
            this.btnEditRoom.TabIndex = 45;
            this.btnEditRoom.Text = "Редактировать";
            this.btnEditRoom.UseVisualStyleBackColor = false;
            this.btnEditRoom.Click += new System.EventHandler(this.btnEditRoom_Click);
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
            // txtRoomNumber
            // 
            this.txtRoomNumber.Location = new System.Drawing.Point(121, 52);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.ReadOnly = true;
            this.txtRoomNumber.Size = new System.Drawing.Size(240, 22);
            this.txtRoomNumber.TabIndex = 11;
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.ForeColor = System.Drawing.Color.Sienna;
            this.lblRoomNumber.Location = new System.Drawing.Point(3, 55);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(109, 16);
            this.lblRoomNumber.TabIndex = 10;
            this.lblRoomNumber.Text = "Номер комнаты";
            // 
            // txtFloor
            // 
            this.txtFloor.Location = new System.Drawing.Point(121, 164);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.ReadOnly = true;
            this.txtFloor.Size = new System.Drawing.Size(240, 22);
            this.txtFloor.TabIndex = 9;
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.ForeColor = System.Drawing.Color.Sienna;
            this.lblFloor.Location = new System.Drawing.Point(3, 167);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(41, 16);
            this.lblFloor.TabIndex = 8;
            this.lblFloor.Text = "Этаж";
            // 
            // txtRoomType
            // 
            this.txtRoomType.Location = new System.Drawing.Point(121, 80);
            this.txtRoomType.Name = "txtRoomType";
            this.txtRoomType.ReadOnly = true;
            this.txtRoomType.Size = new System.Drawing.Size(240, 22);
            this.txtRoomType.TabIndex = 7;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.ForeColor = System.Drawing.Color.Sienna;
            this.lblRoomType.Location = new System.Drawing.Point(3, 86);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(91, 16);
            this.lblRoomType.TabIndex = 6;
            this.lblRoomType.Text = "Тип комнаты";
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.BackColor = System.Drawing.Color.LightSalmon;
            this.btnAddRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRoom.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddRoom.ForeColor = System.Drawing.Color.Sienna;
            this.btnAddRoom.Location = new System.Drawing.Point(8, 352);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(217, 28);
            this.btnAddRoom.TabIndex = 55;
            this.btnAddRoom.Text = "Добавить новый номер\r\n";
            this.btnAddRoom.UseVisualStyleBackColor = false;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click_1);
            // 
            // pnlRoomsDetails
            // 
            this.pnlRoomsDetails.BackColor = System.Drawing.Color.PapayaWhip;
            this.pnlRoomsDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRoomsDetails.Controls.Add(this.btnDeleteRoom);
            this.pnlRoomsDetails.Controls.Add(this.btnEditRoom);
            this.pnlRoomsDetails.Controls.Add(this.lbldetails);
            this.pnlRoomsDetails.Controls.Add(this.txtRoomNumber);
            this.pnlRoomsDetails.Controls.Add(this.lblRoomNumber);
            this.pnlRoomsDetails.Controls.Add(this.txtFloor);
            this.pnlRoomsDetails.Controls.Add(this.lblFloor);
            this.pnlRoomsDetails.Controls.Add(this.txtRoomType);
            this.pnlRoomsDetails.Controls.Add(this.lblRoomType);
            this.pnlRoomsDetails.Controls.Add(this.txtCapacity);
            this.pnlRoomsDetails.Controls.Add(this.lblCapacity);
            this.pnlRoomsDetails.Controls.Add(this.txtPricePerNight);
            this.pnlRoomsDetails.Controls.Add(this.lblPricePerNight);
            this.pnlRoomsDetails.Controls.Add(this.txtStatus);
            this.pnlRoomsDetails.Controls.Add(this.lblStatus);
            this.pnlRoomsDetails.Location = new System.Drawing.Point(244, 41);
            this.pnlRoomsDetails.Name = "pnlRoomsDetails";
            this.pnlRoomsDetails.Size = new System.Drawing.Size(372, 339);
            this.pnlRoomsDetails.TabIndex = 54;
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(121, 108);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.ReadOnly = true;
            this.txtCapacity.Size = new System.Drawing.Size(240, 22);
            this.txtCapacity.TabIndex = 5;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.ForeColor = System.Drawing.Color.Sienna;
            this.lblCapacity.Location = new System.Drawing.Point(3, 114);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(119, 16);
            this.lblCapacity.TabIndex = 4;
            this.lblCapacity.Text = "Количество мест";
            // 
            // txtPricePerNight
            // 
            this.txtPricePerNight.Location = new System.Drawing.Point(121, 136);
            this.txtPricePerNight.Name = "txtPricePerNight";
            this.txtPricePerNight.ReadOnly = true;
            this.txtPricePerNight.Size = new System.Drawing.Size(240, 22);
            this.txtPricePerNight.TabIndex = 3;
            // 
            // lblPricePerNight
            // 
            this.lblPricePerNight.AutoSize = true;
            this.lblPricePerNight.ForeColor = System.Drawing.Color.Sienna;
            this.lblPricePerNight.Location = new System.Drawing.Point(3, 139);
            this.lblPricePerNight.Name = "lblPricePerNight";
            this.lblPricePerNight.Size = new System.Drawing.Size(77, 16);
            this.lblPricePerNight.TabIndex = 2;
            this.lblPricePerNight.Text = "Стоимость";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(121, 192);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(240, 22);
            this.txtStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Sienna;
            this.lblStatus.Location = new System.Drawing.Point(3, 195);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Статус";
            // 
            // dgvRooms
            // 
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.AllowUserToDeleteRows = false;
            this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.GridColor = System.Drawing.Color.Peru;
            this.dgvRooms.Location = new System.Drawing.Point(8, 102);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.RowHeadersVisible = false;
            this.dgvRooms.RowHeadersWidth = 51;
            this.dgvRooms.RowTemplate.Height = 24;
            this.dgvRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRooms.Size = new System.Drawing.Size(217, 244);
            this.dgvRooms.TabIndex = 53;
            this.dgvRooms.SelectionChanged += new System.EventHandler(this.dgvRooms_SelectionChanged);
            // 
            // txtSearchRoom
            // 
            this.txtSearchRoom.Location = new System.Drawing.Point(8, 71);
            this.txtSearchRoom.Name = "txtSearchRoom";
            this.txtSearchRoom.Size = new System.Drawing.Size(217, 22);
            this.txtSearchRoom.TabIndex = 51;
            this.txtSearchRoom.TextChanged += new System.EventHandler(this.txtSearchRoom_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Yu Gothic Light", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Sienna;
            this.label2.Location = new System.Drawing.Point(220, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 36);
            this.label2.TabIndex = 50;
            this.label2.Text = "Номера";
            // 
            // cmbRoomTypeFilter
            // 
            this.cmbRoomTypeFilter.FormattingEnabled = true;
            this.cmbRoomTypeFilter.Location = new System.Drawing.Point(8, 41);
            this.cmbRoomTypeFilter.Name = "cmbRoomTypeFilter";
            this.cmbRoomTypeFilter.Size = new System.Drawing.Size(217, 24);
            this.cmbRoomTypeFilter.TabIndex = 56;
            this.cmbRoomTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cmbRoomTypeFilter_SelectedIndexChanged);
            // 
            // FormRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PPR.Properties.Resources._5465662569738603782_120;
            this.ClientSize = new System.Drawing.Size(624, 381);
            this.Controls.Add(this.btnBackRooms);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.pnlRoomsDetails);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.txtSearchRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbRoomTypeFilter);
            this.Name = "FormRooms";
            this.Text = "FormRooms";
            this.Load += new System.EventHandler(this.FormRooms_Load);
            this.pnlRoomsDetails.ResumeLayout(false);
            this.pnlRoomsDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackRooms;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.Button btnEditRoom;
        private System.Windows.Forms.Label lbldetails;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.TextBox txtRoomType;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Panel pnlRoomsDetails;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox txtPricePerNight;
        private System.Windows.Forms.Label lblPricePerNight;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.TextBox txtSearchRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRoomTypeFilter;
    }
}