using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTextBox
{
    public class txtPassword : CustomTextBox
    {
        public txtPassword()
        {
         
            this.Icon = Properties.Resources.password_icon;
            this.PasswordChar = '*'; 
            this.Placeholder = "Nhập mật khẩu"; 
        }
    }

}
