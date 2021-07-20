using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virtual_Assistance_Teaching
{
    public partial class Assignment_For_Learners : Form
    {
        public Assignment_For_Learners()
        {
            InitializeComponent();
        }

        private void Assignment_For_Learners_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int widht = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int heght = Screen.PrimaryScreen.Bounds.Height;
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
            Learners form = new Learners();
            form.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           /* if(txtBox.Text == "The Chosen Assignement should indicate the date Time it was uploaded, subject and grade e.g 2021 / 01 / 01  at 12:00pm Mathematics Solve for x was issued as the first assignment for grade 12")
            {
                txtBox.Text = null;
       
            }*/
        }

        /*private void txtBox_Enter(object sender, EventArgs e)
        {
            if (txtBox.Text == "When ever the Assignement is handed out to the learners please indicate it here. The date given and the time for record sake. Thank you!")
                txtBox.Text = null;
            txtBox.ForeColor = Color.DarkBlue;
        }

        private void txtBox_Leave(object sender, EventArgs e)
        {
            if (txtBox.Text == "")
                txtBox.Text = "When ever the Assignement is handed out to the learners please indicate it here.The date given and the time for record sake. Thank you!";
            txtBox.ForeColor = Color.DarkGray;
        }
        */
        private void txtBox_Enter_1(object sender, EventArgs e)
        {
            if (txtBox.Text == "When ever the Assignement is handed out to the learners please indicate it here.The date given and the time for record sake. Thank you!")
                 txtBox.Text = null;
             txtBox.ForeColor = Color.DarkGray;
           // if (txtBox.Text == "Full Names")
              //  txtBox.Text = null;
            //txtBox.ForeColor = Color.DarkGray;
        }

        private void txtBox_Leave_1(object sender, EventArgs e)
        {
            if (txtBox.Text == "")
                txtBox.Text = "When ever the Assignement is handed out to the learners please indicate it here.The date given and the time for record sake. Thank you!";
            txtBox.ForeColor = Color.DarkGray;
           // if (txtBox.Text == "")
              //  txtBox.Text = "Full Names";
           // txtBox.ForeColor = Color.DarkGray;
        }
    }
}
