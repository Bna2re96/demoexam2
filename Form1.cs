using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SQLite;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Склад_готовой_продукции
{
    public partial class Form1 : Form
    {
        private string placeholder = "Email или телефон";
        public Form1()
        {
            InitializeComponent();
            textBoxPassword.UseSystemPasswordChar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            textBoxPassword.UseSystemPasswordChar = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBoxLogin.Text.Trim() == "" || textBoxPassword.Text.Trim() == "")
            {
                label3.Visible = true;
                /*MessageBox.Show("Введите логин и пароль!", "Предупреждение");*/
            }
            else 
            {
                string query = "SELECT * FROM Account WHERE Login = @Login AND Password = @Password";
                SQLiteConnection conn = new SQLiteConnection("Data Source = SGP.db;Verion=3");

                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Login",textBoxLogin.Text);
                cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);

                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;

                conn.Close();


                DataGridViewCell cell = dataGridView1.Rows[0].Cells[4];
                if (Convert.ToString(cell.Value)== "Менеджер склада")
                {
                    
                    Admin admin = new Admin();
                    admin.Show();
                    Hide();
                }
                else if (Convert.ToString(cell.Value) == "Отдел приема")
                {
                    
                }
                if (Convert.ToString(cell.Value) == "Отдел учета")
                {

                    Admin admin = new Admin();
                    admin.Show();
                    Hide();
                }
                else if (Convert.ToString(cell.Value) == "Оформление заказов")
                {
                    
                }
                else
                {
                    label3.Visible = true;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }
        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
            if (textBoxPassword.Text!="")
            {
                checkBox1.Visible = true;
            }
            else
            {
                checkBox1.Visible=false;
            }
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            label3.Visible=false;
        }
    }
}
