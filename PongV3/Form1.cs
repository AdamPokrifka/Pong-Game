using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongV3
{
    public enum cpuDifficulty
    {
        Easy,
        Medium,
        Hard,
        Impossible
    }

    public enum GameState
    {
        Menu,
        Playing
    }

    public partial class Form1 : Form
    {

        GameState CurrentState = GameState.Menu;
        //Declare variables
        Rectangle cpuPaddle;
        Rectangle userPaddle;
        Rectangle ball;


        int userSpeed = 20;
        int ballX = 5;
        int ballY = 5;

        //CPU Difficulty
        cpuDifficulty cpuLevel;
        int cpuSpeed;
        int cpuError;

        //Socre
        int cpuScore = 0;
        int userScore = 0;
        Timer gameTimer = new Timer();

      
        public Form1()
        {
            
            //cpuLevel = difficulty;
            InitializeComponent();
            this.cpuLevel = cpuDifficulty.Easy;
            //Setup Form
            this.DoubleBuffered = true;
            this.Width = 600;
            this.Height = 400;
            this.Text = "Welcome Player Vs CPU!";
            this.BackColor = Color.Black;
            

            //Create a Rectangular Paddle
            cpuPaddle = new Rectangle(this.ClientSize.Width / 2 - 80 / 2, 30, 80, 15);

            //Create a Rectangular Paddle
            userPaddle = new Rectangle(this.ClientSize.Width / 2 - 80 / 2, this.ClientSize.Height - 30 - 15, 80, 15);

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
            if (CurrentState == GameState.Menu) return;

            //Move the ball
            ball.X += ballX;
            ball.Y += ballY;

            //bounce off left/right walls
            if (ball.Left <= 0 || ball.Right >= this.ClientSize.Width)
                ballX = -ballX;

            //CPU Difficulty
            switch(cpuLevel)
            {
                case cpuDifficulty.Easy:
                    cpuSpeed = 3;
                    cpuError = 15;
                    break;
                case cpuDifficulty.Medium:
                    cpuSpeed = 6;
                    cpuError = 5;
                    break;
                case cpuDifficulty.Hard:
                    cpuSpeed = 9;
                    cpuError = 2;
                    break;
                case cpuDifficulty.Impossible:
                    cpuSpeed = 12;
                    cpuError = 0;
                    break;
           
            }

            //CPU Paddle - Ai Tracking
            if (ball.X + ball.Width / 2 < cpuPaddle.X + cpuPaddle.Width / 2 - cpuError && cpuPaddle.Left > 0)
                cpuPaddle.X -= cpuSpeed;
            else if (ball.X + ball.Width / 2 > cpuPaddle.X + cpuPaddle.Width / 2 + cpuError && cpuPaddle.Right < ClientSize.Width)
                cpuPaddle.X += cpuSpeed;

            //CheckBox paddle collison
            if (ball.IntersectsWith(cpuPaddle))
            {
                ballY = -ballY;

            }

            if (ball.IntersectsWith(userPaddle))
            {
                ballY = -ballY;


            }


            //miss ball
            if (ball.Top <= 0)
            {
                userScore++;
                resetBall();
                this.Text = "Simple Pong Version 1 | Score: " + "Top: " + cpuScore + " Bottom: " + userScore;

                //MessageBox.Show("Game Over. Try Again. Final Score: " + "Top: " + scoretop + " Bottom: " + scorebot);
            }

            if (ball.Bottom >= this.ClientSize.Height)
            {

                cpuScore++;
                resetBall();
                this.Text = "Simple Pong Version 1 | Score: " + "Top: " + cpuScore + " Bottom: " + userScore;

                //MessageBox.Show("Game Over. Try Again. Final Score: " + "Top: " + scoretop + " Bottom: " + scorebot);
            }

            Invalidate();


        }
        private void DrawGame(object sender, PaintEventArgs e)
        {
            if (CurrentState == GameState.Menu)
            {
                //Draw Menu Screen
                string title = "CPU Vs User Pong";
                string instructions = "Choose Difficulty:\n" +
                                      "1 = Easy\n" +
                                      "2 = Meduim\n" +
                                      "3 = Hard\n" +
                                      "4 = Impossible";

                using (Font font = new Font("Arial", 16))
                using (Brush brush = Brushes.White)
                {
                    SizeF titleSize = e.Graphics.MeasureString(title, font);
                    e.Graphics.DrawString(title, font, brush,
                        (this.ClientSize.Width - titleSize.Width) / 2, 100);

                    e.Graphics.DrawString(instructions, font, brush,
                        200, 200);
                }
                return;

               
            }
            

            e.Graphics.FillRectangle(Brushes.AliceBlue, cpuPaddle);

            e.Graphics.FillRectangle(Brushes.AliceBlue, userPaddle);

            e.Graphics.FillEllipse(Brushes.Green, ball);

        }




        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (CurrentState == GameState.Menu)
            {
                if (keyData == Keys.D1)
                {
                    cpuLevel = cpuDifficulty.Easy;
                    CurrentState = GameState.Playing;

                }
                if (keyData == Keys.D2)
                {
                    cpuLevel = cpuDifficulty.Medium;
                    CurrentState = GameState.Playing;

                }
                if (keyData == Keys.D3)
                {
                    cpuLevel = cpuDifficulty.Hard;
                    CurrentState = GameState.Playing;

                }
                if (keyData == Keys.D4)
                {
                    cpuLevel = cpuDifficulty.Impossible;
                    CurrentState = GameState.Playing;

                }
            }



            if (keyData == Keys.Left && userPaddle.Left > 0)
                userPaddle.X -= userSpeed;
            else if (keyData == Keys.Right && userPaddle.Right > 0)
                userPaddle.X += userSpeed;

            return base.ProcessCmdKey(ref msg, keyData);
        }

            
        

        private void resetBall()
        {
            ball.X = this.ClientSize.Width / 2 - ball.Width / 2;
            ball.Y = this.ClientSize.Height / 2 - ball.Height / 2;
            
        }

    }
}
