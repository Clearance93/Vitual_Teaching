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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        public Login()
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
                cmbUsername.ValueMember = "VAT_L_Number_Id";
                cmbUsername.DataSource = dt;
                con.Close();
            }
            catch
            {

            }
        }
        string Fetch;
        void FetchIdNumber()
        {
            con.Open();
            string fetch = "Select * from PersonalTbl where VAT_L_Number_Id = " + cmbUsername.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(fetch, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Fetch = dr["ID_Number"].ToString();
                txtId_Number.Text = Fetch;
            }
            con.Close();
        }
        string fetch;
        void FetchName()
        {
            con.Open();
            string take = "Select * from PersonalTbl where VAT_L_Number_Id = " + cmbUsername.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(take, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                fetch = dr["First_Name"].ToString();
                txtName.Text = fetch;
            }
            con.Close();
        }
        string take;
        void FetchSurname()
        {
            con.Open();
            string query = "Select * from PersonalTbl where VAT_L_Number_Id = " + cmbUsername.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                take = dr["Surname"].ToString();
                txtSurname.Text = take;
            }
            con.Close();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            populate();
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbUsername.Text == "" || txtPassword.Text == "" || txtConfrim_Password.Text == "")
            {
                MessageBox.Show("Enter all the fields");
            }
            else if (cmbUsername.Text == "")
            {
                MessageBox.Show("The Username field is empty!");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("The Password field is empty!");
            }
            else if (txtConfrim_Password.Text == "")
            {
                MessageBox.Show("Confirm Password field is empty!");
            }
            else if (txtPassword.Text != txtConfrim_Password.Text)
            {
                MessageBox.Show("The Password do not match!");
            }
            else
            {
                con.Open();
                string query = "insert into LoginTbl  values('" + cmbUsername.Text + "', '" + txtPassword.Text + "', '" + txtConfrim_Password.Text + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration was successful!");
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbUsername.Text = "";
            txtPassword.Text = "";
            txtConfrim_Password.Text = "";
            txtId_Number.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void cmbUsername_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FetchIdNumber();
            FetchSurname();
            FetchName();
        }

        /*private void pictureBox4_Click(object sender, EventArgs e)
        {
                    }

       private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }*/
    }
}
