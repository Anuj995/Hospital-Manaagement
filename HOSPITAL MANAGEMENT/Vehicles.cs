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
    public partial class Vehicles : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=ANUJ\SQLEXPRESS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Vehicles()
        {
            InitializeComponent();
        }
        void populate()
        {
            Con.Open();
            string query = " select * from VehiclesTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVVehicles.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtVehicleId.Text = "";
            txtDriverName.Text = "";
            txtDriverNumber.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DGVVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVehicleId.Text = DGVVehicles.SelectedRows[0].Cells[0].ToString();
            txtDriverName.Text = DGVVehicles.SelectedRows[0].Cells[1].ToString();
            txtDriverNumber.Text = DGVVehicles.SelectedRows[0].Cells[2].ToString();

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            if (txtVehicleId.Text == "" || txtDriverName.Text == "" || txtDriverNumber.Text == "")
                MessageBox.Show("Missing Information ! See carefully");
            else
            {
                Con.Open();
                string query = "insert into VehiclesTbl values(" + txtVehicleId.Text + " ,'" + txtDriverName.Text + "', '" + txtDriverNumber.Text + "' , '" + CbVehicleType.SelectedItem.ToString() + "' )";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vehicle Added Successfully");
                Con.Close();
                populate();
                Reset();
            }
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "update VehiclesTbl set DriverName ='" + txtDriverName.Text + "' , DriverNummber = '" +txtDriverNumber + "' ,  VehicleType = '" + CbVehicleType.SelectedItem.ToString() + "' where VehicleId = " + txtVehicleId+ "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Vehicle Updated Successfully !");
            Con.Close();
            populate();
            Reset();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtVehicleId.Text == "")
                MessageBox.Show("Enter the VehicleID");
            else
            {
                Con.Open();
                string query = "delete from VehiclesTbl where VehicleId = " + txtVehicleId.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("vehicle Deleted Successfully");
                Con.Close();
                populate();

            }
        }

        private void Vehicles_Load(object sender, EventArgs e)
        {
            populate();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Admin_login Obj = new Admin_login();
            Obj.Show();
            this.Hide();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            Transactions Obj = new Transactions();
            Obj.Show();
            this.Hide();
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            Machines Obj = new Machines();
            Obj.Show();
            this.Hide();
        }
    }
}
