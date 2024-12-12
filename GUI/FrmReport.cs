using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;


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
            btnFilter.Click += (s, e) =>
            {
                var startDate = dtpStartDate.Value.Date;
                var endDate = dtpEndDate.Value.Date;

                UpdateRevenueChart(startDate, endDate);
                UpdateCustomerChart(startDate, endDate);
            };

            btnXuatThongKe.Click += (s, e) =>
            {
                ExportReportToPdf();
            };

            UpdateRevenueChart(DateTime.Today.AddMonths(-1), DateTime.Today);
            UpdateCustomerChart(DateTime.Today.AddMonths(-1), DateTime.Today);
        }

        private void UpdateRevenueChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                var revenueData = reportBLL.GetRevenueByDateRangeDetails(startDate, endDate);

                chartRevenue.Series.Clear();
                chartRevenue.ChartAreas.Clear();

                var chartArea = new ChartArea("RevenueArea");
                chartArea.AxisX.Title = "Thời gian";
                chartArea.AxisY.Title = "Doanh thu";
                chartRevenue.ChartAreas.Add(chartArea);

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

                chartCustomer.Series.Clear();
                chartCustomer.ChartAreas.Clear();

                var chartArea = new ChartArea("CustomerArea");
                chartArea.AxisX.Title = "Thời gian";
                chartArea.AxisY.Title = "Khách hàng mới";
                chartCustomer.ChartAreas.Add(chartArea);

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
        private void ExportReportToPdf()
        {
            try
            {
                var startDate = dtpStartDate.Value.Date;
                var endDate = dtpEndDate.Value.Date;

                var revenueData = reportBLL.GetRevenueByDateRangeDetails(startDate, endDate);
                var customerData = reportBLL.GetNewCustomerDetails(startDate, endDate);

                // Tạo file PDF
                using (var saveFileDialog = new SaveFileDialog { Filter = "PDF Files|*.pdf", Title = "Save PDF Report" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var filePath = saveFileDialog.FileName;

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            var document = new Document(PageSize.A4);
                            PdfWriter.GetInstance(document, stream);
                            document.Open();

                            // Tải font Unicode
                            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                            var baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            var titleFont = new Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                            var contentFont = new Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

                            // Tiêu đề
                            document.Add(new Paragraph("Báo Cáo Thống Kê", titleFont));
                            document.Add(new Paragraph($"Từ ngày: {startDate.ToShortDateString()} đến ngày: {endDate.ToShortDateString()}", contentFont));
                            document.Add(new Paragraph("\n"));

                            // Thống kê doanh thu
                            document.Add(new Paragraph("Thống kê doanh thu:", titleFont));
                            var revenueTable = new PdfPTable(2) { WidthPercentage = 100 };
                            revenueTable.AddCell(new PdfPCell(new Phrase("Ngày", contentFont)));
                            revenueTable.AddCell(new PdfPCell(new Phrase("Doanh thu", contentFont)));
                            foreach (var data in revenueData)
                            {
                                revenueTable.AddCell(new PdfPCell(new Phrase(data.Date.ToShortDateString(), contentFont)));
                                revenueTable.AddCell(new PdfPCell(new Phrase(data.Revenue.ToString("C"), contentFont)));
                            }
                            document.Add(revenueTable);
                            document.Add(new Paragraph("\n"));

                            // Thống kê khách hàng mới
                            document.Add(new Paragraph("Thống kê khách hàng mới:", titleFont));
                            var customerTable = new PdfPTable(2) { WidthPercentage = 100 };
                            customerTable.AddCell(new PdfPCell(new Phrase("Ngày", contentFont)));
                            customerTable.AddCell(new PdfPCell(new Phrase("Khách hàng mới", contentFont)));
                            foreach (var data in customerData)
                            {
                                customerTable.AddCell(new PdfPCell(new Phrase(data.Date.ToShortDateString(), contentFont)));
                                customerTable.AddCell(new PdfPCell(new Phrase(data.NewCustomers.ToString(), contentFont)));
                            }
                            document.Add(customerTable);

                            document.Close();
                        }

                        MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {

        }
    }
}

