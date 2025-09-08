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
        int balldirx = 4;
        int balldiry = 4;
        int score1 = 0;
        int score2 = 0;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (p1.Top + p1dir >= 0 && p1.Top + p1dir + p1.Height <= this.ClientSize.Height)
            {
                p1.Top += p1dir;
            }
            if (p2.Top + p2dir >= 0 && p2.Top + p2dir + p2.Height <= this.ClientSize.Height)
            {
                p2.Top += p2dir;
            }
            ball.Left += balldirx;
            ball.Top += balldiry;
            if (ball.Top <= 0 || ball.Top + ball.Height >= this.ClientSize.Height)
            {
                balldiry = -balldiry;
            }
            if (ball.Bounds.IntersectsWith(p1.Bounds) || ball.Bounds.IntersectsWith(p2.Bounds))
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
    }
}
