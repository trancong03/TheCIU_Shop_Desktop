using System.Drawing;
using System.Windows.Forms;

namespace CustomControl
{
    partial class StatCard
    {
        private PictureBox picIcon;
        private Label lblTitle;
        private Label lblValue;

        private void InitializeComponent()
        {
            this.picIcon = new PictureBox();
            this.lblTitle = new Label();
            this.lblValue = new Label();

            // 
            // picIcon
            // 
            this.picIcon.Location = new Point(10, 10);
            this.picIcon.Size = new Size(50, 50);
            this.picIcon.SizeMode = PictureBoxSizeMode.StretchImage;

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitle.Location = new Point(70, 10);
            this.lblTitle.Size = new Size(150, 20);

            // 
            // lblValue
            // 
            this.lblValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblValue.ForeColor = Color.DarkBlue;
            this.lblValue.Location = new Point(70, 40);
            this.lblValue.Size = new Size(150, 30);

            // 
            // StatCard
            // 
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblValue);
            this.Size = new Size(230, 80);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
