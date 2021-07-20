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
    public partial class Learners : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        public Learners()
        {
            InitializeComponent();
        }
        /*void populate()
        {
            con.Open();
            string query = "Select * from LearnerTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder build = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            LearnerDV.DataSource = ds.Tables[0];
            con.Close();
        }*/
        private void Learners_Load(object sender, EventArgs e)
        {
            //populate();
            WindowState = FormWindowState.Maximized;
            int heihgt = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
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
            int width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard back = new Dashboard();
            back.Show();
            this.Hide();
        }

       /* private void button2_Click(object sender, EventArgs e)
        {
            if(txtLearner_Id.Text == "")
            {
                MessageBox.Show("Learner cannot be deleted without learner VAT Id Number");
            }
            else
            {
                con.Open();
                string query = "Delete from LearnerTbl where LearnerTbl = " + txtLearner_Id.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Learner Successfully deleted!");
                con.Close();
            }
        }
       */
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Learner_s_Deletition form = new Learner_s_Deletition();
            form.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Learner_Info_Del form = new Learner_Info_Del();
            form.Show();
            this.Hide();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Learner_Educational_Del form = new Learner_Educational_Del();
            form.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Documents_Upload form = new Documents_Upload();
            form.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Subjects form = new Subjects();
            form.Show();
            this.Hide();
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            Subjects form = new Subjects();
            form.Show();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Assignment form = new Assignment();
            form.Show();
            this.Hide();
        }
    }
}
