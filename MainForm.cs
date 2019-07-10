using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {// Открытие формы добавления
            AddForm addform = new AddForm();
            this.Visible = false;
            addform.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        { // Открытие формы редактирования
            EditForm editForm = new EditForm();
            this.Visible = false;
            editForm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        { // Открытие формы оформления билета
            ByeTicket byeTicket = new ByeTicket();
            this.Visible = false;
            byeTicket.Show();
        }
        private void label5_Click_1(object sender, EventArgs e)
        { //Выход из программы
            Application.Exit();
        }

        private void label4_Click_1(object sender, EventArgs e)
        { // Переход на форму авторизации
            Autorisation autorisation = new Autorisation();
            this.Visible = false;
            autorisation.Show();
        }

        private void label3_Click_1(object sender, EventArgs e)
        { // открытие формы информации
            BoughtTickets boughttickets = new BoughtTickets();
            this.Visible = false;
            boughttickets.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        { // Показ урезанного главного меню пользователю
            if (Cinema.Workspace.IsAdmin == false)
            {
                this.Height = 203;
            }
        }

    }
}
