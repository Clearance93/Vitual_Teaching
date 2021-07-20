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
    public partial class Videos : Form
    {
        public Videos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtUpload.Text = openFile.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            axWindowsMediaPlayer1.URL = txtUpload.Text;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Subjects form = new Subjects();
            form.Show();
            this.Hide();
        }
        int duration = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            duration++;
            txttimer.Text = duration.ToString();
        }
    }
}
