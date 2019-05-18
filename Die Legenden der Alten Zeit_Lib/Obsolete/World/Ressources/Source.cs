//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Zeus.Hermes;

//namespace Die_Legenden_der_Alten_Zeit_Lib.World.Ressources
//{
//    /// <summary>
//    /// Eine Quelle vereint eine Ressource mit ihrer Herkunft.
//    /// Die Quelle berechnet jede Runde die Regeneration ihrer Ressourcen sowie die Auswirkung etwaiger Schäden.
//    /// Dazu können Arbeiter auf dem Tile GatherRessources aufrufen, wobei das Tile wiederum dann einfach GatherRessources auf der Source aufruft.
//    /// </summary>
//    class Source : HermesLoggable
//    {
//        private int _ID;
//        private int RessourceID;
//        private (string type, int ID) Bound;

//        /// <summary>
//        /// Repräsentiert den aktuellen Stand der Ressource.
//        /// </summary>
//        private int currentAmount;

//        /// <summary>
//        /// Repräsentiert der Anfangsstand der Ressource.
//        /// </summary>
//        private readonly int startAmount;

//        public long ID => _ID;
//        public string Type => "Ressourcenquelle";

//        /// <summary>
//        /// Liest die Source unter der gegebenen ID aus der DB.
//        /// </summary>
//        /// <param name="ID"></param>
//        public Source(int ID)
//        {
            
//        }
//    }
//}
