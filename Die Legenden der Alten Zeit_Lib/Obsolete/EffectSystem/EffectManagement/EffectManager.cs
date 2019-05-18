//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Zeus.Hermes;
//using System.Data;

//namespace Die_Legenden_der_Alten_Zeit_Lib.EffectSystem.EffectManagement
//{
//    /// <summary>
//    /// Die grundlegende Implementierung des EffectManagers. Er bietet bereits die nötigsten Funktionen,
//    /// wird aber von jeder spezielleren Implementierung erweitert, um zum Beispiel die benötigten Abfragen für Conditions zu bieten
//    /// wie zum Beispiel Variablen-Checkes.
//    /// </summary>
//    class EffectManager : HermesLoggable
//    {
//        private int _ID;
//        private string type = "BasicEffectManager"; // Der Typ des EffectManagers wird auch genutzt, um die Initialisierung zu managen.

//        public long ID => _ID;
//        public string Type => type;

//        public EffectManager(DataTableReader reader)
//        {
//            _ID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ID")));
//            type = Convert.ToString(reader.GetValue(reader.GetOrdinal("Type")));
//        }


//        /// <summary>
//        /// Diese statische Methode wählt den passenden Konstruktor für
//        /// die gegebene ID. Die Funktion lädt den Type aus der DB und bestimmt darüber den benötigten Konstruktor.
//        /// </summary>
//        /// <param name="effectManager">Die Referenz, welche initialisiert werden soll.</param>
//        /// <param name="ID">Die ID des zu ladenden EffectManagers.</param>
//        public static EffectManager InitializeBasedOnType(EffectManager effectManager, int ID)
//        {
//            return effectManager;
//        }
//    }
//}
