using System;
using System.Drawing;
using System.Windows.Forms;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        private readonly Random rd = new Random();
        private int score = 0;           
        private int missCount = 0;       
        private Size initialButtonSize; 

        public Form1()
        {
            InitializeComponent();

            initialButtonSize = btnTarget.Size;
            UpdateGameTitle();
        }

        private void UpdateGameTitle()
        {
            this.Text = $"점수: {score}점 | 놓친 횟수: {missCount}/20 | 위치 X: {btnTarget.Location.X}, Y: {btnTarget.Location.Y}";
        }

        private void BtnTarget_MouseEnter(object sender, EventArgs e)
        {

            if (!btnTarget.Enabled) return;

            score -= 10;
            missCount++; 

            if (missCount >= 20)
            {
                UpdateGameTitle(); 
                btnTarget.Enabled = false; 
                MessageBox.Show("20번을 놓치셨습니다. Game Over!", "게임 종료", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

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
            MessageBox.Show("축하합니다~!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            score = 0;
            missCount = 0;

           
            btnTarget.Size = initialButtonSize; 
            btnTarget.Enabled = true;         

            btnTarget.Location = new Point(
                (this.ClientSize.Width - btnTarget.Width) / 2,
                (this.ClientSize.Height - btnTarget.Height) / 2
            );

            UpdateGameTitle();
        }
    }
}