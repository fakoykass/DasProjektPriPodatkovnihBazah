using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Projektmusic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Text = label4.Text + Globals.nejm;

        }
        public DateTime zacetek;
        public DateTime konec;

        private void button1_Click(object sender, EventArgs e)
        {
            zacetek = DateTime.Now;
            string kakec = "";
            kakec = zacetek.ToString("HH:mm:ss");
            label1.Text = "Started at: ";
            button2.Enabled = true;
            button1.Enabled = false;
            label1.Text = label1.Text + " " + kakec;
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            konec = DateTime.Now;
            string datum = konec.ToString("dd-MM-yyyy");
            label5.Text = datum;
            string kakec = "";
            kakec = konec.ToString("HH:mm:ss");
            label2.Text = "Ended at: ";
            label2.Text = label2.Text + " " + kakec;
            TimeSpan kuzlica = konec - zacetek;
            label3.Text = kuzlica.ToString(@"hh\:mm\:ss");
            label3.Visible = true;
            button3.Visible = true;

            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Data Source = localhost; Initial Catalog = projektmusic; User ID = root; Password =");
            conn.Open();
            DateTime date = Convert.ToDateTime(label5.Text);
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO times(user_id,time,date) VALUES(@person, @time ,@date)";
            comm.Parameters.Add("@person", Globals.ajdi);
            comm.Parameters.Add("@time", label3.Text);
            comm.Parameters.Add("@date", date);
            comm.ExecuteNonQuery();
            MessageBox.Show("Successfully added!");
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            izpis bb = new izpis();
            bb.Show();
            this.Hide();
        }
    }
}
