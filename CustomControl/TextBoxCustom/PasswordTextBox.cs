﻿using System;
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
    public partial class PasswordTextBox : TextBox
    {
        public PasswordTextBox()
        {
            this.UseSystemPasswordChar = true;
        }

        public bool IsValid()
        {
            return this.Text.Length >= 8;
        }
    }
}
