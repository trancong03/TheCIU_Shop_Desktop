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
        public event EventHandler SearchTextChanged;
        public event EventHandler FilterChanged;

        public ActionControl()
        {
            InitializeComponent();
        }

        public string SearchText
        {
            get => txtSearch.Text;
        }

        public object FilterDataSource
        {
            get => cbFilter.DataSource;
            set => cbFilter.DataSource = value;
        }

        public string FilterDisplayMember
        {
            get => cbFilter.DisplayMember;
            set => cbFilter.DisplayMember = value;
        }

        public string FilterValueMember
        {
            get => cbFilter.ValueMember;
            set => cbFilter.ValueMember = value;
        }

        public object SelectedFilterValue
        {
            get => cbFilter.SelectedValue;
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchTextChanged?.Invoke(this, EventArgs.Empty);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
