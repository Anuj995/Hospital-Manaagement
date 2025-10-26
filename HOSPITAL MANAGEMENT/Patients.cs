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
    public partial class Patients : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=ANUJ\SQLEXPRESS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Patients()
        {
            InitializeComponent();
        }

        private void txtDisease_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            Doctors Obj = new Doctors();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Admin_login Obj = new Admin_login();
            Obj.Show();
            this.Hide();
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
        private void btnAd_Click(object sender, EventArgs e)
        {
            if (txtPatientId.Text == "" || txtPatientName.Text == "" || txtPatientAddress.Text == "" || txtPatientPhone.Text == "" || txtAge.Text == "" || txtDisease.Text == "")
                MessageBox.Show("Missing Information ! See carefully");
            else
            {
                Con.Open();
                string query = "insert into PatientsTbl values("+txtPatientId.Text+" ,'"+txtPatientName.Text+"', '"+txtPatientAddress.Text+"' , '"+txtPatientPhone.Text+"' , "+txtAge.Text+" , '"+CbGender.SelectedItem.ToString()+"' , '"+CbBloodGroup.SelectedItem.ToString()+"', '"+txtDisease.Text+"'  )";
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

        private void Patients_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnUpadat_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "update PatientsTbl set PatientName ='" + txtPatientName.Text + "' , PatientAddress = '" + txtPatientAddress + "' , PatientPhone = '" + txtPatientPhone.Text + "' , PatinetAge = " + txtAge.Text + ", PatientGender = '" + CbGender.SelectedItem.ToString() + "' ,PatientBG = '" + CbBloodGroup.SelectedItem.ToString() + "' ,PatientDisease = "+txtDisease.Text+" where PatientId = " + txtPatientId + "";
            SqlCommand cmd = new SqlCommand(query , Con);
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
                string query = "delete from PatientsTbl where PatientId = "+ txtPatientId.Text +"";
                SqlCommand cmd = new SqlCommand(query , Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("patient Deleted Successfully");
                Con.Close();
                populate();

            }
        }

        private void btnReloa_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void CbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

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
