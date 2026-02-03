namespace SinglePongTB
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.paddle1 = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.score1Label = new System.Windows.Forms.Label();
            this.paddle2 = new System.Windows.Forms.PictureBox();
            this.score2Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paddle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddle2)).BeginInit();
            this.SuspendLayout();
            // 
            // paddle1
            // 
            this.paddle1.BackColor = System.Drawing.Color.Crimson;
            this.paddle1.Location = new System.Drawing.Point(20, 250);
            this.paddle1.Name = "paddle1";
            this.paddle1.Size = new System.Drawing.Size(20, 100);
            this.paddle1.TabIndex = 0;
            this.paddle1.TabStop = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ball.Location = new System.Drawing.Point(390, 290);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(20, 20);
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // score1Label
            // 
            this.score1Label.AutoSize = true;
            this.score1Label.BackColor = System.Drawing.Color.Transparent;
            this.score1Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.score1Label.Font = new System.Drawing.Font("Old English Text MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score1Label.ForeColor = System.Drawing.Color.DarkMagenta;
            this.score1Label.Location = new System.Drawing.Point(121, 9);
            this.score1Label.Name = "score1Label";
            this.score1Label.Size = new System.Drawing.Size(92, 26);
            this.score1Label.TabIndex = 2;
            this.score1Label.Text = "Score: 0";
            // 
            // paddle2
            // 
            this.paddle2.BackColor = System.Drawing.Color.Crimson;
            this.paddle2.Location = new System.Drawing.Point(752, 250);
            this.paddle2.Name = "paddle2";
            this.paddle2.Size = new System.Drawing.Size(20, 100);
            this.paddle2.TabIndex = 3;
            this.paddle2.TabStop = false;
            // 
            // score2Label
            // 
            this.score2Label.AutoSize = true;
            this.score2Label.BackColor = System.Drawing.Color.Transparent;
            this.score2Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.score2Label.Font = new System.Drawing.Font("Old English Text MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score2Label.ForeColor = System.Drawing.Color.DarkMagenta;
            this.score2Label.Location = new System.Drawing.Point(591, 9);
            this.score2Label.Name = "score2Label";
            this.score2Label.Size = new System.Drawing.Size(92, 26);
            this.score2Label.TabIndex = 4;
            this.score2Label.Text = "Score: 0";
            this.score2Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chartreuse;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.score2Label);
            this.Controls.Add(this.paddle2);
            this.Controls.Add(this.score1Label);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.paddle1);
            this.ForeColor = System.Drawing.Color.Crimson;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paddle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddle2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox paddle1;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label score1Label;
        private System.Windows.Forms.PictureBox paddle2;
        private System.Windows.Forms.Label score2Label;
    }
}

