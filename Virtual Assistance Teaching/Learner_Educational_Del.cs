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
    public partial class Learner_Educational_Del : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        public Learner_Educational_Del()
        {
            InitializeComponent();
        }
        void populate()
        {
            con.Open();
            string query = "Select * from EducationaTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            EducationDV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void Learner_Educational_Del_Load(object sender, EventArgs e)
        {
            populate();
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int WIdth = Screen.PrimaryScreen.Bounds.Width;
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
            int Height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            int Height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtEdu_VAT_Nu.Text == "")
            {
                MessageBox.Show("Enter Educational VAT number!");
            }
            else
            {
                con.Open();
                string del = "Delete from EducationaTbl where Education_VAT_Id = " + txtEdu_VAT_Nu.Text + "";
                SqlCommand cmd = new SqlCommand(del, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Educationn information was successfully deleted!");
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Learners form = new Learners();
            form.Show();
            this.Hide();
        }
    }
}
