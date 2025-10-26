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
    public partial class Medicine : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=ANUJ\SQLEXPRESS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Medicine()
        {
            InitializeComponent();
        }

        private void Medicine_Load(object sender, EventArgs e)
        {
            populate();
        }
        void populate()
        {
            Con.Open();
            string query = " select * from MedicineTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVMedicine.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtMedicineId.Text = "";
            txtMedicineName.Text = "";
            txtMedicineType.Text = "";
            txtByDoctor.Text = "";
        }
        private void DGVMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMedicineId.Text = DGVMedicine.SelectedRows[0].Cells[0].ToString();
            txtMedicineName.Text = DGVMedicine.SelectedRows[0].Cells[1].ToString();
            txtMedicineType.Text = DGVMedicine.SelectedRows[0].Cells[2].ToString();
            txtByDoctor.Text = DGVMedicine.SelectedRows[0].Cells[3].ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMedicineId.Text == "" || txtMedicineName.Text == "" || txtMedicineType.Text == "" || txtByDoctor.Text == "")
                MessageBox.Show("Missing Information ! Fill all Details carefully");
            else
            {
                Con.Open();
                string query = "Insert into MedicineTbl values(" + txtMedicineId.Text + " ,'" + txtMedicineName.Text + "','" + txtMedicineType.Text + "', '" + txtByDoctor.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Addeed Successfully");
                Con.Close();
                populate();
                Reset();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "update MedicineTbl set MedicineName = '" + txtMedicineName.Text + "',MedicineType = '" + txtMedicineType.Text + "',ByDoctor = '" + txtByDoctor.Text + "' where MedicineId =  " + txtMedicineId.Text + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Medicine Updates Successfully!");
            Con.Close();
            populate();
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtMedicineId.Text == "")
                MessageBox.Show("Enter the meedicine Id");
            else
            {
                Con.Open();
                string query = "delete from MedicineTbl where MedicineId=" + txtMedicineId.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Deleted Successfully!");
                Con.Close();
                populate();
                Reset();
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

        private void btnPatient_Click(object sender, EventArgs e)
        {
            Patient Obj = new Patient();
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