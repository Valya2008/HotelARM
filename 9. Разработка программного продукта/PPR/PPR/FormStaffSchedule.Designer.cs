namespace PPR
{
    partial class FormStaffSchedule
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
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPositionFilter = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveSchedule = new System.Windows.Forms.Button();
            this.btnLoadSchedule = new System.Windows.Forms.Button();
            this.lblPositionFilter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(27, 50);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.RowHeadersWidth = 51;
            this.dgvSchedule.RowTemplate.Height = 24;
            this.dgvSchedule.Size = new System.Drawing.Size(555, 255);
            this.dgvSchedule.TabIndex = 0;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(27, 22);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 22);
            this.dtpStartDate.TabIndex = 1;
            // 
            // cmbPositionFilter
            // 
            this.cmbPositionFilter.FormattingEnabled = true;
            this.cmbPositionFilter.Location = new System.Drawing.Point(382, 20);
            this.cmbPositionFilter.Name = "cmbPositionFilter";
            this.cmbPositionFilter.Size = new System.Drawing.Size(200, 24);
            this.cmbPositionFilter.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSalmon;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.Sienna;
            this.btnCancel.Location = new System.Drawing.Point(426, 342);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(156, 28);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSaveSchedule
            // 
            this.btnSaveSchedule.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSaveSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSchedule.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveSchedule.ForeColor = System.Drawing.Color.Sienna;
            this.btnSaveSchedule.Location = new System.Drawing.Point(27, 342);
            this.btnSaveSchedule.Name = "btnSaveSchedule";
            this.btnSaveSchedule.Size = new System.Drawing.Size(156, 27);
            this.btnSaveSchedule.TabIndex = 67;
            this.btnSaveSchedule.Text = "Сохранить";
            this.btnSaveSchedule.UseVisualStyleBackColor = false;
            this.btnSaveSchedule.Click += new System.EventHandler(this.btnSaveSchedule_Click);
            // 
            // btnLoadSchedule
            // 
            this.btnLoadSchedule.BackColor = System.Drawing.Color.LightSalmon;
            this.btnLoadSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadSchedule.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadSchedule.ForeColor = System.Drawing.Color.Sienna;
            this.btnLoadSchedule.Location = new System.Drawing.Point(219, 342);
            this.btnLoadSchedule.Name = "btnLoadSchedule";
            this.btnLoadSchedule.Size = new System.Drawing.Size(173, 28);
            this.btnLoadSchedule.TabIndex = 69;
            this.btnLoadSchedule.Text = "Отменить";
            this.btnLoadSchedule.UseVisualStyleBackColor = false;
            // 
            // lblPositionFilter
            // 
            this.lblPositionFilter.AutoSize = true;
            this.lblPositionFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblPositionFilter.ForeColor = System.Drawing.Color.Sienna;
            this.lblPositionFilter.Location = new System.Drawing.Point(253, 27);
            this.lblPositionFilter.Name = "lblPositionFilter";
            this.lblPositionFilter.Size = new System.Drawing.Size(61, 16);
            this.lblPositionFilter.TabIndex = 70;
            this.lblPositionFilter.Text = "ГРАФИК";
            // 
            // FormStaffSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PPR.Properties.Resources._5465662569738603782_120;
            this.ClientSize = new System.Drawing.Size(624, 381);
            this.Controls.Add(this.lblPositionFilter);
            this.Controls.Add(this.btnLoadSchedule);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveSchedule);
            this.Controls.Add(this.cmbPositionFilter);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dgvSchedule);
            this.Name = "FormStaffSchedule";
            this.Text = "FormStaffSchedule";
            this.Load += new System.EventHandler(this.FormStaffSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cmbPositionFilter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveSchedule;
        private System.Windows.Forms.Button btnLoadSchedule;
        private System.Windows.Forms.Label lblPositionFilter;
    }
}