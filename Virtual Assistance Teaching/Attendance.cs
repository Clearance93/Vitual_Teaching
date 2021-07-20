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
    public partial class Attendance : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        public Attendance()
        {
            InitializeComponent();
        }
        void PopulateCombo()
        {
            string select = "Select * from PersonalTbl";
            SqlCommand cmd = new SqlCommand(select, con);
            SqlDataReader rdr;
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("VAT_L_Number_Id", typeof(int));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                cmblearner_Number.ValueMember = "VAT_L_Number_Id";
                cmblearner_Number.DataSource = dt;
                con.Close();
            }
            catch
            {

            }
        }
        string patname;
        void fatchDataPath()
        {
            con.Open();
            string fetch = "Select * from PersonalTbl where VAT_L_Number_Id = " + cmblearner_Number.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(fetch, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                patname = dr["First_Name"].ToString();
                txtName.Text = patname;
            }
            con.Close();
        }
        string potname;
        void FetchSurname()
        {
            con.Open();
            string fetch = "Select * from PersonalTbl where VAT_L_Number_Id = " + cmblearner_Number.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(fetch, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                potname = dr["Surname"].ToString();
                txtSurname.Text = potname;
            }
            con.Close();
        }
        string PitchName;
        void fetchGender()
        {
            con.Open();
            string fetch = "Select * from PersonalTbl where VAT_L_Number_Id = " + cmblearner_Number.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(fetch, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                PitchName = dr["ID_Number"].ToString();
                txtId_Number.Text = PitchName;
            }
            con.Close();
        }
        private void Attendance_Load(object sender, EventArgs e)
        {
            PopulateCombo();
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
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
            if(cmblearner_Number.Text == "")
            {
                MessageBox.Show("Enter Learner's Number");
            }
            else
            {
                con.Open();
                string query = "insert into AttendanceTbl values ('" + cmblearner_Number.SelectedText.ToString() + "', '" + txtName.Text + "', '" + txtSurname.Text + "', '" + txtId_Number.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("We Welcome you '" + txtName.Text + "'  '"+txtSurname.Text+"'to our class, have a nice virtual class. All the best!");
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmblearner_Number.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtId_Number.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }

        private void cmblearner_Number_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fatchDataPath();
            FetchSurname();
            fetchGender();
        }
    }
}
