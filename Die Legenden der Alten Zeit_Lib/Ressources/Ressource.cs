using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Die_Legenden_der_Alten_Zeit_Lib.Ressources
{
    public class Ressource
    {
        private static string Path = AppDomain.CurrentDomain.BaseDirectory + "\\Ressources\\";
        private static Dictionary<string, Ressource> instances = new Dictionary<string, Ressource>();

        #region Properties & Fields
        private RessourceData data;
        public string Name => data.Name;
        public string DescriptionPath
        {
            get => data.RTF_Description_Path;
            set => data.RTF_Description_Path = value;
        }
        public Dictionary<string, int[]> DepositRanges
        {
            get => data.DepositRanges;
            set => data.DepositRanges = value;
        }

        public List<string> NeededTileAttributes
        {
            get => data.NeededTileAttributes;
            set => data.NeededTileAttributes = value;
        }

        public List<string> ForbiddenTileAttributes
        {
            get => data.ForbiddenTileAttributes;
            set => data.ForbiddenTileAttributes = value;
        }

        #endregion

        private void InitializeData()
        {
            DepositRanges = new Dictionary<string, int[]>
            {
                [DepositSizes.VerySmall] = new int[2],
                [DepositSizes.Small] = new int[2],
                [DepositSizes.Medium] = new int[2],
                [DepositSizes.Large] = new int[2],
                [DepositSizes.VeryLarge] = new int[2]
            };
            NeededTileAttributes = new List<string>();
            ForbiddenTileAttributes = new List<string>();
        }

        public Ressource(string name)
        {
            if (File.Exists(Path + name + ".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RessourceData));
                using (Stream stream = File.OpenRead(Path + name + ".xml"))
                {
                    data = (RessourceData)serializer.Deserialize(stream);
                }
            }
            else
            {
                data = new RessourceData()
                {
                    Name = name
                };
                InitializeData();
            }
        }

        public static Ressource GetRessource(string name)
        {
            if (!instances.ContainsKey(name))
            {
                instances[name] = new Ressource(name);
            }
            return instances[name];
        }
    }

    [Serializable]
    public struct RessourceData
    {
        public string Name { get; set; }
        public string RTF_Description_Path { get; set; }
        public Dictionary<string, int[]> DepositRanges { get; set; }

        public List<string> NeededTileAttributes { get; set; }
        public List<string> ForbiddenTileAttributes { get; set; }
    }
}
