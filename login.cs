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
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reg kakec = new reg();
                kakec.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int exist=0;
            MySqlConnection cnn = new MySqlConnection("Data Source = localhost; Initial Catalog = projektmusic; User ID = root; Password =");
            try
            {
                cnn.Open();
                /* MessageBox.Show("Connection Open ! ");
                 using (MySqlCommand cmd = new MySqlCommand("select count(*) from users where (name=@UserName AND pass=@pass)", cnn))
                 {
                     cmd.Parameters.AddWithValue("UserName", textBox1.Text);
                     cmd.Parameters.AddWithValue("pass", maskedTextBox1.Text);
                     var reader = cmd.ExecuteReader();
                     while (reader.Read())
                     {
                         exist = reader.GetInt32(0);
                     }
                 }*/
                using (MySqlCommand cmd = new MySqlCommand("select login(@UserName, @pass)", cnn))
                {
                    cmd.Parameters.AddWithValue("UserName", textBox1.Text);
                    cmd.Parameters.AddWithValue("pass", maskedTextBox1.Text);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        exist = reader.GetInt32(0);
                    }
                }
                cnn.Close();


                        if (exist>0)
                        {
                    cnn.Open();
                            using (MySqlCommand command = new MySqlCommand("select * from users where (name=@Name AND pass=@ss)", cnn))
                            {
                                command.Parameters.AddWithValue("Name", textBox1.Text);
                                command.Parameters.AddWithValue("ss", maskedTextBox1.Text);
                                var bralec = command.ExecuteReader();
                                while (bralec.Read())
                                {
                                    Globals.ajdi = (int)bralec["id"];
                                    Globals.nejm = (string)bralec["name"];
                                }
                                Form1 bb = new Form1();
                                bb.Show();
                                this.Hide();
                            }
                    cnn.Close();
                        }
                    
                        else
                        {
                            MessageBox.Show("Username or password invalid");
                        }
                    

                
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message); //shows what error actually occurs
            }
            finally
            {
                cnn.Close();
            }
        }
    }
    public static class Globals
    {
        public static String nejm;
        public static int ajdi;
    }
}
