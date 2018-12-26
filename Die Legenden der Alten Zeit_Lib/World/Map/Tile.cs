using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zeus.Hermes;

namespace Die_Legenden_der_Alten_Zeit_Lib.World.Map
{
    /// <summary>
    /// Ein Tile ist das kleinste Element der Karte.
    /// Auf ihm kann sich stets nur ein 'Konstrukt' (z.B. Lager, Stadt, Dorf, Burg) befinden.
    /// Darüber hinaus befinden sich Einwohner, Ressourcenquellen, Armeen, Handlanger o.ä. stets auf einem Tile einer Map.
    /// 
    /// Ein Tile kann zur Laufzeit initialisiert werden oder aus der Datenbank via einer World-Map-Self-ID-Kombination geladen werden.
    /// 
    /// Ein Teile weist ein Relief sowie eine vorherrschende Flora auf.
    /// Zusätzlich können sich Landmarks auf ihm befinden z.B. Flüsse, Straßen, Sehr hohe Berge, Canyonabschnitte
    /// 
    /// </summary>
    class Tile : HermesLoggable
    {
        #region local-values
        private int tileID;
        private string HermesType = "Tile";
        private string reliefName = "flat"; // Das Relief beschreibt die Terrainform des Tiles
        private string floraName = "grassland"; // Welche Vegetation hier vorherrscht
        private List<string> landmarks = new List<string>(); // features können zum Beispiel Flüsse, Straßen oder Canyons sein
        #endregion

        #region field-values
        /// <summary>
        /// Die Hermes-spezifische Variante der tileID. Für Loggin-Zwecke.
        /// </summary>
        public long ID => Convert.ToInt64(tileID);

        /// <summary>
        /// Die ID, die das Tile auf seiner Map innehat. Wahrscheinlich ebenfalls global-gültig für Tiles.
        /// </summary>
        public int TileID
        {
            get => tileID;
            set => tileID = value;
        }

        /// <summary>
        /// Der Hermes-Type - nicht der DLaZ-Type.
        /// </summary>
        public string Type => HermesType;
        #endregion

        /// <summary>
        /// Dieser Konstruktor lädt ein Tile aus der Database basierend auf den drei ID-Parametern.
        /// </summary>
        /// <param name="WorldID">Die ID der Welt.</param>
        /// <param name="MapID">Die ID der Map, auf der sich das gewünschte Tile befindet.</param>
        /// <param name="TileID">Die ID des Tiles.</param>
        public Tile(int WorldID, int MapID, int TileID)
        {

        }

        /// <summary>
        /// Erzeugt ein leeres Tile.
        /// </summary>
        public Tile()
        {

        }
    }
}
