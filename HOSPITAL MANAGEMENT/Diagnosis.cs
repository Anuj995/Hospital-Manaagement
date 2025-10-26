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
using System.Resources;
using System.Reflection.Emit;

namespace HOSPITAL_MANAGEMENT
{
    public partial class Diagnosis : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=ANUJ\SQLEXPRESS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Diagnosis()
        {
            InitializeComponent();
        }

        private void txtPatientId_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            txtDiagnosisId.Text = "";
            txtPatientName.Text = "";
            txtSymptoms.Text = "";
            txtMedicine.Text = "";
        }
        private void btnDoctors_Click(object sender, EventArgs e)
        {
            Doctors Obj = new Doctors();
            Obj.Show();
            this.Hide();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
           Patients Obj = new Patients();
            Obj.Show();
            this.Hide();
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            Medicines Obj = new Medicines();
            Obj.Show();
            this.Hide();
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("PATIENT REPORT ", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Black, new Point(230));
            e.Graphics.DrawString("ID: " + txtDiagnosisId.Text + "\n" + "Patient Name:" +txtPatientName.Text + "\n" + "Symptoms:" + txtSymptoms.Text + "\n" + "Diagnosis:" + txtDiagnosis.Text + "\n" + "Medicine:" + txtMedicine.Text, new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(130, 150));
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void DGVDiagnosis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             txtDiagnosisId.Text = DGVDiagnosis.SelectedRows[0].Cells[0].Value.ToString();
            txtPatientName.Text = DGVDiagnosis.SelectedRows[0].Cells[1].Value.ToString();
            txtSymptoms.Text = DGVDiagnosis.SelectedRows[0].Cells[2].Value.ToString();
            txtDiagnosis.Text = DGVDiagnosis.SelectedRows[0].Cells[3].Value.ToString();
            txtMedicine.Text = DGVDiagnosis.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblPrint_Click(object sender, EventArgs e)
        {

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

        private void Diagnosis_Load(object sender, EventArgs e)
        {
            
            populate();
        }

        private void CbPatientId_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            Machines Obj = new Machines();
            Obj.Show();
            this.Hide();
        }
    }
}

