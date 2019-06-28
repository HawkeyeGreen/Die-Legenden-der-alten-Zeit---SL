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

        public int WorkPerUnit
        {
            get => data.WorkPerUnit;
            set => data.WorkPerUnit = value;
        }

        public Dictionary<string, int> RessourcesPerUnit
        {
            get => data.RessourcesPerUnit;
            set => data.RessourcesPerUnit = value;
        }

        public Dictionary<string, int> Gather(int work)
        {
            Dictionary<string, int> returnMe = new Dictionary<string, int>();
            foreach (string res in Ressources)
            {
                returnMe[res] = Convert.ToInt32(Math.Round((double)(work / WorkPerUnit) * RessourcesPerUnit[res]));
            }
            return returnMe;
        }

        public void InitializeData()
        {
            data = new SourceData
            {
                WorkPerUnit = 1,
                Ressources = new List<string>(),
                RessourcesPerUnit = new Dictionary<string, int>()
            };
        }
    }

    [Serializable]
    public struct SourceData
    {
        public int WorkPerUnit { get; set; }
        public List<string> Ressources { get; set; }
        public Dictionary<string, int> RessourcesPerUnit { get; set; }
        public string RTF_Path { get; set; }
    }
}
