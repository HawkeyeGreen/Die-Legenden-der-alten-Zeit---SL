//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Zeus.Hermes;
//using Die_Legenden_der_Alten_Zeit_Lib.DB_Management;
//using System.Data;
//using System.Data.SQLite;

//namespace Die_Legenden_der_Alten_Zeit_Lib.PlayerManagement.NewsSystem
//{
//    public class News : HermesLoggable
//    {
//        private string rtfPath;
//        private int _ID;
//        private int _TargetID;
//        private string _Topic;
//        private string _Name;
//        private string _Mode;
//        private string _PlaceTag;

//        public string RTFPath => rtfPath;
//        public string Name => _Name;
//        public string Topic => _Topic;
//        public string PlaceTag => _PlaceTag;
//        public string Mode
//        {
//            get => _Mode;
//            set => _Mode = value;
//        }
//        public bool Template
//        {
//            get
//            {
//                if (_TargetID == -1)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//        }

//        public int TargetID => _TargetID;
//        public long ID => _ID;
//        public string Type => "News";

//        /// <summary>
//        /// Die so erzeugte News ist IMMER ein Template und wird direkt in der Datenbank abgespeichert.
//        /// </summary>
//        /// <param name="name">Der Name der News.</param>
//        /// <param name="topic">Das Topic der News.</param>
//        /// <param name="rtfPath">Der Pfade zum RTF-Dokument der News.</param>
//        /// <param name="placeTag">Der Ort an dem die News stattfindet. Leer heißt ortsunabhängig. Platzhalter möglich.</param>
//        public News(string name, string topic, string rtfPath, string placeTag = "")
//        {
//            _Name = name;
//            _Topic = topic;
//            _TargetID = -1; // Alle Templates erhalten die targetID -1.
//            _Mode = "auto-template";
//            this.rtfPath = rtfPath;
//            _PlaceTag = placeTag;

//            SaveNewsToMainDB();
//        }

//        /// <summary>
//        /// Dieser Konstruktor lädt die News mit der angegebenen ID aus der MainDB.
//        /// </summary>
//        /// <param name="id">Die ID der zu initialisierenden News.</param>
//        public News(int id)
//        {
//            LoadNewsFromMainDB(id);
//        }

//        /// <summary>
//        /// Speichert die News in die mainDB.
//        /// </summary>
//        /// <param name="isNew">Kontrolliert, ob eine neue ID vergeben werden soll oder nicht.</param>
//        /// <returns>Gibt die ID zurück unter der die News in der DB abgelegt wurde.</returns>
//        public int SaveNewsToMainDB(bool isNew = true)
//        {
//            string command = "";

//            if (isNew)
//            {
//                DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT MAX(ID) FROM News;").CreateDataReader();
//                reader.Read();
//                _ID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("MAX(ID)"))) + 1;
//                reader.Close();
//                command = "INSERT INTO News VALUES(" + _ID.ToString() + ",'" + _Name + "','" + _Topic + "','" + rtfPath + "','" + _Mode + "','" + _PlaceTag + "'," + _TargetID.ToString() + ");";
//            }
//            else
//            {
//                command = "UPDATE News SET Name='" + _Name + "', Topic='" + _Topic + "', Path='" + rtfPath + "', Mode='" + _Mode + "', PlaceTag='" + _PlaceTag + "', TargetPlayerID=" + _TargetID.ToString() + " WHERE ID=" + _ID.ToString() + ";";
//            }



//            DBManager.GetInstance().ExecuteCommandNonQuery(command);

//            return _ID;
//        }

//        /// <summary>
//        /// Diese Funktion ruft alle nötige Einträge aus der MainDB ab, um die News zu laden.
//        /// ACHTUNG: Wenn die ID nicht vorhanden ist, dann wird nur ein Hermes-Log geschrieben und der DUMMY-Entry geladen.
//        /// </summary>
//        /// <param name="id">Die ID der zu ladenen News.</param>
//        public void LoadNewsFromMainDB(int id)
//        {
//            DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM News WHERE ID=" + id.ToString() + ";").CreateDataReader();
//            reader.Read();
//            if (reader.HasRows)
//            {
//                _ID = id;
//                _Name = Convert.ToString(reader.GetValue(reader.GetOrdinal("Name")));
//                _Topic = Convert.ToString(reader.GetValue(reader.GetOrdinal("Topic")));
//                rtfPath = Convert.ToString(reader.GetValue(reader.GetOrdinal("Path")));
//                _Mode = Convert.ToString(reader.GetValue(reader.GetOrdinal("Mode")));
//                _PlaceTag = Convert.ToString(reader.GetValue(reader.GetOrdinal("PlaceTag")));
//                _TargetID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("TargetPlayerID")));
//                Hermes.getInstance().log(this, "A News-Entry was loaded from the main database and is ready for use.");
//                Hermes.getInstance().log(this, "Name: " + _Name + " \n Topic: " + _Topic + "\n Path: " + rtfPath);
//            }
//            else
//            {
//                Hermes.getInstance().log(this, "It was attempted to load a News with the following ID - but there was no entry! ID: " + id.ToString());
//                Hermes.getInstance().log(this, "The DUMMY-Entry will be used.");
//                LoadNewsFromMainDB(0); // Lade Dummy
//            }
//            reader.Close();
//        }

//        /// <summary>
//        /// Lädt alle verfügbaren News aus der Datenbank und übergibt sie als Liste.
//        /// </summary>
//        /// <returns>Eine Liste aller News in der MainDB.</returns>
//        public static List<News> GetAllMainDBNews()
//        {
//            List<News> news = new List<News>();

//            DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM News;").CreateDataReader();
//            while(reader.Read())
//            {
//                news.Add(new News(Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ID")))));
//            }

//            return news;

//        }

//        /// <summary>
//        /// Gibt alle derzeit vorhandenen Themen als Liste zurück.
//        /// </summary>
//        /// <returns>Eine Liste aller derzeit abgespeicherten Themen.</returns>
//        public static List<string> GetAllCurrentTopics()
//        {
//            List<String> topics = new List<String>();

//            DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT Topic FROM News;").CreateDataReader();
//            while (reader.Read())
//            {
//                topics.Add(Convert.ToString(reader.GetValue(reader.GetOrdinal("Topic"))));
//            }

//            return topics;
//        }

//        /// <summary>
//        /// Listet alle bis jetzt verwendeten Ortangaben auf.
//        /// </summary>
//        /// <returns>Eine Liste aller bekannten Orttags.</returns>
//        public static List<string> GetAllCurrentPlaceTags()
//        {
//            List<String> placeTags = new List<String>();

//            DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT PlaceTag FROM News;").CreateDataReader();
//            while (reader.Read())
//            {
//                placeTags.Add(Convert.ToString(reader.GetValue(reader.GetOrdinal("PlaceTag"))));
//            }

//            return placeTags;
//        }
//    }
//}
