namespace GUI
{
    partial class FrmOrderManagement
    {
        private CustomControl.CustomDataGridViewControl customDataGridViewOrders; // Sử dụng UserControl
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.DateTimePicker dateOrderDate;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private CustomControl.ActionControl actionControl;

        private void InitializeComponent()
        {
            this.customDataGridViewOrders = new CustomControl.CustomDataGridViewControl(); // Thay DataGridView bằng UserControl
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.actionControl = new CustomControl.ActionControl();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.dateOrderDate = new System.Windows.Forms.DateTimePicker();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();

            // GroupBox "Thao tác"
            this.groupBoxDetails.Text = "Thao tác";
            this.groupBoxDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDetails.Height = 150;

            // Labels and Inputs
            int labelX = 20;
            int inputX = 140;
            int topMargin = 30;
            int verticalSpacing = 30;

            this.lblOrderId.Location = new System.Drawing.Point(labelX, topMargin);
            this.lblOrderId.Size = new System.Drawing.Size(100, 20);
            this.lblOrderId.Text = "Mã đơn hàng:";
            this.groupBoxDetails.Controls.Add(this.lblOrderId);

            this.lblUsername.Location = new System.Drawing.Point(labelX, topMargin + verticalSpacing);
            this.lblUsername.Size = new System.Drawing.Size(100, 20);
            this.lblUsername.Text = "Tên tài khoản:";
            this.groupBoxDetails.Controls.Add(this.lblUsername);

            this.lblOrderDate.Location = new System.Drawing.Point(labelX + 400, topMargin);
            this.lblOrderDate.Size = new System.Drawing.Size(100, 20);
            this.lblOrderDate.Text = "Ngày đặt:";
            this.groupBoxDetails.Controls.Add(this.lblOrderDate);

            this.lblStatus.Location = new System.Drawing.Point(labelX + 400, topMargin + verticalSpacing);
            this.lblStatus.Size = new System.Drawing.Size(100, 20);
            this.lblStatus.Text = "Trạng thái:";
            this.groupBoxDetails.Controls.Add(this.lblStatus);

            this.lblAmount.Location = new System.Drawing.Point(labelX, topMargin + 2 * verticalSpacing);
            this.lblAmount.Size = new System.Drawing.Size(100, 20);
            this.lblAmount.Text = "Số tiền:";
            this.groupBoxDetails.Controls.Add(this.lblAmount);

            // Textboxes and DateTimePicker
            this.txtOrderId.Location = new System.Drawing.Point(inputX, topMargin);
            this.txtOrderId.Size = new System.Drawing.Size(200, 22);
            this.groupBoxDetails.Controls.Add(this.txtOrderId);

            this.txtUsername.Location = new System.Drawing.Point(inputX, topMargin + verticalSpacing);
            this.txtUsername.Size = new System.Drawing.Size(200, 22);
            this.groupBoxDetails.Controls.Add(this.txtUsername);

            this.dateOrderDate.Location = new System.Drawing.Point(inputX + 400, topMargin);
            this.dateOrderDate.Size = new System.Drawing.Size(200, 22);
            this.groupBoxDetails.Controls.Add(this.dateOrderDate);

            this.txtStatus.Location = new System.Drawing.Point(inputX + 400, topMargin + verticalSpacing);
            this.txtStatus.Size = new System.Drawing.Size(200, 22);
            this.groupBoxDetails.Controls.Add(this.txtStatus);

            this.txtAmount.Location = new System.Drawing.Point(inputX, topMargin + 2 * verticalSpacing);
            this.txtAmount.Size = new System.Drawing.Size(200, 22);
            this.groupBoxDetails.Controls.Add(this.txtAmount);

            // ActionControl
            this.actionControl.Dock = System.Windows.Forms.DockStyle.Top;

            // CustomDataGridViewControl
            this.customDataGridViewOrders.Dock = System.Windows.Forms.DockStyle.Fill;

            // Add Controls to Form
            this.Controls.Add(this.customDataGridViewOrders); // Thêm UserControl vào Form
            this.Controls.Add(this.actionControl);
            this.Controls.Add(this.groupBoxDetails);

            // Form Settings
            this.Text = "Quản lý Đơn hàng";
            this.ClientSize = new System.Drawing.Size(1000, 600);
        }
    }
}
