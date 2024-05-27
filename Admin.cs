using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Склад_готовой_продукции
{
    public partial class Admin : Form
    {

        SQLiteCommand cmd = new SQLiteCommand();//команда
        private SQLiteConnection conn = new SQLiteConnection();//создаем соединение

        public delegate void LabelName(string nText);
        public event LabelName changeLabel;

        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Hide();
            form1.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Jurnal_otpuska_tovarov;";
            SQLiteConnection conn = new SQLiteConnection("Data Source = SGP.db;Verion=3");

            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Проверим кол-во выбранных строк
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Выберите одну строку!", "Ошибка");
                    return;
                }

                //Заполнил выделенную строку
                int index = dataGridView1.SelectedRows[0].Index;

                //Проверим данные в таблице
                if (dataGridView1.Rows[index].Cells[0].Value == null)
                {
                    MessageBox.Show("Не все данные введены!", "Внимание!");
                    return;
                }

                //Считываем данных
                string Id_товара = dataGridView1.Rows[index].Cells[0].Value.ToString();
                SQLiteConnection conn = new SQLiteConnection("Data Source = SGP.db;Verion=3");
                string querydelet = "DELETE FROM Jurnal_otpuska_tovarov WHERE Id_товара = " + Id_товара;//строка запроса
                //Создание соединения
                SQLiteCommand cmd = new SQLiteCommand(querydelet, conn);

                //Выполняем запрос к бд
                conn.Open();//открываем соединение
                cmd = new SQLiteCommand(querydelet, conn);//команда

                //Выполнение запроса
                if (cmd.ExecuteNonQuery() != 1)
                    MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
                else
                {
                    MessageBox.Show("Данные удалены!", "Внимание!");
                    //Удаляем данные из таблицы
                    dataGridView1.Rows.RemoveAt(index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления данных: " + ex.Message.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Закрываем соединение с БД
                conn.Close();
            }
        }
    }
}
