using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Zeus.Hermes;

namespace Die_Legenden_der_Alten_Zeit_Lib.World.Global
{
    /// <summary>
    /// Ein Locomotor bewegt ein zugewiesenes MapObject über die Karte.
    /// Am Locomotor können verschwiedene Bewegungsweisen usw. zugewiesen werden.
    /// Auch kann es in der MainDB abgelegt werden.
    /// </summary>
    public class Locomotor : HermesLoggable
    {
        private int _ID;

        private List<string> locomotions;
        private int movement_Points;
        private MapObject mapObject;


        public long ID => _ID;
        public string Type => "Locomotor";

        public Locomotor(string arg)
        {
            if (arg.Contains("Static"))
            {
                _ID = 1338;
                locomotions = new List<string>
                {
                    "Immovable"
                };
                movement_Points = 0;
                Hermes.getInstance().log(this, "Ein statischer Locomotor wurde durch den Parameter Static erzeugt.");
            }
        }

        private Locomotor()
        {
            _ID = 1338;
            locomotions = new List<string>
            {
                "Auto-Generated",
                "Immovable"
            };
            movement_Points = 0;
            Hermes.getInstance().log(this, "Ein statischer Locomotor wurde erzeugt.");
        }

        /// <summary>
        /// Dieser Locomotor spiegel unbewegliche Objekte wider,
        /// und wird zum Beispiel bei der Initialisierung von MapObjekten standardmäßig verwendet.
        /// </summary>
        /// <returns>Locomotor ohne Bewegungsmöglichkeit.</returns>
        public static Locomotor Stationary()
        {
            Hermes.getInstance().log("Ein statischer Locomotor wurde angefragt.", "Locomotor");
            return new Locomotor();
        }
    }
}
