using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class PhoneTextBox : TextBox
    {
        public PhoneTextBox() { }

        public bool IsValid()
        {
            Regex phoneRegex = new Regex(@"^\d{10,11}$");
            return phoneRegex.IsMatch(this.Text);
        }
    }
}
