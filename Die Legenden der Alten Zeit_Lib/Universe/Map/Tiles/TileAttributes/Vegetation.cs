using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe.Map.TileAttributes
{
    public class Vegetation
    {
        public static string SavePath { get; set; }

        private static Dictionary<string, Vegetation> Instances = new Dictionary<string, Vegetation>();

        private VegetationData data;

        public string Name => data.Name;
        public string RTF => data.RTF;
        public int MovementCost => data.MovementCost;

        private Vegetation(string Name)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VegetationData));

            using (Stream file = File.OpenRead(SavePath + "\\" + Name + ".xml"))
            {
                data = (VegetationData)serializer.Deserialize(file);
            }
        }

        public Vegetation(string Name, string RTF, int MovementCost)
        {
            data = new VegetationData
            {
                Name = Name,
                RTF = RTF,
                MovementCost = MovementCost
            };
        }

        public static Vegetation GetVegetation(string Name)
        {
            if (!Instances.ContainsKey(Name))
            {
                Instances[Name] = new Vegetation(Name);
            }
            return Instances[Name];
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VegetationData));

            Directory.CreateDirectory(SavePath);

            using (StreamWriter file = new StreamWriter(SavePath + "\\" + data.Name + ".xml"))
            {
                serializer.Serialize(file, data);
            }
        }
    }

    [Serializable]
    public struct VegetationData
    {
        public string Name { get; set; }
        public string RTF { get; set; }
        public int MovementCost { get; set; }

        public List<string> ForbiddenBaseTypes { get; set; }
    }
}