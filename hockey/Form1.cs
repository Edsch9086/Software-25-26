using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pong
{
    public partial class Form1 : Form
    {
        int p1dir = 0;
        int p2dir = 0;
        int puckDirX = 6;
        int puckDirY = 6;  
        int score1 = 0;
        int score2 = 0;
        bool p2Computer = false;
        private readonly int goalHeight = 200; // Height of each goal area

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;

            // Restore original style
            this.Text = "Pong Sports IV: Hockey";
            this.BackColor = Color.Black;
            ball.BackColor = Color.White;
            ball.Size = new Size(30, 12); // Puck shape
            p1.BackColor = Color.White;
            p2.BackColor = Color.White;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label1.Text = "Goals: 0";
            label2.Text = "Goals: 0";
            label3.Text = "P2: Player";
            button1.Text = "Toggle P2 Mode";

            button1.Click += ToggleP2Button_Click;
            this.DoubleBuffered = true; // Reduce flicker for custom drawing
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 'w')
            //{
            //    p1.Top -= 20;
            //}
            //else if (e.KeyChar == 's')
            //{
            //    p1.Top += 20;
            //}
            //if (e.KeyChar == 'o')
            //{
            //    p2.Top -= 20;
            //}
            //else if (e.KeyChar == 'l')
            //{
            //    p2.Top += 20;
            //}
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                p1dir = -5;
            else if (e.KeyCode == Keys.S)
                p1dir = 5;
            if (e.KeyCode == Keys.O)
                p2dir = -5;
            else if (e.KeyCode == Keys.L)
                p2dir = 5;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.S)
                p1dir = 0;
            if (e.KeyCode == Keys.O || e.KeyCode == Keys.L)
                p2dir = 0;
        }

        private Rectangle GetLeftGoal()
        {
            int y = (this.ClientSize.Height - goalHeight) / 2;
            return new Rectangle(0, y, 1, goalHeight); // 1px wide for thin line
        }

        private Rectangle GetRightGoal()
        {
            int y = (this.ClientSize.Height - goalHeight) / 2;
            return new Rectangle(this.ClientSize.Width - 1, y, 1, goalHeight);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Move paddles
            if (p1.Top + p1dir >= 0 && p1.Top + p1dir + p1.Height <= this.ClientSize.Height)
                p1.Top += p1dir;

            if (p2Computer)
            {
                if (ball.Top + ball.Height / 2 < p2.Top + p2.Height / 2 && p2.Top > 0)
                    p2.Top -= 5;
                else if (ball.Top + ball.Height / 2 > p2.Top + p2.Height / 2 && p2.Top + p2.Height < this.ClientSize.Height)
                    p2.Top += 5;
            }
            else
            {
                if (p2.Top + p2dir >= 0 && p2.Top + p2dir + p2.Height <= this.ClientSize.Height)
                    p2.Top += p2dir;
            }

            // Move puck
            ball.Left += puckDirX;
            ball.Top += puckDirY;

            // Bounce off top/bottom
            if (ball.Top <= 0 || ball.Top + ball.Height >= this.ClientSize.Height)
                puckDirY = -puckDirY;

            // Bounce off paddles
            if (ball.Bounds.IntersectsWith(p1.Bounds) || ball.Bounds.IntersectsWith(p2.Bounds))
                puckDirX = -puckDirX;

            // Check for left goal
            if (ball.Left <= leftGoalLine.Right)
            {
                if (ball.Bounds.IntersectsWith(leftGoalLine.Bounds))
                {
                    score2++;
                    label2.Text = $"Goals: {score2}";
                    ResetPuck();
                    return;
                }
                else
                {
                    ball.Left = leftGoalLine.Right;
                    puckDirX = -puckDirX;
                }
            }

            // Check for right goal
            if (ball.Right >= rightGoalLine.Left)
            {
                if (ball.Bounds.IntersectsWith(rightGoalLine.Bounds))
                {
                    score1++;
                    label1.Text = $"Goals: {score1}";
                    ResetPuck();
                    return;
                }
                else
                {
                    ball.Left = rightGoalLine.Left - ball.Width;
                    puckDirX = -puckDirX;
                }
            }
        }

        private void ResetPuck()
        {
            ball.Left = this.ClientSize.Width / 2 - ball.Width / 2;
            ball.Top = this.ClientSize.Height / 2 - ball.Height / 2;
            puckDirX = -puckDirX;
        }

        private void ToggleP2Button_Click(object sender, EventArgs e)
        {
            p2Computer = !p2Computer;
            label3.Text = p2Computer ? "P2: Computer" : "P2: Player";
        }

        // Draw thin white lines for goals
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.White, 1))
            {
                Rectangle leftGoal = GetLeftGoal();
                Rectangle rightGoal = GetRightGoal();
                e.Graphics.DrawLine(pen, leftGoal.Left, leftGoal.Top, leftGoal.Left, leftGoal.Bottom);
                e.Graphics.DrawLine(pen, rightGoal.Left, rightGoal.Top, rightGoal.Left, rightGoal.Bottom);
            }
        }
    }
}
