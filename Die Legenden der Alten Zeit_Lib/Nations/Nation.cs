using System;
using System.Xml.Serialization;
using System.IO;

namespace Die_Legenden_der_Alten_Zeit_Lib.Nations
{
    public class Nation
    {

        private NationData data;

        public Nation(NationData nationData)
        {
            data = nationData;
        }

        public Nation(string path, string name)
        {
            LoadFrom(path, name);
        }

        public void SaveTo(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NationData));

            Directory.CreateDirectory(path + "\\" + data.Name + "\\");

            using (StreamWriter file = new StreamWriter(path + "\\" + data.Name + "\\" + data.Name + ".xml"))
            {
                serializer.Serialize(file, data);
            }
        }

        public void LoadFrom(string path, string name)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NationData));

            using (Stream file = File.OpenRead(path + "\\" + name + ".xml"))
            {
                data = (NationData)serializer.Deserialize(file);
            }
        }
    }

    [Serializable]
    public struct NationData
    {
        public string Name { get; set; }

        public NationData(string name)
        {
            Name = name;
        }
    }
}
