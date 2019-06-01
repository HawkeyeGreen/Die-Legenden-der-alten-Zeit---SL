using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Die_Legenden_der_Alten_Zeit_Lib
{
    /// <summary>
    /// Remember to first Start the SettlementIDHelper in order to initialize the ID Chache.
    /// </summary>
    public class SettlementIDHelper
    {
        public static string PATH;
        private static SettlementIDHelper Instance;

        private SettlementIDHelperData data;

        public int MaxID
        {
            get => data.MaxID;
            protected set => data.MaxID = value;
        }

        private Queue<int> FreedIDs
        {
            get => data.FreedIDs;
            set => data.FreedIDs = value;
        }

        private SettlementIDHelper()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettlementIDHelperData));

            if (File.Exists(PATH + "\\SettlementIDHelper.xml"))
            {
                using (Stream file = File.OpenRead(PATH + "\\SettlementIDHelper.xml"))
                {
                    data = (SettlementIDHelperData)serializer.Deserialize(file);
                }
            }
            else
            {
                data = new SettlementIDHelperData
                {
                    MaxID = 0,
                    FreedIDs = new Queue<int>()
                };
            }
        }

        /// <summary>
        /// Starts the SettlementIDHelper-System up so it can take on new ID-Requests.
        /// </summary>
        /// <param name="path"></param>
        public static void StartHelper(string path)
        {
            PATH = path;
            Instance = new SettlementIDHelper();
        }

        public SettlementIDHelper GetIDHelper()
        {
            return Instance;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettlementIDHelperData));

            using (StreamWriter file = new StreamWriter(PATH + "\\SettlementIDHelper.xml"))
            {
                serializer.Serialize(file, data);
            }
        }

        public int GetID()
        {
            int ID;
            if(FreedIDs.Count > 0)
            {
                ID = FreedIDs.Dequeue();
            }
            else
            {
                ID = MaxID;
                MaxID++;
            }
            return ID;
        }

        public void FreeID(int ID)
        {
            FreedIDs.Enqueue(ID);
        }
    }

    [Serializable]
    public struct SettlementIDHelperData
    {
        public int MaxID { get; set; }
        public Queue<int> FreedIDs { get; set; }
    }

}
