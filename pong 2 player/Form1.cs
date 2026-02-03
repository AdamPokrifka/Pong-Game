using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pong 2 player
{
    public partial class Form1 : Form
    {
        //Declare variables
        Rectangle paddle;
        Rectangle paddle2;
        Rectangle ball;


        int paddleSpeed = 20;
        int paddle2Speed = 20;
        int ballX = 4;
        int ballY = 4;

        //Socre
        int score = 0;

        Timer gameTimer = new Timer();
        
        public Form1()
        {
            InitializeComponent();

            //Setup Form
            this.Width = 600;
            this.Height = 400;
            this.Text = "This is my new title.";
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;

            //Create a Rectangular Paddle
            paddle = new Rectangle(this.ClientSize.Width / 2 - 40, this.ClientSize.Height - 20, 80, 10);

            //Create a Rectangular Paddle2
            paddle2 = new Rectangle(this.ClientSize.Width / 2 - 40, this.ClientSize.Height - 20, 80, 10);

            //Create a Ball
            ball = new Rectangle(this.ClientSize.Width / 2, this.ClientSize.Height / 2, 15, 15);

            //Timer
            gameTimer.Interval = 20; // Update 50 times/second
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            //Paint Event - Draws paddle and ball
            this.Paint += DrawGame;


        }
        private void GameLoop(object sender, EventArgs e)
        {
            //Move the ball
            ball.X += ballX;
            ball.Y += ballY;

            //bounce off left/right walls
            if (ball.Left <= 0 || ball.Right >= this.ClientSize.Width)
                ballX = -ballX;

            //bounce off top
            if (ball.Top <= 0)
                ballY = -ballY;

            //CheckBox paddle collison
            if (ball.IntersectsWith(paddle))
            {
                ballY = -ballY;
                score++;
                this.Text = "Simple Pong Version 1 | Score: " + score;
            }

            
            //CheckBox paddle2 collison
            if (ball.IntersectsWith(paddle2))
            {
                ballY = -ballY;
                score++;
                this.Text = "Simple Pong Version 1 | Score: " + score;
            }


            //miss ball
            if (ball.Bottom >= this.ClientSize.Height)
            {
                gameTimer.Stop();
                MessageBox.Show("Game Over. Try Again. Final Score: " + score);
            }
            if (ball.Top >= this.ClientSize.Height)
            {
                gameTimer.Stop();
                MessageBox.Show("Game Over. Try Again. Final Score: " + score);
            }

            Invalidate();


        }
        private void DrawGame(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.AliceBlue, paddle);

            e.Graphics.FillRectangle(Brushes.AliceBlue, paddle2);

            e.Graphics.FillEllipse(Brushes.Green, ball);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left && paddle.Left > 0)
                paddle.X -= paddleSpeed;
            else if (keyData == Keys.Right && paddle.Right > 0)
                paddle.X += paddleSpeed;

           

             if (keyData == Keys.A && paddle2.Left > 0)
                paddle2.X -= paddle2Speed;
            else if (keyData == Keys.D && paddle2.Right > 0)
                paddle2.X += paddle2Speed;

            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}

