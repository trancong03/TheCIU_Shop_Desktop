namespace GUI
{
    partial class FrmVoucherManagement
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewVouchers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.CheckBox chkStatus;
        private CustomControl.ActionControl actionControl;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblStatus;

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
            this.dataGridViewVouchers = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.actionControl = new CustomControl.ActionControl();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVouchers)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // dataGridViewVouchers
            // 
            this.dataGridViewVouchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVouchers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewVouchers.Location = new System.Drawing.Point(0, 420);
            this.dataGridViewVouchers.Name = "dataGridViewVouchers";
            this.dataGridViewVouchers.RowHeadersWidth = 51;
            this.dataGridViewVouchers.Size = new System.Drawing.Size(1146, 280);
            this.dataGridViewVouchers.TabIndex = 0;

            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.txtTitle, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lblDescription, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.txtDescription, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.lblStartDate, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.dtpStartDate, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.lblEndDate, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.dtpEndDate, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.lblDiscount, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.txtDiscount, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.lblStatus, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.chkStatus, 3, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1146, 150);
            this.tableLayoutPanel.TabIndex = 1;

            // Labels
            ConfigureLabel(this.lblTitle, "Tiêu đề:", 0, 0);
            ConfigureLabel(this.lblDescription, "Mô tả:", 2, 0);
            ConfigureLabel(this.lblStartDate, "Ngày bắt đầu:", 0, 1);
            ConfigureLabel(this.lblEndDate, "Ngày kết thúc:", 2, 1);
            ConfigureLabel(this.lblDiscount, "Giảm giá (%):", 0, 2);
            ConfigureLabel(this.lblStatus, "Trạng thái:", 2, 2);

            // TextBoxes and other controls
            ConfigureTextBox(this.txtTitle, 1, 0, 1);
            ConfigureTextBox(this.txtDescription, 3, 0, 1);
            ConfigureDatePicker(this.dtpStartDate, 1, 1);
            ConfigureDatePicker(this.dtpEndDate, 3, 1);
            ConfigureTextBox(this.txtDiscount, 1, 2);
            ConfigureCheckBox(this.chkStatus, "Kích hoạt", 3, 2);

            // 
            // actionControl
            // 
            this.actionControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionControl.FilterDataSource = null;
            this.actionControl.FilterDisplayMember = "";
            this.actionControl.FilterValueMember = "";
            this.actionControl.FilterVisible = true;
            this.actionControl.Location = new System.Drawing.Point(0, 150);
            this.actionControl.Name = "actionControl";
            this.actionControl.Size = new System.Drawing.Size(1146, 60);
            this.actionControl.TabIndex = 7;

            // 
            // FrmVoucherManagement
            // 
            this.ClientSize = new System.Drawing.Size(1146, 700);
            this.Controls.Add(this.dataGridViewVouchers);
            this.Controls.Add(this.actionControl);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "FrmVoucherManagement";
            this.Text = "Quản lý Voucher";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVouchers)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        private void ConfigureLabel(System.Windows.Forms.Label label, string text, int col, int row)
        {
            label.Text = text;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.Black;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(label, col, row);
        }

        private void ConfigureTextBox(System.Windows.Forms.TextBox textBox, int col, int row, int columnSpan = 1)
        {
            textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(textBox, col, row);
            this.tableLayoutPanel.SetColumnSpan(textBox, columnSpan);
        }

        private void ConfigureDatePicker(System.Windows.Forms.DateTimePicker datePicker, int col, int row)
        {
            datePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            datePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(datePicker, col, row);
        }

        private void ConfigureCheckBox(System.Windows.Forms.CheckBox checkBox, string text, int col, int row)
        {
            checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox.Text = text;
            checkBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(checkBox, col, row);
        }
    }
}
