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
    /// Remember to first Start the PawnHelper in order to initialize the ID Chache.
    /// </summary>
    public class PawnIDHelper
    {
        public static string PATH;
        private static PawnIDHelper Instance;

        private PawnIDHelperData data;

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

        private PawnIDHelper()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PawnIDHelperData));

            if (File.Exists(PATH + "\\PawnIDHelper.xml"))
            {
                using (Stream file = File.OpenRead(PATH + "\\PawnIDHelper.xml"))
                {
                    data = (PawnIDHelperData)serializer.Deserialize(file);
                }
            }
            else
            {
                data = new PawnIDHelperData
                {
                    MaxID = 0,
                    FreedIDs = new Queue<int>()
                };
            }
        }

        /// <summary>
        /// Starts the PawnIDHelper-System up so it can take on new ID-Requests.
        /// </summary>
        /// <param name="path"></param>
        public static void StartHelper(string path)
        {
            PATH = path;
            Instance = new PawnIDHelper();
        }

        public static PawnIDHelper GetIDHelper()
        {
            return Instance;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PawnIDHelperData));

            using (StreamWriter file = new StreamWriter(PATH + "\\PawnIDHelper.xml"))
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
    public struct PawnIDHelperData
    {
        public int MaxID { get; set; }
        public Queue<int> FreedIDs { get; set; }
    }

}
