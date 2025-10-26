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
   
    public partial class Doctors : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=ANUJ\SQLEXPRESS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public Doctors()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Admin_login Obj = new Admin_login();
            Obj.Show();
            this.Hide();
        }

        private void bunifuMaterialTextbox4_OnValueChanged(object sender, EventArgs e)
        {

        }
        void populate()
        {
            Con.Open();
            string query = " select * from DoctorTbl";
            SqlDataAdapter da = new SqlDataAdapter(query , Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVDoctors.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtDoctorId.Text = "";
            txtDoctorName.Text = "";
            txtPassword.Text = "";
            txtYearsOfExperience.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDoctorId.Text == "" || txtDoctorName.Text == "" || txtYearsOfExperience.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Missing Information ! Fill all Details carefully");
            else
            {
                Con.Open();
                string query = "Insert into DoctorTbl values(" + txtDoctorId.Text + " ,'" + txtDoctorName.Text + "'," + txtYearsOfExperience.Text + ", '" + txtPassword.Text + "')";
                SqlCommand cmd = new SqlCommand(query,Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Addeed Successfully");
                Con.Close();
                populate();
                Reset();

            }
        }

        private void gunaDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDoctorId.Text = DGVDoctors.SelectedRows[0].Cells[0].ToString();
            txtDoctorName.Text = DGVDoctors.SelectedRows[0].Cells[1].ToString();
            txtYearsOfExperience.Text = DGVDoctors.SelectedRows[0].Cells[2].ToString();
            txtPassword.Text = DGVDoctors.SelectedRows[0].Cells[3].ToString();
           






        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            Patients Obj = new Patients();
            Obj.Show();
            this.Hide();
        }

        private void btndiagnosis_Click(object sender, EventArgs e)
        {
            Diagnosis Obj = new Diagnosis();
            Obj.Show();
            this.Hide();
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            Medicines Obj = new Medicines();
            Obj.Show();
            this.Hide();
        }

        private void Doctors_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "update DoctorTbl set DoctorName = '"+txtDoctorName.Text+"',DoctorExp = '"+txtYearsOfExperience.Text+"',DoctorPassword = '"+txtPassword.Text+"' where DoctorId = " +txtDoctorId.Text+"";
            SqlCommand cmd = new SqlCommand(query,Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Doctor Updates Successfully!");
            Con.Close();
            populate();
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDoctorId.Text == "")
                MessageBox.Show("Enter the doctor Id");
            else
            {
                Con.Open();
                string query = "delete from DoctorTbl where DoctorId=" + txtDoctorId.Text + "";
                SqlCommand cmd = new SqlCommand(query,Con); 
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Deleted Successfully!");
                Con.Close();
                populate();
                Reset();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            Vehicles Obj = new Vehicles();
            Obj.Show();
            this.Hide();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            Transactions Obj = new Transactions();
            Obj.Show();
            this.Hide();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            Machines Obj = new Machines();
            Obj.Show();
            this.Hide();
        }
    }
}
