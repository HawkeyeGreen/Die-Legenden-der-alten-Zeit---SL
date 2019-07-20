using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Die_Legenden_der_Alten_Zeit_Lib.Artifacts
{
    [Serializable]
    public class ArtifactTemplate
    {
        [NonSerialized]
        private static Dictionary<string, ArtifactTemplate> Instances = new Dictionary<string, ArtifactTemplate>();
        [NonSerialized]
        public static string PATH = "//ArtifactTemplates";
        [NonSerialized]
        public static readonly string SELECTIONMODE_INORDER = "InOrder";
        [NonSerialized]
        public static readonly string SELECTIONMODE_RANDOM = "Random";

        public int Stages { get; set; }
        public string StageSelectionMode { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public int CultureWorth { get; set; }
        public string BaseDescriptionRTF { get; set; }
        public List<string> StageNames { get; set; }
        public List<string> RTF { get; set; }
        public List<string> Tags { get; set; }
        public List<int> WorkNeededForNextStage { get; set; }
        public List<List<int>> Technologies { get; set; }
        public List<List<int>> Tech_Buffs { get; set; }
        public List<List<string>> Items { get; set; }

        public ArtifactTemplate()
        {
            Name = "Undefined";
            Stages = 1;
            StageSelectionMode = SELECTIONMODE_INORDER;
            RTF = new List<string>();
            WorkNeededForNextStage = new List<int>
            {
                1
            };
            Technologies = new List<List<int>>
            {
                new List<int>()
            };
            Tech_Buffs = new List<List<int>>()
            {
                new List<int>()
            };
            Items = new List<List<string>>()
            {
                new List<string>()
            };
            Tags = new List<string>();
        }

        public static ArtifactTemplate GetArtifactTemplate(string name)
        {
            if (!Instances.ContainsKey(name))
            {
                Instances[name] = LoadArtifactTemplate(name);
            }

            return Instances[name];
        }

        /// <summary>
        /// Loads an Artifact from the given Path.
        /// Path needs to point to the Directory the Artifact lays in.
        /// </summary>
        /// <param name="path">The BaseDirectory of the Artifacts.</param>
        /// <param name="name">The Name of the Artifact to be loaded.</param>
        /// <returns></returns>
        public static ArtifactTemplate LoadArtifactTemplate(string name)
        {
            ArtifactTemplate ReturnMe = new ArtifactTemplate();
            XmlSerializer serializer = new XmlSerializer(typeof(ArtifactTemplate));

            using (Stream file = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + PATH + "\\" + name + ".xml"))
            {
                ReturnMe = (ArtifactTemplate)serializer.Deserialize(file);
            }
            return ReturnMe;
        }

        public static void SaveArtifactTemplate(ArtifactTemplate artifact)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + PATH);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ArtifactTemplate));

            using (Stream file = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + PATH + "//" + artifact.Name + ".xml"))
            {
                serializer.Serialize(file, artifact);
            }
        }

        public static List<string> GetArtifactTemplates()
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
    }
}
