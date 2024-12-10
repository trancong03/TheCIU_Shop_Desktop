using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MLIntegration.Services;
using MLIntegration.Models;
using BLL;

namespace GUI
{
    public partial class FrmDistributeVoucher : Form
    {
        private VoucherBLL voucherBLL = new VoucherBLL();
        private ClusteringService _clusteringService;
        private List<ClusteredCustomerDTO> listCustomer = new List<ClusteredCustomerDTO>();
        private readonly Dictionary<uint, string> _clusterNames = new Dictionary<uint, string>
        {
            { 1, "Khách hàng chi tiêu cao, mua thường xuyên" },
            { 2, "Khách hàng chi tiêu trung bình, mua không thường xuyên" },
            { 3, "Khách hàng chi tiêu thấp, mua rất ít" }
        };

        public FrmDistributeVoucher()
        {
            InitializeComponent();
            _clusteringService = new ClusteringService();

            btnTrainModel.Click += BtnTrainModel_Click;
            btnDistributeVouchers.Click += BtnDistributeVouchers_Click;
            btnLoadDistributeData.Click += btnLoadDistributeData_Click;

            LoadVoucherComboBox();
            LoadClusterCustomerComboBox();
        }

        private void LoadClusterCustomerComboBox()
        {
            cboClusterCustomer.DataSource = _clusterNames
                .Select(c => new { ClusterId = c.Key, ClusterName = c.Value })
                .ToList();
            cboClusterCustomer.DisplayMember = "ClusterName";
            cboClusterCustomer.ValueMember = "ClusterId";
            cboClusterCustomer.SelectedIndex = -1;
        }

        private void LoadVoucherComboBox()
        {
            try
            {
                var vouchers = voucherBLL.GetAllVouchers();

                cboVoucher.DataSource = vouchers;
                cboVoucher.DisplayMember = "tiltle";
                cboVoucher.ValueMember = "voucher_id";
                cboVoucher.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTrainModel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(cboClusterNumber.SelectedItem?.ToString(), out int numberOfClusters) || numberOfClusters <= 0)
                {
                    MessageBox.Show("Vui lòng chọn số cụm hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var featureExtractor = new MLIntegration.Data.FeatureExtractor();
                var customerFeatures = featureExtractor.GetCustomerFeatures();

                if (!customerFeatures.Any())
                {
                    MessageBox.Show("Không có dữ liệu khách hàng để huấn luyện mô hình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Huấn luyện và phân cụm
                _clusteringService.Train(customerFeatures, numberOfClusters);
                var predictions = _clusteringService.Predict(customerFeatures).ToList();

                if (!predictions.Any())
                {
                    MessageBox.Show("Dữ liệu dự đoán rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị danh sách khách hàng kèm cụm
                DisplayCustomerClusters(predictions);

                MessageBox.Show("Huấn luyện và phân cụm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi huấn luyện mô hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCustomerClusters(List<CustomerPrediction> predictions)
        {
            listCustomer = predictions.Select(p => new ClusteredCustomerDTO
            {
                CustomerID = p.CustomerID,
                ClusterId = p.ClusterId,
                ClusterName = _clusterNames.ContainsKey(p.ClusterId) ? _clusterNames[p.ClusterId] : "Cụm không xác định"
            }).ToList();

            dgvCustomerClusters.Columns.Clear();
            dgvCustomerClusters.AutoGenerateColumns = false;

            dgvCustomerClusters.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã khách hàng", DataPropertyName = "CustomerID" });
            dgvCustomerClusters.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cụm", DataPropertyName = "ClusterId" });
            dgvCustomerClusters.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên cụm", DataPropertyName = "ClusterName" });

            dgvCustomerClusters.DataSource = listCustomer;
        }

        private void LoadDistributeVoucherData()
        {
            if (cboClusterCustomer.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn cụm khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            uint selectedClusterId = Convert.ToUInt32(cboClusterCustomer.SelectedValue);

            var distributeData = listCustomer
                .Where(c => c.ClusterId == selectedClusterId)
                .ToList();

            if (!distributeData.Any())
            {
                MessageBox.Show("Không tìm thấy khách hàng trong cụm đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvDistributeVoucher.Columns.Clear();
            dgvDistributeVoucher.AutoGenerateColumns = false;

            dgvDistributeVoucher.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã khách hàng",
                DataPropertyName = "CustomerID",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDistributeVoucher.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cụm",
                DataPropertyName = "ClusterId",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDistributeVoucher.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên cụm",
                DataPropertyName = "ClusterName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvDistributeVoucher.DataSource = distributeData;
            dgvDistributeVoucher.Refresh();
        }

        private void BtnDistributeVouchers_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboVoucher.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn voucher để phân phối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedVoucherId = cboVoucher.SelectedValue.ToString();

                if (dgvDistributeVoucher.DataSource is List<ClusteredCustomerDTO> distributeData)
                {
                    var targetCustomers = distributeData
                        .Select(c => c.CustomerID)
                        .ToList();

                    if (!targetCustomers.Any())
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để phân phối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Gọi phương thức phân phối voucher
                    voucherBLL.DistributeVoucher(selectedVoucherId, targetCustomers);

                    MessageBox.Show($"Đã phân phối voucher cho {targetCustomers.Count} khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu khách hàng để phân phối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi phân phối voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLoadDistributeData_Click(object sender, EventArgs e)
        {
            LoadDistributeVoucherData();
        }
    }
}
