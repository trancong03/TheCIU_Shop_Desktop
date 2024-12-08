namespace GUI
{
    partial class FrmOrderManagement
    {
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrderDetails;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dateOrderDate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.GroupBox groupBoxOrder;
        private CustomControl.ActionControl actionControl;

        private void InitializeComponent()
        {
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrderDetails = new System.Windows.Forms.DataGridView();
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtAmount = new CustomControls.CurrencyTextBox();
            this.lblAddressDeliver = new System.Windows.Forms.Label();
            this.txtAddressDeliver = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.dateOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.groupBoxOrderDetails = new System.Windows.Forms.GroupBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new CustomControls.CurrencyTextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.actionControl = new CustomControl.ActionControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).BeginInit();
            this.groupBoxOrder.SuspendLayout();
            this.groupBoxOrderDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeight = 29;
            this.dataGridViewOrders.Location = new System.Drawing.Point(12, 221);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersWidth = 51;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(1226, 185);
            this.dataGridViewOrders.TabIndex = 0;
            // 
            // dataGridViewOrderDetails
            // 
            this.dataGridViewOrderDetails.ColumnHeadersHeight = 29;
            this.dataGridViewOrderDetails.Location = new System.Drawing.Point(12, 507);
            this.dataGridViewOrderDetails.Name = "dataGridViewOrderDetails";
            this.dataGridViewOrderDetails.RowHeadersWidth = 51;
            this.dataGridViewOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrderDetails.Size = new System.Drawing.Size(1226, 150);
            this.dataGridViewOrderDetails.TabIndex = 1;
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.cboStatus);
            this.groupBoxOrder.Controls.Add(this.txtAmount);
            this.groupBoxOrder.Controls.Add(this.lblAddressDeliver);
            this.groupBoxOrder.Controls.Add(this.txtAddressDeliver);
            this.groupBoxOrder.Controls.Add(this.lblName);
            this.groupBoxOrder.Controls.Add(this.txtName);
            this.groupBoxOrder.Controls.Add(this.lblOrderDate);
            this.groupBoxOrder.Controls.Add(this.dateOrderDate);
            this.groupBoxOrder.Controls.Add(this.lblStatus);
            this.groupBoxOrder.Controls.Add(this.lblAmount);
            this.groupBoxOrder.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOrder.Location = new System.Drawing.Point(30, 12);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(1208, 150);
            this.groupBoxOrder.TabIndex = 2;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "THÔNG TIN ĐƠN HÀNG";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(229, 116);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(200, 28);
            this.cboStatus.TabIndex = 13;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(229, 79);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 22);
            this.txtAmount.TabIndex = 12;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblAddressDeliver
            // 
            this.lblAddressDeliver.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressDeliver.Location = new System.Drawing.Point(489, 79);
            this.lblAddressDeliver.Name = "lblAddressDeliver";
            this.lblAddressDeliver.Size = new System.Drawing.Size(100, 23);
            this.lblAddressDeliver.TabIndex = 10;
            this.lblAddressDeliver.Text = "Địa chỉ";
            // 
            // txtAddressDeliver
            // 
            this.txtAddressDeliver.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressDeliver.Location = new System.Drawing.Point(609, 79);
            this.txtAddressDeliver.Multiline = true;
            this.txtAddressDeliver.Name = "txtAddressDeliver";
            this.txtAddressDeliver.Size = new System.Drawing.Size(593, 65);
            this.txtAddressDeliver.TabIndex = 11;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(109, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(114, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Khách Hàng";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(229, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 28);
            this.txtName.TabIndex = 3;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(489, 39);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(100, 23);
            this.lblOrderDate.TabIndex = 4;
            this.lblOrderDate.Text = "Ngày đặt:";
            // 
            // dateOrderDate
            // 
            this.dateOrderDate.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOrderDate.Location = new System.Drawing.Point(609, 39);
            this.dateOrderDate.Name = "dateOrderDate";
            this.dateOrderDate.Size = new System.Drawing.Size(292, 28);
            this.dateOrderDate.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(109, 116);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(109, 79);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(100, 23);
            this.lblAmount.TabIndex = 8;
            this.lblAmount.Text = "Tổng tiền:";
            // 
            // groupBoxOrderDetails
            // 
            this.groupBoxOrderDetails.Controls.Add(this.lblQuantity);
            this.groupBoxOrderDetails.Controls.Add(this.txtQuantity);
            this.groupBoxOrderDetails.Controls.Add(this.txtSubtotal);
            this.groupBoxOrderDetails.Controls.Add(this.lblProductName);
            this.groupBoxOrderDetails.Controls.Add(this.txtProductName);
            this.groupBoxOrderDetails.Controls.Add(this.lblSubtotal);
            this.groupBoxOrderDetails.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOrderDetails.Location = new System.Drawing.Point(43, 412);
            this.groupBoxOrderDetails.Name = "groupBoxOrderDetails";
            this.groupBoxOrderDetails.Size = new System.Drawing.Size(1195, 76);
            this.groupBoxOrderDetails.TabIndex = 13;
            this.groupBoxOrderDetails.TabStop = false;
            this.groupBoxOrderDetails.Text = "THÔNG TIN CHI TIẾT ĐƠN HÀNG";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(371, 30);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(114, 23);
            this.lblQuantity.TabIndex = 13;
            this.lblQuantity.Text = "Số lượng";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(491, 30);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(59, 28);
            this.txtQuantity.TabIndex = 14;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(712, 31);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(200, 22);
            this.txtSubtotal.TabIndex = 12;
            this.txtSubtotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(20, 30);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(114, 23);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Sản Phẩm";
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(140, 30);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(200, 28);
            this.txtProductName.TabIndex = 1;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(592, 30);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(100, 23);
            this.lblSubtotal.TabIndex = 8;
            this.lblSubtotal.Text = "Thành tiền";
            // 
            // actionControl
            // 
            this.actionControl.AddButtonVisible = true;
            this.actionControl.DeleteButtonVisible = true;
            this.actionControl.ExcelButtonVisible = true;
            this.actionControl.FilterDataSource = null;
            this.actionControl.FilterDisplayMember = "";
            this.actionControl.FilterLocation = new System.Drawing.Point(578, 16);
            this.actionControl.FilterSize = new System.Drawing.Size(150, 28);
            this.actionControl.FilterValueMember = "";
            this.actionControl.FilterVisible = true;
            this.actionControl.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionControl.Location = new System.Drawing.Point(124, 165);
            this.actionControl.Name = "actionControl";
            this.actionControl.PrintButtonVisible = true;
            this.actionControl.ReloadButtonVisible = true;
            this.actionControl.SaveButtonVisible = true;
            this.actionControl.SearchButtonLocation = new System.Drawing.Point(340, 10);
            this.actionControl.SearchButtonSize = new System.Drawing.Size(40, 40);
            this.actionControl.SearchButtonVisible = true;
            this.actionControl.SelectedFilter = null;
            this.actionControl.Size = new System.Drawing.Size(960, 50);
            this.actionControl.TabIndex = 3;
            this.actionControl.UpdateButtonVisible = true;
            // 
            // FrmOrderManagement
            // 
            this.ClientSize = new System.Drawing.Size(1250, 669);
            this.Controls.Add(this.groupBoxOrderDetails);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.dataGridViewOrderDetails);
            this.Controls.Add(this.groupBoxOrder);
            this.Controls.Add(this.actionControl);
            this.Name = "FrmOrderManagement";
            this.Text = "Quản lý Đơn hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).EndInit();
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            this.groupBoxOrderDetails.ResumeLayout(false);
            this.groupBoxOrderDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblAddressDeliver;
        private System.Windows.Forms.TextBox txtAddressDeliver;
        private CustomControls.CurrencyTextBox txtAmount;
        private System.Windows.Forms.GroupBox groupBoxOrderDetails;
        private CustomControls.CurrencyTextBox txtSubtotal;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtProductName;
    }
}
