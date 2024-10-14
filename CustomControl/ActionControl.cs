using System;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class ActionControl : UserControl
    {
        public event EventHandler SearchClicked;
        public event EventHandler AddClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;

        public ActionControl()
        {
            InitializeComponent();
        }

        public string SearchText
        {
            get { return txtSearch.Text; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
