namespace TheCIU_Shop.GUI.Forms
{
    partial class frmDangNhap
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
            this.loginControl = new LoginControl.LoginControl();
            this.SuspendLayout();
            // 
            // loginControl
            // 
            this.loginControl.Location = new System.Drawing.Point(27, 12);
            this.loginControl.Name = "loginControl";
            this.loginControl.Password = "";
            this.loginControl.Size = new System.Drawing.Size(410, 247);
            this.loginControl.TabIndex = 4;
            this.loginControl.UserName = "";
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 292);
            this.Controls.Add(this.loginControl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDangNhap";
            this.Text = "frmDangNhap";
            this.ResumeLayout(false);

        }

        #endregion

        private LoginControl.LoginControl loginControl;
    }
}