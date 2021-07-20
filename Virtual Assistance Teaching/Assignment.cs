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
    public partial class Assignment : Form
    {
        public Assignment()
        {
            InitializeComponent();
        }

        private void Assignment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'virtual_Assistance_TeachingDataSet.Previous_Question_Paper' table. You can move, or remove it, as needed.
            this.previous_Question_PaperTableAdapter.Fill(this.virtual_Assistance_TeachingDataSet.Previous_Question_Paper);
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Widht = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random Paper = new Random();
            int i = listBox1.Items.Count;
            int ChosenItem = Paper.Next(0, i);

           // MessageBox.Show("Assignement selected for this monnt is : " + listBox1.SelectedItem.ToString());

            listBox1.SelectedIndex = ChosenItem;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Learners form = new Learners();
            form.Show();
            this.Hide();
        }
    }
}
