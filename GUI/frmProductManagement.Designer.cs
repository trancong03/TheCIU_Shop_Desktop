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
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Label lblDateAdd;
        private System.Windows.Forms.DateTimePicker dtpDateAdd;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private CustomControl.ActionControl actionControl;

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
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.actionControl = new CustomControl.ActionControl();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.144793F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.13209F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6F));
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
            // 
            // lblProductName
            // 
            this.lblProductName.Location = new System.Drawing.Point(13, 10);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(100, 23);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Tên sản phẩm:";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtProductName.Location = new System.Drawing.Point(121, 19);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(279, 22);
            this.txtProductName.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(406, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Tiêu đề:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTitle.Location = new System.Drawing.Point(602, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(190, 22);
            this.txtTitle.TabIndex = 3;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(798, 10);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(100, 23);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Danh mục:";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbCategory.Location = new System.Drawing.Point(994, 18);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(194, 24);
            this.cmbCategory.TabIndex = 5;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(13, 50);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(100, 23);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Giá:";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPrice.Location = new System.Drawing.Point(121, 59);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(105, 22);
            this.txtPrice.TabIndex = 7;
            // 
            // lblSize
            // 
            this.lblSize.Location = new System.Drawing.Point(406, 50);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(100, 23);
            this.lblSize.TabIndex = 8;
            this.lblSize.Text = "Kích cỡ:";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSize
            // 
            this.cmbSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbSize.Location = new System.Drawing.Point(602, 58);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(190, 24);
            this.cmbSize.TabIndex = 9;
            // 
            // lblColor
            // 
            this.lblColor.Location = new System.Drawing.Point(798, 50);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(100, 23);
            this.lblColor.TabIndex = 10;
            this.lblColor.Text = "Màu sắc:";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbColor
            // 
            this.cmbColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbColor.Location = new System.Drawing.Point(994, 58);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(194, 24);
            this.cmbColor.TabIndex = 11;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(13, 90);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 23);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "Số lượng:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtQuantity.Location = new System.Drawing.Point(121, 99);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(61, 22);
            this.txtQuantity.TabIndex = 13;
            // 
            // lblRating
            // 
            this.lblRating.Location = new System.Drawing.Point(406, 90);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(100, 23);
            this.lblRating.TabIndex = 14;
            this.lblRating.Text = "Đánh giá:";
            this.lblRating.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRating
            // 
            this.txtRating.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtRating.Location = new System.Drawing.Point(602, 99);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(190, 22);
            this.txtRating.TabIndex = 15;
            // 
            // lblDateAdd
            // 
            this.lblDateAdd.Location = new System.Drawing.Point(798, 90);
            this.lblDateAdd.Name = "lblDateAdd";
            this.lblDateAdd.Size = new System.Drawing.Size(100, 23);
            this.lblDateAdd.TabIndex = 16;
            this.lblDateAdd.Text = "Ngày thêm:";
            this.lblDateAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDateAdd
            // 
            this.dtpDateAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateAdd.Location = new System.Drawing.Point(994, 99);
            this.dtpDateAdd.Name = "dtpDateAdd";
            this.dtpDateAdd.Size = new System.Drawing.Size(194, 22);
            this.dtpDateAdd.TabIndex = 17;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeight = 29;
            this.dataGridViewProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProducts.Location = new System.Drawing.Point(0, 198);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.Size = new System.Drawing.Size(1201, 455);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // actionControl
            // 
            this.actionControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionControl.FilterDataSource = null;
            this.actionControl.FilterDisplayMember = "";
            this.actionControl.FilterValueMember = "";
            this.actionControl.Location = new System.Drawing.Point(0, 140);
            this.actionControl.Margin = new System.Windows.Forms.Padding(20, 10, 0, 20);
            this.actionControl.Name = "actionControl";
            this.actionControl.Size = new System.Drawing.Size(1201, 58);
            this.actionControl.TabIndex = 1;
            // 
            // FrmProductManagement
            // 
            this.ClientSize = new System.Drawing.Size(1201, 653);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.actionControl);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "FrmProductManagement";
            this.Text = "Quản lý sản phẩm và biến thể";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

    }
}