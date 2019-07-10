using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        public void AddForm_Load(object sender, EventArgs e)
        {
            //Инициализация формы
            UpdateClient();
            UpdateFilm();
            ClientdataGridView.Rows[0].Selected = false; // Отмена выделения первой строки
      
        }
        public  void UpdateClient() // Обновление таблицы Клиент
        {
            try
            {
                int Clientcount = 0;
                // Подключение к БД
                string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                OleDbConnection ODcon = new OleDbConnection(con);
                DataTable DT = new DataTable();
                ODcon.Open();
                OleDbCommand sql = new OleDbCommand("Select * From Client;", ODcon); // Получение всего из таблицы Клиент
                sql.ExecuteNonQuery();
                OleDbDataAdapter ODA = new OleDbDataAdapter(sql);

                OleDbCommand sqlcount = new OleDbCommand("Select COUNT(*) AS [Count] From Client", ODcon); // Получение количества записей
                sqlcount.ExecuteNonQuery();
                OleDbDataReader readerCount = sqlcount.ExecuteReader();
                while (readerCount.Read()) Clientcount = Convert.ToInt32(readerCount["Count"]);

                ClientCount.Text = Convert.ToString(Clientcount);

                ODA.Fill(DT);
                // Переименовывание заголовков
                DT.Columns["Client_number"].ColumnName = "Номер";
                DT.Columns["Client_name"].ColumnName = "Имя";
                DT.Columns["Client_surname"].ColumnName = "Фамилия";
                DT.Columns["Client_age"].ColumnName = "Возраст";
                DT.Columns["Client_phone"].ColumnName = "Телефон";

                ClientdataGridView.DataSource = DT;
                ClientdataGridView.Columns[0].Visible = false;
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
        public void UpdateFilm() // Обновление таблицы Сеансы
        {
            try
            {
                int Filmcount = 0;

                string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                OleDbConnection ODcon = new OleDbConnection(con);
                DataTable DT = new DataTable();
                ODcon.Open();
                OleDbCommand sql = new OleDbCommand("Select * From Film;", ODcon); // Получение всего из таблицы
                sql.ExecuteNonQuery();
                OleDbDataAdapter ODA = new OleDbDataAdapter(sql);

                OleDbCommand sqlcount = new OleDbCommand("Select COUNT(*) AS [Count] From Film", ODcon); // Получение количества записей
                sqlcount.ExecuteNonQuery();
                OleDbDataReader readerCount = sqlcount.ExecuteReader();
                while (readerCount.Read()) Filmcount = Convert.ToInt32(readerCount["Count"]);

                FilmCount.Text = Convert.ToString(Filmcount);


                ODA.Fill(DT);
                // Переименовывание заголовков
                DT.Columns["Film_number"].ColumnName = "Номер";
                DT.Columns["Film_name"].ColumnName = "Название";
                DT.Columns["Film_producer"].ColumnName = "Режисcер";
                DT.Columns["Film_durationMin"].ColumnName = "Длительность";
                DT.Columns["Film_year"].ColumnName = "Год";
                DT.Columns["Film_cost"].ColumnName = "Стоимость(р)";

                FilmdataGridView.DataSource = DT;
                FilmdataGridView.Columns[0].Visible = false;
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
        private void ClientAdd_Click(object sender, EventArgs e)
        {
            try
            { // Проверка на совпадение 
                OleDbConnection ODconNumber = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;");
                ODconNumber.Open();
                OleDbCommand sqlNumber = new OleDbCommand("Select Client_number From Client", ODconNumber);
                sqlNumber.ExecuteNonQuery();
                OleDbDataReader readerNumber = sqlNumber.ExecuteReader();
                while (readerNumber.Read())
                {
                    if (readerNumber.GetValue(0).ToString() == textBox1.Text)
                    {
                        MessageBox.Show("Номера клиентов совпадают!");
                        textBox1.Clear();
                        break;
                    }
                }

                if (textBox1.Text == "" || textBox1.Text == "" || textBox1.Text == "" || textBox1.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("Заполните все поля!", "Предупреждение");
                }
                else if (Convert.ToInt32(textBox4.Text) > 130)
                {
                    MessageBox.Show("К сожалению люди столько не живут!", "Сообщение");
                }
                else
                {
                    Random rnd = new Random();
                    int id = rnd.Next(1, 5000000);
                    // Заполнение данными из полей
                    string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                    OleDbConnection ODcon = new OleDbConnection(con);
                    DataTable DT = new DataTable();
                    ODcon.Open();
                    OleDbCommand sql = new OleDbCommand("Insert Into Client Values (" + id + ", " + Convert.ToInt32(textBox1.Text) + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "');", ODcon);
                    sql.ExecuteNonQuery();

                    MessageBox.Show("Запись успешно добавлена");
                    UpdateClient();
                    // Очистка полей
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
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
            MainForm mainform = new MainForm();
            this.Visible = false;
            mainform.Show();
        }

        private void FilmAdd_Click(object sender, EventArgs e)
        {
            try
            { // Проверка на совпадения номеров фильмов
                OleDbConnection ODconNumber = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;");
                ODconNumber.Open();
                OleDbCommand sqlNumber = new OleDbCommand("Select Film_number From Film", ODconNumber);
                sqlNumber.ExecuteNonQuery();
                OleDbDataReader readerNumber = sqlNumber.ExecuteReader();
                while (readerNumber.Read())
                {
                    if (readerNumber.GetValue(0).ToString() == textBox6.Text)
                    {
                        MessageBox.Show("Номера клиентов совпадают!");
                        textBox6.Clear();
                        break;
                    }
                }
                // проверка на совпадение названий фильмов
                OleDbConnection ODconName = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;");
                ODconName.Open();
                OleDbCommand sqlName = new OleDbCommand("Select Film_name From Film", ODconName);
                sqlName.ExecuteNonQuery();
                OleDbDataReader readerName = sqlName.ExecuteReader();
                while (readerName.Read())
                {
                    if (readerName.GetValue(0).ToString() == textBox7.Text)
                    {
                        MessageBox.Show("Названия фильмов совпадают!");
                        textBox7.Clear();
                        break;
                    }
                }


                if (textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox10.Text == "" || textBox11.Text == "")
                {
                    MessageBox.Show("Заполните все поля!", "Предупреждение");
                }
                else
                {
                    Random rnd = new Random();
                    int id = rnd.Next(1, 5000000);

                    try
                    { // Заполнение данными из полей
                            string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                            OleDbConnection ODcon = new OleDbConnection(con);
                            DataTable DT = new DataTable();
                            ODcon.Open();
                            OleDbCommand sql = new OleDbCommand("Insert into Film Values (" + id + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "'," + Convert.ToInt32(textBox10.Text) + "," + Convert.ToInt32(textBox11.Text) + ");", ODcon);
                            sql.ExecuteNonQuery();

                            MessageBox.Show("Запись успешно добавлена");
                            UpdateFilm();
                        // очистка полей
                            textBox6.Clear();
                            textBox7.Clear();
                            textBox8.Clear();
                            textBox9.Clear();
                            textBox10.Clear();
                            textBox11.Clear();
                    }
                    catch (System.FormatException){
                        MessageBox.Show("Не коректное значение времени!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox9.Clear(); }
                }
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

        // Проверки на коректный ввод
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            FilmdataGridView.Rows[0].Selected = false;
            ClientdataGridView.Rows[0].Selected = false;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        // Очистки полей по кнопке
        private void label7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            MessageBox.Show("Поля очищены", "Сообщение");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            MessageBox.Show("Поля очищены", "Сообщение");
        }
        // Проверки на коректный ввод
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8 )
            {
                e.Handled = true;
            }
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
