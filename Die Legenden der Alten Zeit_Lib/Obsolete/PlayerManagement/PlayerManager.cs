//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SQLite;
//using Die_Legenden_der_Alten_Zeit_Lib.DB_Management;
//using System.Data;

//namespace Die_Legenden_der_Alten_Zeit_Lib.PlayerManagement
//{
//    class PlayerManager
//    {

//        public static List<string> GetAllPlayerNames()
//        {
//            List<string> playerNames = new List<string>();

//            DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT PlayerName FROM Players;").CreateDataReader();

//            while (reader.Read())
//            {
//                playerNames.Add(reader.GetValue(reader.GetOrdinal("PlayerName")).ToString());
//            }

//            reader.Close();

//            return playerNames;
//        }
//    }
//}
