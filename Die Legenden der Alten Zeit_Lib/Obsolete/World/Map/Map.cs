//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;
//using Zeus.Hermes;
//using Die_Legenden_der_Alten_Zeit_Lib.DB_Management;

//namespace Die_Legenden_der_Alten_Zeit_Lib.World.Map
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    class Map : HermesLoggable
//    {
//        private static Dictionary<int, Map> mapsLoaded = new Dictionary<int, Map>();

//        private int _ID;
//        private string name;
//        private string DBKey;

//        public long ID => _ID;
//        public string Type => "Map";

//        private Map(int id)
//        {
//            DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM Maps WHERE ID=" + id.ToString() + ";").CreateDataReader();
//            if(reader.HasRows)
//            {
//                reader.Read();
//                name = Convert.ToString(reader.GetValue(reader.GetOrdinal("Name")));
//                DBKey = Convert.ToString(reader.GetValue(reader.GetOrdinal("DBKey")));
//                Hermes.getInstance().log(this, "Die Karte mit dem Namen " + name + " und der ID " + ID.ToString() + " wurde geladen.");
//            }
//            else
//            {
//                Hermes.getInstance().log(this, "Es wurde versucht eine Karte mit der ID " + ID.ToString() + " zu laden, aber so eine Karte existiert nicht!");
//            }
//        }

//        public static Map GetMap(int id)
//        {
//            if(mapsLoaded.ContainsKey(id))
//            {
//                return mapsLoaded[id];
//            }
//            else
//            {
//                mapsLoaded[id] = new Map(id);
//                return mapsLoaded[id];
//            }
//        }
//    }
//}
