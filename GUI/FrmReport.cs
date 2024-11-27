using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;

namespace GUI
{
    public partial class FrmReport : Form
    {
        private readonly ReportBLL reportBLL;

        public FrmReport()
        {
            InitializeComponent();
            reportBLL = new ReportBLL();
            LoadQuickStatistics();
            LoadDefaultData();
        }

        private void LoadQuickStatistics()
        {
            try
            {
                // Tổng số đơn hàng
                statCardTotalOrders.Title = "Tổng số đơn hàng";
                statCardTotalOrders.Value = reportBLL.GetTotalOrders().ToString();
                statCardTotalOrders.Icon = Properties.Resources.orders_icon;

                // Tổng doanh thu
                statCardTotalRevenue.Title = "Tổng doanh thu";
                statCardTotalRevenue.Value = $"{reportBLL.GetTotalRevenue():C}";
                statCardTotalRevenue.Icon = Properties.Resources.revenue_icon;

                // Tổng số sản phẩm đã bán
                statCardTotalProductsSold.Title = "Sản phẩm đã bán";
                statCardTotalProductsSold.Value = reportBLL.GetTotalProductsSold().ToString();
                statCardTotalProductsSold.Icon = Properties.Resources.products_icon;

                // Số lượng khách hàng mới
                statCardNewCustomers.Title = "Khách hàng mới";
                statCardNewCustomers.Value = reportBLL.GetNewCustomers().ToString();
                statCardNewCustomers.Icon = Properties.Resources.customers_icon;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDefaultData()
        {
            // Thiết lập sự kiện cho Button lọc
            btnFilter.Click += (s, e) =>
            {
                var startDate = dtpStartDate.Value.Date;
                var endDate = dtpEndDate.Value.Date;

                // Cập nhật dữ liệu biểu đồ doanh thu và khách hàng
                UpdateRevenueChart(startDate, endDate);
                UpdateCustomerChart(startDate, endDate);
            };

            // Load dữ liệu biểu đồ mặc định (tháng hiện tại)
            UpdateRevenueChart(DateTime.Today.AddMonths(-1), DateTime.Today);
            UpdateCustomerChart(DateTime.Today.AddMonths(-1), DateTime.Today);
        }

        private void UpdateRevenueChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                var revenueData = reportBLL.GetRevenueByDateRangeDetails(startDate, endDate);

                // Xóa dữ liệu cũ
                chartRevenue.Series.Clear();
                chartRevenue.ChartAreas.Clear();

                // Thêm ChartArea
                var chartArea = new ChartArea("RevenueArea");
                chartArea.AxisX.Title = "Thời gian";
                chartArea.AxisY.Title = "Doanh thu";
                chartRevenue.ChartAreas.Add(chartArea);

                // Tạo Series
                var series = new Series("Doanh thu")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3
                };

                foreach (var data in revenueData)
                {
                    series.Points.AddXY(data.Date.ToShortDateString(), data.Revenue);
                }

                chartRevenue.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ doanh thu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCustomerChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                var customerData = reportBLL.GetNewCustomerDetails(startDate, endDate);

                // Xóa dữ liệu cũ
                chartCustomer.Series.Clear();
                chartCustomer.ChartAreas.Clear();

                // Thêm ChartArea
                var chartArea = new ChartArea("CustomerArea");
                chartArea.AxisX.Title = "Thời gian";
                chartArea.AxisY.Title = "Khách hàng mới";
                chartCustomer.ChartAreas.Add(chartArea);

                // Tạo Series
                var series = new Series("Khách hàng mới")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3
                };

                foreach (var data in customerData)
                {
                    series.Points.AddXY(data.Date.ToShortDateString(), data.NewCustomers);
                }

                chartCustomer.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
