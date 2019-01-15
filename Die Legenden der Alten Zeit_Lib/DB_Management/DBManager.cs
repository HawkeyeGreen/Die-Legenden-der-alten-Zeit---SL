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

        private Dictionary<string, string> nonMainDatabase = new Dictionary<string, string>();
        private Dictionary<string, Tuple<bool, string>> nonMainKeys = new Dictionary<string, Tuple<bool, string>>();

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

        // Die MainDB wird nicht spezifisch neu erzeugt vom Programm
        // Das hätte auch keinen Wert, denn der DBManager KANN nicht wissen,
        // was alles an Informationen in der DB benötigt werden

        /// <summary>
        /// Initialisiert den DBManager auf der MainDB.
        /// </summary>
        private DBManager()
        {
            mainDBPath = AppDomain.CurrentDomain.BaseDirectory + "\\Databases\\mainDB.sqlite";

            mainConnectionString = CreateConnectionString("mainDB");

            Hermes.getInstance().log(this, "DBManager was instanced.");
        }

        /// <summary>
        /// Ruft die aktuelle Instanz des DBManagers ab oder veranlasst die Erstellung einer verwendbaren DBManager-Instanz.
        /// </summary>
        /// <returns>Initialisierte DBManager-Instanz</returns>
        public static DBManager GetInstance()
        {
            if (instance == null)
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
        public bool DatabaseAccessible(string myKey = "Main", string dbKey = "mainDB")
        {

            if (dbKey == "mainDB")
            {
                if (!locked)
                {
                    // DB offen
                    return true;
                }
                else
                {
                    if (threadKey == myKey)
                    {
                        // Key öffnet Zugang
                        return true;
                    }
                    //Falscher Key
                    return false;
                }
            }
            else
            {
                if (nonMainKeys[dbKey].Item1)
                {
                    // DB ist frei
                    return true;
                }
                else
                {
                    if (nonMainKeys[dbKey].Item2 == myKey)
                    {
                        // Key ist richtig
                        return true;
                    }
                    // Key ist nicht der passende
                    return false;
                }
            }

        }

        /// <summary>
        /// Ein SQLite-konformer Verbindungsstring wird erzeugt.
        /// </summary>
        /// <param name="dbName">Der Name der Datenbank, für die ein String erzeugt werden soll.</param>
        /// <returns>Ein valider SQLiteConnectionString.</returns>
        public static string CreateConnectionString(string dbName, string Location = "\\Databases\\")
        {
            return "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + Location + dbName + ".sqlite" + ";Version=3;";
        }

        /// <summary>
        /// Führt den angegebenen SQLite-Befehl auf der MainDB aus.
        /// Diese Methode ist für alle Fälle gedacht, deren Command keine Rückgabe erzeugt.
        /// </summary>
        /// <param name="cmdString">Der vollständige, formatierte SQLite-Befehlsstring. ACHTUNG: ; nicht vergessen!</param>
        public void ExecuteCommandNonQuery(string cmdString, string dbKey = "mainDB")
        {
            try
            {
                SQLiteConnection sQLiteConnection;
                if (dbKey == "mainDB")
                {
                    sQLiteConnection = new SQLiteConnection(mainConnectionString);
                }
                else
                {
                    sQLiteConnection = new SQLiteConnection(nonMainDatabase[dbKey]);
                }
                sQLiteConnection.Open();
                SQLiteCommand command = new SQLiteCommand(cmdString, sQLiteConnection);
                command.ExecuteNonQuery();
                sQLiteConnection.Close();


                Hermes.getInstance().log(this, "Following command was executed: " + cmdString);
            }
            catch (Exception e)
            {
                Hermes.getInstance().log(this, "An error occured while executing this command: " + cmdString + " on the following database " + dbKey);
                Hermes.getInstance().log(this, "The error was: " + e.Message);
            }
        }

        /// <summary>
        /// Der übergebene SQLite-Befehlsstring wird auf der MainDB ausgeführt und das die Rückgabe der Query wird in einem
        /// DataSet abgelegt. Diese Methode ist für rückgabe-behaftete Befehle vorgesehen.
        /// </summary>
        /// <param name="cmdString">Dieser String ist der Befehel, der ausgeführt werden soll. Muss mit einem ';' geschlossen werden.</param>
        /// <returns>Dieses DataSet enthält die Rückgabe der DB.</returns>
        public DataSet ExecuteQuery(string cmdString, string dbKey = "mainDB")
        {
            //Hermes.getInstance().log(this, "Following command will be executed " + cmdString);

            try
            {
                SQLiteConnection sqlite_conn;          // Database Connection Object
                SQLiteDataAdapter sqlite_adapter;  // Data Reader Object

                if (dbKey == "mainDB")
                {
                    sqlite_conn = new SQLiteConnection(mainConnectionString);
                }
                else
                {
                    sqlite_conn = new SQLiteConnection(nonMainDatabase[dbKey]);
                }


                sqlite_conn.Open();

                sqlite_adapter = new SQLiteDataAdapter(cmdString, sqlite_conn);

                Hermes.getInstance().log(this, "Following command will be executed: " + cmdString);

                DataSet Return = new DataSet();

                int rows = sqlite_adapter.Fill(Return);
                Hermes.getInstance().log(this, "This amount of rows was found: " + rows.ToString());
                sqlite_conn.Close();

                return Return;
            }
            catch (Exception e)
            {
                Hermes.getInstance().log(this, "Following error occured: " + e.Message + " on the following database " + dbKey);
                return null;
            }

        }

        /// <summary>
        /// Diese Methode erstellt ein DB-File, wenn es noch nicht existiert.
        /// Und vermerkt es unter seinem Key in der Liste, so dass man sie ab dann leicht abrufen kann.
        /// </summary>
        /// <param name="dbKey">Der Schlüssel (und Name) der Datenbank</param>
        /// <param name="location">Der Speicherort der Datenbank.</param>
        public void CreateDatabase(string dbKey, bool force = false, string location = "\\Databases\\")
        {
            string FileName = AppDomain.CurrentDomain.BaseDirectory + location + dbKey + ".sqlite";

            Hermes.getInstance().log(this, "Trying to create this database: " + FileName);

            try
            {
                if (!nonMainDatabase.ContainsKey(dbKey))
                {
                    if (!File.Exists(FileName))
                    {
                        Hermes.getInstance().log(this, "File will be created!");
                        SQLiteConnection.CreateFile(FileName);
                    }
                    else if (force)
                    {
                        Hermes.getInstance().log(this, "File will be created!");
                        SQLiteConnection.CreateFile(FileName);
                    }
                    else
                    {
                        Hermes.getInstance().log(this, "DB already existed!");
                    }
                    Hermes.getInstance().log(this, "Key will be inserted!");
                    nonMainDatabase[dbKey] = CreateConnectionString(dbKey, location);
                }
            }
            catch (Exception e)
            {
                Hermes.getInstance().log(this, "Following error occured while trying to create the database and it's entry: " + e.Message);
            }
        }

        /// <summary>
        /// Nimmt einen string aus einer DB entgegen, welcher einen bool-Wert repräsentiert.
        /// </summary>
        /// <param name="input">Der Eintrag aus der DB.</param>
        /// <returns>true, wenn der Eintrag "true" entspricht, ansonsten false.</returns>
        public static bool ConvertToBoolean(string input)
        {
            if (input == "true")
            {
                return true;
            }
            else if (input == "false")
            {
                return false;
            }
            else
            {
                Hermes.getInstance().log(DBManager.GetInstance(), input + " matched neither true nor false.");
                return false;
            }
        }

        /// <summary>
        /// Erzeugt einen DBManager-konformen string aus einem gegebenen boolean-Wert.
        /// Dient zur Kontrolle über den Wert, welcher in die DB eingetragen wird.
        /// </summary>
        /// <param name="input">Der boolean-Wert, dessen Entsprechung angefordert wird.</param>
        /// <returns>Ein string, der dem boolean-Wert des inputs entspricht.</returns>
        public static string ConvertBooleanToString(bool input)
        {
            if (input)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }

}
