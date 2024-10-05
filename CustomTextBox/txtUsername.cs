using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTextBox
{
    public class txtUsername : CustomTextBox
    {
        public txtUsername()
        {
            this.Icon = Properties.Resources.username_icon;
            this.Placeholder = "Nhập tên đăng nhập"; 
        }
    }
}
