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
    public partial class Educational : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        public Educational()
        {
            InitializeComponent();
        }
       /* void populate()
        {
            con.Open();
            string query = "Select * From EducationaTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            EducationalDV.DataSource = ds.Tables[0];
            con.Close();
        }*/
        private void Educational_Load(object sender, EventArgs e)
        {
           // populate();
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if(txtPreviousSchool.Text == "" || cmbHighest.Text == "")
            {
                MessageBox.Show("Enter Medentory fields");
            }
            else if(cmbHighest.Text == "Yes")
            {
                MessageBox.Show("Supply the reason why do you want to repeat from combobox below!");
            }
            else
            {
                con.Open();
                string query = "insert into EducationaTbl values ('" + txtPreviousSchool.Text + "', '" + cmbHighest.SelectedItem.ToString() + "', '" + cmbPassPrevious.SelectedItem.ToString() + "', '" + cmbMath.SelectedItem.ToString() + "', '" + cmbMath_Lit.SelectedItem.ToString() + "', '" + cmbPhysical_Science.SelectedItem.ToString() + "', '" + cmbLife_Science.SelectedItem.ToString() + "', '" + cmbAgricaltural_Science.SelectedItem.ToString() + "', '" +cmbGeography.SelectedItem.ToString()+ "', '" +cmbAccounting.SelectedItem.ToString()+ "', '" +cmbEconomics.SelectedItem.ToString() + "', '"+cmbBussiness_Study.SelectedItem.ToString()+"', '"+cmbCAT.SelectedItem.ToString()+"', '"+cmbLife_Oriantation.SelectedItem.ToString()+"', '"+cmbTuarism.SelectedItem.ToString()+"')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Edicational information was successful!");
                con.Close();
                // populate();

                Login form = new Login();
                form.Show();
                this.Hide();
            }

            /*Form1 form = new Form1();
            form.Show();
            this.Hide();*/
        }

        /*private void button5_Click(object sender, EventArgs e)
        {
            if(txtEdu_VAT.Text == "")
            {
                MessageBox.Show("Enter Educational VAT Number!");
            }
            else
            {
                con.Open();
                string query = "Delete from EducationaTbl where Education_VAT_Id = " + txtEdu_VAT.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Educational history Successfully deleted!");
                con.Close();
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
           /* Form1 form = new Form1();
            form.Show();
            this.Hide();*/
        }
    }
}
