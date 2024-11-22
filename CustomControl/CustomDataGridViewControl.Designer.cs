namespace CustomControl
{
    partial class CustomDataGridViewControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView customDataGridView;

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
            this.customDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.customDataGridView)).BeginInit();
            this.SuspendLayout();

            // 
            // customDataGridView
            // 
            this.customDataGridView.AllowUserToAddRows = false;
            this.customDataGridView.AllowUserToDeleteRows = false;
            this.customDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customDataGridView.Location = new System.Drawing.Point(0, 0);
            this.customDataGridView.Name = "customDataGridView";
            this.customDataGridView.RowHeadersWidth = 62;
            this.customDataGridView.RowTemplate.Height = 28;
            this.customDataGridView.Size = new System.Drawing.Size(800, 450);
            this.customDataGridView.TabIndex = 0;
            this.customDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomDataGridView_CellContentClick);

            // 
            // CustomDataGridViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customDataGridView);
            this.Name = "CustomDataGridViewControl";
            this.Size = new System.Drawing.Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)(this.customDataGridView)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
