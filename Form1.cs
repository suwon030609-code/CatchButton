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

                // 1. 예/아니요 버튼이 있는 메시지 박스를 띄우고 사용자의 선택을 result 변수에 저장합니다.
                DialogResult result = MessageBox.Show(
                    "20번을 놓치셨습니다. 다시 시작하시겠습니까?",
                    "Game Over",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // 2. 사용자의 선택에 따라 동작을 분기합니다.
                if (result == DialogResult.Yes)
                {
                    // '예'를 누르면 다시 시작
                    btnRestart_Click(null, null);
                }
                else
                {
                    // '아니요'를 누르면 프로그램(게임)을 완전히 종료
                    Application.Exit();
                }

                return;
            }
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