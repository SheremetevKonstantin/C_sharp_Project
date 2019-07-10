using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class ByeTicket : Form
    {
        public ByeTicket()
        {
            InitializeComponent();
        }

        private void ByeTicket_Load(object sender, EventArgs e)
        {
            try
            { // Заполнение Сombobox(ов)
                string con1 = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                OleDbConnection ODcon1 = new OleDbConnection(con1);
                ODcon1.Open();
                OleDbCommand sql1 = new OleDbCommand("Select Client_id AS [Clientid], Client_name As [Clientname], Client_surname AS [Clientsurname], Client_age AS [Clientage] From Client", ODcon1);
                sql1.ExecuteNonQuery();
                OleDbDataReader reader1 = sql1.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox1.Items.Add(reader1["Clientid"] + "-" + reader1["Clientname"] + "-" + reader1["Clientsurname"] + "-" + reader1["Clientage"]);
                }
                reader1.Close();
                ODcon1.Close();

                string con2 = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                OleDbConnection ODcon2 = new OleDbConnection(con2);
                ODcon2.Open();
                OleDbCommand sql2 = new OleDbCommand("Select Film_id AS [Filmid], Film_name As [Filmname], Film_producer AS [Filmproducer], Film_year AS [Filmyear] From Film", ODcon2);
                sql2.ExecuteNonQuery();
                OleDbDataReader reader2 = sql2.ExecuteReader();
                while (reader2.Read())
                {
                    comboBox2.Items.Add(reader2["Filmid"] + "-" + reader2["Filmname"] + "-" + reader2["Filmproducer"] + "-" + reader2["Filmyear"]);
                }
                reader2.Close();
                ODcon2.Close();


                dateTimePicker1.MinDate = DateTime.Now.Date;
            }
            catch (System.ComponentModel.InvalidEnumArgumentException) { MessageBox.Show("Ошибка Вывода информации", "Error"); }
            catch (System.InvalidOperationException) { MessageBox.Show("Ошибка выполнения операции", "Error"); }
            catch (System.Data.OleDb.OleDbException) { MessageBox.Show("Ошибка открытия Базы данных", "Error"); }
            catch (System.FormatException) { MessageBox.Show("Ошибка формата", "Error"); }
            catch (System.OverflowException) { MessageBox.Show("Ошибка переполнения", "Error"); }
            catch (System.ArgumentOutOfRangeException) { MessageBox.Show("Ошибка выхода за пределы допустимых значений", "Error"); }
            catch (System.IndexOutOfRangeException) { MessageBox.Show("Ошибка выхода индекса за пределы допустимых значений", "Error"); }
            catch (System.ArgumentNullException) { MessageBox.Show("Ошибка аргумента!"); }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Visible = false;
            mainForm.Show();
        }

        private void TicketAdd_Click(object sender, EventArgs e)
        {
          // Офоормление билета
            string Data = "";
            try
            {
                Data = DateTime.Now.Date.ToString();
            }
            catch (System.ArgumentOutOfRangeException) { MessageBox.Show("Ошибка выхода за пределы допустимых значений", "Error"); }
            string[] Date = Data.Split(' ');

            string SessionDate = dateTimePicker1.Text;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение");
            }
            else
            {
                try
                {
                        Random rnd = new Random();
                        int id = rnd.Next(1, 500000);

                        string[] ClientBox = comboBox1.Text.Split('-');
                        string[] FilmBox = comboBox2.Text.Split('-');


                        string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                        OleDbConnection ODcon = new OleDbConnection(con);
                        ODcon.Open();
                        OleDbCommand sql = new OleDbCommand("Insert Into Tickets Values (" + id + "," + Convert.ToInt32(ClientBox[0]) + "," + Convert.ToInt32(FilmBox[0]) + ",'" + Date[0] + "','" + comboBox3.Text + "'," + Convert.ToInt32(textBox1.Text) + "," + Convert.ToInt32(textBox2.Text) + ",'" + SessionDate + "');", ODcon);
                        sql.ExecuteNonQuery();

                        MessageBox.Show("Запись успешно добавлена");
                        textBox1.Clear();
                        textBox2.Clear();
                        comboBox1.SelectedIndex = -1;
                        comboBox2.SelectedIndex = -1;
                        comboBox3.SelectedIndex = -1;
                        dateTimePicker1.Text = DateTime.Now.Date.ToString();
                        ODcon.Close();
                }
                catch (System.ComponentModel.InvalidEnumArgumentException) { MessageBox.Show("Ошибка Вывода информации", "Error"); }
                catch (System.InvalidOperationException) { MessageBox.Show("Ошибка выполнения операции", "Error"); }
                catch (System.Data.OleDb.OleDbException) { MessageBox.Show("Ошибка открытия Базы данных", "Error"); }
                catch (System.FormatException) { MessageBox.Show("Ошибка формата", "Error"); }
                catch (System.OverflowException) { MessageBox.Show("Ошибка переполнения", "Error"); }
                catch (System.ArgumentOutOfRangeException) { MessageBox.Show("Ошибка выхода за пределы допустимых значений", "Error"); }
                catch (System.IndexOutOfRangeException) { MessageBox.Show("Ошибка выхода индекса за пределы допустимых значений", "Error"); }
                catch (System.ArgumentNullException) { MessageBox.Show("Ошибка аргумента!"); }

            }
        }
        // Проверка на коректный ввод
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
