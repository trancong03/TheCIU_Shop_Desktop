using System.Windows.Forms;

namespace GUI
{
    partial class FrmAccountManagement
    {
        private System.Windows.Forms.DataGridView dataGridViewAccounts;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.CheckBox chkStatus;  // CheckBox trạng thái
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblStatus;   // Label cho trạng thái
        private System.Windows.Forms.GroupBox groupBoxAccountInfo;
        private CustomControl.ActionControl actionControl;

        private void InitializeComponent()
        {
            this.dataGridViewAccounts = new System.Windows.Forms.DataGridView();
            this.groupBoxAccountInfo = new System.Windows.Forms.GroupBox();
            this.actionControl = new CustomControl.ActionControl();

            // Labels
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();

            // Inputs
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.chkStatus = new System.Windows.Forms.CheckBox();

            // DataGridView
            this.dataGridViewAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccounts.Dock = System.Windows.Forms.DockStyle.Fill;

            // ActionControl
            this.actionControl.Dock = System.Windows.Forms.DockStyle.Top;

            // GroupBox
            this.groupBoxAccountInfo.Controls.Add(this.lblUsername);
            this.groupBoxAccountInfo.Controls.Add(this.txtUsername);
            this.groupBoxAccountInfo.Controls.Add(this.lblName);
            this.groupBoxAccountInfo.Controls.Add(this.txtName);
            this.groupBoxAccountInfo.Controls.Add(this.lblPassword);
            this.groupBoxAccountInfo.Controls.Add(this.txtPassword);
            this.groupBoxAccountInfo.Controls.Add(this.lblEmail);
            this.groupBoxAccountInfo.Controls.Add(this.txtEmail);
            this.groupBoxAccountInfo.Controls.Add(this.lblPhone);
            this.groupBoxAccountInfo.Controls.Add(this.txtPhone);
            this.groupBoxAccountInfo.Controls.Add(this.lblAddress);
            this.groupBoxAccountInfo.Controls.Add(this.txtAddress);
            this.groupBoxAccountInfo.Controls.Add(this.lblGender);
            this.groupBoxAccountInfo.Controls.Add(this.cmbGender);
            this.groupBoxAccountInfo.Controls.Add(this.lblStatus);
            this.groupBoxAccountInfo.Controls.Add(this.chkStatus);
            this.groupBoxAccountInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxAccountInfo.Height = 180;
            this.groupBoxAccountInfo.Text = "Thông tin tài khoản";

            // Labels Position
            int labelX = 20, inputX = 140;
            int topStart = 20, verticalSpacing = 30;

            this.lblUsername.Location = new System.Drawing.Point(labelX, topStart);
            this.lblUsername.Text = "Tên đăng nhập:";
            this.txtUsername.Location = new System.Drawing.Point(inputX, topStart);

            this.lblName.Location = new System.Drawing.Point(labelX, topStart + verticalSpacing);
            this.lblName.Text = "Họ và tên:";
            this.txtName.Location = new System.Drawing.Point(inputX, topStart + verticalSpacing);

            this.lblPassword.Location = new System.Drawing.Point(labelX, topStart + 2 * verticalSpacing);
            this.lblPassword.Text = "Mật khẩu:";
            this.txtPassword.Location = new System.Drawing.Point(inputX, topStart + 2 * verticalSpacing);

            this.lblEmail.Location = new System.Drawing.Point(labelX, topStart + 3 * verticalSpacing);
            this.lblEmail.Text = "Email:";
            this.txtEmail.Location = new System.Drawing.Point(inputX, topStart + 3 * verticalSpacing);

            // Cột phải
            labelX = 360;
            inputX = 480;

            this.lblPhone.Location = new System.Drawing.Point(labelX, topStart);
            this.lblPhone.Text = "Số điện thoại:";
            this.txtPhone.Location = new System.Drawing.Point(inputX, topStart);

            this.lblAddress.Location = new System.Drawing.Point(labelX, topStart + verticalSpacing);
            this.lblAddress.Text = "Địa chỉ:";
            this.txtAddress.Location = new System.Drawing.Point(inputX, topStart + verticalSpacing);

            this.lblGender.Location = new System.Drawing.Point(labelX, topStart + 2 * verticalSpacing);
            this.lblGender.Text = "Giới tính:";
            this.cmbGender.Location = new System.Drawing.Point(inputX, topStart + 2 * verticalSpacing);

            this.lblStatus.Location = new System.Drawing.Point(labelX, topStart + 3 * verticalSpacing);
            this.lblStatus.Text = "Trạng thái:";
            this.chkStatus.Location = new System.Drawing.Point(inputX, topStart + 3 * verticalSpacing);
            this.chkStatus.Text = "Hoạt động";

            // Form
            this.Controls.Add(this.dataGridViewAccounts);
            this.Controls.Add(this.actionControl);
            this.Controls.Add(this.groupBoxAccountInfo);
            this.Text = "Quản lý tài khoản";
            this.ClientSize = new System.Drawing.Size(1000, 600);
        }




    }
}
