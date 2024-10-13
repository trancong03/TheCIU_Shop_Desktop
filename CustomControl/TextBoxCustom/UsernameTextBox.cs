using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class UsernameTextBox : TextBox
    {
        public UsernameTextBox()
        {
            this.MaxLength = 20;  
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.Text) && this.Text.Length >= 5;
        }
    }
}
