using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe.Map
{
    public class Region
    {
        private RegionData data;

    }

    [Serializable]
    public struct RegionData
    {
        public string Name { get; set; }
        public string MemberProvince { get; set; }
        public string Owner { get; set; }
        public string RegionalCentre { get; set; }
    }
}
