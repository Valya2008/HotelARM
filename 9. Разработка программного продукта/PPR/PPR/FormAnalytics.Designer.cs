namespace PPR
{
    partial class FormAnalytics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblFreeRooms = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBackAnalytics = new System.Windows.Forms.Button();
            this.chartOccupancy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTotalRooms = new System.Windows.Forms.Label();
            this.lblTotalIncome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartOccupancy)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFreeRooms
            // 
            this.lblFreeRooms.AutoSize = true;
            this.lblFreeRooms.BackColor = System.Drawing.Color.Transparent;
            this.lblFreeRooms.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFreeRooms.ForeColor = System.Drawing.Color.Sienna;
            this.lblFreeRooms.Location = new System.Drawing.Point(386, 115);
            this.lblFreeRooms.Name = "lblFreeRooms";
            this.lblFreeRooms.Size = new System.Drawing.Size(51, 21);
            this.lblFreeRooms.TabIndex = 59;
            this.lblFreeRooms.Text = "label";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Yu Gothic Light", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Sienna;
            this.label2.Location = new System.Drawing.Point(170, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 36);
            this.label2.TabIndex = 58;
            this.label2.Text = "Аналитика";
            // 
            // btnBackAnalytics
            // 
            this.btnBackAnalytics.BackColor = System.Drawing.Color.Transparent;
            this.btnBackAnalytics.FlatAppearance.BorderSize = 0;
            this.btnBackAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackAnalytics.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBackAnalytics.ForeColor = System.Drawing.Color.Sienna;
            this.btnBackAnalytics.Location = new System.Drawing.Point(12, 12);
            this.btnBackAnalytics.Name = "btnBackAnalytics";
            this.btnBackAnalytics.Size = new System.Drawing.Size(101, 43);
            this.btnBackAnalytics.TabIndex = 57;
            this.btnBackAnalytics.Text = "Назад";
            this.btnBackAnalytics.UseVisualStyleBackColor = false;
            // 
            // chartOccupancy
            // 
            chartArea2.Name = "ChartArea1";
            this.chartOccupancy.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartOccupancy.Legends.Add(legend2);
            this.chartOccupancy.Location = new System.Drawing.Point(12, 69);
            this.chartOccupancy.Name = "chartOccupancy";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartOccupancy.Series.Add(series2);
            this.chartOccupancy.Size = new System.Drawing.Size(359, 300);
            this.chartOccupancy.TabIndex = 62;
            this.chartOccupancy.Text = "chart1";
            // 
            // lblTotalRooms
            // 
            this.lblTotalRooms.AutoSize = true;
            this.lblTotalRooms.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRooms.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalRooms.ForeColor = System.Drawing.Color.Sienna;
            this.lblTotalRooms.Location = new System.Drawing.Point(386, 69);
            this.lblTotalRooms.Name = "lblTotalRooms";
            this.lblTotalRooms.Size = new System.Drawing.Size(51, 21);
            this.lblTotalRooms.TabIndex = 63;
            this.lblTotalRooms.Text = "label";
            // 
            // lblTotalIncome
            // 
            this.lblTotalIncome.AutoSize = true;
            this.lblTotalIncome.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalIncome.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalIncome.ForeColor = System.Drawing.Color.Sienna;
            this.lblTotalIncome.Location = new System.Drawing.Point(386, 154);
            this.lblTotalIncome.Name = "lblTotalIncome";
            this.lblTotalIncome.Size = new System.Drawing.Size(51, 21);
            this.lblTotalIncome.TabIndex = 64;
            this.lblTotalIncome.Text = "label";
            // 
            // FormAnalytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PPR.Properties.Resources._5465662569738603782_120;
            this.ClientSize = new System.Drawing.Size(638, 381);
            this.Controls.Add(this.lblTotalIncome);
            this.Controls.Add(this.lblTotalRooms);
            this.Controls.Add(this.chartOccupancy);
            this.Controls.Add(this.lblFreeRooms);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBackAnalytics);
            this.Name = "FormAnalytics";
            this.Text = "FormAnalytics";
            this.Load += new System.EventHandler(this.FormAnalytics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartOccupancy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFreeRooms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBackAnalytics;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOccupancy;
        private System.Windows.Forms.Label lblTotalRooms;
        private System.Windows.Forms.Label lblTotalIncome;
    }
}