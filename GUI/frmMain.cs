using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> Huy
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // Sự kiện để mở form Account Management khi nhấn vào menu Account
        private void accountManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountManagement accountForm = new frmAccountManagement();
            accountForm.MdiParent = this;
            accountForm.Show();
        }

        // Sự kiện để mở form Product Management khi nhấn vào menu Product
        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmProductManagement productForm = new frmProductManagement();
            //productForm.MdiParent = this;
            //productForm.Show();
        }

        // Sự kiện để mở form Category Management khi nhấn vào menu Category
        private void categoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCategoryManagement categoryForm = new frmCategoryManagement();
            //categoryForm.MdiParent = this;
            //categoryForm.Show();
        }

        // Sự kiện để mở form Order Management khi nhấn vào menu Order
        private void orderManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmOrderManagement orderForm = new frmOrderManagement();
            //orderForm.MdiParent = this;
            //orderForm.Show();
        }

        // Sự kiện để mở form Feedback Management khi nhấn vào menu Feedback
        private void feedbackManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmFeedbackManagement feedbackForm = new frmFeedbackManagement();
            //feedbackForm.MdiParent = this;
            //feedbackForm.Show();
        }

        // Sự kiện để mở form Voucher Management khi nhấn vào menu Voucher
        private void voucherManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmVoucherManagement voucherForm = new frmVoucherManagement();
            //voucherForm.MdiParent = this;
            //voucherForm.Show();
        }

<<<<<<< HEAD
=======
        // Thêm sự kiện khác tương tự cho các chức năng khác (User Group, Order Details, etc.)
>>>>>>> Huy
    }
}
