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
            txtCurrency.Font = new Font("Times New Roman", 10);
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

        // Sự kiện xử lý định dạng tiền tệ
        private void TxtCurrency_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrency.Text)) return;

            // Xóa định dạng hiện tại
            txtCurrency.TextChanged -= TxtCurrency_TextChanged;

            // Lấy giá trị số
            string value = txtCurrency.Text.Replace(",", "").Replace("đ", "").Trim();
            if (decimal.TryParse(value, out decimal number))
            {
                // Định dạng lại
                txtCurrency.Text = string.Format(CultureInfo.InvariantCulture, "{0:n0} đ", number);
                txtCurrency.SelectionStart = txtCurrency.Text.Length;
            }

            txtCurrency.TextChanged += TxtCurrency_TextChanged;
        }

        // Thuộc tính để lấy giá trị tiền tệ
        public decimal Value
        {
            get
            {
                string value = txtCurrency.Text.Replace(",", "").Replace("đ", "").Trim();
                return decimal.TryParse(value, out decimal number) ? number : 0;
            }
            set
            {
                txtCurrency.Text = string.Format(CultureInfo.InvariantCulture, "{0:n0} đ", value);
            }
        }
        public void Clear()
        {
            txtCurrency.Clear(); // Xóa nội dung của TextBox
        }
    }
}
