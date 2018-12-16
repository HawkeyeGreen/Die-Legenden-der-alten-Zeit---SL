using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;
using Zeus.Hermes;

namespace Die_Legenden_der_Alten_Zeit_Lib.DB_Management
{
    /// <summary>
    /// Klasse: DBManager
    /// Diese Klasse stellt die Funktionen zur Nutzung der DBs bereit.
    /// Sie verwaltet die zugreifbaren DBs und gibt Funktionen zum einfachen Ausführen von Queries bereit.
    /// </summary>
    public class DBManager : HermesLoggable
    {
        private static DBManager instance;

        private string mainDBPath;
        private string mainConnectionString;

        private bool locked = false;
        private string threadKey = "Main";

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

            Hermes.getInstance().log(this, "DBManager was instanced.");
        }

        public static DBManager GetInstance()
        {
            if(instance == null)
            {
                instance = new DBManager();
            }
            return instance;
        }

        /// <summary>
        /// Diese Methode prüft, ob die MainDB gerade von einem thread-belegt ist.
        /// Sollte das der Fall sein, so kann überpüft werden, ob der gegebene Key den Zugang zur DB herstellt.
        /// </summary>
        /// <param name="myKey">Ein ThreadKey für die Database. Default=Main</param>
        /// <returns>Wenn die Rückgabe true ist, so ist für diesen Thread der Zugriff gerade möglich.</returns>
        public bool DatabaseAccesible(string myKey = "Main")
        {
            if(!locked)
            {
                // DB offen
                return true;
            }
            else
            {
                if(threadKey == myKey)
                {
                    // Key öffnet Zugang
                    return true;
                }
                //Falscher Key
                return false;
            }
        }

        /// <summary>
        /// Ein SQLite-konformer Verbindungsstring wird erzeugt.
        /// </summary>
        /// <param name="dbName">Der Name der Datenbank, für die ein String erzeugt werden soll.</param>
        /// <returns>Ein valider SQLiteConnectionString.</returns>
        public static string CreateConnectionString(string dbName)
        {
            return "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\Databases\\" + dbName + ".sqlite" + ";Version=3;";
        }

        /// <summary>
        /// Führt den angegebenen SQLite-Befehl auf der MainDB aus.
        /// Diese Methode ist für alle Fälle gedacht, deren Command keine Rückgabe erzeugt.
        /// </summary>
        /// <param name="cmdString">Der vollständige, formatierte SQLite-Befehlsstring. ACHTUNG: ; nicht vergessen!</param>
        public void ExecuteCommandNonQuery(string cmdString)
        {
            try
            {
                SQLiteConnection sQLiteConnection = new SQLiteConnection(mainConnectionString);
                sQLiteConnection.Open();
                SQLiteCommand command = new SQLiteCommand(cmdString, sQLiteConnection);
                command.ExecuteNonQuery();
                sQLiteConnection.Close();

                Hermes.getInstance().log(this, "Following command was executed: " + cmdString);
            }
            catch(Exception e)
            {
                Hermes.getInstance().log(this, "An error occured while executing this command: " + cmdString);
                Hermes.getInstance().log(this, "The error was: " + e.Message);          
            }
        }

        /// <summary>
        /// Der übergebene SQLite-Befehlsstring wird auf der MainDB ausgeführt und das die Rückgabe der Query wird in einem
        /// DataSet abgelegt. Diese Methode ist für rückgabe-behaftete Befehle vorgesehen.
        /// </summary>
        /// <param name="cmdString">Dieser String ist der Befehel, der ausgeführt werden soll. Muss mit einem ';' geschlossen werden.</param>
        /// <returns>Dieses DataSet enthält die Rückgabe der DB.</returns>
        public DataSet ExecuteQuery(string cmdString)
        {
            //Hermes.getInstance().log(this, "Following command will be executed " + cmdString);

            try
            {
                SQLiteConnection sqlite_conn;          // Database Connection Object
                SQLiteDataAdapter sqlite_adapter;  // Data Reader Object

                sqlite_conn = new SQLiteConnection(mainConnectionString);


                sqlite_conn.Open();

                sqlite_adapter = new SQLiteDataAdapter(cmdString, sqlite_conn);

                Hermes.getInstance().log(this, "Following command will be executed: " + cmdString);

                DataSet Return = new DataSet();

                int rows = sqlite_adapter.Fill(Return);
                Hermes.getInstance().log(this, "This amount of rows was found: " + rows.ToString());
                sqlite_conn.Close();

                return Return;
            }
            catch(Exception e)
            {
                Hermes.getInstance().log(this, "Following error occured: " + e.Message);
                return null;
            }

        }
    }

}
