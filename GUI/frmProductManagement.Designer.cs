namespace GUI
{
    partial class frmProductManagement
    {
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmbCategoryId;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtRating; // Số lượng rating
        private System.Windows.Forms.TextBox txtImagePath; // Đường dẫn của ImageSP
        private System.Windows.Forms.DateTimePicker dtpDateAdd; // DatePicker để chọn ngày
        private System.Windows.Forms.Button btnUploadImage; // Nút upload ảnh
        private CustomControl.ActionControl actionControl;
        private System.Windows.Forms.GroupBox groupBoxProductInfo;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCategoryId;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblRating; // Label cho rating
        private System.Windows.Forms.Label lblImageSP; // Label cho ImageSP
        private System.Windows.Forms.Label lblDateAdd; // Label cho DateAdd

        private void InitializeComponent()
        {
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmbCategoryId = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.dtpDateAdd = new System.Windows.Forms.DateTimePicker();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.actionControl = new CustomControl.ActionControl();
            this.groupBoxProductInfo = new System.Windows.Forms.GroupBox();
            this.lblProductId = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCategoryId = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblImageSP = new System.Windows.Forms.Label();
            this.lblDateAdd = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.groupBoxProductInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(12, 199);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.Size = new System.Drawing.Size(1013, 246);
            this.dataGridViewProducts.TabIndex = 0;
            this.dataGridViewProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellClick);
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(100, 27);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(150, 20);
            this.txtProductId.TabIndex = 1;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(100, 57);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(150, 20);
            this.txtProductName.TabIndex = 2;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(100, 87);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(150, 20);
            this.txtPrice.TabIndex = 3;
            // 
            // cmbCategoryId
            // 
            this.cmbCategoryId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryId.FormattingEnabled = true;
            this.cmbCategoryId.Location = new System.Drawing.Point(503, 26);
            this.cmbCategoryId.Name = "cmbCategoryId";
            this.cmbCategoryId.Size = new System.Drawing.Size(150, 21);
            this.cmbCategoryId.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(841, 22);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(150, 20);
            this.txtDescription.TabIndex = 34;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(503, 57);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(150, 20);
            this.txtStock.TabIndex = 5;
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(503, 87);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(150, 20);
            this.txtRating.TabIndex = 6;
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(841, 52);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(69, 20);
            this.txtImagePath.TabIndex = 7;
            // 
            // dtpDateAdd
            // 
            this.dtpDateAdd.Location = new System.Drawing.Point(841, 84);
            this.dtpDateAdd.Name = "dtpDateAdd";
            this.dtpDateAdd.Size = new System.Drawing.Size(150, 20);
            this.dtpDateAdd.TabIndex = 8;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Location = new System.Drawing.Point(916, 50);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(75, 23);
            this.btnUploadImage.TabIndex = 31;
            this.btnUploadImage.Text = "Upload";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // actionControl
            // 
            this.actionControl.Location = new System.Drawing.Point(206, 155);
            this.actionControl.Name = "actionControl";
            this.actionControl.Size = new System.Drawing.Size(664, 38);
            this.actionControl.TabIndex = 7;
            // 
            // groupBoxProductInfo
            // 
            this.groupBoxProductInfo.Controls.Add(this.lblProductId);
            this.groupBoxProductInfo.Controls.Add(this.txtProductId);
            this.groupBoxProductInfo.Controls.Add(this.lblProductName);
            this.groupBoxProductInfo.Controls.Add(this.txtProductName);
            this.groupBoxProductInfo.Controls.Add(this.lblPrice);
            this.groupBoxProductInfo.Controls.Add(this.txtPrice);
            this.groupBoxProductInfo.Controls.Add(this.lblCategoryId);
            this.groupBoxProductInfo.Controls.Add(this.cmbCategoryId);
            this.groupBoxProductInfo.Controls.Add(this.lblStock);
            this.groupBoxProductInfo.Controls.Add(this.txtStock);
            this.groupBoxProductInfo.Controls.Add(this.lblRating);
            this.groupBoxProductInfo.Controls.Add(this.txtRating);
            this.groupBoxProductInfo.Controls.Add(this.lblImageSP);
            this.groupBoxProductInfo.Controls.Add(this.txtImagePath);
            this.groupBoxProductInfo.Controls.Add(this.lblDateAdd);
            this.groupBoxProductInfo.Controls.Add(this.dtpDateAdd);
            this.groupBoxProductInfo.Controls.Add(this.btnUploadImage);
            this.groupBoxProductInfo.Controls.Add(this.lblDescription);
            this.groupBoxProductInfo.Controls.Add(this.txtDescription);
            this.groupBoxProductInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxProductInfo.Name = "groupBoxProductInfo";
            this.groupBoxProductInfo.Size = new System.Drawing.Size(1013, 137);
            this.groupBoxProductInfo.TabIndex = 22;
            this.groupBoxProductInfo.TabStop = false;
            this.groupBoxProductInfo.Text = "Thông tin sản phẩm";
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(16, 30);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(71, 13);
            this.lblProductId.TabIndex = 23;
            this.lblProductId.Text = "Mã sản phẩm";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(16, 60);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(75, 13);
            this.lblProductName.TabIndex = 24;
            this.lblProductName.Text = "Tên sản phẩm";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(16, 90);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(23, 13);
            this.lblPrice.TabIndex = 25;
            this.lblPrice.Text = "Giá";
            // 
            // lblCategoryId
            // 
            this.lblCategoryId.AutoSize = true;
            this.lblCategoryId.Location = new System.Drawing.Point(419, 29);
            this.lblCategoryId.Name = "lblCategoryId";
            this.lblCategoryId.Size = new System.Drawing.Size(56, 13);
            this.lblCategoryId.TabIndex = 26;
            this.lblCategoryId.Text = "Danh mục";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(419, 60);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(47, 13);
            this.lblStock.TabIndex = 27;
            this.lblStock.Text = "Tồn kho";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(419, 90);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(38, 13);
            this.lblRating.TabIndex = 29;
            this.lblRating.Text = "Rating";
            // 
            // lblImageSP
            // 
            this.lblImageSP.AutoSize = true;
            this.lblImageSP.Location = new System.Drawing.Point(757, 55);
            this.lblImageSP.Name = "lblImageSP";
            this.lblImageSP.Size = new System.Drawing.Size(50, 13);
            this.lblImageSP.TabIndex = 30;
            this.lblImageSP.Text = "Hình ảnh";
            // 
            // lblDateAdd
            // 
            this.lblDateAdd.AutoSize = true;
            this.lblDateAdd.Location = new System.Drawing.Point(757, 87);
            this.lblDateAdd.Name = "lblDateAdd";
            this.lblDateAdd.Size = new System.Drawing.Size(58, 13);
            this.lblDateAdd.TabIndex = 32;
            this.lblDateAdd.Text = "Ngày thêm";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(757, 22);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(56, 23);
            this.lblDescription.TabIndex = 33;
            this.lblDescription.Text = "Mô tả";
            // 
            // frmProductManagement
            // 
            this.ClientSize = new System.Drawing.Size(1036, 479);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.groupBoxProductInfo);
            this.Controls.Add(this.actionControl);
            this.Name = "frmProductManagement";
            this.Text = "Quản lý Sản phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.groupBoxProductInfo.ResumeLayout(false);
            this.groupBoxProductInfo.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
