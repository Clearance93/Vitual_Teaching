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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtL_Number.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Enter login Credentials");
            }
            else
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select Count(*) from Logintbl where Userid = '"+txtL_Number.Text+ "' and Password = '"+txtPassword.Text+"'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows[0][0].ToString() == "1")
                {
                    Dashboard form = new Dashboard();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password!");
                }
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Student_reg form = new Student_reg();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtL_Number.Text = "";
            txtPassword.Text = "";
        }
    }
}
