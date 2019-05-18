using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeus.Hermes;

namespace Die_Legenden_der_Alten_Zeit_Lib.Nations
{
    public class NationManagement : HermesLoggable
    {
        private static NationManagement Instance;
        private NationManagementData data;

        private List<Nation> nations;

        public long ID => 1337;

        public string Type => "NationManagement";

        private NationManagement(string path)
        {
            nations = new List<Nation>();

            XmlSerializer serializer = new XmlSerializer(typeof(NationManagementData));

            if (File.Exists(path + "\\Management.xml"))
            {
                using (Stream file = File.OpenRead(path + "\\Management.xml"))
                {
                    data = (NationManagementData)serializer.Deserialize(file);
                }
            }
            else
            {
                data = new NationManagementData();
                data.nationNames = new HashSet<string>();
            }

            IEnumerator<string> enumerator = Directory.EnumerateDirectories(path).GetEnumerator();
            while(enumerator.MoveNext())
            {
                LoadNationFromPath(enumerator.Current.Substring(enumerator.Current.LastIndexOf(Path.DirectorySeparatorChar) + 1), enumerator.Current);
            }
        }

        private void LoadNationFromPath(string name, string path)
        {
            data.nationNames.Add(name);
            nations.Add(new Nation(path, name));

            Hermes.getInstance().log(this, "Loading Nation with Name " + name, 0);
        }

        public static void StartManagement(string path)
        {
            Instance = new NationManagement(path);
        }

        public static NationManagement GetManagement()
        {
            if (Instance == null)
            {
                throw new Exception("NationManagement needs to be started up before use.");
            }
            return Instance;
        }

        public void SaveState(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NationManagementData));

            using (StreamWriter file = new StreamWriter(path + "\\Management.xml"))
            {
                serializer.Serialize(file, data);
            }
        }
    }

    [Serializable]
    public struct NationManagementData
    {
        public HashSet<string> nationNames { get; set; }
    }
}
