using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Die_Legenden_der_alten_Zeit___SL.Sources.DB_Management
{
    /*  Class: DBManager
     *  This class provides ManagedConnections, opens and setups the database and checks if the database is fine.
     */
    class DBManager
    {
        private static DBManager instance;

        private string mainDBPath;
        private string mainConnectionString;

        public string MainConnectionString
        {
            get => mainConnectionString;
        }

        private List<Prefab> prefabs = new List<Prefab>();

        private DBManager(string dbName)
        {
            mainDBPath = AppDomain.CurrentDomain.BaseDirectory + "\\Databases\\" + dbName +".sqlite";
            
            if(!File.Exists(mainDBPath))
            {
                SQLiteConnection.CreateFile(mainDBPath);
            }

            mainConnectionString = createConnectionString(dbName);

            #region prefabs
            prefabs.Add(new Players());
            #endregion

            // need some kind of check if the tables all are right
            // if not create them/ correct them
            createTables();
        }

        public static DBManager getInstance(string dbName)
        {
            if(instance == null)
            {
                instance = new DBManager(dbName);
            }
            return instance;
        }

        private void createTables()
        {
            SQLiteConnection connection = new SQLiteConnection(mainConnectionString);
            connection.Open();
            foreach(Prefab prefab in prefabs)
            {
                foreach(string command in prefab.TableDefinitions)
                {
                    SQLiteCommand cmd = new SQLiteCommand(command, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static string createConnectionString(string dbName)
        {
            return "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\Databases\\" + dbName + ".sqlite" + ";Version=3;";
        }

        #region prefab definitions
        class Prefab
        {
            private List<string> sourceStrings;
            public List<string> TableDefinitions
            {
                get => sourceStrings;
                set => sourceStrings = value;
            }
        }

        class Players : Prefab
        {
            public Players()
            {
                List<string> tableCreators = new List<string>();

                tableCreators.Add("CREATE TABLE players (name varchar(40) NOT NULL PRIMARY KEY)");

                TableDefinitions = tableCreators;
            }
        }

        #endregion
    }

}
