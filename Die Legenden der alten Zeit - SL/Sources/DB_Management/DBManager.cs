using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

using Zeus.Hermes;

namespace Die_Legenden_der_alten_Zeit___SL.Sources.DB_Management
{
    /*  Class: DBManager
     *  This class provides ManagedConnections, opens and setups the database and checks if the database is fine.
     */
    class DBManager : HermesLoggable
    {
        private static DBManager instance;

        private string mainDBPath;
        private string mainConnectionString;

        public string MainConnectionString
        {
            get => mainConnectionString;
        }

        long HermesLoggable.ID => 1338;

        string HermesLoggable.Type => "DBManager";

        private DBManager()
        {
            mainDBPath = AppDomain.CurrentDomain.BaseDirectory + "\\Databases\\mainDB.sqlite";
            
            if(!File.Exists(mainDBPath))
            {
                SQLiteConnection.CreateFile(mainDBPath);
            }

            mainConnectionString = CreateConnectionString("mainDB");

            Hermes.getInstance().log(this, "Database was opened.");
        }

        public static DBManager GetInstance()
        {
            if(instance == null)
            {
                instance = new DBManager();
            }
            return instance;
        }

        public static string CreateConnectionString(string dbName)
        {
            return "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\Databases\\" + dbName + ".sqlite" + ";Version=3;";
        }

        public void ExecuteCommandNonQuery(string cmdString)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(mainConnectionString);
            sQLiteConnection.Open();
            SQLiteCommand command = new SQLiteCommand(cmdString, sQLiteConnection);
            command.ExecuteNonQuery();
            sQLiteConnection.Close();

            Hermes.getInstance().log(this, "Following command was executed: " + cmdString);
        }

        public SQLiteDataReader ExecuteQuery(string cmdString)
        {
            SQLiteConnection sqlite_conn;          // Database Connection Object
            SQLiteCommand sqlite_cmd;             // Database Command Object
            SQLiteDataReader sqlite_datareader;  // Data Reader Object

            sqlite_conn = new SQLiteConnection(mainConnectionString);

            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = cmdString;

            sqlite_datareader = sqlite_cmd.ExecuteReader(CommandBehavior.CloseConnection);

            Hermes.getInstance().log(this ,"Following command was executed and the DataReader returned: " + cmdString);

            return sqlite_datareader;

        }
    }

}
