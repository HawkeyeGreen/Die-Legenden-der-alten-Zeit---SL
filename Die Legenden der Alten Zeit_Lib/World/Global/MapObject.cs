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
    /// Ein MapObject ist die Repräsentation eines beliebigen Spielobjekts auf der Karte.
    /// Es hat keine Kenntnis davon, was es ist, hält aber alles bereit,
    /// dass ein anderes Objekt brauchen könnte, um zu entscheiden, was es repräsentiert.
    /// </summary>
    public class MapObject : HermesLoggable
    {
        // ID und Typ des Objektes, die das MapObject repräsentiert
        private string represented_Type;
        private int represented_ID;
        
        private int mapID;
        private int own_ID;
        private Vector2 position;

        // Der String, welcher auf die Grafik verweist,
        // welche dieses MapObject repräsentiert.
        private string graphic;

        private Locomotor locomotor = Locomotor.Stationary();

        // Hermes-Schnitstelle
        public long ID => own_ID;
        public string Type => represented_Type + "_MapObject";

        /// <summary>
        /// Der Typ des repräsentierten Objektes.
        /// </summary>
        public string Represented_Type
        {
            get => represented_Type;
            set => represented_Type = value;
        }

        public int Represented_ID
        {
            get => represented_ID;
            set => represented_ID = value;
        }
    }
}
