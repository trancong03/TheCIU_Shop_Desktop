namespace GUI
{
    partial class FrmProductManagement
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Label lblDateAdd;
        private System.Windows.Forms.DateTimePicker dtpDateAdd;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private CustomControl.ActionControl actionControl;
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.Button btnUploadImage;

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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.lblDateAdd = new System.Windows.Forms.Label();
            this.dtpDateAdd = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.actionControl = new CustomControl.ActionControl();

            // tableLayoutPanel
            this.tableLayoutPanel.ColumnCount = 7;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.144793F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.13209F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.Controls.Add(this.lblProductName, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.txtProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lblTitle, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.txtTitle, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.lblCategory, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.cmbCategory, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.lblPrice, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.txtPrice, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.lblSize, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.cmbSize, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.lblColor, 4, 1);
            this.tableLayoutPanel.Controls.Add(this.cmbColor, 5, 1);
            this.tableLayoutPanel.Controls.Add(this.lblQuantity, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.txtQuantity, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.lblRating, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.txtRating, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.lblDateAdd, 4, 2);
            this.tableLayoutPanel.Controls.Add(this.dtpDateAdd, 5, 2);
            this.tableLayoutPanel.Controls.Add(this.pictureBoxProduct, 6, 0);
            this.tableLayoutPanel.Controls.Add(this.btnUploadImage, 6, 2);
            this.tableLayoutPanel.SetRowSpan(this.pictureBoxProduct, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 20);
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1201, 140);
            this.tableLayoutPanel.TabIndex = 2;

            // btnUploadImage
            this.btnUploadImage.Text = "Upload ảnh";
            this.btnUploadImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUploadImage.Name = "btnUploadImage";

            // Configure Labels
            ConfigureLabel(this.lblProductName, "Tên sản phẩm:", new System.Drawing.Point(13, 10));
            ConfigureLabel(this.lblTitle, "Tiêu đề:", new System.Drawing.Point(406, 10));
            ConfigureLabel(this.lblCategory, "Danh mục:", new System.Drawing.Point(798, 10));
            ConfigureLabel(this.lblPrice, "Giá:", new System.Drawing.Point(13, 50));
            ConfigureLabel(this.lblSize, "Kích cỡ:", new System.Drawing.Point(406, 50));
            ConfigureLabel(this.lblColor, "Màu sắc:", new System.Drawing.Point(798, 50));
            ConfigureLabel(this.lblQuantity, "Số lượng:", new System.Drawing.Point(13, 90));
            ConfigureLabel(this.lblRating, "Đánh giá:", new System.Drawing.Point(406, 90));
            ConfigureLabel(this.lblDateAdd, "Ngày thêm:", new System.Drawing.Point(798, 90));

            // PictureBox
            this.pictureBoxProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // DataGridView
            this.dataGridViewProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProducts.Size = new System.Drawing.Size(1201, 455);

            // ActionControl
            this.actionControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionControl.Location = new System.Drawing.Point(0, 140);
            this.actionControl.Size = new System.Drawing.Size(1201, 58);

            // FrmProductManagement
            this.ClientSize = new System.Drawing.Size(1201, 653);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.actionControl);
            this.Controls.Add(this.tableLayoutPanel);
            this.Text = "Quản lý sản phẩm và biến thể";

            // Bind events
            this.btnUploadImage.Click += new System.EventHandler(this.BtnUploadImage_Click);
        }

        private void ConfigureLabel(System.Windows.Forms.Label label, string text, System.Drawing.Point location)
        {
            label.Text = text;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            label.ForeColor = System.Drawing.Color.Black;
            label.BackColor = System.Drawing.SystemColors.Control;
            label.AutoSize = false;
            label.Size = new System.Drawing.Size(100, 23);
            label.Location = location;
        }
    }
}
