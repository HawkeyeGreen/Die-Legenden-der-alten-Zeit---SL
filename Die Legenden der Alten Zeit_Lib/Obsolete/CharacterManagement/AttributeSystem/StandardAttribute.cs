//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;
//using Zeus.Hermes;
//using Die_Legenden_der_Alten_Zeit_Lib.DB_Management;

//namespace Die_Legenden_der_Alten_Zeit_Lib.CharacterManagement.AttributeSystem
//{
//    /// <summary>
//    /// Diese Klasse verpackt ein Standardattributnamen und alle auf dieses Attribut verweisende Referenzen.
//    /// </summary>
//    public class StandardAttribute : HermesLoggable
//    {
//        private string Descr_Path;
//        private int _ID;
//        private string attributeKey;
//        private List<string> linkedKeys;
//        private int currentLookIndex = 0;

//        /// <summary>
//        /// Der Schlüssel des Attributs unter dem es primär angesprochen werden soll.
//        /// </summary>
//        public string Key
//        {
//            get => attributeKey;
//            set => attributeKey = value;
//        }

//        /// <summary>
//        /// Attributsnamen, die auf dieses Attribut verlinkt werden sollen.
//        /// </summary>
//        public List<string> LinkedKeys
//        {
//            get => linkedKeys;
//            set => linkedKeys = value;
//        }

//        public string Path
//        {
//            get => Descr_Path;
//            set => Descr_Path = value;
//        }

//        public long ID => Convert.ToInt64(_ID);

//        public string Type => "StandardAttribute";

//        /// <summary>
//        /// Dieser Konstruktor ermöglicht es ausschließlich den Key festzulegen.
//        /// Alle Referenzen müssen nachträglich hinzugefügt werden.
//        /// </summary>
//        /// <param name="key">Der Attributsschlüssel. Beispiele: "ST" für Stärke; "GE" für Geschicklichkeit</param>
//        public StandardAttribute(string key)
//        {
//            attributeKey = key;
//            linkedKeys = new List<string>();
//        }

//        /// <summary>
//        /// In diesem Konstruktor wird die Liste der referenzierten Schlüsselnamen gemeinsam mit dem Attributsschlüssel übergeben.
//        /// </summary>
//        /// <param name="key">Der Attributsschlüssel. Beispiele: "ST" für Stärke; "GE" für Geschicklichkeit</param>
//        /// <param name="referenced">Die verwiesenen Schlüssel.</param>
//        public StandardAttribute(string key, List<string> referenced, string descr)
//        {
//            attributeKey = key;
//            linkedKeys = referenced;
//            Descr_Path = descr;
//        }

//        /// <summary>
//        /// Initialisiert das StandardAttribut via der Datenbank.
//        /// </summary>
//        /// <param name="ID">Die ID des StandardAttributs in der StandardAttribute-Tabelle.</param>
//        public StandardAttribute(int ID)
//        {
//            _ID = ID;

//            DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM StandardAttributes WHERE ID = " + _ID.ToString() + ";").CreateDataReader();
//            reader.Read();
//            attributeKey = reader.GetValue(reader.GetOrdinal("AttributeKey")).ToString();
//            Descr_Path = reader.GetValue(reader.GetOrdinal("Path")).ToString();

//            linkedKeys = new List<string>();
//            reader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM StandardAttributes_References WHERE ID = " + _ID.ToString() + ";").CreateDataReader();
//            while(reader.Read())
//            {
//                linkedKeys.Add(reader.GetValue(reader.GetOrdinal("ReferencedKey")).ToString());
//            }
//            reader.Close();

//            Hermes.getInstance().log(this, "The Standardattribute " + attributeKey + " was loaded from the database.");
//        }

//        /// <summary>
//        /// Dieser Konstruktor nimmt auch den Pfad zur Beschreibung an.
//        /// </summary>
//        /// <param name="key"></param>
//        /// <param name="path"></param>
//        public StandardAttribute(string key, string path)
//        {
//            Path = path;
//            attributeKey = key;
//            linkedKeys = new List<string>();
//        }

//        /// <summary>
//        /// Fügt den referencedKeys dieses Standardattributes einen neuen Schlüssel hinzu.
//        /// </summary>
//        /// <param name="key">Dieser Schlüssel wird als referenzierter Schlüssel hinzugefügt.</param>
//        public void AddReferencedKey(string key)
//        {
//            LinkedKeys.Add(key);
//        }

//        /// <summary>
//        /// Liest einen Schlüssel aus der Liste der referenzierten Schlüssel und erhöht den Index um eins.
//        /// </summary>
//        /// <returns>
//        /// Gibt ein Tupel zurück:
//        /// 1) Wurde das Ende der Liste erreicht
//        /// 2) Gelesener Schlüssel
//        /// </returns>
//        public Tuple<bool, string> ReadReferencedKey()
//        {
//            Tuple<bool, string> Return;

//            if (currentLookIndex < linkedKeys.Count)
//            {
//                Return = new Tuple<bool, string>(true, linkedKeys[currentLookIndex]);
//                currentLookIndex++;
//            }
//            else
//            {
//                Return = new Tuple<bool, string>(false, null);
//                currentLookIndex = 0;
//            }

//            return Return;
//        }

//        /// <summary>
//        /// Setzt den aktuellen LookIndex auf 0.
//        /// </summary>
//        public void ResetLookIndex() => currentLookIndex = 0;

//        /// <summary>
//        /// Sichert dieses Standardattribut in die Standardattributtabellen der MainDB.
//        /// </summary>
//        /// <param name="id">Wenn dieser Parameter auf -1 gesetzt wird, dann wird der Wert neu in die Tabelle eingeführt.</param>
//        /// <returns>Die ID unter der das Attribut aktuell in der Tabelle zu finden ist.</returns>
//        public int SaveStandardAttribute(int id = -1)
//        {
//            if(id == -1)
//            {
//                DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT Max(ID) FROM StandardAttributes;").CreateDataReader();
//                reader.Read();
//                if(reader[0] != DBNull.Value)
//                {
//                    _ID = Convert.ToInt32(reader[0]) + 1;
//                }
//                else
//                {
//                    _ID = 0;
//                }

//                id = _ID;
//                reader.Close();

//                DBManager.GetInstance().ExecuteQuery("INSERT INTO StandardAttributes VALUES(" + _ID.ToString() + ", '" + attributeKey + "', '" + Descr_Path + "');");

//                foreach(string refKey in linkedKeys)
//                {
//                    DBManager.GetInstance().ExecuteQuery("INSERT INTO StandardAttributes_References VALUES(" + _ID.ToString() + ", '" + refKey + "');");
//                }
//            }
//            else
//            {

//            }

//            return id;
//        }

//        /// <summary>
//        /// Liest das StandardAttribut 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns>Ein StandardAttribut, das mit der gegebenen ID initialisiert wurde.</returns>
//        public static StandardAttribute LoadStandardAttribute(int id)
//        {
//            return new StandardAttribute(id);
//        }
//    }
//}
