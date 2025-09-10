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
        int p3dir = 0;
        int p4dir = 0;
        int balldirx = 4;
        int balldiry = 4;
        int score1 = 0;
        int score2 = 0;
        bool p2Computer = false;
        bool p3Computer = false;
        bool p4Computer = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;

            label3.Text = "P2: Player";
            label4.Text = "P3: Player";
            label5.Text = "P4: Player";

            button1.Click += ToggleP2Button_Click;
            button3.Click += ToggleP3Button_Click;
            button4.Click += ToggleP4Button_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {}

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                p1dir = -5;
            }
            else if (e.KeyCode == Keys.S)
            {
                p1dir = 5;
            }
            if (e.KeyCode == Keys.O)
            {
                p2dir = -5;
            }
            else if (e.KeyCode == Keys.L)
            {
                p2dir = 5;
            }
            if (e.KeyCode == Keys.D)
            {
                p3dir = -5;
            }
            else if (e.KeyCode == Keys.C)
            {
                p3dir = 5;
            }
            if (e.KeyCode == Keys.Up)
            {
                p4dir = -5;
            }
            else if (e.KeyCode == Keys.Down)
            {
                p4dir = 5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.S)
            {
                p1dir = 0;
            }
            if (e.KeyCode == Keys.O || e.KeyCode == Keys.L)
            {
                p2dir = 0;
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.C)
            {
                p3dir = 0;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                p4dir = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int topHalf = this.ClientSize.Height / 2;
            if (p1.Top + p1dir >= 0 && p1.Top + p1dir + p1.Height <= topHalf)
            {
                p1.Top += p1dir;
            }
            if (p2Computer)
            {
                if (ball.Top + ball.Height / 2 < p2.Top + p2.Height / 2 && p2.Top > 0)
                    p2.Top -= 4;
                else if (ball.Top + ball.Height / 2 > p2.Top + p2.Height / 2 && p2.Top + p2.Height < topHalf)
                    p2.Top += 4;
            }
            else
            {
                if (p2.Top + p2dir >= 0 && p2.Top + p2dir + p2.Height <= topHalf)
                {
                    p2.Top += p2dir;
                }
            }
            if (p3Computer)
            {s
                if (ball.Top + ball.Height / 2 < p3.Top + p3.Height / 2 && p3.Top > topHalf)
                    p3.Top -= 4;
                else if (ball.Top + ball.Height / 2 > p3.Top + p3.Height / 2 && p3.Top + p3.Height < this.ClientSize.Height)
                    p3.Top += 4;
            }
            else
            {
                if (p3.Top + p3dir >= topHalf && p3.Top + p3dir + p3.Height <= this.ClientSize.Height)
                {
                    p3.Top += p3dir;
                }
            }
            if (p4Computer)
            {
                if (ball.Top + ball.Height / 2 < p4.Top + p4.Height / 2 && p4.Top > topHalf)
                    p4.Top -= 4;
                else if (ball.Top + ball.Height / 2 > p4.Top + p4.Height / 2 && p4.Top + p4.Height < this.ClientSize.Height)
                    p4.Top += 4;
            }
            else
            {
                if (p4.Top + p4dir >= topHalf && p4.Top + p4dir + p4.Height <= this.ClientSize.Height)
                {
                    p4.Top += p4dir;
                }
            }

            ball.Left += balldirx;
            ball.Top += balldiry;
            if (ball.Top <= 0 || ball.Top + ball.Height >= this.ClientSize.Height)
            {
                balldiry = -balldiry;
            }
            if (ball.Bounds.IntersectsWith(p1.Bounds) || ball.Bounds.IntersectsWith(p2.Bounds)
                || ball.Bounds.IntersectsWith(p3.Bounds) || ball.Bounds.IntersectsWith(p4.Bounds))
            {
                balldirx = -balldirx;
            }
            if (ball.Left <= 0)
            {
                score2++;
                label2.Text = $"Score: {score2}";
                ResetBall();
            }
            else if (ball.Left + ball.Width >= this.ClientSize.Width)
            {
                score1++;
                label1.Text = $"Score: {score1}";
                ResetBall();
            }
        }

        private void ResetBall()
        {
            ball.Left = this.ClientSize.Width / 2 - ball.Width / 2;
            ball.Top = this.ClientSize.Height / 2 - ball.Height / 2;
            balldirx = -balldirx;
        }

        private void ToggleP2Button_Click(object sender, EventArgs e)
        {
            p2Computer = !p2Computer;
            label3.Text = p2Computer ? "P2: Computer" : "P2: Player";
        }

        private void ToggleP3Button_Click(object sender, EventArgs e)
        {
            p3Computer = !p3Computer;
            label4.Text = p3Computer ? "P3: Computer" : "P3: Player";
        }

        private void ToggleP4Button_Click(object sender, EventArgs e)
        {
            p4Computer = !p4Computer;
            label5.Text = p4Computer ? "P4: Computer" : "P4: Player";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetBall();
            score1 = 0;
            score2 = 0;
            label1.Text = "Score: 0";
            label2.Text = "Score: 0";
        }
    }
}
