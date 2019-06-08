using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Ressources
{
    /// <summary>
    /// Represents any Type of ressource-giving Source.
    /// May give several Ressources @once.
    /// </summary>
    public class Source
    {
        private SourceData data;
        public List<string> Ressources
        {
            get => data.Ressources;
            set => data.Ressources = value;
        }

        public Dictionary<string, int> Gather(int work)
        {
            Dictionary<string, int> returnMe = new Dictionary<string, int>();
            foreach(string res in Ressources)
            {
                int neededWork = Ressource.GetRessource(res).WorkPerUnit;
                if(work > neededWork)
                {
                    int amount = Convert.ToInt32(Math.Floor(Convert.ToDouble(work / neededWork)));
                    returnMe[res] = amount;
                }
            }
            return returnMe;
        }
    }

    [Serializable]
    public struct SourceData
    {
        public List<string> Ressources { get; set; }
    }
}
