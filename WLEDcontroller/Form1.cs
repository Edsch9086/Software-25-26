using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WLEDcontroller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void save1_Click(object sender, EventArgs e)
        {
            int r = 0;
            int.TryParse(red.Text, out r);
            int g = 0;
            int.TryParse(green.Text, out g);
            int b = 0;
            int.TryParse(blue.Text, out b);
            int w = 0;
            int.TryParse(white.Text, out w);
        }
    }
}
