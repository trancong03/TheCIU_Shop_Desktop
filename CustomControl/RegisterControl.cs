using System;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class RegisterControl : UserControl
    {
        private ErrorProvider errorProvider = new ErrorProvider();

        public event EventHandler RegisterClicked;
        public event EventHandler CancelClicked;

        public RegisterControl()
        {
            InitializeComponent();

            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        public string NameField
        {
            get { return txtName.Text; }
        }

        public string Username
        {
            get { return txtUsername.Text; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
        }

        public string Phone
        {
            get { return txtPhone.Text; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
        }

        public string Gender
        {
            get { return cboGender.SelectedItem?.ToString(); }
        }

        public string AvatarPath { get; private set; }
        public string BackgroundPath { get; private set; }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(NameField))
            {
                errorProvider.SetError(txtName, "Name is required.");
                hasError = true;
            }
            else
            {
                errorProvider.SetError(txtName, "");
            }

            if (string.IsNullOrEmpty(Username))
            {
                errorProvider.SetError(txtUsername, "Username is required.");
                hasError = true;
            }
            else
            {
                errorProvider.SetError(txtUsername, "");
            }

            if (string.IsNullOrEmpty(Password))
            {
                errorProvider.SetError(txtPassword, "Password is required.");
                hasError = true;
            }
            else
            {
                errorProvider.SetError(txtPassword, "");
            }

            if (string.IsNullOrEmpty(Email))
            {
                errorProvider.SetError(txtEmail, "Email is required.");
                hasError = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, "");
            }

            if (string.IsNullOrEmpty(Phone))
            {
                errorProvider.SetError(txtPhone, "Phone number is required.");
                hasError = true;
            }
            else
            {
                errorProvider.SetError(txtPhone, "");
            }

            if (string.IsNullOrEmpty(Address))
            {
                errorProvider.SetError(txtAddress, "Address is required.");
                hasError = true;
            }
            else
            {
                errorProvider.SetError(txtAddress, "");
            }

            if (hasError) return;

            // Gọi sự kiện RegisterClicked nếu không có lỗi
            RegisterClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnUploadAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AvatarPath = openFileDialog.FileName;
                    MessageBox.Show($"Avatar selected: {AvatarPath}");
                }
            }
        }

        private void btnUploadBackground_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    BackgroundPath = openFileDialog.FileName;
                    MessageBox.Show($"Background selected: {BackgroundPath}");
                }
            }
        }
    }
}
