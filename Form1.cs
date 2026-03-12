using System;
using System.Drawing;
using System.Windows.Forms;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        private readonly Random rd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnTarget_MouseEnter(object sender, EventArgs e)
        {
            int maxX = this.ClientSize.Width - btnTarget.Width;
            int maxY = this.ClientSize.Height - btnTarget.Height;

            int nextX = rd.Next(0, Math.Max(1, maxX));
            int nextY = rd.Next(0, Math.Max(1, maxY));

            btnTarget.Location = new Point(nextX, nextY);

            this.Text = "버튼 위치 - X: " + btnTarget.Location.X + ", Y: " + btnTarget.Location.Y;
        }
    }
}
