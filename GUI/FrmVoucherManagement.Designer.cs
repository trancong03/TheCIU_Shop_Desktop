namespace GUI
{
    partial class FrmVoucherManagement
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvVouchers;
        private CustomControl.ActionControl actionControl;
        private System.Windows.Forms.GroupBox gbVoucherInfo;
        private System.Windows.Forms.Label lblVoucherID;
        private System.Windows.Forms.TextBox txtVoucherID;
        private System.Windows.Forms.Label lblDateStart;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.Label lblDateEnd;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkStatus;

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
            this.dgvVouchers = new System.Windows.Forms.DataGridView();
            this.gbVoucherInfo = new System.Windows.Forms.GroupBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblVoucherID = new System.Windows.Forms.Label();
            this.txtVoucherID = new System.Windows.Forms.TextBox();
            this.lblDateStart = new System.Windows.Forms.Label();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.actionControl = new CustomControl.ActionControl();
            this.lblEvent = new System.Windows.Forms.Label();
            this.cboEvent = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVouchers)).BeginInit();
            this.gbVoucherInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVouchers
            // 
            this.dgvVouchers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVouchers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVouchers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVouchers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvVouchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVouchers.Location = new System.Drawing.Point(12, 260);
            this.dgvVouchers.Name = "dgvVouchers";
            this.dgvVouchers.RowHeadersWidth = 51;
            this.dgvVouchers.Size = new System.Drawing.Size(1530, 360);
            this.dgvVouchers.TabIndex = 0;
            // 
            // gbVoucherInfo
            // 
            this.gbVoucherInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVoucherInfo.Controls.Add(this.cboEvent);
            this.gbVoucherInfo.Controls.Add(this.lblEvent);
            this.gbVoucherInfo.Controls.Add(this.lblQuantity);
            this.gbVoucherInfo.Controls.Add(this.txtQuantity);
            this.gbVoucherInfo.Controls.Add(this.lblVoucherID);
            this.gbVoucherInfo.Controls.Add(this.txtVoucherID);
            this.gbVoucherInfo.Controls.Add(this.lblDateStart);
            this.gbVoucherInfo.Controls.Add(this.dtpDateStart);
            this.gbVoucherInfo.Controls.Add(this.lblDateEnd);
            this.gbVoucherInfo.Controls.Add(this.dtpDateEnd);
            this.gbVoucherInfo.Controls.Add(this.lblDiscount);
            this.gbVoucherInfo.Controls.Add(this.txtDiscount);
            this.gbVoucherInfo.Controls.Add(this.lblTitle);
            this.gbVoucherInfo.Controls.Add(this.txtTitle);
            this.gbVoucherInfo.Controls.Add(this.lblDescription);
            this.gbVoucherInfo.Controls.Add(this.txtDescription);
            this.gbVoucherInfo.Controls.Add(this.lblStatus);
            this.gbVoucherInfo.Controls.Add(this.chkStatus);
            this.gbVoucherInfo.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.gbVoucherInfo.Location = new System.Drawing.Point(12, 12);
            this.gbVoucherInfo.Name = "gbVoucherInfo";
            this.gbVoucherInfo.Size = new System.Drawing.Size(1530, 190);
            this.gbVoucherInfo.TabIndex = 2;
            this.gbVoucherInfo.TabStop = false;
            this.gbVoucherInfo.Text = "Thông Tin Voucher";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(14, 119);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(78, 21);
            this.lblQuantity.TabIndex = 14;
            this.lblQuantity.Text = "Số lượng";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(98, 116);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(65, 29);
            this.txtQuantity.TabIndex = 15;
            // 
            // lblVoucherID
            // 
            this.lblVoucherID.AutoSize = true;
            this.lblVoucherID.Location = new System.Drawing.Point(10, 30);
            this.lblVoucherID.Name = "lblVoucherID";
            this.lblVoucherID.Size = new System.Drawing.Size(105, 21);
            this.lblVoucherID.TabIndex = 0;
            this.lblVoucherID.Text = "Mã Voucher:";
            // 
            // txtVoucherID
            // 
            this.txtVoucherID.Location = new System.Drawing.Point(120, 27);
            this.txtVoucherID.Name = "txtVoucherID";
            this.txtVoucherID.ReadOnly = true;
            this.txtVoucherID.Size = new System.Drawing.Size(56, 29);
            this.txtVoucherID.TabIndex = 1;
            // 
            // lblDateStart
            // 
            this.lblDateStart.AutoSize = true;
            this.lblDateStart.Location = new System.Drawing.Point(429, 30);
            this.lblDateStart.Name = "lblDateStart";
            this.lblDateStart.Size = new System.Drawing.Size(119, 21);
            this.lblDateStart.TabIndex = 2;
            this.lblDateStart.Text = "Ngày Bắt Đầu:";
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Location = new System.Drawing.Point(583, 24);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Size = new System.Drawing.Size(311, 29);
            this.dtpDateStart.TabIndex = 3;
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.AutoSize = true;
            this.lblDateEnd.Location = new System.Drawing.Point(429, 70);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(128, 21);
            this.lblDateEnd.TabIndex = 4;
            this.lblDateEnd.Text = "Ngày Kết Thúc:";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(583, 67);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(311, 29);
            this.dtpDateEnd.TabIndex = 5;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(190, 31);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(85, 21);
            this.lblDiscount.TabIndex = 6;
            this.lblDiscount.Text = "Giảm Giá:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(300, 28);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(72, 29);
            this.txtDiscount.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(10, 154);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(73, 21);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Tiêu Đề:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(120, 151);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(695, 29);
            this.txtTitle.TabIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(915, 30);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(61, 21);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Mô Tả";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(919, 54);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(522, 91);
            this.txtDescription.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(176, 121);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(95, 21);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Trạng Thái:";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Location = new System.Drawing.Point(278, 120);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(138, 25);
            this.chkStatus.TabIndex = 13;
            this.chkStatus.Text = "Còn Hiệu Lực";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // actionControl
            // 
            this.actionControl.AddButtonVisible = true;
            this.actionControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionControl.DeleteButtonVisible = true;
            this.actionControl.ExcelButtonVisible = true;
            this.actionControl.FilterDataSource = null;
            this.actionControl.FilterDisplayMember = "";
            this.actionControl.FilterLocation = new System.Drawing.Point(578, 16);
            this.actionControl.FilterSize = new System.Drawing.Size(150, 28);
            this.actionControl.FilterValueMember = "";
            this.actionControl.FilterVisible = true;
            this.actionControl.Location = new System.Drawing.Point(210, 198);
            this.actionControl.Name = "actionControl";
            this.actionControl.PrintButtonVisible = true;
            this.actionControl.ReloadButtonVisible = true;
            this.actionControl.SaveButtonVisible = true;
            this.actionControl.SearchButtonLocation = new System.Drawing.Point(340, 10);
            this.actionControl.SearchButtonSize = new System.Drawing.Size(40, 40);
            this.actionControl.SearchButtonVisible = true;
            this.actionControl.SelectedFilter = null;
            this.actionControl.Size = new System.Drawing.Size(1045, 50);
            this.actionControl.TabIndex = 1;
            this.actionControl.UpdateButtonVisble = true;
            this.actionControl.UpdateButtonVisible = true;
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Location = new System.Drawing.Point(14, 73);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(66, 21);
            this.lblEvent.TabIndex = 16;
            this.lblEvent.Text = "Sự kiện";
            // 
            // cboEvent
            // 
            this.cboEvent.FormattingEnabled = true;
            this.cboEvent.Location = new System.Drawing.Point(110, 70);
            this.cboEvent.Name = "cboEvent";
            this.cboEvent.Size = new System.Drawing.Size(121, 28);
            this.cboEvent.TabIndex = 17;
            // 
            // FrmVoucherManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 636);
            this.Controls.Add(this.gbVoucherInfo);
            this.Controls.Add(this.actionControl);
            this.Controls.Add(this.dgvVouchers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVoucherManagement";
            this.Text = "Quản lý voucher";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVouchers)).EndInit();
            this.gbVoucherInfo.ResumeLayout(false);
            this.gbVoucherInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cboEvent;
        private System.Windows.Forms.Label lblEvent;
    }
}
