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
using System.IO;

namespace Virtual_Assistance_Teaching
{
    public partial class Previous_Question_Paper : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        public Previous_Question_Paper()
        {
            InitializeComponent();
        }

        private void populate()
        {
            using (SqlConnection con = GetConnection())
            {

                string query = "select ID, FileName, Extension from Previous_Question_Paper";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                //var ds = new DataSet();
                da.Fill(dt);
                //DocumentsDV.DataSource = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    PreviousQuestionPaperDV.DataSource = dt;
                }
            }
        }

        private void Previous_Question_Paper_Load(object sender, EventArgs e)
        {
            populate();
            WindowState = FormWindowState.Maximized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            txtFilePath.Text = dlg.FileName;
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
            int widht = Screen.PrimaryScreen.Bounds.Width;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SaveFile(txtFilePath.Text);
            MessageBox.Show("Saved");
        }

        private void SaveFile(string filepath)
        {
            using (Stream stream = File.OpenRead(filepath))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                var fi = new FileInfo(filepath);
                string extn = fi.Extension;
                string name = fi.Name;

                string query = "Insert into Previous_Question_Paper (FileName, Data, Extension) values (@name, @Data, @extn)";

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@data", SqlDbType.VarBinary).Value = buffer;
                    cmd.Parameters.Add("@extn", SqlDbType.Char).Value = extn;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    //con.Close();
                }
            }
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=Clearance;Initial Catalog=Virtual_Assistance_Teaching;Integrated Security=True");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var selectedRow = PreviousQuestionPaperDV.SelectedRows;

            foreach (var row in selectedRow)
            {
                int id = (int)((DataGridViewRow)row).Cells[0].Value;
                OpenFile(id);
            }
        }

        private void OpenFile(int id)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "Select Data, FileName, Extension from Previous_Question_Paper where ID=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["FileName"].ToString();
                    var data = (byte[])reader["data"];
                    var extn = reader["Extension"].ToString();
                    var filename = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss") + extn);
                    File.WriteAllBytes(filename, data);
                    System.Diagnostics.Process.Start(filename);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           Authorized_reg form = new Authorized_reg();
            form.Show();
            this.Hide();
        }
    }
}
