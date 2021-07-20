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
    public partial class Student_reg : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        public Student_reg()
        {
            InitializeComponent();
            
        }
        
       /* void populate()
        {
           
            con.Open();
            string query = "Select * from PersonalTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder build = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            PersonalDV.DataSource = ds.Tables[0];
            con.Close();
        }*/
        private void Student_reg_Load(object sender, EventArgs e)
        {
            //populate();
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtFull_Name.Text == "" || txtSecond_Number.Text == "" || txtDate.Text == "" || txtID_Number.Text == "" || cmbGender.Text == "" || txtContact_Number.Text == "" || txtEmail_Address.Text == "" || txtStreet_Number.Text == "" || txtSection.Text == "" || txtSuburb.Text == "" || txtCode.Text == "")
            {
                MessageBox.Show("Fill the all the fields");
            }
            /*else if(cmbGender.Text != "Male" || cmbGender.Text != "Female")
            {
                MessageBox.Show("Please select your gender!");
            }*/
            else
            { 
                con.Open();
                string query = "insert into PersonalTbl values ('" + txtFull_Name.Text + "', '" + txtSecond_Number.Text + "', '" + txtDate.Text + "', '" + txtID_Number.Text + "', '" + cmbGender.SelectedItem.ToString() + "', '"+txtContact_Number.Text+"', '"+txtEmail_Address.Text+"', '"+txtStreet_Number.Text+"', '"+txtSection.Text+"', '"+txtSuburb.Text+"', '"+txtCode.Text+"')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Learner Successfully added to the database!");
                con.Close();
                //populate();

                Educational form = new Educational();
                form.Show();
                this.Hide();
            }
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
            int width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            if(txtVAT_Nu.Text == "")
            {
                MessageBox.Show("Enter Learner VAT Number!");
            }
            else 
            { 
                con.Open();
                string query = "Delete from PersonalTbl where VAT_L_Number_Id = "+txtVAT_Nu.Text+"";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Learner Successfully deleted!");
                con.Close();
            }
        }*/

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

       private void button3_Click(object sender, EventArgs e)
        {
           /* if(txtFull_Name.Text == "" || txtSecond_Number.Text == "" || txtDate.Text == "" || txtID_Number.Text == "" || cmbGender.Text == "" || txtContact_Number.Text == "" || txtEmail_Address.Text == "" || txtStreet_Number.Text == "" || txtSection.Text == "" || txtSuburb.Text == "" || txtCode.Text == "")
            {
                MessageBox.Show("Fill all the fields excluding VAT_L Number before you can proceed!");
            }
            else
            { 
                Educational form = new Educational();
                form.Show();
                this.Hide();
            }*/
        }
    }
}
