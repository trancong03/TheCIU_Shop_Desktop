using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
            this.btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            OnLoginClicked();
        }

        public string UserName
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        public event EventHandler LoginClicked;

        protected virtual void OnLoginClicked()
        {
            LoginClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
