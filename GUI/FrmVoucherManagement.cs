using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class FrmVoucherManagement : Form
    {
        private VoucherBLL voucherBLL = new VoucherBLL();
        public FrmVoucherManagement()
        {
            InitializeComponent();
            LoadVouchers();
            LoadEvent();

            actionControl.AddClicked += ActionControl_AddClicked;
            actionControl.UpdateClicked += ActionControl_UpdateClicked;
            actionControl.DeleteClicked += ActionControl_DeleteClicked;
            actionControl.ReloadClicked += ActionControl_ReloadClicked;
            actionControl.SearchClicked += ActionControl_SearchClicked;
            actionControl.SaveButtonVisible = false;
            dgvVouchers.CellClick += DgvVouchers_CellClick;
            dgvVouchers.CellFormatting += DgvVouchers_CellFormatting;

        }

        private void ActionControl_SearchClicked(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa tìm kiếm từ actionControl
                string searchText = actionControl.SearchText.Trim();

                // Gọi BLL để tìm kiếm
                var result = voucherBLL.SearchVouchers(searchText);

                if (result.Any())
                {
                    // Hiển thị kết quả tìm kiếm lên DataGridView
                    dgvVouchers.DataSource = result;

                    // Ẩn cột product_voucher và đặt tên header
                    if (dgvVouchers.Columns.Contains("product_voucher"))
                    {
                        dgvVouchers.Columns["product_voucher"].Visible = false;
                    }

                    dgvVouchers.Columns["voucher_id"].DisplayIndex = 0; // Mã Voucher
                    dgvVouchers.Columns["tiltle"].DisplayIndex = 1;     // Tiêu Đề
                    dgvVouchers.Columns["discount"].DisplayIndex = 2;  // Giảm Giá (%)
                    dgvVouchers.Columns["dateStart"].DisplayIndex = 3; // Ngày Bắt Đầu
                    dgvVouchers.Columns["dateEnd"].DisplayIndex = 4;   // Ngày Kết Thúc
                    dgvVouchers.Columns["discription"].DisplayIndex = 5; // Mô Tả
                    dgvVouchers.Columns["status"].DisplayIndex = 6;    // Trạng Thái
                    dgvVouchers.Columns["quantity"].DisplayIndex = 7;  // Số Lượng

                    // Đặt lại tên header
                    dgvVouchers.Columns["voucher_id"].HeaderText = "Mã Voucher";
                    dgvVouchers.Columns["dateStart"].HeaderText = "Ngày Bắt Đầu";
                    dgvVouchers.Columns["dateEnd"].HeaderText = "Ngày Kết Thúc";
                    dgvVouchers.Columns["discount"].HeaderText = "Giảm Giá (%)";
                    dgvVouchers.Columns["tiltle"].HeaderText = "Tiêu Đề";
                    dgvVouchers.Columns["discription"].HeaderText = "Mô Tả";
                    dgvVouchers.Columns["status"].HeaderText = "Trạng Thái";
                    dgvVouchers.Columns["quantity"].HeaderText = "Số Lượng";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy voucher nào phù hợp với điều kiện tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvVouchers.DataSource = null; // Xóa dữ liệu nếu không có kết quả
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void ActionControl_DeleteClicked(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào trong DataGridView được chọn không
                if (dgvVouchers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một voucher để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin voucher đang được chọn
                var selectedRow = dgvVouchers.SelectedRows[0];
                string voucherId = selectedRow.Cells["VoucherID"].Value.ToString();

                // Xác nhận trước khi xóa
                var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa voucher với mã '{voucherId}' không?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Gọi BLL để xóa voucher
                        voucherBLL.RemoveVoucher(voucherId);

                        // Hiển thị thông báo thành công
                        MessageBox.Show("Xóa voucher thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại danh sách voucher
                        LoadVouchers();
                    }
                    catch (Exception ex)
                    {
                        // Kiểm tra lỗi liên quan đến khóa ngoại
                        if (ex.InnerException != null && ex.InnerException.Message.Contains("REFERENCE constraint"))
                        {
                            MessageBox.Show($"Không thể xóa voucher vì đang được tham chiếu trong bảng khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Lỗi khác
                            MessageBox.Show($"Lỗi khi xóa voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý yêu cầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string GenerateVoucherCode()
        {
            try
            {
                // Lấy mã sự kiện
                string eventCode = cboEvent.SelectedValue?.ToString() ?? "UNK";

                // Lấy năm từ ngày bắt đầu
                string startYear = dtpDateStart.Value.Year.ToString();

                // Lấy giảm giá và chuyển thành chuỗi có 2 chữ số
                string discountCode = int.TryParse(txtDiscount.Text.Trim(), out int discount) ? discount.ToString("00") : "00";

                // Tạo mã voucher
                string voucherCode = $"{eventCode}{startYear}{discountCode}";

                return voucherCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo mã voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }


        private void ActionControl_AddClicked(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra thông tin nhập hợp lệ
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Tiêu đề không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTitle.Focus();
                    return;
                }

                if (!decimal.TryParse(txtDiscount.Text, out decimal discount) || discount <= 0)
                {
                    MessageBox.Show("Giảm giá phải là số lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Focus();
                    return;
                }

                if (dtpDateStart.Value > dtpDateEnd.Value)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpDateStart.Focus();
                    return;
                }

                if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Focus();
                    return;
                }

                if (cboEvent.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một sự kiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboEvent.Focus();
                    return;
                }

                // Gọi hàm GenerateVoucherCode để tạo mã voucher
                string voucherCode = GenerateVoucherCode();
                if (string.IsNullOrEmpty(voucherCode))
                {
                    MessageBox.Show("Không thể tạo mã voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng voucher
                var newVoucher = new Voucher
                {
                    voucher_id = voucherCode, // Sử dụng mã voucher dạng chuỗi
                    tiltle = txtTitle.Text.Trim(),
                    discount = (int)discount,
                    dateStart = dtpDateStart.Value.Date,
                    dateEnd = dtpDateEnd.Value.Date,
                    discription = txtDescription.Text.Trim(),
                    status = chkStatus.Checked,
                    quantity = quantity
                };

                // Gọi BLL để thêm voucher
                voucherBLL.AddVoucher(newVoucher);

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm voucher mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại danh sách voucher
                LoadVouchers();

                // Xóa nội dung các control
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ActionControl_UpdateClicked(object sender, EventArgs e)
        {
            try
            {
                if (dgvVouchers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một voucher để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Tiêu đề không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTitle.Focus();
                    return;
                }

                if (!decimal.TryParse(txtDiscount.Text, out decimal discount) || discount <= 0)
                {
                    MessageBox.Show("Giảm giá phải là số lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Focus();
                    return;
                }

                if (dtpDateStart.Value > dtpDateEnd.Value)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpDateStart.Focus();
                    return;
                }

                if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Focus();
                    return;
                }

                var selectedRow = dgvVouchers.SelectedRows[0];
                string voucherId = selectedRow.Cells["VoucherID"].Value.ToString();

                // Xác định trạng thái dựa trên ngày bắt đầu và ngày kết thúc
                var currentDate = DateTime.Now.Date;
                bool isActive = currentDate >= dtpDateStart.Value.Date && currentDate <= dtpDateEnd.Value.Date;

                // Tạo đối tượng voucher để cập nhật
                var updatedVoucher = new DTO.Voucher
                {
                    voucher_id = voucherId,
                    tiltle = txtTitle.Text.Trim(),
                    discount = (int)discount,
                    dateStart = dtpDateStart.Value.Date,
                    dateEnd = dtpDateEnd.Value.Date,
                    discription = txtDescription.Text.Trim(),
                    status = isActive,
                    quantity = quantity
                };

                // Gọi BLL để cập nhật voucher
                voucherBLL.EditVoucher(updatedVoucher);

                // Hiển thị thông báo thành công
                MessageBox.Show("Cập nhật voucher thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại danh sách voucher
                LoadVouchers();

                // Xóa nội dung các control
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ActionControl_ReloadClicked(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadVouchers();
        }

        private void DgvVouchers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvVouchers.Columns[e.ColumnIndex].Name == "Status" && e.Value is bool status)
            {
                e.Value = status ? "Còn hiệu lực" : "Hết hiệu lực";
                e.FormattingApplied = true;
            }
        }

        private void DgvVouchers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Đảm bảo rằng người dùng đã chọn một dòng hợp lệ
                if (e.RowIndex >= 0 && dgvVouchers.Rows[e.RowIndex].Cells["VoucherID"].Value != null)
                {
                    // Lấy dòng được chọn
                    DataGridViewRow selectedRow = dgvVouchers.Rows[e.RowIndex];

                    // Hiển thị thông tin từ dòng được chọn vào các control
                    txtVoucherID.Text = selectedRow.Cells["VoucherID"].Value?.ToString() ?? string.Empty;
                    txtTitle.Text = selectedRow.Cells["Title"].Value?.ToString() ?? string.Empty;
                    txtDiscount.Text = selectedRow.Cells["Discount"].Value?.ToString() ?? string.Empty;
                    dtpDateStart.Value = DateTime.TryParse(selectedRow.Cells["DateStart"].Value?.ToString(), out DateTime dateStart) ? dateStart : DateTime.Now;
                    dtpDateEnd.Value = DateTime.TryParse(selectedRow.Cells["DateEnd"].Value?.ToString(), out DateTime dateEnd) ? dateEnd : DateTime.Now;
                    txtDescription.Text = selectedRow.Cells["Description"].Value?.ToString() ?? string.Empty;
                    txtQuantity.Text = selectedRow.Cells["Quantity"].Value?.ToString() ?? string.Empty;

                    chkStatus.Checked = selectedRow.Cells["Status"].Value is bool status && status;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị thông tin voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        

        private void ClearInputFields()
        {
            txtVoucherID.Clear();
            txtTitle.Clear();
            txtDiscount.Clear();
            dtpDateStart.Value = DateTime.Now;
            dtpDateEnd.Value = DateTime.Now;
            txtDescription.Clear();
            chkStatus.Checked = false;
            txtTitle.Focus();
            txtQuantity.Clear();

            dgvVouchers.ClearSelection();
        }


        private void LoadVouchers()
        {
            try
            {
                // Gọi BLL để lấy danh sách voucher
                var vouchers = voucherBLL.GetAllVouchers().Select(voucher => new
                {
                    VoucherID = voucher.voucher_id,
                    Title = voucher.tiltle,
                    Discount = voucher.discount,
                    DateStart = voucher.dateStart?.ToString("dd/MM/yyyy") ?? "Không có ngày bắt đầu",
                    DateEnd = voucher.dateEnd?.ToString("dd/MM/yyyy") ?? "Không có ngày kết thúc",
                    Description = voucher.discription ?? "Không có mô tả",
                    Status = voucher.status,
                    Quantity = voucher.quantity

                }).ToList();

                // Kiểm tra nếu không có dữ liệu
                if (!vouchers.Any())
                {
                    MessageBox.Show("Không có dữ liệu voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvVouchers.DataSource = null; // Xóa dữ liệu
                    return;
                }

                // Gán dữ liệu vào DataGridView
                dgvVouchers.DataSource = vouchers;

                // Định dạng DataGridView
                ConfigureDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridViewColumns()
        {
            // Đặt lại thứ tự cột
            dgvVouchers.Columns["VoucherID"].DisplayIndex = 0; // Mã Voucher
            dgvVouchers.Columns["Title"].DisplayIndex = 1;     // Tiêu Đề
            dgvVouchers.Columns["Discount"].DisplayIndex = 2;  // Giảm Giá (%)
            dgvVouchers.Columns["DateStart"].DisplayIndex = 3; // Ngày Bắt Đầu
            dgvVouchers.Columns["DateEnd"].DisplayIndex = 4;   // Ngày Kết Thúc
            dgvVouchers.Columns["Description"].DisplayIndex = 5; // Mô Tả
            dgvVouchers.Columns["Status"].DisplayIndex = 6;    // Trạng Thái
            dgvVouchers.Columns["Quantity"].DisplayIndex = 7;  // Số Lượng

            // Đặt lại tên header
            dgvVouchers.Columns["VoucherID"].HeaderText = "Mã Voucher";
            dgvVouchers.Columns["Title"].HeaderText = "Tiêu Đề";
            dgvVouchers.Columns["Discount"].HeaderText = "Giảm Giá (%)";
            dgvVouchers.Columns["DateStart"].HeaderText = "Ngày Bắt Đầu";
            dgvVouchers.Columns["DateEnd"].HeaderText = "Ngày Kết Thúc";
            dgvVouchers.Columns["Description"].HeaderText = "Mô Tả";
            dgvVouchers.Columns["Status"].HeaderText = "Trạng Thái";
            dgvVouchers.Columns["Quantity"].HeaderText = "Số Lượng";

            // Ẩn các cột không cần thiết nếu có (ví dụ: product_voucher)
            if (dgvVouchers.Columns.Contains("product_voucher"))
            {
                dgvVouchers.Columns["product_voucher"].Visible = false;
            }

            // Tự động điều chỉnh kích thước cột
            dgvVouchers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void LoadEvent()
        {
            // Danh sách từ khóa sự kiện
            var events = new[]
             {
                new { Code = "NY", Name = "New Year" },
                new { Code = "TET", Name = "Tết Nguyên Đán" },
                new { Code = "VAL", Name = "Valentine" },
                new { Code = "WOMEN", Name = "International Women's Day" },
                new { Code = "SUMMER", Name = "Summer Sale" },
                new { Code = "BK2S", Name = "Back to School" },
                new { Code = "HALLO", Name = "Halloween" },
                new { Code = "SINGLE", Name = "Singles' Day" },
                new { Code = "BFCM", Name = "Black Friday & Cyber Monday" },
                new { Code = "XMAS", Name = "Christmas" },
                new { Code = "SALE", Name = "End of Year Sale" },
                new { Code = "EVERYSALE", Name = "Monthly Sale" },
                new { Code = "BDAY", Name = "Birthday" },
                new { Code = "FREESHIP", Name = "Free Shipping" }
            }.ToList();

            // Gán danh sách vào ComboBox
            cboEvent.DataSource = events;
            cboEvent.DisplayMember = "Name"; // Hiển thị tên sự kiện
            cboEvent.ValueMember = "Code";   // Giá trị là mã viết tắt
        }

    }
}

