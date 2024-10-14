namespace GUI
{
    partial class frmAccountManagement
    {
        private System.Windows.Forms.DataGridView dataGridViewAccounts;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cmbGender;
<<<<<<< HEAD
=======
        private System.Windows.Forms.CheckBox chkStatus;  // CheckBox trạng thái
>>>>>>> Huy
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblGender;
<<<<<<< HEAD
        private System.Windows.Forms.GroupBox groupBoxAccountInfo;
        private CustomControl.ActionControl actionControl;  // Thêm ActionControl vào form
=======
        private System.Windows.Forms.Label lblStatus;   // Label cho trạng thái
        private System.Windows.Forms.GroupBox groupBoxAccountInfo;
        private CustomControl.ActionControl actionControl;
>>>>>>> Huy

        private void InitializeComponent()
        {
            this.dataGridViewAccounts = new System.Windows.Forms.DataGridView();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
<<<<<<< HEAD
=======
            this.chkStatus = new System.Windows.Forms.CheckBox();  // Thêm CheckBox trạng thái
>>>>>>> Huy
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
<<<<<<< HEAD
            this.groupBoxAccountInfo = new System.Windows.Forms.GroupBox();
            this.actionControl = new CustomControl.ActionControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounts)).BeginInit();
            this.groupBoxAccountInfo.SuspendLayout();
            this.SuspendLayout();
=======
            this.lblStatus = new System.Windows.Forms.Label();    // Thêm Label trạng thái
            this.groupBoxAccountInfo = new System.Windows.Forms.GroupBox();
            this.actionControl = new CustomControl.ActionControl();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounts)).BeginInit();
            this.groupBoxAccountInfo.SuspendLayout();
            this.SuspendLayout();

>>>>>>> Huy
            // 
            // dataGridViewAccounts
            // 
            this.dataGridViewAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccounts.Location = new System.Drawing.Point(12, 242);
            this.dataGridViewAccounts.Name = "dataGridViewAccounts";
<<<<<<< HEAD
            this.dataGridViewAccounts.Size = new System.Drawing.Size(760, 206);
            this.dataGridViewAccounts.TabIndex = 0;
            this.dataGridViewAccounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAccounts_CellClick);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(102, 27);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(167, 20);
            this.txtUsername.TabIndex = 15;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(102, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(167, 20);
            this.txtName.TabIndex = 16;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(102, 93);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(167, 20);
            this.txtPassword.TabIndex = 17;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(102, 120);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(167, 20);
            this.txtEmail.TabIndex = 18;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(499, 26);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(167, 20);
            this.txtPhone.TabIndex = 19;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(499, 53);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(167, 20);
            this.txtAddress.TabIndex = 20;
            // 
            // cmbGender
            // 
            this.cmbGender.Location = new System.Drawing.Point(499, 83);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(167, 21);
            this.cmbGender.TabIndex = 21;
=======
            this.dataGridViewAccounts.Size = new System.Drawing.Size(927, 206);
            this.dataGridViewAccounts.TabIndex = 0;
            this.dataGridViewAccounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAccounts_CellClick);

            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(182, 27);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(167, 20);
            this.txtUsername.TabIndex = 15;

            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(182, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(167, 20);
            this.txtName.TabIndex = 16;

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(182, 93);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(167, 20);
            this.txtPassword.TabIndex = 17;

            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(182, 120);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(167, 20);
            this.txtEmail.TabIndex = 18;

            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(579, 26);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(167, 20);
            this.txtPhone.TabIndex = 19;

            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(579, 53);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(167, 20);
            this.txtAddress.TabIndex = 20;

            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            this.cmbGender.Location = new System.Drawing.Point(579, 83);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(167, 21);
            this.cmbGender.TabIndex = 21;

            // 
            // chkStatus
            // 
            this.chkStatus.Location = new System.Drawing.Point(579, 120);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(167, 24);
            this.chkStatus.TabIndex = 22;
            this.chkStatus.Text = "Hoạt động";
            this.chkStatus.UseVisualStyleBackColor = true;

            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(487, 126);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 13);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Text = "Trạng thái:";

>>>>>>> Huy
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
<<<<<<< HEAD
            this.lblUsername.Location = new System.Drawing.Point(10, 30);
=======
            this.lblUsername.Location = new System.Drawing.Point(90, 30);
>>>>>>> Huy
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(84, 13);
            this.lblUsername.TabIndex = 14;
            this.lblUsername.Text = "Tên đăng nhập:";
<<<<<<< HEAD
=======

>>>>>>> Huy
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
<<<<<<< HEAD
            this.lblName.Location = new System.Drawing.Point(10, 60);
=======
            this.lblName.Location = new System.Drawing.Point(90, 60);
>>>>>>> Huy
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 13);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Họ và tên:";
<<<<<<< HEAD
=======

>>>>>>> Huy
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
<<<<<<< HEAD
            this.lblPassword.Location = new System.Drawing.Point(10, 90);
=======
            this.lblPassword.Location = new System.Drawing.Point(90, 90);
>>>>>>> Huy
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(55, 13);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "Mật khẩu:";
<<<<<<< HEAD
=======

>>>>>>> Huy
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
<<<<<<< HEAD
            this.lblEmail.Location = new System.Drawing.Point(10, 120);
=======
            this.lblEmail.Location = new System.Drawing.Point(90, 120);
>>>>>>> Huy
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 17;
            this.lblEmail.Text = "Email:";
<<<<<<< HEAD
=======

>>>>>>> Huy
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
<<<<<<< HEAD
            this.lblPhone.Location = new System.Drawing.Point(407, 26);
=======
            this.lblPhone.Location = new System.Drawing.Point(487, 26);
>>>>>>> Huy
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(73, 13);
            this.lblPhone.TabIndex = 18;
            this.lblPhone.Text = "Số điện thoại:";
<<<<<<< HEAD
=======

>>>>>>> Huy
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
<<<<<<< HEAD
            this.lblAddress.Location = new System.Drawing.Point(407, 56);
=======
            this.lblAddress.Location = new System.Drawing.Point(487, 56);
>>>>>>> Huy
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(43, 13);
            this.lblAddress.TabIndex = 19;
            this.lblAddress.Text = "Địa chỉ:";
<<<<<<< HEAD
=======

>>>>>>> Huy
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
<<<<<<< HEAD
            this.lblGender.Location = new System.Drawing.Point(407, 86);
=======
            this.lblGender.Location = new System.Drawing.Point(487, 86);
>>>>>>> Huy
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(50, 13);
            this.lblGender.TabIndex = 20;
            this.lblGender.Text = "Giới tính:";
<<<<<<< HEAD
=======

>>>>>>> Huy
            // 
            // groupBoxAccountInfo
            // 
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
<<<<<<< HEAD
            this.groupBoxAccountInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAccountInfo.Name = "groupBoxAccountInfo";
            this.groupBoxAccountInfo.Size = new System.Drawing.Size(760, 170);
            this.groupBoxAccountInfo.TabIndex = 21;
            this.groupBoxAccountInfo.TabStop = false;
            this.groupBoxAccountInfo.Text = "Thông tin tài khoản";
            // 
            // actionControl
            // 
            this.actionControl.Location = new System.Drawing.Point(25, 188);
            this.actionControl.Name = "actionControl";
            this.actionControl.Size = new System.Drawing.Size(714, 40);
            this.actionControl.TabIndex = 22;
            // 
            // frmAccountManagement
            // 
            this.ClientSize = new System.Drawing.Size(784, 464);
=======
            this.groupBoxAccountInfo.Controls.Add(this.chkStatus);  // Thêm CheckBox trạng thái
            this.groupBoxAccountInfo.Controls.Add(this.lblStatus);  // Thêm Label trạng thái
            this.groupBoxAccountInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAccountInfo.Name = "groupBoxAccountInfo";
            this.groupBoxAccountInfo.Size = new System.Drawing.Size(910, 170);
            this.groupBoxAccountInfo.TabIndex = 21;
            this.groupBoxAccountInfo.TabStop = false;
            this.groupBoxAccountInfo.Text = "Thông tin tài khoản";

            // 
            // actionControl
            // 
            this.actionControl.Location = new System.Drawing.Point(105, 188);
            this.actionControl.Name = "actionControl";
            this.actionControl.Size = new System.Drawing.Size(760, 40);
            this.actionControl.TabIndex = 22;

            // 
            // frmAccountManagement
            // 
            this.ClientSize = new System.Drawing.Size(968, 464);
>>>>>>> Huy
            this.Controls.Add(this.dataGridViewAccounts);
            this.Controls.Add(this.groupBoxAccountInfo);
            this.Controls.Add(this.actionControl);
            this.Name = "frmAccountManagement";
            this.Text = "Quản lý tài khoản";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounts)).EndInit();
            this.groupBoxAccountInfo.ResumeLayout(false);
            this.groupBoxAccountInfo.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
