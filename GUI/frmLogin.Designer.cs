namespace GUI
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginControl = new CustomControl.LoginControl();
            this.SuspendLayout();
            // 
            // loginControl
            // 
            this.loginControl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loginControl.Location = new System.Drawing.Point(9, 10);
            this.loginControl.Margin = new System.Windows.Forms.Padding(2);
            this.loginControl.Name = "loginControl";
            this.loginControl.Password = "";
            this.loginControl.Size = new System.Drawing.Size(382, 277);
            this.loginControl.TabIndex = 0;
            this.loginControl.Username = "";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 312);
            this.Controls.Add(this.loginControl);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControl.LoginControl loginControl;
    }
}