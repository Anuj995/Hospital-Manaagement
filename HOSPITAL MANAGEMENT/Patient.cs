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
    public partial class Patient : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=ANUJ\SQLEXPRESS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Patient()
        {
            InitializeComponent();
        }
        void populate()
        {
            Con.Open();
            string query = " select * from PatientsTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVPatients.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtPatientId.Text = "";
            txtPatientName.Text = "";
            txtPatientAddress.Text = "";
            txtPatientPhone.Text = "";
            txtAge.Text = "";
            txtDisease.Text = "";
        }
        private void Patient_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnAd_Click(object sender, EventArgs e)
        {
            if (txtPatientId.Text == "" || txtPatientName.Text == "" || txtPatientAddress.Text == "" || txtPatientPhone.Text == "" || txtAge.Text == "" || txtDisease.Text == "")
                MessageBox.Show("Missing Information ! See carefully");
            else
            {
                Con.Open();
                string query = "insert into PatientsTbl values(" + txtPatientId.Text + " ,'" + txtPatientName.Text + "', '" + txtPatientAddress.Text + "' , '" + txtPatientPhone.Text + "' , " + txtAge.Text + " , '" + CbGender.SelectedItem.ToString() + "' , '" + CbBloodGroup.SelectedItem.ToString() + "', '" + txtDisease.Text + "'  )";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Added Successfully");
                Con.Close();
                populate();
                Reset();
            }
        }

        private void DGVPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPatientId.Text = DGVPatients.SelectedRows[0].Cells[0].ToString();
            txtPatientName.Text = DGVPatients.SelectedRows[0].Cells[1].ToString();
            txtPatientAddress.Text = DGVPatients.SelectedRows[0].Cells[2].ToString();
            txtPatientPhone.Text = DGVPatients.SelectedRows[0].Cells[3].ToString();
            txtAge.Text = DGVPatients.SelectedRows[0].Cells[4].ToString();
            txtDisease.Text = DGVPatients.SelectedRows[0].Cells[7].ToString();
        }

        private void btnUpadat_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "update PatientsTbl set PatientName ='" + txtPatientName.Text + "' , PatientAddress = '" + txtPatientAddress + "' , PatientPhone = '" + txtPatientPhone.Text + "' , PatinetAge = " + txtAge.Text + ", PatientGender = '" + CbGender.SelectedItem.ToString() + "' ,PatientBG = '" + CbBloodGroup.SelectedItem.ToString() + "' ,PatientDisease = " + txtDisease.Text + " where PatientId = " + txtPatientId + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Patient Updated Successfully !");
            Con.Close();
            populate();
            Reset();
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            if (txtPatientId.Text == "")
                MessageBox.Show("Enter the PatiendID");
            else
            {
                Con.Open();
                string query = "delete from PatientsTbl where PatientId = " + txtPatientId.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("patient Deleted Successfully");
                Con.Close();
                populate();

            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            User_Login Obj = new User_Login();
            Obj.Show();
            this.Hide();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            Medicine Obj = new Medicine();
            Obj.Show();
            this.Hide();
        }

        private void btndiagnosis_Click(object sender, EventArgs e)
        {
            Patient_Diagnosis Obj = new Patient_Diagnosis();
            Obj.Show();
            this.Hide();
        }
    }
}
