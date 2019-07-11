using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Zeus.Metis.Pythagoras;

namespace Die_Legenden_der_Alten_Zeit_Lib.Nations.Settlements
{
    public class Settlement
    {
        private SettlementData data;
        private string path;
        public int ID
        {
            get => data.ID;
            protected set => data.ID = value;
        }
        public int ParentCityID
        {
            get => data.ParentCity;
            set => data.ParentCity = value;
        }
        public Settlement Liege
        {
            get;
            set;
        }
        public string Name
        {
            get => data.Name;

            set => data.Name = value;
        }
        public string Map => data.Map;
        public long Community
        {
            get => data.Community;
            set => data.Community = value;
        }
        public Vector2D Position => data.Position;
        public List<int> PropertyIDs
        {
            get => data.ChildCities;
            set => data.ChildCities = value;
        }
        public List<Settlement> Properties { get; set; }

        /// <summary>
        /// Erstellt ein neues, leeres Settlement. Im Pfad wird ein XML-Dokument mit der ID des Settlements angelegt.
        /// </summary>
        /// <param name="dataPath"></param>
        public Settlement(string basePath, string name)
        {
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            data = new SettlementData()
            {
                ID = SettlementManager.GetInstance().GetID(),
                Name = name,
                Map = "Das Nichts",
                Community = -1,
                Position = new Vector2D(),
                ParentCity = -1,
                ChildCities = new List<int>()
            };
            path = basePath + ID + ".xml";
            Save();
            SettlementManager.GetInstance().RegisterSettlement(ID, path);
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettlementData));
            using(Stream file = File.OpenWrite(path))
            {
                serializer.Serialize(file, data);
            }
        }
    }

    [Serializable]
    public struct SettlementData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public long Community { get; set; }
        public Vector2D Position { get; set; }
        public int ParentCity { get; set; }
        public List<int> ChildCities { get; set; }
    }
}
