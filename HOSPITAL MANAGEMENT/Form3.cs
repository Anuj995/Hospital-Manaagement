using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOSPITAL_MANAGEMENT
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            ProgressBar1.Value = startpoint;
            if(ProgressBar1.Value == 100)
            {
                ProgressBar1.Value = 0;
                Timer1.Stop();  
               User_Login Page = new User_Login();
                Page.Show();
                this.Hide();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Timer1.Start();
        }
    }
}
