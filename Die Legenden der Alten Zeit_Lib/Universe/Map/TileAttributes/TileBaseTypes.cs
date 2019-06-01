using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe.Map.TileAttributes
{
    public class TileBaseType
    {
        public static string SavePath;

        private static Dictionary<string, TileBaseType> Instances = new Dictionary<string, TileBaseType>();

        private TileBaseTypeData data;
        public string Name => data.Name;
        public string RTF => data.RTF;
        public int MovementCost => data.MovementCost;

        private TileBaseType(string Name)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TileBaseTypeData));

            using (Stream file = File.OpenRead(SavePath + "\\" + Name + ".xml"))
            {
                data = (TileBaseTypeData)serializer.Deserialize(file);
            }
        }

        public TileBaseType(string Name, string RTF, int MovementCost)
        {
            data = new TileBaseTypeData
            {
                Name = Name,
                RTF = RTF,
                MovementCost = MovementCost
            };
        }

        public static TileBaseType GetBaseType(string Name)
        {
            if (!Instances.ContainsKey(Name))
            {
                Instances[Name] = new TileBaseType(Name);
            }
            return Instances[Name];
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TileBaseTypeData));

            Directory.CreateDirectory(SavePath);

            using (StreamWriter file = new StreamWriter(SavePath + "\\" + data.Name + ".xml"))
            {
                serializer.Serialize(file, data);
            }
        }
    }

    [Serializable]
    public struct TileBaseTypeData
    {
        public string Name { get; set; }
        public int MovementCost { get; set; }
        public string RTF { get; set; }
    }
}
