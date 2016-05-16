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
    public partial class izpis : Form
    {
        public izpis()
        {
            InitializeComponent();
        }

        private void izpis_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            MySqlConnection con;
            con = new MySqlConnection(@"Data Source = localhost; Initial Catalog = projektmusic; User ID = root; Password =;Convert Zero Datetime=True");
            /*DataGridViewImageColumn img = new DataGridViewImageColumn();
            img = (DataGridViewImageColumn)dataGridView1.Columns[5];
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;*/
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 120;
            dataGridView1.AllowUserToAddRows = false;
            DataTable table = new DataTable();
            try
            {

                con.Open();
                string sql = "SELECT name, date, time FROM times t INNER JOIN users u ON u.id=t.user_id WHERE (u.id=@Value) ORDER BY date DESC;";

                MySqlCommand command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@Value", Globals.ajdi);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                /* dataAdapter.Fill(table);
                 bindingSource1.DataSource = table;
                 dataGridView1.ReadOnly = true;
                 dataGridView1.DataSource = bindingSource1;*/
                
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;



            }
            catch (InvalidCastException y)
            {

            }


        }
    }
}
