using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HOSPITAL_MANAGEMENT
{
    public partial class User_Login : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=ANUJ\SQLEXPRESS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public User_Login()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            Admin_login form = new Admin_login();
            form.Show();
            this.Hide();
        }

        private void lblAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin_login Page = new Admin_login();
            Page.Show();
            this.Hide();
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Enter Username and Password to Proceed");
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from DoctorTbl where DoctorName='" + txtUsername.Text + "' and DoctorPassword='" + txtPassword.Text + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Medicine page = new Medicine();
                    page.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Username and Password");
                }
                Con.Close();
            }
        }
    }
}