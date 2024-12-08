namespace GUI
{
    partial class FrmOrderStatusUpdate
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
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtAmount = new CustomControls.CurrencyTextBox();
            this.lblAddressDeliver = new System.Windows.Forms.Label();
            this.txtAddressDeliver = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.dateOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrderDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.currencyTextBox1 = new CustomControls.CurrencyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.cboStatus);
            this.groupBoxOrder.Controls.Add(this.txtAmount);
            this.groupBoxOrder.Controls.Add(this.lblAddressDeliver);
            this.groupBoxOrder.Controls.Add(this.txtAddressDeliver);
            this.groupBoxOrder.Controls.Add(this.lblName);
            this.groupBoxOrder.Controls.Add(this.txtName);
            this.groupBoxOrder.Controls.Add(this.lblOrderDate);
            this.groupBoxOrder.Controls.Add(this.dateOrderDate);
            this.groupBoxOrder.Controls.Add(this.lblStatus);
            this.groupBoxOrder.Controls.Add(this.lblAmount);
            this.groupBoxOrder.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOrder.Location = new System.Drawing.Point(37, 12);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(1208, 163);
            this.groupBoxOrder.TabIndex = 3;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "THÔNG TIN ĐƠN HÀNG";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(229, 116);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(200, 28);
            this.cboStatus.TabIndex = 13;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(229, 79);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 22);
            this.txtAmount.TabIndex = 12;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblAddressDeliver
            // 
            this.lblAddressDeliver.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressDeliver.Location = new System.Drawing.Point(489, 79);
            this.lblAddressDeliver.Name = "lblAddressDeliver";
            this.lblAddressDeliver.Size = new System.Drawing.Size(100, 23);
            this.lblAddressDeliver.TabIndex = 10;
            this.lblAddressDeliver.Text = "Địa chỉ";
            // 
            // txtAddressDeliver
            // 
            this.txtAddressDeliver.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressDeliver.Location = new System.Drawing.Point(609, 79);
            this.txtAddressDeliver.Multiline = true;
            this.txtAddressDeliver.Name = "txtAddressDeliver";
            this.txtAddressDeliver.Size = new System.Drawing.Size(593, 65);
            this.txtAddressDeliver.TabIndex = 11;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(109, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(114, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Khách Hàng";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(229, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 28);
            this.txtName.TabIndex = 3;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(489, 39);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(100, 23);
            this.lblOrderDate.TabIndex = 4;
            this.lblOrderDate.Text = "Ngày đặt:";
            // 
            // dateOrderDate
            // 
            this.dateOrderDate.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOrderDate.Location = new System.Drawing.Point(609, 39);
            this.dateOrderDate.Name = "dateOrderDate";
            this.dateOrderDate.Size = new System.Drawing.Size(292, 28);
            this.dateOrderDate.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(109, 116);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(109, 79);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(100, 23);
            this.lblAmount.TabIndex = 8;
            this.lblAmount.Text = "Tổng tiền:";
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeight = 29;
            this.dataGridViewOrders.Location = new System.Drawing.Point(37, 280);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersWidth = 51;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(831, 185);
            this.dataGridViewOrders.TabIndex = 4;
            // 
            // dataGridViewOrderDetails
            // 
            this.dataGridViewOrderDetails.ColumnHeadersHeight = 29;
            this.dataGridViewOrderDetails.Location = new System.Drawing.Point(888, 280);
            this.dataGridViewOrderDetails.Name = "dataGridViewOrderDetails";
            this.dataGridViewOrderDetails.RowHeadersWidth = 51;
            this.dataGridViewOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrderDetails.Size = new System.Drawing.Size(485, 185);
            this.dataGridViewOrderDetails.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(466, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Số lượng";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(586, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 28);
            this.textBox1.TabIndex = 14;
            // 
            // currencyTextBox1
            // 
            this.currencyTextBox1.Location = new System.Drawing.Point(807, 36);
            this.currencyTextBox1.Name = "currencyTextBox1";
            this.currencyTextBox1.Size = new System.Drawing.Size(200, 22);
            this.currencyTextBox1.TabIndex = 12;
            this.currencyTextBox1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sản Phẩm";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(235, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 28);
            this.textBox2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(687, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Thành tiền";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.currencyTextBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(37, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1208, 76);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN CHI TIẾT ĐƠN HÀNG";
            // 
            // FrmOrderStatusUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 559);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewOrderDetails);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.groupBoxOrder);
            this.Name = "FrmOrderStatusUpdate";
            this.Text = "FrmOrderStatusUpdate";
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.ComboBox cboStatus;
        private CustomControls.CurrencyTextBox txtAmount;
        private System.Windows.Forms.Label lblAddressDeliver;
        private System.Windows.Forms.TextBox txtAddressDeliver;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dateOrderDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrderDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private CustomControls.CurrencyTextBox currencyTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}