using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinglePongTB
{
    public partial class Form1 : Form
    {
        int ballXSpeed = 5;
        int ballYSpeed = 5;
        int playerSpeed = 20;
        int score1 = 0;
        int score2 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            ball.Left += ballXSpeed;
            ball.Top += ballYSpeed;

            //Bounce Top and Bottom
            if (ball.Top <= 0 || ball.Bottom >= this.ClientSize.Height)
                ballYSpeed = -ballYSpeed;

            //Collision for paddles
            if (ball.Bounds.IntersectsWith(paddle1.Bounds))
            {
                ballXSpeed = -ballXSpeed;
            }

            if (ball.Bounds.IntersectsWith(paddle2.Bounds))
            {
                ballXSpeed = -ballXSpeed;
            }

            //Ball goes past paddle
            if (ball.Left <= 0)
            {
                ball.Left = this.ClientSize.Width / 2 - ball.Width / 2;
                ball.Top = this.ClientSize.Height / 2 - ball.Height / 2;
                ballXSpeed = 5;
                ballYSpeed = 5;
                score2++;
                score2Label.Text = "Score: " + score2;

            }
            


            if (ball.Right >= this.ClientSize.Width)
            {
                ballXSpeed = -ballXSpeed;
                ball.Left = this.ClientSize.Width / 2 - ball.Width / 2;
                ball.Top = this.ClientSize.Height / 2 - ball.Height / 2;
                ballXSpeed = 5;
                ballYSpeed = 5;
                score1++;
                score1Label.Text = "Score: " + score1;
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        { 
            if (keyData == Keys.W && paddle1.Top > 0)
                paddle1.Top -= playerSpeed;
            if (keyData == Keys.S && paddle1.Bottom < this.ClientSize.Height)
                paddle1.Top += playerSpeed;
            if (keyData == Keys.Up && paddle2.Top > 0)
                paddle2.Top -= playerSpeed;
            if (keyData == Keys.Down && paddle2.Bottom < this.ClientSize.Height)
                paddle2.Top += playerSpeed;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
