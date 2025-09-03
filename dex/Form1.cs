using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            description.Text = "Not much is known about Subject 69. Their number is displayed on The Patriarch's helmet, indicating they were one of the subjects that The Patriarch killed.";
            string imagePath = Path.Combine(Application.StartupPath, "images", "unknown.png");
            displaypicturebox.Image = Image.FromFile(imagePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject LXXVII (78) - Anton Lazar";
            description.Text = "Anton Lazar was a former Syndicate subject who had a high intelligence and created the Horizon Corporation, a company meant to help the Syndicate gain full economic control. However, his intelligence led to him realizing what the Syndicate was really doing, causing him to rebel and turn against them.";
            string imagePath = Path.Combine(Application.StartupPath, "images", "anton.png");
            displaypicturebox.Image = Image.FromFile(imagePath);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject LXXXV (85)";
            description.Text = "Not much is known about Subject 85. Their number is displayed on The Patriarch's helmet, indicating they were one of the subjects that The Patriarch killed.";
            string imagePath = Path.Combine(Application.StartupPath, "images", "unknown.png");
            displaypicturebox.Image = Image.FromFile(imagePath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject XCI (91) - The Patriarch";
            description.Text = "The Patriarch is an ex-Syndicate subject created to take control of a cult. However, he realized what the Syndicate were doing, leading to him rebelling. He killed 3 subjects and used theirs and his Syndicate Coins to forge his iconic golden headpeice.";
            string imagePath = Path.Combine(Application.StartupPath, "images", "patty.png");
            displaypicturebox.Image = Image.FromFile(imagePath);
        }
   
        private void button5_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject XCV (95) - Dr. Emerson";
            description.Text = "Doctor Emerson was a subject equipped with cloaking that was designed to infiltrate the Horizon Corporation's Pandora Institute by masquerading as a civillian researcher. The Pandora Institute was an end-of-life care facility that was suspected to be running unethical human experiments. Dr. Emerson released several dangerous entities from containment before self-terminating, to help bring down the facility from inside.";
            string imagePath = Path.Combine(Application.StartupPath, "images", "emerson.png");
            displaypicturebox.Image = Image.FromFile(imagePath);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject CIV (104)";
            description.Text = "Not much is known about Subject 104. Their number is displayed on The Patriarch's helmet, indicating they were one of the subjects that The Patriarch killed.";
            string imagePath = Path.Combine(Application.StartupPath, "images", "unknown.png");
            displaypicturebox.Image = Image.FromFile(imagePath);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject CV (105)";
            description.Text = "Subject 105 was a combative unit capable of cloaking designed to break Subject 106 out of containment at site fourteen. They succeeded in their task and self-terminated in a freezer complex within the site.";
            string imagePath = Path.Combine(Application.StartupPath, "images", "CV.png");
            displaypicturebox.Image = Image.FromFile(imagePath);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject CVI (106)";
            description.Text = "Subject 106 was a combative unit capable of cloaking and superhuman reaction times that was designed with the express purpose to kill The Patriarch and Anton Lazar. After completing those two tasks, the Syndicate attempted to incinerate him, and detonating the TF-27 base.";
            string imagePath = Path.Combine(Application.StartupPath, "images", "CVI.png");
            displaypicturebox.Image = Image.FromFile(imagePath);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            namelbl.Text = "Subject CVII (107)";
            description.Text = "Subject 107 was the sucessor to 106 and was mass produced to be used as the Syndicate's main combative unit. It was capable of cloaking indefinitley, superhuman reaction times, and exceptional mobility. Unfortunatley, the only Subject 107 unit that was ever activated was killed by Subject 106 due to 106's superior combat experience.";
            string imagePath = Path.Combine(Application.StartupPath, "images", "CVII.png");
            displaypicturebox.Image = Image.FromFile(imagePath);
        }
    }
}
