using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Nations.Communities
{
    public class Community
    {
        private CommunityData data;

        public long ID => data.ID;
    }

    [Serializable]
    public struct CommunityData
    {
        public long ID { get; set; }
    }
}
