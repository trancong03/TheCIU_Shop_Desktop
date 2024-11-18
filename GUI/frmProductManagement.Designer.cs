namespace GUI
{
    partial class frmProductManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtImageSP = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.dtpDateAdd = new System.Windows.Forms.DateTimePicker();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblImageSP = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblDateAdd = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();

            // txtProductName
            this.txtProductName.Location = new System.Drawing.Point(125, 33);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(200, 22);

            // cmbSize
            this.cmbSize.Location = new System.Drawing.Point(120, 124);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(200, 22);

            // cmbColor
            this.cmbColor.Location = new System.Drawing.Point(120, 152);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(200, 22);

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(520, 33);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 22);

            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(520, 65);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 22);

            // txtImageSP
            this.txtImageSP.Location = new System.Drawing.Point(520, 97);
            this.txtImageSP.Name = "txtImageSP";
            this.txtImageSP.Size = new System.Drawing.Size(200, 22);

            // txtRating
            this.txtRating.Location = new System.Drawing.Point(520, 129);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(200, 22);

            // dtpDateAdd
            this.dtpDateAdd.Location = new System.Drawing.Point(520, 161);
            this.dtpDateAdd.Name = "dtpDateAdd";
            this.dtpDateAdd.Size = new System.Drawing.Size(200, 22);

            // cmbCategory
            this.cmbCategory.Location = new System.Drawing.Point(120, 95);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 22);

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(120, 61);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 22);

            // dataGridViewProducts
            this.dataGridViewProducts.Location = new System.Drawing.Point(30, 263);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.Size = new System.Drawing.Size(800, 367);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(268, 211);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 32);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(349, 211);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 32);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(430, 211);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 32);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // lblProductName
            this.lblProductName.Location = new System.Drawing.Point(30, 32);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(89, 16);
            this.lblProductName.Text = "Tên Sản Phẩm:";

            // lblSize
            this.lblSize.Location = new System.Drawing.Point(30, 124);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(45, 16);
            this.lblSize.Text = "Kích cỡ:";

            // lblColor
            this.lblColor.Location = new System.Drawing.Point(30, 152);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(52, 16);
            this.lblColor.Text = "Màu sắc:";

            // lblQuantity
            this.lblQuantity.Location = new System.Drawing.Point(430, 33);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(59, 16);
            this.lblQuantity.Text = "Số Lượng:";

            // lblTitle
            this.lblTitle.Location = new System.Drawing.Point(430, 65);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(50, 16);
            this.lblTitle.Text = "Tiêu Đề:";

            // lblImageSP
            this.lblImageSP.Location = new System.Drawing.Point(430, 97);
            this.lblImageSP.Name = "lblImageSP";
            this.lblImageSP.Size = new System.Drawing.Size(56, 16);
            this.lblImageSP.Text = "Hình Ảnh:";

            // lblRating
            this.lblRating.Location = new System.Drawing.Point(430, 129);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(57, 16);
            this.lblRating.Text = "Đánh Giá:";

            // lblDateAdd
            this.lblDateAdd.Location = new System.Drawing.Point(430, 161);
            this.lblDateAdd.Name = "lblDateAdd";
            this.lblDateAdd.Size = new System.Drawing.Size(70, 16);
            this.lblDateAdd.Text = "Ngày Thêm:";

            // lblCategory
            this.lblCategory.Location = new System.Drawing.Point(30, 95);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 16);
            this.lblCategory.Text = "Danh Mục:";

            // lblPrice
            this.lblPrice.Location = new System.Drawing.Point(30, 60);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(23, 16);
            this.lblPrice.Text = "Giá:";

            // frmProductManagement
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 640);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDateAdd);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblImageSP);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.dtpDateAdd);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.txtImageSP);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.cmbSize);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmProductManagement";
            this.Text = "Quản Lý Sản Phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtImageSP;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.DateTimePicker dtpDateAdd;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblImageSP;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblDateAdd;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblPrice;
    }
}
