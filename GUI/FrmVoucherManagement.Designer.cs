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
            this.cboEvent = new System.Windows.Forms.ComboBox();
            this.lblEvent = new System.Windows.Forms.Label();
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
            this.dgvVouchers.Location = new System.Drawing.Point(9, 211);
            this.dgvVouchers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvVouchers.Name = "dgvVouchers";
            this.dgvVouchers.RowHeadersWidth = 51;
            this.dgvVouchers.Size = new System.Drawing.Size(1316, 292);
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
            this.gbVoucherInfo.Location = new System.Drawing.Point(9, 10);
            this.gbVoucherInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbVoucherInfo.Name = "gbVoucherInfo";
            this.gbVoucherInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbVoucherInfo.Size = new System.Drawing.Size(1316, 154);
            this.gbVoucherInfo.TabIndex = 2;
            this.gbVoucherInfo.TabStop = false;
            this.gbVoucherInfo.Text = "Thông Tin Voucher";
            // 
            // cboEvent
            // 
            this.cboEvent.FormattingEnabled = true;
            this.cboEvent.Location = new System.Drawing.Point(82, 57);
            this.cboEvent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboEvent.Name = "cboEvent";
            this.cboEvent.Size = new System.Drawing.Size(162, 25);
            this.cboEvent.TabIndex = 17;
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Location = new System.Drawing.Point(10, 59);
            this.lblEvent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(52, 17);
            this.lblEvent.TabIndex = 16;
            this.lblEvent.Text = "Sự kiện";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(285, 55);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(60, 17);
            this.lblQuantity.TabIndex = 14;
            this.lblQuantity.Text = "Số lượng";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(361, 52);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(55, 24);
            this.txtQuantity.TabIndex = 15;
            // 
            // lblVoucherID
            // 
            this.lblVoucherID.AutoSize = true;
            this.lblVoucherID.Location = new System.Drawing.Point(8, 24);
            this.lblVoucherID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVoucherID.Name = "lblVoucherID";
            this.lblVoucherID.Size = new System.Drawing.Size(84, 17);
            this.lblVoucherID.TabIndex = 0;
            this.lblVoucherID.Text = "Mã Voucher:";
            // 
            // txtVoucherID
            // 
            this.txtVoucherID.Location = new System.Drawing.Point(96, 21);
            this.txtVoucherID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVoucherID.Name = "txtVoucherID";
            this.txtVoucherID.ReadOnly = true;
            this.txtVoucherID.Size = new System.Drawing.Size(148, 24);
            this.txtVoucherID.TabIndex = 1;
            // 
            // lblDateStart
            // 
            this.lblDateStart.AutoSize = true;
            this.lblDateStart.Location = new System.Drawing.Point(493, 19);
            this.lblDateStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateStart.Name = "lblDateStart";
            this.lblDateStart.Size = new System.Drawing.Size(97, 17);
            this.lblDateStart.TabIndex = 2;
            this.lblDateStart.Text = "Ngày Bắt Đầu:";
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Location = new System.Drawing.Point(608, 18);
            this.dtpDateStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Size = new System.Drawing.Size(234, 24);
            this.dtpDateStart.TabIndex = 3;
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.AutoSize = true;
            this.lblDateEnd.Location = new System.Drawing.Point(487, 63);
            this.lblDateEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(103, 17);
            this.lblDateEnd.TabIndex = 4;
            this.lblDateEnd.Text = "Ngày Kết Thúc:";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(608, 57);
            this.dtpDateEnd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(234, 24);
            this.dtpDateEnd.TabIndex = 5;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(285, 18);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(66, 17);
            this.lblDiscount.TabIndex = 6;
            this.lblDiscount.Text = "Giảm Giá:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(361, 17);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(55, 24);
            this.txtDiscount.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(241, 97);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(58, 17);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Tiêu Đề:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(320, 94);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(522, 48);
            this.txtTitle.TabIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(877, 19);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(48, 17);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Mô Tả";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(908, 39);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(392, 103);
            this.txtDescription.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 97);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(75, 17);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Trạng Thái:";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Location = new System.Drawing.Point(96, 97);
            this.chkStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(111, 21);
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
            this.actionControl.FilterLocation = new System.Drawing.Point(434, 13);
            this.actionControl.FilterSize = new System.Drawing.Size(114, 25);
            this.actionControl.FilterValueMember = "";
            this.actionControl.FilterVisible = true;
            this.actionControl.Location = new System.Drawing.Point(158, 161);
            this.actionControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.actionControl.Name = "actionControl";
            this.actionControl.PrintButtonVisible = true;
            this.actionControl.ReloadButtonVisible = true;
            this.actionControl.SaveButtonVisible = true;
            this.actionControl.SearchButtonLocation = new System.Drawing.Point(255, 8);
            this.actionControl.SearchButtonSize = new System.Drawing.Size(30, 32);
            this.actionControl.SearchButtonVisible = true;
            this.actionControl.SelectedFilter = null;
            this.actionControl.Size = new System.Drawing.Size(952, 41);
            this.actionControl.TabIndex = 1;
            this.actionControl.UpdateButtonVisble = true;
            this.actionControl.UpdateButtonVisible = true;
            // 
            // FrmVoucherManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 517);
            this.Controls.Add(this.gbVoucherInfo);
            this.Controls.Add(this.actionControl);
            this.Controls.Add(this.dgvVouchers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
