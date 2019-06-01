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
        public Vector2D Position {get; set;}
        public int ID { get; set; }
        public string Type { get; set; }
        public string Relief { get; set; }
        public string Vegetation { get; set; }
        public string Region { get; set; }
        public List<int> Effects { get; set; }
        public List<int> Features { get; set; }
        public Dictionary<string, int> Ressources { get; set; }
    }

}
