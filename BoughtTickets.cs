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
    public partial class BoughtTickets : Form
    {
        int ClientId, FilmId, TicketsId;

        public BoughtTickets()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            this.Visible = false;
            mainform.Show();
        }

        private void BoughtTickets_Load(object sender, EventArgs e)
        {
            UpdateClient();
            UpdateFilm();
            UpdateTickets();
            ClientdataGridView.Rows[0].Selected = false;
            // Проверка на наличие прав администратора
            if(Cinema.Workspace.IsAdmin == false)
            {
                FilmDel.Visible = false;
                TicketsDel.Visible = false;
                tabPage1.Parent = null;
                tabControl1.ItemSize = new Size(620, 29);
            }
        }
        // Возврат в главное меню
        private void ClientBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Visible = false;
            mainForm.Show();
        }

        private void FilmBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Visible = false;
            mainForm.Show();
        }

        private void TicketsBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Visible = false;
            mainForm.Show();
        }
        // Получение ID
        private void ClientdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ClientId = Convert.ToInt32(ClientdataGridView.SelectedCells[0].Value.ToString());
            }
            catch (System.FormatException) { }
            catch (System.OverflowException){   MessageBox.Show("Ошибка переполнения", "Error"); }
        }

        private void FilmdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FilmId = Convert.ToInt32(FilmdataGridView.SelectedCells[0].Value.ToString());
            }
            catch (System.FormatException) { }
            catch (System.OverflowException) {   MessageBox.Show("Ошибка переполнения", "Error"); }
        }

        private void TicketsdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TicketsId = Convert.ToInt32(TicketsdataGridView.SelectedCells[0].Value.ToString());
            }
            catch (System.FormatException) { }
            catch (System.OverflowException) {  MessageBox.Show("Ошибка переполнения", "Error");  }
        }

        private void ClientDel_Click(object sender, EventArgs e)
        {
            try // Удаление записи
            {
                if (ClientId == 0)
                {
                    MessageBox.Show("Пожалуйста выберите запись","Предупреждение");
                }
                else
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                        OleDbConnection ODcon = new OleDbConnection(con);
                        ODcon.Open();
                        OleDbCommand sql = new OleDbCommand("Delete * From Client Where Client_id = " + ClientId + ";", ODcon);
                        sql.ExecuteNonQuery();

                        MessageBox.Show("Запись была успешно удалена");
                        UpdateClient();
                    }
                }
            }
            catch (System.ComponentModel.InvalidEnumArgumentException)  {   MessageBox.Show("Ошибка Вывода информации", "Error");}
            catch (System.InvalidOperationException)  {    MessageBox.Show("Ошибка выполнения операции", "Error");  }
            catch (System.Data.OleDb.OleDbException) {    MessageBox.Show("Ошибка открытия Базы данных", "Error");  }
            catch (System.FormatException)  {    MessageBox.Show("Ошибка формата", "Error"); }
            catch (System.OverflowException) {  MessageBox.Show("Ошибка переполнения", "Error");  }
            catch (System.ArgumentOutOfRangeException)  {   MessageBox.Show("Ошибка выхода за пределы допустимых значений", "Error");}
            catch (System.IndexOutOfRangeException)  {    MessageBox.Show("Ошибка выхода индекса за пределы допустимых значений", "Error");  }
            catch (System.ArgumentNullException)  {   MessageBox.Show("Ошибка аргумента!");  }
        }

        public void UpdateClient() // Обновление таблицы Клиент
        {
            try
            {
                int Clientcount = 0;

                string con1 = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                OleDbConnection ODcon1 = new OleDbConnection(con1);
                DataTable DT1 = new DataTable();
                ODcon1.Open();
                OleDbCommand sql1 = new OleDbCommand("Select * From Client;", ODcon1);
                sql1.ExecuteNonQuery();
                OleDbDataAdapter ODA1 = new OleDbDataAdapter(sql1);

                OleDbCommand sqlcount = new OleDbCommand("Select COUNT(*) AS [Count] From Client", ODcon1);
                sqlcount.ExecuteNonQuery();
                OleDbDataReader readerCount = sqlcount.ExecuteReader();
                while (readerCount.Read()) Clientcount = Convert.ToInt32(readerCount["Count"]);

                ClientCount.Text = Convert.ToString(Clientcount);


                ODA1.Fill(DT1);
                // Переименование столбцов
                DT1.Columns["Client_number"].ColumnName = "Номер";
                DT1.Columns["Client_name"].ColumnName = "Имя";
                DT1.Columns["Client_surname"].ColumnName = "Фамилия";
                DT1.Columns["Client_age"].ColumnName = "Возраст";
                DT1.Columns["Client_phone"].ColumnName = "Телефон";

                ClientdataGridView.DataSource = DT1;
                ClientdataGridView.Columns[0].Visible = false;
                ODcon1.Close();
                try
                {
                    ClientdataGridView.Rows[0].Selected = false;
                }
                catch (System.Exception) { }
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

        public void UpdateFilm()// Обновление таблицы Сеанс
        {
            try
            {
                int Filmcount = 0;

                string con2 = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                OleDbConnection ODcon2 = new OleDbConnection(con2);
                DataTable DT2 = new DataTable();
                ODcon2.Open();
                OleDbCommand sql2 = new OleDbCommand("Select * From Film;", ODcon2);
                sql2.ExecuteNonQuery();
                OleDbDataAdapter ODA2 = new OleDbDataAdapter(sql2);

                OleDbCommand sqlcount = new OleDbCommand("Select COUNT(*) AS [Count] From Film", ODcon2); //Получение количества записей
                sqlcount.ExecuteNonQuery();
                OleDbDataReader readerCount = sqlcount.ExecuteReader();
                while (readerCount.Read()) Filmcount = Convert.ToInt32(readerCount["Count"]);

                FilmCount.Text = Convert.ToString(Filmcount);

                ODA2.Fill(DT2);
                // Переименование столбцов
                DT2.Columns["Film_number"].ColumnName = "Номер";
                DT2.Columns["Film_name"].ColumnName = "Название";
                DT2.Columns["Film_producer"].ColumnName = "Режисcер";
                DT2.Columns["Film_durationMin"].ColumnName = "Длительность";
                DT2.Columns["Film_year"].ColumnName = "Год";
                DT2.Columns["Film_cost"].ColumnName = "Стоимость(р)";

                FilmdataGridView.DataSource = DT2;
                FilmdataGridView.Columns[0].Visible = false;
                ODcon2.Close();
                try
                {
                    FilmdataGridView.Rows[0].Selected = false;
                }
                catch (System.Exception) { }

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

        public void UpdateTickets()// Обновление таблицы Билеты
        {
            try
            {
                var Ticketscount = 0;

                string con = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Cinema.mdb;";
                OleDbConnection ODcon = new OleDbConnection(con);
                DataTable DT = new DataTable();
                ODcon.Open();
                OleDbCommand sql = new OleDbCommand("Select Tickets_id AS [Номер билета],(Select Client_surname from Client Where Client.Client_id = Tickets.Client_id) AS [Имя], (Select Client_surname From Client Where Client.Client_id = Tickets.Client_id) As [Фамилия], (Select Film_name From Film Where Film.Film_id = Tickets.Film_id) AS [Название фильма], (Select Film_cost From Film Where Film.Film_id = Tickets.Film_id) AS [Стоимость(р)], Tickets_sessionDate AS [Дата сеанса], Tickets_sessionTime AS [Время сеанса], Tickets_row AS [Ряд], Tickets_place AS [Место] From Tickets", ODcon);
                OleDbDataAdapter ODA = new OleDbDataAdapter(sql);

                OleDbCommand sqlcount = new OleDbCommand("Select COUNT(*) AS [Count] From Tickets", ODcon);
                sqlcount.ExecuteNonQuery();
                OleDbDataReader readerCount = sqlcount.ExecuteReader();
                while (readerCount.Read()) Ticketscount = Convert.ToInt32(readerCount["Count"]);

                TicketsCount.Text = Convert.ToString(Ticketscount);

                ODA.Fill(DT);
                TicketsdataGridView.DataSource = DT;
                ODcon.Close();
                try
                {
                    TicketsdataGridView.Rows[0].Selected = false;
                }
                catch (System.Exception) { }
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

        private void FilmDel_Click(object sender, EventArgs e) // Удаление записи Сеанса
        {
            try
            {
                if (FilmId == 0)
                {
                    MessageBox.Show("Пожалуйста выберите запись", "Предупреждение");
                }
                else
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;";
                        OleDbConnection ODcon = new OleDbConnection(con);
                        ODcon.Open();
                        OleDbCommand sql = new OleDbCommand("Delete * From Film Where Film_id = " + FilmId + ";", ODcon);
                        sql.ExecuteNonQuery();

                        MessageBox.Show("Запись была успешно удалена");
                        UpdateFilm();
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

        private void TicketsDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (TicketsId == 0)
                {
                    MessageBox.Show("Пожалуйста выберите запись", "Предупреждение");
                }
                else
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string con = "Provider=Microsoft.Jet.OLEDB.4.0; Data source = Cinema.mdb;"; // строка подключения
                        OleDbConnection ODcon = new OleDbConnection(con); // подключение
                        ODcon.Open(); // открытие соединения
                        OleDbCommand sql = new OleDbCommand("Delete * From Tickets Where Tickets_id = " + TicketsId + ";", ODcon); // запрос
                        sql.ExecuteNonQuery(); //выполнение запроса

                        MessageBox.Show("Запись была успешно удалена"); // сообщение
                        UpdateTickets(); // обновление
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
        // отмена выделения первой строки таблицы
        private void tabControl1_Click(object sender, EventArgs e)
        {
            try
            {
                ClientdataGridView.Rows[0].Selected = false;
            }
            catch (System.Exception) { }
            try
            {
                FilmdataGridView.Rows[0].Selected = false;
            }
            catch (System.Exception) { }
            try
            {
                TicketsdataGridView.Rows[0].Selected = false;
            }
            catch (System.Exception) { }
        }
    }
}
