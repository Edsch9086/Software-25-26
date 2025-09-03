using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int l = 0;
            int w = 0;
            int.TryParse(textBox1.Text, out l);
            int.TryParse(textBox2.Text, out w);    
            int area = rArea(l, w);
            int prei = rPerimeter(l, w);
            textBox3.Text = area.ToString();
            textBox4.Text = prei.ToString();
        }

        private int rArea(int l, int w)
        {
            return l * w;
        }

        private int rPerimeter(int l, int w)
        {
            return 2 * (l + w);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int l = 0;
            int.TryParse(textBox5.Text, out l);
            int area = rArea(l, l);
            int prei = rPerimeter(l, l);
            textBox6.Text = area.ToString();
        textBox7.Text = prei.ToString();
        }
            
        private void button3_Click(object sender, EventArgs e)
        {
            int r = 0;
            int.TryParse(textBox8.Text, out r);
            double carea = car(r);
            double cie = france(r);
            double dia = diam(r);
            textBox11.Text = carea.ToString();
            textBox10.Text = cie.ToString();
            textBox9.Text = dia.ToString();
      
        }

        private double car(int r)
        {
            return Math.PI   * (r * r) ;
        }
        private double france(int r)
        {
            return Math.PI * r * 2;
        }
        private double diam(int r)
        {
            return r * 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int s = 0;
            int.TryParse(textBox12.Text, out s);
            double tria = tarea(s);
            double sdlvgq3o = albania(s);
            textBox15.Text = tria.ToString();
            textBox14.Text = sdlvgq3o.ToString();
        }

        private double tarea(int s)
        {
            return ((Math.Sqrt(3)) / 4) * (s * s);
        }

        private double albania(int s)
        {
            return s * 3;
        }
    }
}
