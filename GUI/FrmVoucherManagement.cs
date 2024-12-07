using System;
using System.Windows.Forms;
using BLL;
using CustomControl;
using DTO;

namespace GUI
{
    public partial class FrmVoucherManagement : Form
    {
        private VoucherBLL voucherBLL = new VoucherBLL();

        public FrmVoucherManagement()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadVouchers();

            actionControl.AddClicked += ActionControl_AddClicked;
            actionControl.UpdateClicked += ActionControl_UpdateClicked;
            actionControl.DeleteClicked += ActionControl_DeleteClicked;
            actionControl.ReloadClicked += ActionControl_ReloadClicked;

            dataGridViewVouchers.SelectionChanged += DataGridViewVouchers_SelectionChanged;
        }

        private void LoadVouchers()
        {
            var vouchers = voucherBLL.GetAllVouchers();
            dataGridViewVouchers.DataSource = vouchers;
        }

        private void ActionControl_AddClicked(object sender, EventArgs e)
        {
            try
            {
                var voucher = new Voucher
                {
                    tiltle = txtTitle.Text,
                    discount = int.TryParse(txtDiscount.Text, out int discount) ? discount : 0,
                    dateStart = dtpStartDate.Value.ToString("yyyy-MM-dd"),
                    dateEnd = dtpEndDate.Value,
                    discription = txtDescription.Text,
                    status = chkStatus.Checked
                };
                voucherBLL.AddVoucher(voucher);
                MessageBox.Show("Thêm voucher thành công!", "Thông báo");
                LoadVouchers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void ActionControl_UpdateClicked(object sender, EventArgs e)
        {
            if (dataGridViewVouchers.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn voucher để cập nhật.", "Thông báo");
                return;
            }

            try
            {
                var voucherId = (int)dataGridViewVouchers.CurrentRow.Cells["voucher_id"].Value;
                var voucher = voucherBLL.GetVoucherById(voucherId);
                voucher.tiltle = txtTitle.Text;
                voucher.discount = int.TryParse(txtDiscount.Text, out int discount) ? discount : 0;
                voucher.dateStart = dtpStartDate.Value.ToString("yyyy-MM-dd");
                voucher.dateEnd = dtpEndDate.Value;
                voucher.discription = txtDescription.Text;
                voucher.status = chkStatus.Checked;
                voucherBLL.EditVoucher(voucher);
                MessageBox.Show("Cập nhật voucher thành công!", "Thông báo");
                LoadVouchers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void ActionControl_DeleteClicked(object sender, EventArgs e)
        {
            if (dataGridViewVouchers.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn voucher để xóa.", "Thông báo");
                return;
            }

            try
            {
                var voucherId = (int)dataGridViewVouchers.CurrentRow.Cells["voucher_id"].Value;
                voucherBLL.RemoveVoucher(voucherId);
                MessageBox.Show("Xóa voucher thành công!", "Thông báo");
                LoadVouchers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void ActionControl_ReloadClicked(object sender, EventArgs e)
        {
            LoadVouchers();
        }

        private void DataGridViewVouchers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewVouchers.CurrentRow == null) return;

            var row = dataGridViewVouchers.CurrentRow;
            txtTitle.Text = row.Cells["tiltle"].Value?.ToString() ?? string.Empty;
            txtDiscount.Text = row.Cells["discount"].Value?.ToString() ?? string.Empty;
            dtpStartDate.Value = DateTime.TryParse(row.Cells["dateStart"].Value?.ToString(), out DateTime startDate) ? startDate : DateTime.Now;
            dtpEndDate.Value = DateTime.TryParse(row.Cells["dateEnd"].Value?.ToString(), out DateTime endDate) ? endDate : DateTime.Now;
            txtDescription.Text = row.Cells["discription"].Value?.ToString() ?? string.Empty;
            chkStatus.Checked = row.Cells["status"].Value != null && (bool)row.Cells["status"].Value;
        }
    }
}
