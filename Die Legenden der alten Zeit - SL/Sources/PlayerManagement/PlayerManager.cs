using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Die_Legenden_der_alten_Zeit___SL.Sources.DB_Management;
using System.Data;

namespace Die_Legenden_der_alten_Zeit___SL.Sources.PlayerManagement
{
    class PlayerManager
    {

        public static List<string> GetAllPlayerNames()
        {
            List<string> playerNames = new List<string>();

            SQLiteConnection sQLiteConnection = new SQLiteConnection(DBManager.GetInstance().MainConnectionString);
            sQLiteConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT PlayerName FROM Players", sQLiteConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                playerNames.Add(reader["PlayerName"] as string);
            }

            reader.Close();
            sQLiteConnection.Close();

            return playerNames;
        }
    }
}
