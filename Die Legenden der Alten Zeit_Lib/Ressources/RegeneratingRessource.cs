using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Ressources
{
    public class RegeneratingRessource : BaseRessource
    {
        public const string FIXED_VALUE_REGENERATION = "Fixed";

        private RegenRessourceData regenData;
        public string RegenerationWay => regenData.RegenerationWay;
        public int RegenAmount => regenData.RegenAmount;

        public override int RoundUpdate(int amount)
        {
            base.RoundUpdate(amount);
            switch (RegenerationWay)
            {
                case FIXED_VALUE_REGENERATION:
                    amount += RegenAmount;
                    return amount;
                default:
                    return amount;
            }
        }
    }

    [Serializable]
    public struct RegenRessourceData
    {
        public string RegenerationWay { get; set; }
        public int RegenAmount { get; set; }
    }
}
