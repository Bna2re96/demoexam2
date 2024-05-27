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
using Склад_готовой_продукции;

namespace Демоэкзамен
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = SGP.db;Verion=3");
            conn.Open();
            string sqlQuery1 = $"INSERT INTO Zayavka (Data_add,Vid_orgtechic,Model,Info_problem,FIO,Number_phone,Status_zayavki) VALUES ('{DateTime.Now}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','Новая заявка')";
            SQLiteCommand cmd1 = new SQLiteCommand(sqlQuery1, conn);

            SQLiteCommand command1 = new SQLiteCommand(sqlQuery1, conn);
            SQLiteDataAdapter adapter1 = new SQLiteDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            conn.Close();

            label1.Visible = true;
        }

        private void User_Load(object sender, EventArgs e)
        {
           
        }
    }
}
