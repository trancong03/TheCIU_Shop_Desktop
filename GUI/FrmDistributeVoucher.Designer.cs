using DTO;
using System.Collections.Generic;

namespace GUI
{
    partial class FrmDistributeVoucher
    {
        private System.ComponentModel.IContainer components = null;
        private List<ClusteredCustomerDTO> _clusteredCustomers = new List<ClusteredCustomerDTO>();

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
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblClusterCustomer = new System.Windows.Forms.Label();
            this.cboClusterCustomer = new System.Windows.Forms.ComboBox();
            this.cboVoucher = new System.Windows.Forms.ComboBox();
            this.lblVoucher = new System.Windows.Forms.Label();
            this.cboClusterNumber = new System.Windows.Forms.ComboBox();
            this.lblClusterNumber = new System.Windows.Forms.Label();
            this.btnDistributeVouchers = new System.Windows.Forms.Button();
            this.btnTrainModel = new System.Windows.Forms.Button();
            this.dgvCustomerClusters = new System.Windows.Forms.DataGridView();
            this.customerPredictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvDistributeVoucher = new System.Windows.Forms.DataGridView();
            this.btnLoadDistributeData = new System.Windows.Forms.Button();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerClusters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerPredictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistributeVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnLoadDistributeData);
            this.pnlControls.Controls.Add(this.lblClusterCustomer);
            this.pnlControls.Controls.Add(this.cboClusterCustomer);
            this.pnlControls.Controls.Add(this.cboVoucher);
            this.pnlControls.Controls.Add(this.lblVoucher);
            this.pnlControls.Controls.Add(this.cboClusterNumber);
            this.pnlControls.Controls.Add(this.lblClusterNumber);
            this.pnlControls.Controls.Add(this.btnDistributeVouchers);
            this.pnlControls.Controls.Add(this.btnTrainModel);
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1498, 120);
            this.pnlControls.TabIndex = 0;
            // 
            // lblClusterCustomer
            // 
            this.lblClusterCustomer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblClusterCustomer.AutoSize = true;
            this.lblClusterCustomer.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClusterCustomer.Location = new System.Drawing.Point(784, 77);
            this.lblClusterCustomer.Name = "lblClusterCustomer";
            this.lblClusterCustomer.Size = new System.Drawing.Size(51, 23);
            this.lblClusterCustomer.TabIndex = 6;
            this.lblClusterCustomer.Text = "Cụm";
            // 
            // cboClusterCustomer
            // 
            this.cboClusterCustomer.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClusterCustomer.Location = new System.Drawing.Point(859, 74);
            this.cboClusterCustomer.Name = "cboClusterCustomer";
            this.cboClusterCustomer.Size = new System.Drawing.Size(400, 31);
            this.cboClusterCustomer.TabIndex = 0;
            // 
            // cboVoucher
            // 
            this.cboVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVoucher.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVoucher.FormattingEnabled = true;
            this.cboVoucher.Location = new System.Drawing.Point(859, 31);
            this.cboVoucher.Name = "cboVoucher";
            this.cboVoucher.Size = new System.Drawing.Size(400, 31);
            this.cboVoucher.TabIndex = 5;
            // 
            // lblVoucher
            // 
            this.lblVoucher.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblVoucher.AutoSize = true;
            this.lblVoucher.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucher.Location = new System.Drawing.Point(774, 35);
            this.lblVoucher.Name = "lblVoucher";
            this.lblVoucher.Size = new System.Drawing.Size(85, 23);
            this.lblVoucher.TabIndex = 4;
            this.lblVoucher.Text = "Voucher:";
            // 
            // cboClusterNumber
            // 
            this.cboClusterNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboClusterNumber.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClusterNumber.FormattingEnabled = true;
            this.cboClusterNumber.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.cboClusterNumber.Location = new System.Drawing.Point(342, 31);
            this.cboClusterNumber.Name = "cboClusterNumber";
            this.cboClusterNumber.Size = new System.Drawing.Size(189, 31);
            this.cboClusterNumber.TabIndex = 3;
            // 
            // lblClusterNumber
            // 
            this.lblClusterNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblClusterNumber.AutoSize = true;
            this.lblClusterNumber.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClusterNumber.Location = new System.Drawing.Point(186, 34);
            this.lblClusterNumber.Name = "lblClusterNumber";
            this.lblClusterNumber.Size = new System.Drawing.Size(159, 23);
            this.lblClusterNumber.TabIndex = 2;
            this.lblClusterNumber.Text = "Số cụm phân tích:";
            // 
            // btnDistributeVouchers
            // 
            this.btnDistributeVouchers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDistributeVouchers.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistributeVouchers.Location = new System.Drawing.Point(1286, 74);
            this.btnDistributeVouchers.Name = "btnDistributeVouchers";
            this.btnDistributeVouchers.Size = new System.Drawing.Size(200, 31);
            this.btnDistributeVouchers.TabIndex = 1;
            this.btnDistributeVouchers.Text = "Phân phối Voucher";
            this.btnDistributeVouchers.UseVisualStyleBackColor = true;
            this.btnDistributeVouchers.Click += new System.EventHandler(this.BtnDistributeVouchers_Click);
            // 
            // btnTrainModel
            // 
            this.btnTrainModel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTrainModel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrainModel.Location = new System.Drawing.Point(190, 87);
            this.btnTrainModel.Name = "btnTrainModel";
            this.btnTrainModel.Size = new System.Drawing.Size(188, 30);
            this.btnTrainModel.TabIndex = 0;
            this.btnTrainModel.Text = "Huấn luyện mô hình";
            this.btnTrainModel.UseVisualStyleBackColor = true;
            this.btnTrainModel.Click += new System.EventHandler(this.BtnTrainModel_Click);
            // 
            // dgvCustomerClusters
            // 
            this.dgvCustomerClusters.AllowUserToDeleteRows = false;
            this.dgvCustomerClusters.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvCustomerClusters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerClusters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerClusters.Location = new System.Drawing.Point(12, 126);
            this.dgvCustomerClusters.Name = "dgvCustomerClusters";
            this.dgvCustomerClusters.ReadOnly = true;
            this.dgvCustomerClusters.RowHeadersWidth = 51;
            this.dgvCustomerClusters.RowTemplate.Height = 24;
            this.dgvCustomerClusters.Size = new System.Drawing.Size(739, 411);
            this.dgvCustomerClusters.TabIndex = 1;
            // 
            // dgvDistributeVoucher
            // 
            this.dgvDistributeVoucher.AllowUserToDeleteRows = false;
            this.dgvDistributeVoucher.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvDistributeVoucher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDistributeVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistributeVoucher.Location = new System.Drawing.Point(759, 126);
            this.dgvDistributeVoucher.Name = "dgvDistributeVoucher";
            this.dgvDistributeVoucher.ReadOnly = true;
            this.dgvDistributeVoucher.RowHeadersWidth = 51;
            this.dgvDistributeVoucher.RowTemplate.Height = 24;
            this.dgvDistributeVoucher.Size = new System.Drawing.Size(727, 411);
            this.dgvDistributeVoucher.TabIndex = 2;
            // 
            // btnLoadDistributeData
            // 
            this.btnLoadDistributeData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadDistributeData.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDistributeData.Location = new System.Drawing.Point(1286, 30);
            this.btnLoadDistributeData.Name = "btnLoadDistributeData";
            this.btnLoadDistributeData.Size = new System.Drawing.Size(200, 31);
            this.btnLoadDistributeData.TabIndex = 7;
            this.btnLoadDistributeData.Text = "Load Dữ liệu Khách Hàng";
            this.btnLoadDistributeData.UseVisualStyleBackColor = true;
            this.btnLoadDistributeData.Click += new System.EventHandler(this.btnLoadDistributeData_Click);
            // 
            // FrmDistributeVoucher
            // 
            this.ClientSize = new System.Drawing.Size(1498, 531);
            this.Controls.Add(this.dgvDistributeVoucher);
            this.Controls.Add(this.dgvCustomerClusters);
            this.Controls.Add(this.pnlControls);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDistributeVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Phân phối voucher";
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerClusters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerPredictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistributeVoucher)).EndInit();
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.ComboBox cboVoucher;
        private System.Windows.Forms.Label lblVoucher;
        private System.Windows.Forms.ComboBox cboClusterNumber;
        private System.Windows.Forms.Label lblClusterNumber;
        private System.Windows.Forms.Button btnDistributeVouchers;
        private System.Windows.Forms.Button btnTrainModel;
        private System.Windows.Forms.DataGridView dgvCustomerClusters;
        private System.Windows.Forms.BindingSource customerPredictionBindingSource;
        private System.Windows.Forms.ComboBox cboClusterCustomer;
        private System.Windows.Forms.DataGridView dgvDistributeVoucher;
        private System.Windows.Forms.Label lblClusterCustomer;
        private System.Windows.Forms.Button btnLoadDistributeData;
    }
}
