using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pongverison2
{

    public partial class Form1 : Form
    {
        //Declare variables
        Rectangle paddletop;
        Rectangle paddlebottom;
        Rectangle ball;

        int paddletopSpeed = 20;
        int paddlebottomSpeed = 20;
        int ballX = 4;
        int ballY = 4;

        //Socre
        int scoretop = 0;
        int scorebot = 0;
        Timer gameTimer = new Timer();
        public Form1()
        {
            InitializeComponent();

            //Setup Form
            this.Width = 600;
            this.Height = 400;
            this.Text = "Welcome to 2-Playered Pong.";
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;

            //Create a Rectangular Paddle
            paddletop = new Rectangle(this.ClientSize.Width / 2 - 80 / 2, 30, 80, 15);

            //Create a Rectangular Paddle
            paddlebottom = new Rectangle(this.ClientSize.Width / 2 - 80 / 2, this.ClientSize.Height - 30 - 15, 80, 15);

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

            


            //CheckBox paddle collison
            if (ball.IntersectsWith(paddletop))
            {
                ballY = -ballY;
               
            }

            if (ball.IntersectsWith(paddlebottom))
            {
                ballY = -ballY;
               
                
            }


            //miss ball
            if (ball.Top <= 10)
            {
                scorebot++;
                resetBall();
                this.Text = "Simple Pong Version 1 | Score: " + "Top: " + scoretop + " Bottom: " + scorebot;
                
                //MessageBox.Show("Game Over. Try Again. Final Score: " + "Top: " + scoretop + " Bottom: " + scorebot);
            }

            if (ball.Bottom>= this.ClientSize.Height)
            {

                scoretop++;
                resetBall();
                this.Text = "Simple Pong Version 1 | Score: " + "Top: " + scoretop + " Bottom: " + scorebot;
               
                //MessageBox.Show("Game Over. Try Again. Final Score: " + "Top: " + scoretop + " Bottom: " + scorebot);
            }

            Invalidate();


        }
        private void DrawGame(object sender, PaintEventArgs e)
        {

            e.Graphics.FillRectangle(Brushes.AliceBlue, paddletop);

            e.Graphics.FillRectangle(Brushes.AliceBlue, paddlebottom);

            e.Graphics.FillEllipse(Brushes.Green, ball);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.A && paddletop.Left > 0)
                paddletop.X -= paddletopSpeed;
            else if (keyData == Keys.D && paddletop.Right > 0)
                paddletop.X += paddletopSpeed;

            if (keyData == Keys.Left && paddlebottom.Left > 0)
                paddlebottom.X -= paddlebottomSpeed;
            else if (keyData == Keys.Right && paddlebottom.Right > 0)
                paddlebottom.X += paddlebottomSpeed;

            return base.ProcessCmdKey(ref msg, keyData);



        }

        private void resetBall()
        {
            ball.X = this.ClientSize.Width / 2 - ball.Width / 2;
            ball.Y = this.ClientSize.Height / 2 - ball.Height / 2;

        }

    }
}
