using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Zeus.Hermes;

namespace Die_Legenden_der_Alten_Zeit_Lib.Ressources
{
    public class Ressource
    {
        public static string PATH = AppDomain.CurrentDomain.BaseDirectory + "\\Ressources\\";
        private static Dictionary<string, Ressource> Instances = new Dictionary<string, Ressource>();

        #region Properties & Fields
        private RessourceData data;
        public string Name => data.Name;
        public string DescriptionPath
        {
            get => data.RTF_Description_Path;
            set => data.RTF_Description_Path = value;
        }
               
        #endregion

        private void InitializeData()
        {
            DescriptionPath = null;
        }


        public Ressource(string name)
        {
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }

            if (File.Exists(PATH + name + ".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RessourceData));
                using (Stream stream = File.OpenRead(PATH + name + ".xml"))
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
            if (!Instances.ContainsKey(name))
            {
                Instances[name] = new Ressource(name);
            }
            return Instances[name];
        }

        public static List<string> GetRessourceNames()
        {
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }

            List<string> Return = new List<string>();
            IEnumerator<string> enumerator = Directory.EnumerateFiles(PATH).GetEnumerator();
            while (enumerator.MoveNext())
            {
                Return.Add(Path.GetFileNameWithoutExtension(enumerator.Current));
            }
            return Return;
        }

        public static void Save()
        {
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(RessourceData));
            foreach (Ressource ressource in Instances.Values)
            {
                try
                {
                    using (Stream file = File.OpenWrite(PATH + "\\" + ressource.Name + ".xml"))
                    {
                        serializer.Serialize(file, ressource.data);
                    }
                }
                catch (Exception e)
                {
                    Hermes.getInstance().log("Error occured while saving ressource: " + e.Message, "RessourceSaver", 1);
                }
            }
        }

        public static void Save(Ressource ressource)
        {
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(RessourceData));

            try
            {
                using (Stream file = File.OpenWrite(PATH + "\\" + ressource.Name + ".xml"))
                {
                    serializer.Serialize(file, ressource.data);
                }
            }
            catch (Exception e)
            {
                Hermes.getInstance().log("Error occured while saving ressource: " + e.Message, "RessourceSaver", 1);
            }

        }

        public static bool DoesRessourceExist(string name)
        {
            if (Instances.ContainsKey(name))
            {
                return true;
            }

            if (File.Exists(PATH + name + ".xml"))
            {
                return true;
            }

            return false;
        }
    }

    [Serializable]
    public struct RessourceData
    {
        public string Name { get; set; }
        public string RTF_Description_Path { get; set; }
        
    }
}
