using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomTextBox
{
    public class txtPassword : TextBox
    {
        public txtPassword()
        {
            this.PasswordChar = '*'; 
            this.UseSystemPasswordChar = true;
        }

    }

}
