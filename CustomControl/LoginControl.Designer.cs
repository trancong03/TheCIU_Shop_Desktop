namespace CustomControl
{
    partial class LoginControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBoxUserIcon;
        private System.Windows.Forms.PictureBox pictureBoxPasswordIcon;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.Button btnExit;

        /// <summary> 
        /// Cleanup any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxUserIcon = new System.Windows.Forms.PictureBox();
            this.pictureBoxPasswordIcon = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPasswordIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::CustomControl.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(100, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pictureBoxUserIcon
            // 
            this.pictureBoxUserIcon.Image = global::CustomControl.Properties.Resources.user_icon;
            this.pictureBoxUserIcon.Location = new System.Drawing.Point(40, 120);
            this.pictureBoxUserIcon.Name = "pictureBoxUserIcon";
            this.pictureBoxUserIcon.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUserIcon.TabIndex = 1;
            this.pictureBoxUserIcon.TabStop = false;
            // 
            // pictureBoxPasswordIcon
            // 
            this.pictureBoxPasswordIcon.Image = global::CustomControl.Properties.Resources.password_icon;
            this.pictureBoxPasswordIcon.Location = new System.Drawing.Point(40, 160);
            this.pictureBoxPasswordIcon.Name = "pictureBoxPasswordIcon";
            this.pictureBoxPasswordIcon.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxPasswordIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPasswordIcon.TabIndex = 2;
            this.pictureBoxPasswordIcon.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(70, 120);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(180, 20);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "demo";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(70, 160);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(180, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(40, 210);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(210, 30);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "LOG IN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.Location = new System.Drawing.Point(150, 186);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(100, 20);
            this.btnShowPassword.TabIndex = 6;
            this.btnShowPassword.Text = "Show Password";
            this.btnShowPassword.UseVisualStyleBackColor = true;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(110, 250);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 20);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LoginControl
            // 
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnShowPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pictureBoxPasswordIcon);
            this.Controls.Add(this.pictureBoxUserIcon);
            this.Controls.Add(this.pictureBoxLogo);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPasswordIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
