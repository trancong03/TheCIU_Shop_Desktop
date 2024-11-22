namespace GUI
{
    partial class FrmDangKy
    {
        private CustomControl.RegisterControl registerControl1;

        private void InitializeComponent()
        {
            this.registerControl1 = new CustomControl.RegisterControl();
            this.SuspendLayout();
            // 
            // registerControl1
            // 
            this.registerControl1.Location = new System.Drawing.Point(12, 12);
            this.registerControl1.Name = "registerControl1";
            this.registerControl1.Size = new System.Drawing.Size(457, 422);
            this.registerControl1.TabIndex = 0;
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 443);
            this.Controls.Add(this.registerControl1);
            this.Name = "frmDangKy";
            this.Text = "Đăng Ký";
            this.ResumeLayout(false);

        }
    }
}
