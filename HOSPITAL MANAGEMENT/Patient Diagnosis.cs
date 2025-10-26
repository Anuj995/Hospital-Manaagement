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
    public partial class Patient_Diagnosis : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=ANUJ\SQLEXPRESS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Patient_Diagnosis()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtDiagnosisId.Text = "";
            txtPatientName.Text = "";
            txtSymptoms.Text = "";
            txtMedicine.Text = "";
        }

        void populate()
        {
            Con.Open();
            string query = "select * from DiagnosissTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVDiagnosis.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Patient_Diagnosis_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDiagnosisId.Text == "" || txtPatientName.Text == "" || txtSymptoms.Text == "" || txtDiagnosis.Text == "" || txtMedicine.Text == "")
                MessageBox.Show("Missing Information ! See Carefully");
            else
            {
                Con.Open();
                string query = "insert into DiagnosissTbl values(" + txtDiagnosisId.Text + ",'" + txtPatientName.Text + "','" + txtSymptoms.Text + "','" + txtDiagnosis.Text + "','" + txtMedicine.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Diagnosis Successfully Added");
                Con.Close();
                populate();
            }
        }

        private void DGVDiagnosis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDiagnosisId.Text = DGVDiagnosis.SelectedRows[0].Cells[0].Value.ToString();
            txtPatientName.Text = DGVDiagnosis.SelectedRows[0].Cells[1].Value.ToString();
            txtSymptoms.Text = DGVDiagnosis.SelectedRows[0].Cells[2].Value.ToString();
            txtDiagnosis.Text = DGVDiagnosis.SelectedRows[0].Cells[3].Value.ToString();
            txtMedicine.Text = DGVDiagnosis.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "update DiagnosissTbl set PatientName = '" + txtPatientName.Text + "',Symptoms = '" + txtSymptoms.Text + "',Diagnosis = '" + txtDiagnosis.Text + "',Medicines = '" + txtMedicine.Text + "' where DiagnosisId = " + txtDiagnosisId.Text + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Diagnosis Successfully Updated");
            Con.Close();
            populate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDiagnosisId.Text == "")
                MessageBox.Show("Enter the Diagnosis Id");
            else
            {
                Con.Open();
                string query = "delete from DiagnosissTbl where DiagnosisId=" + txtDiagnosisId.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Diagnosis Successfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            User_Login Obj = new User_Login();
            Obj.Show();
            this.Hide();
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            Medicine Obj = new Medicine();
            Obj.Show();
            this.Hide();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            Patient Obj = new Patient();
            Obj.Show();
            this.Hide();
        }
    }
}
