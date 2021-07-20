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
    public partial class Administrator : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        public Administrator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtAdministrator.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Enter Administration logins!");
            }
            /*else if(txtPassword.Text != "1!Administrator")
            {
                MessageBox.Show("Incorrect Password");
            }*/
            else
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select Count (*) from AdministratorTbl where UserName = '" + txtAdministrator.Text + "' and Password = '" + txtPassword.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows[0][0].ToString() == "1")
                {
                    Learners form = new Learners();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Administration form = new Administration();
            form.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }
    }
}
