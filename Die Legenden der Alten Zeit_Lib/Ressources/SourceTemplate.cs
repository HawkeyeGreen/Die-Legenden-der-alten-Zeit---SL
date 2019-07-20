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
    /// <summary>
    /// Represents any Type of ressource-giving Source.
    /// May give several Ressources @once.
    /// </summary>
    public class SourceTemplate
    {
        public static string PATH = "\\SourceTemplates\\";
        private static Dictionary<string, SourceTemplate> Instances = new Dictionary<string, SourceTemplate>();

        private SourceTData data;

        public string Name
        {
            get => data.Name;
            set => data.Name = value;
        }

        public List<string> Ressources
        {
            get => data.Ressources;
            set => data.Ressources = value;
        }

        private Dictionary<string, int[]> depositRanges;

        public Dictionary<string, int[]> DepositRanges
        {
            get => depositRanges;
            set
            {
                depositRanges = value;
                PushDepositRangeToData();
            }
        }

        public List<string> NeededTileAttributes
        {
            get => data.NeededTileAttributes;
            set => data.NeededTileAttributes = value;
        }

        public List<string> ForbiddenTileAttributes
        {
            get => data.ForbiddenTileAttributes;
            set => data.ForbiddenTileAttributes = value;
        }
        public int WorkPerUnit
        {
            get => data.WorkPerUnit;
            set => data.WorkPerUnit = value;
        }

        public Dictionary<string, int> RessourcesPerUnit
        {
            get => data.RessourcesPerUnit;
            set => data.RessourcesPerUnit = value;
        }

        public string DescriptionPath
        {
            get => data.RTF_Path;
            set => data.RTF_Path = value;
        }

        public SourceTemplate()
        {
            InitializeData();
            PushDepositRangeToData();
        }

        public static SourceTemplate GetTemplate(string name)
        {
            if (!Instances.ContainsKey(name))
            {
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + PATH);
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH + name + ".xml"))
                {
                    SourceTemplate template = new SourceTemplate();
                    XmlSerializer serializer = new XmlSerializer(typeof(SourceTData));
                    using (Stream stream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + PATH + name + ".xml"))
                    {
                        template.data = (SourceTData)serializer.Deserialize(stream);
                    }
                    Instances[name] = template;
                }
                else
                {
                    throw new Exception("SourceTemplate not found!");
                }
            }
            return Instances[name];
        }

        public Dictionary<string, int> Gather(int work)
        {
            Dictionary<string, int> returnMe = new Dictionary<string, int>();
            foreach (string res in Ressources)
            {
                returnMe[res] = Convert.ToInt32(Math.Round((double)(work / WorkPerUnit) * RessourcesPerUnit[res]));
            }
            return returnMe;
        }

        public void PushDepositRangeToData()
        {
            data.DepositRanges = DepositRanges.Values.ToList();
            data.DepositNames = DepositRanges.Keys.ToList();
        }

        public void InitializeData()
        {
            data = new SourceTData
            {
                WorkPerUnit = 1,
                Ressources = new List<string>(),
                RessourcesPerUnit = new Dictionary<string, int>()
            };

            DepositRanges = new Dictionary<string, int[]>
            {
                [DepositSizes.VerySmall] = new int[2],
                [DepositSizes.Small] = new int[2],
                [DepositSizes.Medium] = new int[2],
                [DepositSizes.Large] = new int[2],
                [DepositSizes.VeryLarge] = new int[2]
            };
            NeededTileAttributes = new List<string>();
            ForbiddenTileAttributes = new List<string>();
            DescriptionPath = null;
        }

        public static List<string> GetSourcesTemplates()
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

            XmlSerializer serializer = new XmlSerializer(typeof(SourceTData));
            foreach (SourceTemplate sourceT in Instances.Values)
            {
                sourceT.PushDepositRangeToData();
                try
                {
                    using (Stream file = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + PATH + "\\" + sourceT.Name + ".xml"))
                    {
                        serializer.Serialize(file, sourceT.data);
                    }
                }
                catch (Exception e)
                {
                    Hermes.getInstance().log("Error occured while saving ressource: " + e.Message, "RessourceSaver", 1);
                }
            }
        }

        public static void Save(SourceTemplate sourceT)
        {
            sourceT.PushDepositRangeToData();
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + PATH);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(RessourceData));
            try
            {
                using (Stream file = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + PATH + "\\" + sourceT.Name + ".xml"))
                {
                    serializer.Serialize(file, sourceT.data);
                }
            }
            catch (Exception e)
            {
                Hermes.getInstance().log("Error occured while saving source template: " + e.Message, "SourceTemplateSaver", 1);
            }

        }

        public static bool DoesTemplateExist(string name)
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
    public struct SourceTData
    {
        public string Name { get; set; }
        public int WorkPerUnit { get; set; }
        public List<string> Ressources { get; set; }
        public Dictionary<string, int> RessourcesPerUnit { get; set; }
        public string RTF_Path { get; set; }
        public List<int[]> DepositRanges { get; set; }
        public List<string> DepositNames { get; set; }
        public List<string> NeededTileAttributes { get; set; }
        public List<string> ForbiddenTileAttributes { get; set; }
    }
}
