using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe
{
    public class WorldSpace
    {
        public static string PATH = AppDomain.CurrentDomain.BaseDirectory + "//Spaces//World//";

        private WorldSpaceData data;
        public GameSpace GameSpace { get; protected set; }
    }

    [Serializable]
    public struct WorldSpaceData
    {
        public string GameSpace { get; set; }
    }
}
