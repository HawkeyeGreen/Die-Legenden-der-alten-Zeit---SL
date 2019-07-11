using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Die_Legenden_der_Alten_Zeit_Lib.Nations.Settlements
{
    public class SettlementManager
    {
        public static string SETTLEMENT_MANAGEMENT_PATH = AppDomain.CurrentDomain.BaseDirectory + "//SettlementManagement//";
        private static SettlementManager Instance;

        private Dictionary<int, string> registeredSettlementPaths;
        private SettManagerData data;

        private SettlementManager()
        {
            if (!Directory.Exists(SETTLEMENT_MANAGEMENT_PATH))
            {
                Directory.CreateDirectory(SETTLEMENT_MANAGEMENT_PATH);

            }
            if (!File.Exists(SETTLEMENT_MANAGEMENT_PATH + "ManagementData.xml"))
            {
                CreateData();
            }
            else
            {
                LoadData();
            }
            SettlementIDHelper.StartHelper(SETTLEMENT_MANAGEMENT_PATH);

        }

        private void LoadData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettManagerData));
            using (Stream file = File.OpenRead(SETTLEMENT_MANAGEMENT_PATH + "ManagementData.xml"))
            {
                data = (SettManagerData)serializer.Deserialize(file);
            }
            registeredSettlementPaths = new Dictionary<int, string>();
            for (int i = 0; i < data.SettlementIDs.Count; i++)
            {
                registeredSettlementPaths[data.SettlementIDs[i]] = data.SettlementPaths[i];
            }
        }

        private void CreateData()
        {
            data = new SettManagerData()
            {
                SettlementIDs = new List<int>(),
                SettlementPaths = new List<string>()
            };
            registeredSettlementPaths = new Dictionary<int, string>();
            XmlSerializer serializer = new XmlSerializer(typeof(SettManagerData));
            using (Stream file = File.OpenWrite(SETTLEMENT_MANAGEMENT_PATH + "ManagementData.xml"))
            {
                serializer.Serialize(file, data);
            }
        }

        public static SettlementManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SettlementManager();
            }
            return Instance;
        }

        public void Save()
        {
            SettlementIDHelper.GetIDHelper().Save();
            SaveSettManager();
        }

        private void SaveSettManager()
        {
            data.SettlementIDs = registeredSettlementPaths.Keys.ToList();
            data.SettlementPaths = registeredSettlementPaths.Values.ToList();
            XmlSerializer serializer = new XmlSerializer(typeof(SettManagerData));
            using (Stream file = File.OpenWrite(SETTLEMENT_MANAGEMENT_PATH + "ManagementData.xml"))
            {
                serializer.Serialize(file, data);
            }
        }

        /// <summary>
        /// Registriert das Settlement beim SettlementManagement und ermöglicht so fremden Settlements darauf zuzugreifen.
        /// </summary>
        /// <param name="path">Path muss den Path zur XML-Datei angeben.</param>
        /// <returns>Die zugewiesene ID des Settlements.</returns>
        public int RegisterSettlement(string path)
        {
            int ID = SettlementIDHelper.GetIDHelper().GetID();
            registeredSettlementPaths[ID] = path;
            return ID;
        }

        public void RegisterSettlement(int id, string path) => registeredSettlementPaths[id] = path;

        public void RemoveSettlement(int id)
        {
            if (registeredSettlementPaths.ContainsKey(id))
            {
                registeredSettlementPaths.Remove(id);
            }
            SettlementIDHelper.GetIDHelper().FreeID(id);
        }

        public int GetID() => SettlementIDHelper.GetIDHelper().GetID();
    }

    public struct SettManagerData
    {
        public List<string> SettlementPaths { get; set; }
        public List<int> SettlementIDs { get; set; }
    }
}
