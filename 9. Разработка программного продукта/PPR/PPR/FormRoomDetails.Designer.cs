namespace PPR
{
    partial class FormRoomDetails
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
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnCancelRoom = new System.Windows.Forms.Button();
            this.btnSaveRoom = new System.Windows.Forms.Button();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.lblFloor = new System.Windows.Forms.Label();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.txtPricePerNight = new System.Windows.Forms.TextBox();
            this.lblPricePerNight = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(187, 69);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(240, 24);
            this.cmbRoomType.TabIndex = 79;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(187, 183);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(240, 24);
            this.cmbStatus.TabIndex = 78;
            // 
            // btnCancelRoom
            // 
            this.btnCancelRoom.BackColor = System.Drawing.Color.LightSalmon;
            this.btnCancelRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelRoom.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancelRoom.ForeColor = System.Drawing.Color.Sienna;
            this.btnCancelRoom.Location = new System.Drawing.Point(256, 268);
            this.btnCancelRoom.Name = "btnCancelRoom";
            this.btnCancelRoom.Size = new System.Drawing.Size(217, 48);
            this.btnCancelRoom.TabIndex = 77;
            this.btnCancelRoom.Text = "Отменить";
            this.btnCancelRoom.UseVisualStyleBackColor = false;
            this.btnCancelRoom.Click += new System.EventHandler(this.btnCancelRoom_Click);
            // 
            // btnSaveRoom
            // 
            this.btnSaveRoom.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSaveRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveRoom.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveRoom.ForeColor = System.Drawing.Color.Sienna;
            this.btnSaveRoom.Location = new System.Drawing.Point(21, 268);
            this.btnSaveRoom.Name = "btnSaveRoom";
            this.btnSaveRoom.Size = new System.Drawing.Size(217, 48);
            this.btnSaveRoom.TabIndex = 76;
            this.btnSaveRoom.Text = "Сохранить";
            this.btnSaveRoom.UseVisualStyleBackColor = false;
            this.btnSaveRoom.Click += new System.EventHandler(this.btnSaveRoom_Click);
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Location = new System.Drawing.Point(187, 40);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(240, 22);
            this.txtRoomNumber.TabIndex = 75;
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblRoomNumber.ForeColor = System.Drawing.Color.Sienna;
            this.lblRoomNumber.Location = new System.Drawing.Point(69, 43);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(109, 16);
            this.lblRoomNumber.TabIndex = 74;
            this.lblRoomNumber.Text = "Номер комнаты";
            // 
            // txtFloor
            // 
            this.txtFloor.Location = new System.Drawing.Point(187, 155);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(240, 22);
            this.txtFloor.TabIndex = 73;
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.BackColor = System.Drawing.Color.Transparent;
            this.lblFloor.ForeColor = System.Drawing.Color.Sienna;
            this.lblFloor.Location = new System.Drawing.Point(69, 155);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(41, 16);
            this.lblFloor.TabIndex = 72;
            this.lblFloor.Text = "Этаж";
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.BackColor = System.Drawing.Color.Transparent;
            this.lblRoomType.ForeColor = System.Drawing.Color.Sienna;
            this.lblRoomType.Location = new System.Drawing.Point(69, 72);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(91, 16);
            this.lblRoomType.TabIndex = 71;
            this.lblRoomType.Text = "Тип комнаты";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(187, 99);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(240, 22);
            this.txtCapacity.TabIndex = 70;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.BackColor = System.Drawing.Color.Transparent;
            this.lblCapacity.ForeColor = System.Drawing.Color.Sienna;
            this.lblCapacity.Location = new System.Drawing.Point(69, 102);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(119, 16);
            this.lblCapacity.TabIndex = 69;
            this.lblCapacity.Text = "Количество мест";
            // 
            // txtPricePerNight
            // 
            this.txtPricePerNight.Location = new System.Drawing.Point(187, 127);
            this.txtPricePerNight.Name = "txtPricePerNight";
            this.txtPricePerNight.Size = new System.Drawing.Size(240, 22);
            this.txtPricePerNight.TabIndex = 68;
            // 
            // lblPricePerNight
            // 
            this.lblPricePerNight.AutoSize = true;
            this.lblPricePerNight.BackColor = System.Drawing.Color.Transparent;
            this.lblPricePerNight.ForeColor = System.Drawing.Color.Sienna;
            this.lblPricePerNight.Location = new System.Drawing.Point(69, 127);
            this.lblPricePerNight.Name = "lblPricePerNight";
            this.lblPricePerNight.Size = new System.Drawing.Size(77, 16);
            this.lblPricePerNight.TabIndex = 67;
            this.lblPricePerNight.Text = "Стоимость";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.Color.Sienna;
            this.lblStatus.Location = new System.Drawing.Point(69, 183);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 16);
            this.lblStatus.TabIndex = 66;
            this.lblStatus.Text = "Статус";
            // 
            // FormRoomDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PPR.Properties.Resources._5465662569738603782_120;
            this.ClientSize = new System.Drawing.Size(494, 328);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnCancelRoom);
            this.Controls.Add(this.btnSaveRoom);
            this.Controls.Add(this.txtRoomNumber);
            this.Controls.Add(this.lblRoomNumber);
            this.Controls.Add(this.txtFloor);
            this.Controls.Add(this.lblFloor);
            this.Controls.Add(this.lblRoomType);
            this.Controls.Add(this.txtCapacity);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.txtPricePerNight);
            this.Controls.Add(this.lblPricePerNight);
            this.Controls.Add(this.lblStatus);
            this.Name = "FormRoomDetails";
            this.Text = "FormRoomDetails";
            this.Load += new System.EventHandler(this.FormRoomDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnCancelRoom;
        private System.Windows.Forms.Button btnSaveRoom;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox txtPricePerNight;
        private System.Windows.Forms.Label lblPricePerNight;
        private System.Windows.Forms.Label lblStatus;
    }
}