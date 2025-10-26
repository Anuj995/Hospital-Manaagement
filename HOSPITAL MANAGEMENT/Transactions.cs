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
    public partial class Transactions : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=ANUJ\SQLEXPRESS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Transactions()
        {
            InitializeComponent();
        }
        void populate()
        {
            Con.Open();
            string query = " select * from TransactionsTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVTransactions.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtTransactionId.Text = "";
            txtTransactionDetail.Text = "";
            txtTotal.Text = "";
            txtInOut.Text = "";
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DGVTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTransactionId.Text = DGVTransactions.SelectedRows[0].Cells[0].ToString();
            txtTransactionDetail.Text = DGVTransactions.SelectedRows[0].Cells[1].ToString();
            txtTotal.Text = DGVTransactions.SelectedRows[0].Cells[2].ToString();
            txtInOut.Text = DGVTransactions.SelectedRows[0].Cells[3].ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTransactionId.Text == "" || txtTransactionDetail.Text == "" || txtTotal.Text == "" || txtInOut.Text == "")
                MessageBox.Show("Missing Information ! Fill all Details carefully");
            else
            {
                Con.Open();
                string query = "Insert into TransactionsTbl values(" + txtTransactionId.Text + " ,'" + txtTransactionDetail.Text + "','" + txtTotal.Text + "', '" + txtInOut.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Transaction Addeed Successfully");
                Con.Close();
                populate();
                Reset();

            }
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "update TransactionsTbl set TransactionDetail = '" + txtTransactionDetail.Text + "',Total = '" + txtTotal.Text + "',InOut= '" + txtInOut.Text + "' where TransactionId =  " + txtTransactionId.Text + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Transaction Updates Successfully!");
            Con.Close();
            populate();
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTransactionId.Text == "")
                MessageBox.Show("Enter the meedicine Id");
            else
            {
                Con.Open();
                string query = "delete from TransactionsTbl where TransactionId=" + txtTransactionId.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Transaction Deleted Successfully!");
                Con.Close();
                populate();
                Reset();
            }
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Admin_login Obj = new Admin_login();
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
