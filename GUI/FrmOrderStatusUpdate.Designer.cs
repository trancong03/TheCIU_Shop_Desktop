namespace GUI
{
    partial class FrmOrderStatusUpdate
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelScrollContent = new System.Windows.Forms.Panel();
            this.actionControl = new CustomControl.ActionControl();
            this.dataGridViewPendingOrders = new System.Windows.Forms.DataGridView();
            this.btnCancelOrders = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewOrderDetails = new System.Windows.Forms.DataGridView();
            this.btnCompleteOrders = new System.Windows.Forms.Button();
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
            this.btnShipOrders = new System.Windows.Forms.Button();
            this.btnConfirmOrders = new System.Windows.Forms.Button();
            this.dataGridViewShippingOrders = new System.Windows.Forms.DataGridView();
            this.dataGridViewCompletedOrders = new System.Windows.Forms.DataGridView();
            this.dataGridViewConfirmedOrders = new System.Windows.Forms.DataGridView();
            this.panelScrollContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).BeginInit();
            this.groupBoxOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShippingOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompletedOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConfirmedOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // panelScrollContent
            // 
            this.panelScrollContent.AutoScroll = true;
            this.panelScrollContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelScrollContent.Controls.Add(this.actionControl);
            this.panelScrollContent.Controls.Add(this.dataGridViewPendingOrders);
            this.panelScrollContent.Controls.Add(this.btnCancelOrders);
            this.panelScrollContent.Controls.Add(this.button1);
            this.panelScrollContent.Controls.Add(this.dataGridViewOrderDetails);
            this.panelScrollContent.Controls.Add(this.btnCompleteOrders);
            this.panelScrollContent.Controls.Add(this.groupBoxOrder);
            this.panelScrollContent.Controls.Add(this.btnShipOrders);
            this.panelScrollContent.Controls.Add(this.btnConfirmOrders);
            this.panelScrollContent.Controls.Add(this.dataGridViewShippingOrders);
            this.panelScrollContent.Controls.Add(this.dataGridViewCompletedOrders);
            this.panelScrollContent.Controls.Add(this.dataGridViewConfirmedOrders);
            this.panelScrollContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScrollContent.Location = new System.Drawing.Point(0, 0);
            this.panelScrollContent.Name = "panelScrollContent";
            this.panelScrollContent.Size = new System.Drawing.Size(1492, 1102);
            this.panelScrollContent.TabIndex = 24;
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
            this.actionControl.Location = new System.Drawing.Point(217, 222);
            this.actionControl.Name = "actionControl";
            this.actionControl.PrintButtonVisible = true;
            this.actionControl.ReloadButtonVisible = true;
            this.actionControl.SaveButtonVisible = true;
            this.actionControl.SearchButtonLocation = new System.Drawing.Point(340, 10);
            this.actionControl.SearchButtonSize = new System.Drawing.Size(40, 40);
            this.actionControl.SearchButtonVisible = true;
            this.actionControl.SelectedFilter = null;
            this.actionControl.Size = new System.Drawing.Size(1004, 63);
            this.actionControl.TabIndex = 31;
            this.actionControl.UpdateButtonVisble = true;
            this.actionControl.UpdateButtonVisible = true;
            // 
            // dataGridViewPendingOrders
            // 
            this.dataGridViewPendingOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPendingOrders.Location = new System.Drawing.Point(12, 653);
            this.dataGridViewPendingOrders.Name = "dataGridViewPendingOrders";
            this.dataGridViewPendingOrders.RowHeadersWidth = 51;
            this.dataGridViewPendingOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPendingOrders.Size = new System.Drawing.Size(751, 300);
            this.dataGridViewPendingOrders.TabIndex = 25;
            // 
            // btnCancelOrders
            // 
            this.btnCancelOrders.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelOrders.Location = new System.Drawing.Point(179, 615);
            this.btnCancelOrders.Name = "btnCancelOrders";
            this.btnCancelOrders.Size = new System.Drawing.Size(123, 32);
            this.btnCancelOrders.TabIndex = 22;
            this.btnCancelOrders.Text = "Hủy đơn hàng";
            this.btnCancelOrders.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(783, 980);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 32);
            this.button1.TabIndex = 21;
            this.button1.Text = "Xem lịch sử";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOrderDetails
            // 
            this.dataGridViewOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrderDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderDetails.Location = new System.Drawing.Point(19, 291);
            this.dataGridViewOrderDetails.Name = "dataGridViewOrderDetails";
            this.dataGridViewOrderDetails.RowHeadersWidth = 51;
            this.dataGridViewOrderDetails.Size = new System.Drawing.Size(1423, 318);
            this.dataGridViewOrderDetails.TabIndex = 29;
            // 
            // btnCompleteOrders
            // 
            this.btnCompleteOrders.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleteOrders.Location = new System.Drawing.Point(12, 979);
            this.btnCompleteOrders.Name = "btnCompleteOrders";
            this.btnCompleteOrders.Size = new System.Drawing.Size(123, 32);
            this.btnCompleteOrders.TabIndex = 20;
            this.btnCompleteOrders.Text = "Hoàn tất";
            this.btnCompleteOrders.UseVisualStyleBackColor = true;
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBoxOrder.Location = new System.Drawing.Point(52, 21);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(1314, 177);
            this.groupBoxOrder.TabIndex = 3;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "THÔNG TIN ĐƠN HÀNG";
            // 
            // cboStatus
            // 
            this.cboStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(165, 116);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(200, 28);
            this.cboStatus.TabIndex = 13;
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAmount.Location = new System.Drawing.Point(165, 79);
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
            this.lblAddressDeliver.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAddressDeliver.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressDeliver.Location = new System.Drawing.Point(425, 79);
            this.lblAddressDeliver.Name = "lblAddressDeliver";
            this.lblAddressDeliver.Size = new System.Drawing.Size(100, 23);
            this.lblAddressDeliver.TabIndex = 10;
            this.lblAddressDeliver.Text = "Địa chỉ";
            // 
            // txtAddressDeliver
            // 
            this.txtAddressDeliver.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAddressDeliver.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressDeliver.Location = new System.Drawing.Point(545, 76);
            this.txtAddressDeliver.Multiline = true;
            this.txtAddressDeliver.Name = "txtAddressDeliver";
            this.txtAddressDeliver.Size = new System.Drawing.Size(593, 65);
            this.txtAddressDeliver.TabIndex = 11;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(45, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(114, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Khách Hàng";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(165, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 28);
            this.txtName.TabIndex = 3;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOrderDate.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(425, 39);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(100, 23);
            this.lblOrderDate.TabIndex = 4;
            this.lblOrderDate.Text = "Ngày đặt:";
            // 
            // dateOrderDate
            // 
            this.dateOrderDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateOrderDate.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOrderDate.Location = new System.Drawing.Point(545, 39);
            this.dateOrderDate.Name = "dateOrderDate";
            this.dateOrderDate.Size = new System.Drawing.Size(292, 28);
            this.dateOrderDate.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(45, 116);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAmount.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(45, 79);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(100, 23);
            this.lblAmount.TabIndex = 8;
            this.lblAmount.Text = "Tổng tiền:";
            // 
            // btnShipOrders
            // 
            this.btnShipOrders.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShipOrders.Location = new System.Drawing.Point(783, 615);
            this.btnShipOrders.Name = "btnShipOrders";
            this.btnShipOrders.Size = new System.Drawing.Size(113, 32);
            this.btnShipOrders.TabIndex = 19;
            this.btnShipOrders.Text = "Giao Hàng";
            this.btnShipOrders.UseVisualStyleBackColor = true;
            // 
            // btnConfirmOrders
            // 
            this.btnConfirmOrders.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmOrders.Location = new System.Drawing.Point(52, 615);
            this.btnConfirmOrders.Name = "btnConfirmOrders";
            this.btnConfirmOrders.Size = new System.Drawing.Size(108, 32);
            this.btnConfirmOrders.TabIndex = 30;
            this.btnConfirmOrders.Text = "Xác Nhận";
            // 
            // dataGridViewShippingOrders
            // 
            this.dataGridViewShippingOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShippingOrders.Location = new System.Drawing.Point(12, 1017);
            this.dataGridViewShippingOrders.Name = "dataGridViewShippingOrders";
            this.dataGridViewShippingOrders.RowHeadersWidth = 51;
            this.dataGridViewShippingOrders.Size = new System.Drawing.Size(751, 295);
            this.dataGridViewShippingOrders.TabIndex = 27;
            // 
            // dataGridViewCompletedOrders
            // 
            this.dataGridViewCompletedOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompletedOrders.Location = new System.Drawing.Point(783, 1018);
            this.dataGridViewCompletedOrders.Name = "dataGridViewCompletedOrders";
            this.dataGridViewCompletedOrders.RowHeadersWidth = 51;
            this.dataGridViewCompletedOrders.Size = new System.Drawing.Size(667, 295);
            this.dataGridViewCompletedOrders.TabIndex = 28;
            // 
            // dataGridViewConfirmedOrders
            // 
            this.dataGridViewConfirmedOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConfirmedOrders.Location = new System.Drawing.Point(783, 653);
            this.dataGridViewConfirmedOrders.Name = "dataGridViewConfirmedOrders";
            this.dataGridViewConfirmedOrders.RowHeadersWidth = 51;
            this.dataGridViewConfirmedOrders.Size = new System.Drawing.Size(667, 300);
            this.dataGridViewConfirmedOrders.TabIndex = 26;
            // 
            // FrmOrderStatusUpdate
            // 
            this.ClientSize = new System.Drawing.Size(1492, 1102);
            this.Controls.Add(this.panelScrollContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrderStatusUpdate";
            this.Text = "FrmOrderStatusUpdate";
            this.panelScrollContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).EndInit();
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShippingOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompletedOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConfirmedOrders)).EndInit();
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.Panel panelScrollContent;
        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.ComboBox cboStatus;
        private CustomControls.CurrencyTextBox txtAmount;
        private System.Windows.Forms.Label lblAddressDeliver;
        private System.Windows.Forms.TextBox txtAddressDeliver;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dateOrderDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.DataGridView dataGridViewPendingOrders;
        private System.Windows.Forms.DataGridView dataGridViewConfirmedOrders;
        private System.Windows.Forms.DataGridView dataGridViewShippingOrders;
        private System.Windows.Forms.DataGridView dataGridViewCompletedOrders;
        private System.Windows.Forms.Button btnConfirmOrders;
        private System.Windows.Forms.Button btnShipOrders;
        private System.Windows.Forms.Button btnCompleteOrders;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrderDetails;
        private CustomControl.ActionControl actionControl;
    }
}
