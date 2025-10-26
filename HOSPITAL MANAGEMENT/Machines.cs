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
    public partial class Machines : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=ANUJ\SQLEXPRESS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Machines()
        {
            InitializeComponent();
        }
        void populate()
        {
            Con.Open();
            string query = " select * from DefectsTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVMachines.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
           txtDefectId.Text = "";
            txtDefectMachine.Text = "";
            txtDefect.Text = "";
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDefectId.Text == "" || txtDefectMachine.Text == "" || txtDefect.Text =="")
                MessageBox.Show("Missing Information ! Fill all Details carefully");
            else
            {
                Con.Open();
                string query = "Insert into DefectsTbl values(" + txtDefectId.Text + " ,'" + txtDefectMachine.Text + "','" + txtDefect.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Defect Addeed Successfully");
                Con.Close();
                populate();
                Reset();

            }
        }

        private void DGVMachines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtDefectId.Text = DGVMachines.SelectedRows[0].Cells[0].ToString();
            txtDefectMachine.Text = DGVMachines.SelectedRows[0].Cells[1].ToString();
            txtDefect.Text = DGVMachines.SelectedRows[0].Cells[2].ToString();
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "update DefectsTbl set DefectMachine = '" + txtDefectMachine.Text + "',Defect = '" + txtDefect.Text + "' where DefectId =  " + txtDefectId.Text + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Defect Updates Successfully!");
            Con.Close();
            populate();
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDefectId.Text == "")
                MessageBox.Show("Enter the Defect Id");
            else
            {
                Con.Open();
                string query = "delete from DefectsTbl where DefectId=" + txtDefectId.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Defect Deleted Successfully!");
                Con.Close();
                populate();
                Reset();
            }
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

        private void Machines_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Admin_login Obj = new Admin_login();
            Obj.Show();
            this.Hide();


        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
