using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    partial class FrmReport
    {
        private CustomControl.StatCard statCardTotalOrders;
        private CustomControl.StatCard statCardTotalRevenue;
        private CustomControl.StatCard statCardTotalProductsSold;
        private CustomControl.StatCard statCardNewCustomers;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.GroupBox grpRevenueChart;
        private System.Windows.Forms.GroupBox grpCustomerChart;
        private Chart chartRevenue;
        private Chart chartCustomer;

        private void InitializeComponent()
        {
            this.statCardTotalOrders = new CustomControl.StatCard();
            this.statCardTotalRevenue = new CustomControl.StatCard();
            this.statCardTotalProductsSold = new CustomControl.StatCard();
            this.statCardNewCustomers = new CustomControl.StatCard();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.grpRevenueChart = new System.Windows.Forms.GroupBox();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpCustomerChart = new System.Windows.Forms.GroupBox();
            this.chartCustomer = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxThongKe = new System.Windows.Forms.GroupBox();
            this.btnXuatThongKe = new System.Windows.Forms.Button();
            this.grpRevenueChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.grpCustomerChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomer)).BeginInit();
            this.groupBoxThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // statCardTotalOrders
            // 
            this.statCardTotalOrders.BackColor = System.Drawing.Color.White;
            this.statCardTotalOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCardTotalOrders.Icon = null;
            this.statCardTotalOrders.Location = new System.Drawing.Point(135, 25);
            this.statCardTotalOrders.Name = "statCardTotalOrders";
            this.statCardTotalOrders.Size = new System.Drawing.Size(230, 80);
            this.statCardTotalOrders.TabIndex = 0;
            this.statCardTotalOrders.Title = "Tổng số đơn hàng";
            this.statCardTotalOrders.Value = "0";
            // 
            // statCardTotalRevenue
            // 
            this.statCardTotalRevenue.BackColor = System.Drawing.Color.White;
            this.statCardTotalRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCardTotalRevenue.Icon = null;
            this.statCardTotalRevenue.Location = new System.Drawing.Point(429, 25);
            this.statCardTotalRevenue.Name = "statCardTotalRevenue";
            this.statCardTotalRevenue.Size = new System.Drawing.Size(230, 80);
            this.statCardTotalRevenue.TabIndex = 1;
            this.statCardTotalRevenue.Title = "Tổng doanh thu";
            this.statCardTotalRevenue.Value = "0";
            // 
            // statCardTotalProductsSold
            // 
            this.statCardTotalProductsSold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statCardTotalProductsSold.BackColor = System.Drawing.Color.White;
            this.statCardTotalProductsSold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCardTotalProductsSold.Icon = null;
            this.statCardTotalProductsSold.Location = new System.Drawing.Point(730, 25);
            this.statCardTotalProductsSold.Name = "statCardTotalProductsSold";
            this.statCardTotalProductsSold.Size = new System.Drawing.Size(230, 80);
            this.statCardTotalProductsSold.TabIndex = 2;
            this.statCardTotalProductsSold.Title = "Sản phẩm đã bán";
            this.statCardTotalProductsSold.Value = "0";
            // 
            // statCardNewCustomers
            // 
            this.statCardNewCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statCardNewCustomers.BackColor = System.Drawing.Color.White;
            this.statCardNewCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCardNewCustomers.Icon = null;
            this.statCardNewCustomers.Location = new System.Drawing.Point(1034, 25);
            this.statCardNewCustomers.Name = "statCardNewCustomers";
            this.statCardNewCustomers.Size = new System.Drawing.Size(230, 80);
            this.statCardNewCustomers.TabIndex = 3;
            this.statCardNewCustomers.Title = "Khách hàng mới";
            this.statCardNewCustomers.Value = "0";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.CalendarForeColor = System.Drawing.Color.Red;
            this.dtpStartDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Location = new System.Drawing.Point(691, 128);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 26);
            this.dtpStartDate.TabIndex = 4;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDate.CalendarForeColor = System.Drawing.Color.Red;
            this.dtpEndDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Location = new System.Drawing.Point(897, 128);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 26);
            this.dtpEndDate.TabIndex = 5;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.ForeColor = System.Drawing.Color.Black;
            this.btnFilter.Location = new System.Drawing.Point(1103, 129);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 25);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.Gray;
            this.pnlSeparator.Location = new System.Drawing.Point(738, 160);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(2, 450);
            this.pnlSeparator.TabIndex = 11;
            // 
            // grpRevenueChart
            // 
            this.grpRevenueChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRevenueChart.Controls.Add(this.chartRevenue);
            this.grpRevenueChart.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRevenueChart.Location = new System.Drawing.Point(20, 160);
            this.grpRevenueChart.Name = "grpRevenueChart";
            this.grpRevenueChart.Size = new System.Drawing.Size(694, 400);
            this.grpRevenueChart.TabIndex = 9;
            this.grpRevenueChart.TabStop = false;
            this.grpRevenueChart.Text = "Doanh thu";
            // 
            // chartRevenue
            // 
            this.chartRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRevenue.Location = new System.Drawing.Point(3, 28);
            this.chartRevenue.Name = "chartRevenue";
            this.chartRevenue.Size = new System.Drawing.Size(688, 369);
            this.chartRevenue.TabIndex = 0;
            this.chartRevenue.Text = "chartRevenue";
            // 
            // grpCustomerChart
            // 
            this.grpCustomerChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCustomerChart.Controls.Add(this.chartCustomer);
            this.grpCustomerChart.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCustomerChart.Location = new System.Drawing.Point(764, 160);
            this.grpCustomerChart.Name = "grpCustomerChart";
            this.grpCustomerChart.Size = new System.Drawing.Size(550, 400);
            this.grpCustomerChart.TabIndex = 10;
            this.grpCustomerChart.TabStop = false;
            this.grpCustomerChart.Text = "Khách hàng mới";
            // 
            // chartCustomer
            // 
            this.chartCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCustomer.Location = new System.Drawing.Point(3, 28);
            this.chartCustomer.Name = "chartCustomer";
            this.chartCustomer.Size = new System.Drawing.Size(544, 369);
            this.chartCustomer.TabIndex = 0;
            this.chartCustomer.Text = "chartCustomer";
            // 
            // groupBoxThongKe
            // 
            this.groupBoxThongKe.Controls.Add(this.statCardTotalOrders);
            this.groupBoxThongKe.Controls.Add(this.statCardTotalRevenue);
            this.groupBoxThongKe.Controls.Add(this.statCardTotalProductsSold);
            this.groupBoxThongKe.Controls.Add(this.statCardNewCustomers);
            this.groupBoxThongKe.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxThongKe.Location = new System.Drawing.Point(90, 12);
            this.groupBoxThongKe.Name = "groupBoxThongKe";
            this.groupBoxThongKe.Size = new System.Drawing.Size(1334, 111);
            this.groupBoxThongKe.TabIndex = 12;
            this.groupBoxThongKe.TabStop = false;
            this.groupBoxThongKe.Text = "Thống Kê";
            // 
            // btnXuatThongKe
            // 
            this.btnXuatThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatThongKe.ForeColor = System.Drawing.Color.Black;
            this.btnXuatThongKe.Location = new System.Drawing.Point(1184, 131);
            this.btnXuatThongKe.Name = "btnXuatThongKe";
            this.btnXuatThongKe.Size = new System.Drawing.Size(127, 26);
            this.btnXuatThongKe.TabIndex = 13;
            this.btnXuatThongKe.Text = "Xuất Thống Kê";
            this.btnXuatThongKe.UseVisualStyleBackColor = true;
            // 
            // FrmReport
            // 
            this.ClientSize = new System.Drawing.Size(1486, 650);
            this.Controls.Add(this.btnXuatThongKe);
            this.Controls.Add(this.groupBoxThongKe);
            this.Controls.Add(this.grpRevenueChart);
            this.Controls.Add(this.grpCustomerChart);
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.btnFilter);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReport";
            this.Text = "Thống Kê Báo Cáo";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.grpRevenueChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.grpCustomerChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomer)).EndInit();
            this.groupBoxThongKe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private GroupBox groupBoxThongKe;
        private Button btnXuatThongKe;
    }
}
