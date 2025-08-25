using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject LXIX (69)";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject LXXVII (78) - Anton Lazar";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject LXXXV (85)";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject XCI (91) - The Patriarch";
        }
   
        private void button5_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject XCV (95) - Dr. Emerson";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject CIV (104)";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject CV (105)";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject CVI (106)";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject CVII (107)";
        }
    }
}
