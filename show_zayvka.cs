using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Демоэкзамен
{
    public partial class show_zayvka : Form
    {
        public show_zayvka()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT Status_zayavki,Master_name FROM Zayavka WHERE Id_zayavki = @Id_zayavki";
            SQLiteConnection conn = new SQLiteConnection("Data Source = SGP.db;Verion=3");

            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id_zayavki", textBox1.Text);

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }
    }
}
