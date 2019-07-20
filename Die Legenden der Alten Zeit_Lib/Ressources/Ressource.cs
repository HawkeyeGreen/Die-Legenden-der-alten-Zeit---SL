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
        public static string PATH = "\\Ressources\\";
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
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + PATH);
            }

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH + name + ".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RessourceData));
                using (Stream stream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + PATH + name + ".xml"))
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
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + PATH);
            }

            List<string> Return = new List<string>();
            IEnumerator<string> enumerator = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory + PATH).GetEnumerator();
            while (enumerator.MoveNext())
            {
                Return.Add(Path.GetFileNameWithoutExtension(enumerator.Current));
            }
            return Return;
        }

        public static void Save()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + PATH);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(RessourceData));
            foreach (Ressource ressource in Instances.Values)
            {
                try
                {
                    using (Stream file = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + PATH + "\\" + ressource.Name + ".xml"))
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
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + PATH);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(RessourceData));

            try
            {
                using (Stream file = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + PATH + "\\" + ressource.Name + ".xml"))
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

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH + name + ".xml"))
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
