using System.Windows.Forms;
namespace LoginControl
{
    partial class LoginControl
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các control khác
        private CustomTextBox.txtPassword txtPassword1;
        private CustomTextBox.txtUsername txtUsername1;
        private Button btnLogin;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginControl));
            this.txtPassword1 = new CustomTextBox.txtPassword();
            this.txtUsername1 = new CustomTextBox.txtUsername();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPassword1
            // 
            this.txtPassword1.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword1.Icon = ((System.Drawing.Image)(resources.GetObject("txtPassword1.Icon")));
            this.txtPassword1.Location = new System.Drawing.Point(33, 105);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Placeholder = "Nhập mật khẩu";
            this.txtPassword1.Size = new System.Drawing.Size(250, 22);
            this.txtPassword1.TabIndex = 0;
            // 
            // txtUsername1
            // 
            this.txtUsername1.ForeColor = System.Drawing.Color.Gray;
            this.txtUsername1.Icon = ((System.Drawing.Image)(resources.GetObject("txtUsername1.Icon")));
            this.txtUsername1.Location = new System.Drawing.Point(33, 63);
            this.txtUsername1.Name = "txtUsername1";
            this.txtUsername1.Placeholder = "Nhập tên đăng nhập";
            this.txtUsername1.Size = new System.Drawing.Size(250, 22);
            this.txtUsername1.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(33, 150);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(250, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUsername1);
            this.Controls.Add(this.txtPassword1);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(319, 221);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

