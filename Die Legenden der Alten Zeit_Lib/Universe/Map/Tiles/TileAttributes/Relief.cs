using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe.Map.TileAttributes
{
    public class Relief
    {
        public static string SavePath;

        private static Dictionary<string, Relief> Instances = new Dictionary<string, Relief>();

        private ReliefData data;
        public string Name => data.Name;
        public string RTF => data.RTF;
        public int MovementCost => data.MovementCost;

        private Relief(string Name)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ReliefData));

            using (Stream file = File.OpenRead(SavePath + "\\" + Name + ".xml"))
            {
                data = (ReliefData)serializer.Deserialize(file);
            }
        }

        public Relief(string Name, string RTF, int MovementCost)
        {
            data = new ReliefData
            {
                Name = Name,
                RTF = RTF,
                MovementCost = MovementCost
            };
        }

        public static Relief GetRelief(string Name)
        {
            if (!Instances.ContainsKey(Name))
            {
                Instances[Name] = new Relief(Name);
            }
            return Instances[Name];
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ReliefData));

            Directory.CreateDirectory(SavePath);

            using (StreamWriter file = new StreamWriter(SavePath + "\\" + data.Name + ".xml"))
            {
                serializer.Serialize(file, data);
            }
        }
    }

    [Serializable]
    public struct ReliefData
    {
        public string Name { get; set; }
        public int MovementCost { get; set; }
        public string RTF { get; set; }
    }
}
