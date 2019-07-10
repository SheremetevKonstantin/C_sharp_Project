using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Autorisation : Form
    {
        public Autorisation()
        {
            InitializeComponent();

            textBox2.UseSystemPasswordChar = true;
        }
        bool MeHere;

        public void Autorisation_Load(object sender, EventArgs e)
        {
            MeHere = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Выход
        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            { // Проверка на заполнение полей
                if (comboBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Заполните все поля!", "Предупреждение");
                }
                else
                {
                    string login = comboBox1.Text;
                    string password = textBox2.Text;
                    string HashPassword = GetHashString(password);

                    string con = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Cinema.mdb;";
                    OleDbConnection ODcon = new OleDbConnection(con);
                    ODcon.Open();
                    OleDbCommand sql = new OleDbCommand("Select * From Autorisation;", ODcon); // Выборка данный из таблицы авторизация
                    OleDbDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.GetValue(1).ToString() == comboBox1.Text && reader.GetValue(2).ToString() == HashPassword)
                        {
                            Cinema.Workspace.isAdmin(reader.GetValue(1).ToString());
                            MainForm mainform = new MainForm();
                            this.Visible = false;
                            mainform.Show();
                            MeHere = false;


                        }
                    }
                    if (MeHere == true) MessageBox.Show("Неверный пароль!"); textBox2.Clear();
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


        string GetHashString(string s)
        {
            string hash = "";
            try
            {
                //переводим строку в байт-массим  
                byte[] bytes = Encoding.Unicode.GetBytes(s);


                //создаем объект для получения средств шифрования  
                MD5CryptoServiceProvider CSP =
                    new MD5CryptoServiceProvider();

                //вычисляем хеш-представление в байтах  
                byte[] byteHash = CSP.ComputeHash(bytes);

                hash = string.Empty;

                //формируем одну цельную строку из массива  
                foreach (byte b in byteHash)
                    hash += string.Format("{0:x2}", b);
            }
            catch (System.ObjectDisposedException) {     MessageBox.Show("Ошибка. Объект был перепещен", "Error"); }
            catch (System.ArgumentNullException) {   MessageBox.Show("Ошибка аргумента!", "Error"); }
            catch (System.InvalidOperationException)  {    MessageBox.Show("Ошибка выполнения операции", "Error"); }
            catch(System.FormatException) {  MessageBox.Show("Ошибка формата", "Error"); }
                return hash;  
            


        }
        // Реализация функции показа пароля
        private void checkBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            textBox2.UseSystemPasswordChar = true;
        }
        private void checkBox1_MouseDown(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = true;
            textBox2.UseSystemPasswordChar = false;

        }




        
    }
}
