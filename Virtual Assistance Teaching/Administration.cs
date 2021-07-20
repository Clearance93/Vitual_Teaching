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
    public partial class Administration : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        public Administration()
        {
            InitializeComponent();
        }

        private void Administration_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
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
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtLastname.Text = "";
            txtDOB.Text = "";
            txtIDNumber.Text = "";
            cmbGender.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtStreetName.Text = "";
            txtSection.Text = "";
            txtSuburb.Text = "";
            txtCode.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtLastname.Text == "" || txtDOB.Text == "" || txtIDNumber.Text == "" || cmbGender.Text == "" || txtContact.Text == "" || txtEmail.Text == "" || txtStreetName.Text == "" || txtSection.Text == "" || txtSuburb.Text == "" || txtCode.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Enter all the fields!");
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password does not match!");
            }
            else if (txtName.Text != txtUsername.Text)
            {
                MessageBox.Show("Please Use your Name as your user name!");
            }
            else
            {
                con.Open();
                string query = "insert into AdministratorTbl values('" + txtName.Text + "', '" + txtLastname.Text + "', '" + txtDOB.Text + "', '" + txtIDNumber.Text + "', '" + cmbGender.SelectedText.ToString() + "', '" + txtContact.Text + "', '" + txtEmail.Text + "', '" + txtStreetName.Text + "', '" + txtSection.Text + "', '" + txtSuburb.Text + "', '" + txtCode.Text + "', '" + txtUsername.Text + "', '" + txtPassword.Text + "', '" + txtConfirmPassword.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Administrator information was successfully added!");
                con.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Administrator form = new Administrator();
            form.Show();
            this.Hide();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Full Name/s")
                txtName.Text = null;
            txtName.ForeColor = Color.DarkBlue;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
                txtName.Text = "Full Name/s";
            txtName.ForeColor = Color.DarkGray;
        }

        private void txtName_Leave_1(object sender, EventArgs e)
        {
            if (txtName.Text == "")
                txtName.Text = "Full Name/s";
            txtName.ForeColor = Color.DarkGray;
        }

        private void txtName_Enter_1(object sender, EventArgs e)
        {
            if (txtName.Text == "Full Name/s")
                txtName.Text = null;
            txtName.ForeColor = Color.DarkBlue;
        }

        private void txtLastname_Enter(object sender, EventArgs e)
        {
            if (txtLastname.Text == "Last Name")
                txtLastname.Text = null;
            txtLastname.ForeColor = Color.DarkBlue;
        }

        private void txtLastname_Leave(object sender, EventArgs e)
        {
            if (txtLastname.Text == "")
                txtLastname.Text = "Last Name";
            txtLastname.ForeColor = Color.DarkGray;
        }
    }
}
