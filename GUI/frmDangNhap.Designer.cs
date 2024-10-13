namespace GUI
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
            this.loginControl = new CustomControl.LoginControl();
            this.SuspendLayout();
            // 
            // loginControl
            // 
            this.loginControl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loginControl.Location = new System.Drawing.Point(0, -3);
            this.loginControl.Name = "loginControl";
            this.loginControl.Password = "";
            this.loginControl.Size = new System.Drawing.Size(372, 276);
            this.loginControl.TabIndex = 0;
            this.loginControl.Username = "demo";
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 268);
            this.Controls.Add(this.loginControl);
            this.Name = "frmDangNhap";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControl.LoginControl loginControl;
    }
}

