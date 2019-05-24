using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe.Map.TileAttributes
{
    public class TileBaseTypes
    {
        public static string SavePath;

        private static Dictionary<string, TileBaseTypes> Instances = new Dictionary<string, TileBaseTypes>();

        private TileBaseTypeData data;
        public string Name => data.Name;
        public string RTF => data.RTF;
        public int MovementCost => data.MovementCost;
    }

    [Serializable]
    public struct TileBaseTypeData
    {
        public string Name { get; set; }
        public int MovementCost { get; set; }
        public string RTF { get; set; }
    }
}
