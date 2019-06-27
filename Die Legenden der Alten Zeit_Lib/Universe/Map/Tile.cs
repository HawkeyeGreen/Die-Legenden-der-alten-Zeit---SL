using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe.Map
{
    [Serializable]
    public class Tile
    {
        private Vector2D aspect = new Vector2D(0, 1);

        public Vector2D Position { get; set; }

        /// <summary>
        /// X => Aspekt
        /// Größer gleich 0
        /// Y => Stärke
        /// Zwischen 1 und 3
        /// </summary>
        public Vector2D Aspect
        {
            get => aspect;
            set
            {
                if (value.X >= 0)
                {
                    aspect.X = value.X;
                }

                if (value.Y > 0 && value.Y < 4)
                {
                    aspect.Y = value.Y;
                }
            }
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public string Relief { get; set; }
        public string Vegetation { get; set; }
        public string Region { get; set; }

        public string Wildness { get; set; }

        public List<int> Effects { get; set; }
        public List<int> Features { get; set; }
    }

}
