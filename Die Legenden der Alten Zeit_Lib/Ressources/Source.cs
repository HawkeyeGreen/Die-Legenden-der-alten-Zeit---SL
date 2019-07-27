using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Ressources
{
    [Serializable]
    public class Source
    {
        public int TemplateID { get; protected set; }
        public SourceTemplate Template { get; protected set; }
        public int Amount { get; set; }


        public Dictionary<string, int> DoWorkOnSource(int work) => GetRessources(GetUnits(work));

        private int GetUnits(int work) => Convert.ToInt32(Math.Round(Convert.ToDouble(work / Template.WorkPerUnit), MidpointRounding.AwayFromZero));

        private Dictionary<string, int> GetRessources(int units)
        {
            Dictionary<string, int> Ressources = new Dictionary<string, int>();
            foreach (string res in Template.Ressources)
            {
                Ressources[res] = units * Template.RessourcesPerUnit[res];
            }
            return Ressources;
        }
    }
}
