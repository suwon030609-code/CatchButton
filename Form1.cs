using System;
using System.Drawing;
using System.Windows.Forms;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        private readonly Random rd = new Random();
        private int score = 0; 

        public Form1()
        {
            InitializeComponent();
            UpdateGameTitle();
        }

       
        private void UpdateGameTitle()
        {
            this.Text = $"현재 점수: {score}점 | 위치 - X: {btnTarget.Location.X}, Y: {btnTarget.Location.Y}";
        }

  
        private void BtnTarget_MouseEnter(object sender, EventArgs e)
        {
            score -= 10;

          
            int maxX = this.ClientSize.Width - btnTarget.Width;
            int maxY = this.ClientSize.Height - btnTarget.Height;

            int nextX = rd.Next(0, Math.Max(1, maxX));
            int nextY = rd.Next(0, Math.Max(1, maxY));

            btnTarget.Location = new Point(nextX, nextY);

           
            UpdateGameTitle();
        }

     
        private void btnTarget_Click(object sender, EventArgs e)
        {
          
            score += 100;

      
            btnTarget.Width = (int)(btnTarget.Width * 0.9);
            btnTarget.Height = (int)(btnTarget.Height * 0.9);

            UpdateGameTitle();
            MessageBox.Show("축하합니다~!", "성공");
        }
    }
}