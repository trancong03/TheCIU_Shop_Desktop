using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class CurrencyTextBox : UserControl
    {
        public CurrencyTextBox()
        {
            InitializeComponent();
            txtCurrency.TextAlign = HorizontalAlignment.Right;
            txtCurrency.TextChanged += TxtCurrency_TextChanged;
            txtCurrency.Font = new Font("Times New Roman", 11);
            txtCurrency.KeyPress += TxtCurrency_KeyPress;
        }

        // Sự kiện kiểm tra nhập vào chỉ là số hoặc dấu xóa
        private void TxtCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtCurrency_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu TextBox trống
            if (string.IsNullOrEmpty(txtCurrency.Text)) return;

            // Lấy vị trí con trỏ hiện tại
            int selectionStart = txtCurrency.SelectionStart;

            // Loại bỏ định dạng hiện tại (dấu phẩy và chữ "đ")
            string value = txtCurrency.Text.Replace(",", "").Replace("đ", "").Trim();

            // Nếu giá trị hợp lệ, định dạng lại chuỗi
            if (decimal.TryParse(value, out decimal number))
            {
                txtCurrency.TextChanged -= TxtCurrency_TextChanged;

                // Định dạng lại và thêm "đ" vào cuối
                txtCurrency.Text = string.Format(CultureInfo.InvariantCulture, "{0:n0} đ", number);

                // Đặt lại vị trí con trỏ
                txtCurrency.SelectionStart = Math.Min(selectionStart, txtCurrency.Text.Length - 2);

                txtCurrency.TextChanged += TxtCurrency_TextChanged;
            }
        }




        // Thuộc tính để lấy giá trị tiền tệ
        public decimal Value
        {
            get
            {
                if (string.IsNullOrWhiteSpace(txtCurrency.Text))
                    return 0;

                string value = txtCurrency.Text.Replace(",", "").Replace("đ", "").Trim();
                return decimal.TryParse(value, out decimal number) ? number : 0;
            }
            set
            {
                txtCurrency.Text = value > 0
                    ? string.Format(CultureInfo.InvariantCulture, "{0:n0} đ", value)
                    : string.Empty;
            }
        }

        public void Clear()
        {
            txtCurrency.Clear(); // Xóa nội dung của TextBox
        }
    }
}
