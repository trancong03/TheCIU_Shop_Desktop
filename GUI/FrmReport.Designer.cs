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

            this.grpRevenueChart.SuspendLayout();
            this.grpCustomerChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomer)).BeginInit();
            this.SuspendLayout();

            // 
            // statCardTotalOrders
            // 
            this.statCardTotalOrders.BackColor = System.Drawing.Color.White;
            this.statCardTotalOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCardTotalOrders.Icon = null;
            this.statCardTotalOrders.Location = new System.Drawing.Point(100, 20);
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
            this.statCardTotalRevenue.Location = new System.Drawing.Point(350, 20);
            this.statCardTotalRevenue.Name = "statCardTotalRevenue";
            this.statCardTotalRevenue.Size = new System.Drawing.Size(230, 80);
            this.statCardTotalRevenue.TabIndex = 1;
            this.statCardTotalRevenue.Title = "Tổng doanh thu";
            this.statCardTotalRevenue.Value = "0";

            // 
            // statCardTotalProductsSold
            // 
            this.statCardTotalProductsSold.BackColor = System.Drawing.Color.White;
            this.statCardTotalProductsSold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCardTotalProductsSold.Icon = null;
            this.statCardTotalProductsSold.Location = new System.Drawing.Point(600, 20);
            this.statCardTotalProductsSold.Name = "statCardTotalProductsSold";
            this.statCardTotalProductsSold.Size = new System.Drawing.Size(230, 80);
            this.statCardTotalProductsSold.TabIndex = 2;
            this.statCardTotalProductsSold.Title = "Sản phẩm đã bán";
            this.statCardTotalProductsSold.Value = "0";

            // 
            // statCardNewCustomers
            // 
            this.statCardNewCustomers.BackColor = System.Drawing.Color.White;
            this.statCardNewCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCardNewCustomers.Icon = null;
            this.statCardNewCustomers.Location = new System.Drawing.Point(850, 20);
            this.statCardNewCustomers.Name = "statCardNewCustomers";
            this.statCardNewCustomers.Size = new System.Drawing.Size(230, 80);
            this.statCardNewCustomers.TabIndex = 3;
            this.statCardNewCustomers.Title = "Khách hàng mới";
            this.statCardNewCustomers.Value = "0";

            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(600, 120);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 22);
            this.dtpStartDate.TabIndex = 4;

            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(810, 120);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 22);
            this.dtpEndDate.TabIndex = 5;

            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(1020, 118);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 25);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = true;

            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.Gray;
            this.pnlSeparator.Location = new System.Drawing.Point(600, 160);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(2, 450);
            this.pnlSeparator.TabIndex = 11;

            // 
            // grpRevenueChart
            // 
            this.grpRevenueChart.Controls.Add(this.chartRevenue);
            this.grpRevenueChart.Location = new System.Drawing.Point(20, 160);
            this.grpRevenueChart.Name = "grpRevenueChart";
            this.grpRevenueChart.Size = new System.Drawing.Size(550, 400);
            this.grpRevenueChart.TabIndex = 9;
            this.grpRevenueChart.TabStop = false;
            this.grpRevenueChart.Text = "Doanh thu";

            // 
            // chartRevenue
            // 
            this.chartRevenue.Dock = DockStyle.Fill;
            this.chartRevenue.Location = new System.Drawing.Point(3, 18);
            this.chartRevenue.Name = "chartRevenue";
            this.chartRevenue.Size = new System.Drawing.Size(544, 379);
            this.chartRevenue.TabIndex = 0;
            this.chartRevenue.Text = "chartRevenue";

            // 
            // grpCustomerChart
            // 
            this.grpCustomerChart.Controls.Add(this.chartCustomer);
            this.grpCustomerChart.Location = new System.Drawing.Point(620, 160);
            this.grpCustomerChart.Name = "grpCustomerChart";
            this.grpCustomerChart.Size = new System.Drawing.Size(550, 400);
            this.grpCustomerChart.TabIndex = 10;
            this.grpCustomerChart.TabStop = false;
            this.grpCustomerChart.Text = "Khách hàng mới";

            // 
            // chartCustomer
            // 
            this.chartCustomer.Dock = DockStyle.Fill;
            this.chartCustomer.Location = new System.Drawing.Point(3, 18);
            this.chartCustomer.Name = "chartCustomer";
            this.chartCustomer.Size = new System.Drawing.Size(544, 379);
            this.chartCustomer.TabIndex = 0;
            this.chartCustomer.Text = "chartCustomer";

            // 
            // FrmReport
            // 
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.grpRevenueChart);
            this.Controls.Add(this.grpCustomerChart);
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.statCardTotalOrders);
            this.Controls.Add(this.statCardTotalRevenue);
            this.Controls.Add(this.statCardTotalProductsSold);
            this.Controls.Add(this.statCardNewCustomers);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.btnFilter);
            this.Name = "FrmReport";
            this.Text = "Thống Kê Báo Cáo";
            this.grpRevenueChart.ResumeLayout(false);
            this.grpCustomerChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomer)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
