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
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("Data Source = localhost; Initial Catalog = projektmusic; User ID = root; Password =");
            try
            {
                if (maskedTextBox1.Text == maskedTextBox2.Text)
                {
                    string name = textBox1.Text;
                    string pass = maskedTextBox1.Text;
                    cnn.Open();
                    MessageBox.Show("Connection Open ! ");
                    string sql = "INSERT INTO users (name, pass) VALUES ("+ "'" + name +"'"+","+"'" +pass +"'"+")";
                    var cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("user succesfully added.");
                }
                else
                    MessageBox.Show("Passwords do not match!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                MessageBox.Show(ex.Message); //shows what error actually occurs
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
