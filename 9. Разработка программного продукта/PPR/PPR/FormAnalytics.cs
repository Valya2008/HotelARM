using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PPR
{
    public partial class FormAnalytics : Form
    {
        public FormAnalytics()
        {
            InitializeComponent();
            chartOccupancy.BackColor = Color.Transparent;
        }

        private void FormAnalytics_Load(object sender, EventArgs e)
        {
            LoadKeyMetrics();
            LoadOccupancyChart();
        }

        private void LoadKeyMetrics()
        {
            // Считаем общее кол-во номеров и сколько из них свободны
            string query = "SELECT Status, COUNT(*) as Count FROM Rooms GROUP BY Status";
            DataTable dt = DbHelper.GetDataTable(query);

            int total = 0;
            int free = 0;

            foreach (DataRow row in dt.Rows)
            {
                int count = Convert.ToInt32(row["Count"]);
                total += count;
                if (row["Status"].ToString() == "Свободен")
                    free = count;
            }

            // Настраиваем небольшие шрифты, чтобы всё помещалось
            lblTotalRooms.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblFreeRooms.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            lblTotalRooms.Text = $"Всего номеров: {total}";
            lblFreeRooms.Text = $"Свободно сейчас: {free}";

            // Общий доход: без фильтра по статусу (если хотите учитывать только завершённые — вернём фильтр)
            string incomeQuery = "SELECT IFNULL(SUM(TotalAmount), 0) FROM Bookings";
            object incObj = DbHelper.ExecuteScalar(incomeQuery);
            decimal totalIncome = 0;
            if (incObj != null && incObj != DBNull.Value)
                decimal.TryParse(incObj.ToString(), out totalIncome);

            // lblTotalIncome — маленький жирный текст справа. Убедитесь, что этот label добавлен в дизайнере.
            lblTotalIncome.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblTotalIncome.Text = $"Общий доход: {totalIncome:C}";
        }

        private void LoadOccupancyChart()
        {
            chartOccupancy.Series.Clear();
            chartOccupancy.ChartAreas.Clear();
            chartOccupancy.Legends.Clear();

            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.Transparent;
            chartOccupancy.ChartAreas.Add(area);

            Legend legend = new Legend("MainLegend");
            legend.BackColor = Color.Transparent;
            legend.Font = new Font("Segoe UI", 10);
            chartOccupancy.Legends.Add(legend);

            Series series = new Series("Occupancy");
            series.ChartType = SeriesChartType.Doughnut;
            // Убираем подписи процентов/значений на дольках:
            series.IsValueShownAsLabel = false;
            series["PieLabelStyle"] = "Disabled";
            series["DoughnutRadius"] = "40";

            string query = @"SELECT BookedRoomTypeName, COUNT(*) as Count 
                     FROM Bookings 
                     GROUP BY BookedRoomTypeName";
            DataTable dt = DbHelper.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                string type = row["BookedRoomTypeName"].ToString();
                int count = Convert.ToInt32(row["Count"]);
                int pointIndex = series.Points.AddXY(type, count);
                // Подпись только в легенде: тип (кол-во)
                series.Points[pointIndex].LegendText = $"{type} ({count})";
            }

            chartOccupancy.Series.Add(series);
        }
    }
}