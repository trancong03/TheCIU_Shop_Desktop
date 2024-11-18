namespace GUI
{
    partial class frmLogin
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
            this.loginControl1 = new CustomControl.LoginControl();
            this.SuspendLayout();
            // 
            // loginControl1
            // 
            this.loginControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loginControl1.Location = new System.Drawing.Point(12, 12);
            this.loginControl1.Name = "loginControl1";
            this.loginControl1.Password = "";
            this.loginControl1.Size = new System.Drawing.Size(400, 276);
            this.loginControl1.TabIndex = 0;
            this.loginControl1.Username = "";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 299);
            this.Controls.Add(this.loginControl1);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControl.LoginControl loginControl1;
    }
}