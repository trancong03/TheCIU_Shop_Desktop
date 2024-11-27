using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class StatCard : UserControl
    {
        public StatCard()
        {
            InitializeComponent();
        }
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public string Value
        {
            get => lblValue.Text;
            set => lblValue.Text = value;
        }

        public Image Icon
        {
            get => picIcon.Image;
            set => picIcon.Image = value;
        }
    }
}
