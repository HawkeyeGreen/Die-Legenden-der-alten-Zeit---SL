using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Nations.Settlements
{
    public class Settlement
    {
        private SettlementData data;

        public int ID => data.ID;
        public int ParentCity
        {
            get => data.ParentCity;
            set => data.ParentCity = value;
        }

        public string Name
        {
            get => data.Name;

            set => data.Name = value;
        }
        public string Map => data.Map;

        public long Community
        {
            get => data.Community;
            set => data.Community = value;
        }

        public Vector2D Position => data.Position;
        public List<int> ChildCities
        {
            get => data.ChildCities;
            set => data.ChildCities = value;
        }
    }

    [Serializable]
    public struct SettlementData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public long Community { get; set; }
        public Vector2D Position { get; set; }
        public int ParentCity { get; set; }
        public List<int> ChildCities { get; set; }
    }
}
