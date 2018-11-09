using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

using Die_Legenden_der_alten_Zeit___SL.Sources.DB_Management;

namespace Die_Legenden_der_alten_Zeit___SL
{
    public partial class Form1 : Form
    {
        DBManager dbManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dbManager = DBManager.getInstance("mainDB");

            SQLiteConnection connection = new SQLiteConnection(dbManager.MainConnectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO players VALUES ('Jörn')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
