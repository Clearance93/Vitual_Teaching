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

namespace Virtual_Assistance_Teaching
{
    public partial class Authorized_reg : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        public Authorized_reg()
        {
            InitializeComponent();
        }
        void populate()
        {
            string MySql = "Select * from PersonalTbl";
            SqlCommand cmd = new SqlCommand(MySql, con);
            SqlDataReader rdr;
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("VAT_L_Number_Id", typeof(int));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                cmbUserName.ValueMember = "VAT_L_Number_Id";
                cmbUserName.DataSource = dt;
                con.Close();
            }
            catch
            {

            }
        }

        string fetch;
        void FetchId()
        {
            con.Open();
            string query = "select * from PersonalTbl where VAT_L_Number_Id= " + cmbUserName.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                fetch = dr["ID_Number"].ToString();
                txtId_Number.Text = fetch;
            }
            con.Close();
        }

        string Take;
        void FetchName()
        {
            con.Open();
            string query = "Select * from PersonalTbl where VAT_L_Number_Id = " + cmbUserName.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Take = dr["First_Name"].ToString();
                txtName.Text = Take;
            }
            con.Close();
        }

        string binary;
        void fetchSurname()
        {
            con.Open();
            string query = "Select * from PersonalTbl where VAT_L_Number_Id = " + cmbUserName.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                binary = dr["Surname"].ToString();
                txtSurname.Text = binary;
            }
            con.Close();

        }
        private void Authorized_reg_Load(object sender, EventArgs e)
        {
            populate();
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            int Heoght = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cmbUserName.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtId_Number.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Some or all the fields are empty!");
            }
            else if(txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passowrd do not match!");
            }
            else if (txtName.Text != txtUsername.Text)
            {
                MessageBox.Show("Please use your name as your username!");
            }
            else
            { 
                con.Open();
                string query = "insert into AuthorizedTbl Values ('"+cmbUserName.SelectedValue.ToString()+"', '" + txtUsername.Text + "', '" + txtPassword.Text + "', '" + txtConfirmPassword.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("You are now authorized to access the authorized side Congratulations");
                con.Close();
            }
        }

        private void cmbUserName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FetchId();
            FetchName();
            fetchSurname();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
        }
    }
}
