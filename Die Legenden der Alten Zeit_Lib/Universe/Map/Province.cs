using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe.Map
{
    public class Province
    {
        private ProvinceData data;
    }

    [Serializable]
    public struct ProvinceData
    {
        public string Name { get; set; }
        public List<string> Regions { get; set; }
        public string Owner { get; set; }
    }
}
