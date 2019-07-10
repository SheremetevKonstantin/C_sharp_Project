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

    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        int ClientId, FilmId;

        private void EditForm_Load(object sender, EventArgs e)
        {
            UpdateClient();
            UpdateFilm();
            ClientdataGridView.Rows[0].Selected = false; // 
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            this.Visible = false;
            mainform.Show();
        }

        public void UpdateClient()
        {
            try
            {
                string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                OleDbConnection ODcon = new OleDbConnection(con);
                DataTable DT = new DataTable();
                ODcon.Open();
                OleDbCommand sql = new OleDbCommand("Select * From Client;", ODcon);// Получение всего из таблицы
                sql.ExecuteNonQuery();
                OleDbDataAdapter ODA = new OleDbDataAdapter(sql);

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
        public void UpdateFilm()
        {
            try
            {
                string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                OleDbConnection ODcon = new OleDbConnection(con);
                DataTable DT = new DataTable();
                ODcon.Open();
                OleDbCommand sql = new OleDbCommand("Select * From Film;", ODcon);// Получение всего из таблицы
                sql.ExecuteNonQuery();
                OleDbDataAdapter ODA = new OleDbDataAdapter(sql);

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
        private void FilmEdit_Click(object sender, EventArgs e)
        {
            if(textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox10.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение");                
            }
            else
            {
                try
                { // Редактирование записи в таблице Сеансов
                        string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                        OleDbConnection ODcon = new OleDbConnection(con);
                        DataTable DT = new DataTable();
                        ODcon.Open();
                        OleDbCommand sql = new OleDbCommand("Update Film Set Film_number = " + Convert.ToInt32(textBox6.Text) + ", Film_name = '" + textBox7.Text + "', Film_producer = '" + textBox8.Text + "', Film_durationMin = '" + textBox9.Text + "', Film_year =" + Convert.ToInt32(textBox10.Text) + ", Film_cost = " + Convert.ToInt32(textBox11.Text) + " Where Film_id = " + FilmId + ";", ODcon);
                        sql.ExecuteNonQuery();

                        MessageBox.Show("Запись была успешно редактирована");
                        UpdateFilm();
                    // Очистка полей
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                        textBox9.Clear();
                        textBox10.Clear();
                        textBox11.Clear();
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
        private void Client_Edit_Click(object sender, EventArgs e)
        {
            try
            {// Проверка на пустые значения
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Заполните все поля!", "Предупреждение");
                }
                else if (Convert.ToInt32(textBox4.Text) > 130)
                {
                    MessageBox.Show("К сожалению люди столько не живут!", "Сообщение");
                }
                else
                {// Редактирование записей в таблице Клиент
                    string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                    OleDbConnection ODcon = new OleDbConnection(con);
                    DataTable DT = new DataTable();
                    ODcon.Open();
                    OleDbCommand sql = new OleDbCommand("Update Client Set Client_number =" + Convert.ToInt32(textBox1.Text) + ", Client_name ='" + textBox2.Text + "', Client_surname ='" + textBox3.Text + "', Client_age ='" + textBox4.Text + "', Client_phone ='" + textBox5.Text + "' Where Client_id = " + ClientId + ";", ODcon);
                    sql.ExecuteNonQuery();

                    MessageBox.Show("Запись успешно была редактирована");
                    UpdateClient();
                    // очистка полей
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
        private void ClientDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientId == 0)
                {
                    MessageBox.Show("Пожалуйста выберите запись", "Предупреждение");
                }
                else
                {// Удаление записи
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                        OleDbConnection ODcon = new OleDbConnection(con);
                        DataTable DT = new DataTable();
                        ODcon.Open();
                        OleDbCommand sql = new OleDbCommand("Delete * From Client Where Client_id = " + ClientId + ";", ODcon);
                        sql.ExecuteNonQuery();

                        MessageBox.Show("Запись была успешно удалена");
                        UpdateClient();
                        // Очистка полей
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                    }
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

        private void FilmDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (FilmId == 0)
                {
                    MessageBox.Show("Пожалуйста выберите запись", "Предупреждение");
                }
                else
                {// Удаление записи
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                        OleDbConnection ODcon = new OleDbConnection(con);
                        DataTable DT = new DataTable();
                        ODcon.Open();
                        OleDbCommand sql = new OleDbCommand("Delete * From Film Where Film_id = " + FilmId + ";", ODcon);
                        sql.ExecuteNonQuery();

                        MessageBox.Show("Запись была успешно удалена");
                        UpdateFilm();
                        // Очистка полей
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                        textBox9.Clear();
                        textBox10.Clear();
                        textBox11.Clear();
                    }
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

        private void ClientdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Заполнение полей
                ClientId = Convert.ToInt32(ClientdataGridView.SelectedCells[0].Value.ToString());
                textBox1.Text = ClientdataGridView.SelectedCells[1].Value.ToString();
                textBox2.Text = ClientdataGridView.SelectedCells[2].Value.ToString();
                textBox3.Text = ClientdataGridView.SelectedCells[3].Value.ToString();
                textBox4.Text = ClientdataGridView.SelectedCells[4].Value.ToString();
                textBox5.Text = ClientdataGridView.SelectedCells[5].Value.ToString();
            }
            catch (System.FormatException) { MessageBox.Show("Ошибка формата", "Error"); }
            catch (System.OverflowException) { MessageBox.Show("Ошибка переполнения", "Error"); }
        }

        private void FilmdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Заполнение полей
                FilmId = Convert.ToInt32(FilmdataGridView.SelectedCells[0].Value.ToString());
                textBox6.Text = FilmdataGridView.SelectedCells[1].Value.ToString();
                textBox7.Text = FilmdataGridView.SelectedCells[2].Value.ToString();
                textBox8.Text = FilmdataGridView.SelectedCells[3].Value.ToString();
                textBox9.Text = FilmdataGridView.SelectedCells[4].Value.ToString();
                textBox10.Text = FilmdataGridView.SelectedCells[5].Value.ToString();
                textBox11.Text = FilmdataGridView.SelectedCells[6].Value.ToString();
            }
            catch (System.FormatException) { MessageBox.Show("Ошибка формата", "Error"); }
            catch (System.OverflowException) { MessageBox.Show("Ошибка переполнения", "Error"); }
        }
        // Проверка на коректный ввод
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
            if (Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
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
            ClientdataGridView.Rows[0].Selected = false;
            FilmdataGridView.Rows[0].Selected = false;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }


    }
}
