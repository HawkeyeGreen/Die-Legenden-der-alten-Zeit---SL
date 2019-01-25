using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeus.Hermes;

namespace Die_Legenden_der_Alten_Zeit_Lib.World.Map
{
    /// <summary>
    /// Eine Provinz enthält eine Menge von Regionen.
    /// </summary>
    class Province : HermesLoggable
    {
        private List<Region> regions = new List<Region>();
        private int _ID;
        private string displayName;

        public long ID => _ID;
        public string Type => displayName;

        /// <summary>
        /// Dieser Konstruktor lädt die Provinz anhand ihrer ID und der ID der Karte auf der sie sich befindet aus der Datenbank.
        /// </summary>
        /// <param name="id">Die ID der Provinz, die geladen werden soll.</param>
        /// <param name="mapID">Die ID der Karte, auf der sich die Provinz befindet.</param>
        public Province(int id, int mapID)
        {

        }
    }
}
