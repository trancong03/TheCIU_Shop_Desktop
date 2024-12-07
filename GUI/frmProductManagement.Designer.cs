using System.Windows.Forms;

namespace GUI
{
    partial class FrmProductManagement
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các điều khiển
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblPrice;
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
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private CustomControl.ActionControl actionControl;
        private System.Windows.Forms.DataGridView dataGridViewProductVariant;

        /// <summary>
        /// Giải phóng tài nguyên.
        /// </summary>
        /// <param name="disposing">True nếu cần giải phóng tài nguyên.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Khởi tạo các điều khiển.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
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
            this.dataGridViewProductVariant = new System.Windows.Forms.DataGridView();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.actionControlMini = new CustomControl.ActionControlMini();
            this.txtPrice = new CustomControls.CurrencyTextBox();
            this.actionControl = new CustomControl.ActionControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductVariant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.Black;
            this.lblProductName.Location = new System.Drawing.Point(30, 30);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(105, 19);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Tên sản phẩm:";
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductName.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(150, 20);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(821, 27);
            this.txtProductName.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(30, 70);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(64, 19);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Tiêu đề:";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(150, 60);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTitle.Size = new System.Drawing.Size(821, 71);
            this.txtTitle.TabIndex = 3;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.Color.Black;
            this.lblCategory.Location = new System.Drawing.Point(30, 140);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(82, 19);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Danh mục:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.Location = new System.Drawing.Point(150, 137);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(271, 27);
            this.cmbCategory.TabIndex = 5;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.Black;
            this.lblPrice.Location = new System.Drawing.Point(632, 145);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(38, 19);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Giá:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.ForeColor = System.Drawing.Color.Black;
            this.lblSize.Location = new System.Drawing.Point(23, 597);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(68, 19);
            this.lblSize.TabIndex = 8;
            this.lblSize.Text = "Kích cỡ:";
            // 
            // cmbSize
            // 
            this.cmbSize.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSize.Location = new System.Drawing.Point(97, 597);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(100, 27);
            this.cmbSize.TabIndex = 9;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.ForeColor = System.Drawing.Color.Black;
            this.lblColor.Location = new System.Drawing.Point(206, 600);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(70, 19);
            this.lblColor.TabIndex = 10;
            this.lblColor.Text = "Màu sắc:";
            // 
            // cmbColor
            // 
            this.cmbColor.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColor.Location = new System.Drawing.Point(282, 597);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(100, 27);
            this.cmbColor.TabIndex = 11;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.Color.Black;
            this.lblQuantity.Location = new System.Drawing.Point(393, 600);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(75, 19);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "Số lượng:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(490, 597);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 27);
            this.txtQuantity.TabIndex = 13;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.ForeColor = System.Drawing.Color.Black;
            this.lblRating.Location = new System.Drawing.Point(442, 188);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(73, 19);
            this.lblRating.TabIndex = 14;
            this.lblRating.Text = "Đánh giá:";
            // 
            // txtRating
            // 
            this.txtRating.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRating.Location = new System.Drawing.Point(521, 182);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(56, 27);
            this.txtRating.TabIndex = 15;
            // 
            // lblDateAdd
            // 
            this.lblDateAdd.AutoSize = true;
            this.lblDateAdd.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateAdd.ForeColor = System.Drawing.Color.Black;
            this.lblDateAdd.Location = new System.Drawing.Point(30, 190);
            this.lblDateAdd.Name = "lblDateAdd";
            this.lblDateAdd.Size = new System.Drawing.Size(87, 19);
            this.lblDateAdd.TabIndex = 16;
            this.lblDateAdd.Text = "Ngày thêm:";
            // 
            // dtpDateAdd
            // 
            this.dtpDateAdd.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateAdd.Location = new System.Drawing.Point(150, 184);
            this.dtpDateAdd.Name = "dtpDateAdd";
            this.dtpDateAdd.Size = new System.Drawing.Size(246, 27);
            this.dtpDateAdd.TabIndex = 17;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProducts.ColumnHeadersHeight = 29;
            this.dataGridViewProducts.Location = new System.Drawing.Point(23, 296);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.Size = new System.Drawing.Size(1281, 292);
            this.dataGridViewProducts.TabIndex = 20;
            // 
            // dataGridViewProductVariant
            // 
            this.dataGridViewProductVariant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProductVariant.ColumnHeadersHeight = 29;
            this.dataGridViewProductVariant.Location = new System.Drawing.Point(20, 630);
            this.dataGridViewProductVariant.Name = "dataGridViewProductVariant";
            this.dataGridViewProductVariant.RowHeadersWidth = 51;
            this.dataGridViewProductVariant.Size = new System.Drawing.Size(1281, 158);
            this.dataGridViewProductVariant.TabIndex = 21;
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProduct.Location = new System.Drawing.Point(1084, 12);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxProduct.TabIndex = 18;
            this.pictureBoxProduct.TabStop = false;
            // 
            // actionControlMini
            // 
            this.actionControlMini.FilterDataSource = null;
            this.actionControlMini.FilterDisplayMember = "";
            this.actionControlMini.FilterValueMember = "";
            this.actionControlMini.FilterVisible = true;
            this.actionControlMini.Location = new System.Drawing.Point(636, 591);
            this.actionControlMini.Name = "actionControlMini";
            this.actionControlMini.Size = new System.Drawing.Size(398, 33);
            this.actionControlMini.TabIndex = 24;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(700, 142);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(135, 22);
            this.txtPrice.TabIndex = 23;
            this.txtPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // actionControl
            // 
            this.actionControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionControl.FilterDataSource = null;
            this.actionControl.FilterDisplayMember = "";
            this.actionControl.FilterValueMember = "";
            this.actionControl.FilterVisible = true;
            this.actionControl.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionControl.Location = new System.Drawing.Point(23, 218);
            this.actionControl.Name = "actionControl";
            this.actionControl.Size = new System.Drawing.Size(1281, 50);
            this.actionControl.TabIndex = 22;
            // 
            // FrmProductManagement
            // 
            this.ClientSize = new System.Drawing.Size(1321, 800);
            this.Controls.Add(this.actionControlMini);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.cmbSize);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.lblDateAdd);
            this.Controls.Add(this.dtpDateAdd);
            this.Controls.Add(this.pictureBoxProduct);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.dataGridViewProductVariant);
            this.Controls.Add(this.actionControl);
            this.Name = "FrmProductManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sản phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductVariant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private CustomControls.CurrencyTextBox txtPrice;
        private CustomControl.ActionControlMini actionControlMini;
    }
}
