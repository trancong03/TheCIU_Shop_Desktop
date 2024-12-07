namespace CustomControls
{
    partial class CurrencyTextBox
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCurrency;

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
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtCurrency
            // 
            this.txtCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCurrency.Location = new System.Drawing.Point(0, 0);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(200, 22);
            this.txtCurrency.TabIndex = 0;
            this.txtCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CurrencyTextBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.txtCurrency);
            this.Name = "CurrencyTextBox";
            this.Size = new System.Drawing.Size(200, 22);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
