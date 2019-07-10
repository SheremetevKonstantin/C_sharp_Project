namespace Cinema
{
    partial class BoughtTickets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ClientCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClientDel = new System.Windows.Forms.Label();
            this.ClientBack = new System.Windows.Forms.Label();
            this.ClientdataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FilmCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FilmDel = new System.Windows.Forms.Label();
            this.FilmBack = new System.Windows.Forms.Label();
            this.FilmdataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TicketsCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TicketsDel = new System.Windows.Forms.Label();
            this.TicketsBack = new System.Windows.Forms.Label();
            this.TicketsdataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientdataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilmdataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TicketsdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ItemSize = new System.Drawing.Size(413, 29);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1246, 391);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ClientCount);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ClientDel);
            this.tabPage1.Controls.Add(this.ClientBack);
            this.tabPage1.Controls.Add(this.ClientdataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1238, 354);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Клиент";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ClientCount
            // 
            this.ClientCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientCount.Location = new System.Drawing.Point(375, 324);
            this.ClientCount.Name = "ClientCount";
            this.ClientCount.Size = new System.Drawing.Size(89, 24);
            this.ClientCount.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(64, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 24);
            this.label1.TabIndex = 25;
            this.label1.Text = "Общее количество клиентов: ";
            // 
            // ClientDel
            // 
            this.ClientDel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClientDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientDel.Location = new System.Drawing.Point(879, 322);
            this.ClientDel.Name = "ClientDel";
            this.ClientDel.Size = new System.Drawing.Size(176, 30);
            this.ClientDel.TabIndex = 24;
            this.ClientDel.Text = "Удалить";
            this.ClientDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClientDel.Click += new System.EventHandler(this.ClientDel_Click);
            // 
            // ClientBack
            // 
            this.ClientBack.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClientBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientBack.Location = new System.Drawing.Point(1061, 322);
            this.ClientBack.Name = "ClientBack";
            this.ClientBack.Size = new System.Drawing.Size(176, 30);
            this.ClientBack.TabIndex = 23;
            this.ClientBack.Text = "Назад";
            this.ClientBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClientBack.Click += new System.EventHandler(this.ClientBack_Click);
            // 
            // ClientdataGridView
            // 
            this.ClientdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ClientdataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ClientdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientdataGridView.Location = new System.Drawing.Point(2, 3);
            this.ClientdataGridView.MultiSelect = false;
            this.ClientdataGridView.Name = "ClientdataGridView";
            this.ClientdataGridView.ReadOnly = true;
            this.ClientdataGridView.RowHeadersVisible = false;
            this.ClientdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientdataGridView.Size = new System.Drawing.Size(1235, 315);
            this.ClientdataGridView.TabIndex = 1;
            this.ClientdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientdataGridView_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.FilmCount);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.FilmDel);
            this.tabPage2.Controls.Add(this.FilmBack);
            this.tabPage2.Controls.Add(this.FilmdataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1238, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Сеанс";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FilmCount
            // 
            this.FilmCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilmCount.Location = new System.Drawing.Point(375, 324);
            this.FilmCount.Name = "FilmCount";
            this.FilmCount.Size = new System.Drawing.Size(89, 24);
            this.FilmCount.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(64, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(305, 24);
            this.label4.TabIndex = 27;
            this.label4.Text = "Общее количество сеансов: ";
            // 
            // FilmDel
            // 
            this.FilmDel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.FilmDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FilmDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilmDel.Location = new System.Drawing.Point(879, 322);
            this.FilmDel.Name = "FilmDel";
            this.FilmDel.Size = new System.Drawing.Size(176, 30);
            this.FilmDel.TabIndex = 26;
            this.FilmDel.Text = "Удалить";
            this.FilmDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FilmDel.Click += new System.EventHandler(this.FilmDel_Click);
            // 
            // FilmBack
            // 
            this.FilmBack.BackColor = System.Drawing.Color.LightSteelBlue;
            this.FilmBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FilmBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilmBack.Location = new System.Drawing.Point(1061, 322);
            this.FilmBack.Name = "FilmBack";
            this.FilmBack.Size = new System.Drawing.Size(176, 30);
            this.FilmBack.TabIndex = 25;
            this.FilmBack.Text = "Назад";
            this.FilmBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FilmBack.Click += new System.EventHandler(this.FilmBack_Click);
            // 
            // FilmdataGridView
            // 
            this.FilmdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FilmdataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FilmdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilmdataGridView.Location = new System.Drawing.Point(2, 3);
            this.FilmdataGridView.MultiSelect = false;
            this.FilmdataGridView.Name = "FilmdataGridView";
            this.FilmdataGridView.ReadOnly = true;
            this.FilmdataGridView.RowHeadersVisible = false;
            this.FilmdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FilmdataGridView.Size = new System.Drawing.Size(1235, 315);
            this.FilmdataGridView.TabIndex = 1;
            this.FilmdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilmdataGridView_CellClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TicketsCount);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.TicketsDel);
            this.tabPage3.Controls.Add(this.TicketsBack);
            this.tabPage3.Controls.Add(this.TicketsdataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1238, 354);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Билеты";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TicketsCount
            // 
            this.TicketsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TicketsCount.Location = new System.Drawing.Point(375, 324);
            this.TicketsCount.Name = "TicketsCount";
            this.TicketsCount.Size = new System.Drawing.Size(89, 24);
            this.TicketsCount.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(64, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 24);
            this.label6.TabIndex = 29;
            this.label6.Text = "Общее количество билетов: ";
            // 
            // TicketsDel
            // 
            this.TicketsDel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TicketsDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TicketsDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TicketsDel.Location = new System.Drawing.Point(879, 322);
            this.TicketsDel.Name = "TicketsDel";
            this.TicketsDel.Size = new System.Drawing.Size(176, 30);
            this.TicketsDel.TabIndex = 28;
            this.TicketsDel.Text = "Удалить";
            this.TicketsDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TicketsDel.Click += new System.EventHandler(this.TicketsDel_Click);
            // 
            // TicketsBack
            // 
            this.TicketsBack.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TicketsBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TicketsBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TicketsBack.Location = new System.Drawing.Point(1061, 322);
            this.TicketsBack.Name = "TicketsBack";
            this.TicketsBack.Size = new System.Drawing.Size(176, 30);
            this.TicketsBack.TabIndex = 27;
            this.TicketsBack.Text = "Назад";
            this.TicketsBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TicketsBack.Click += new System.EventHandler(this.TicketsBack_Click);
            // 
            // TicketsdataGridView
            // 
            this.TicketsdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TicketsdataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TicketsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TicketsdataGridView.Location = new System.Drawing.Point(2, 3);
            this.TicketsdataGridView.MultiSelect = false;
            this.TicketsdataGridView.Name = "TicketsdataGridView";
            this.TicketsdataGridView.ReadOnly = true;
            this.TicketsdataGridView.RowHeadersVisible = false;
            this.TicketsdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TicketsdataGridView.Size = new System.Drawing.Size(1235, 315);
            this.TicketsdataGridView.TabIndex = 0;
            this.TicketsdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TicketsdataGridView_CellClick);
            // 
            // BoughtTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1246, 394);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "BoughtTickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АСУ Кинотеатр - Общая сводка";
            this.Load += new System.EventHandler(this.BoughtTickets_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClientdataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FilmdataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TicketsdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView TicketsdataGridView;
        private System.Windows.Forms.DataGridView ClientdataGridView;
        private System.Windows.Forms.DataGridView FilmdataGridView;
        private System.Windows.Forms.Label ClientDel;
        private System.Windows.Forms.Label ClientBack;
        private System.Windows.Forms.Label FilmDel;
        private System.Windows.Forms.Label FilmBack;
        private System.Windows.Forms.Label TicketsDel;
        private System.Windows.Forms.Label TicketsBack;
        private System.Windows.Forms.Label ClientCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FilmCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TicketsCount;
        private System.Windows.Forms.Label label6;
    }
}