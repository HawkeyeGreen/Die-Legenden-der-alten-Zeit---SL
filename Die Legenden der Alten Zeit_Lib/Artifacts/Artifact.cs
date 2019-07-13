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
    public class Artifact
    {
        public string Template { get; set; }
        public bool Identified { get; set; }
        public int CurrentStage { get; protected set; }
        public string Name => ArtifactTemplate.GetArtifactTemplate(Template).Name;
        public List<string> Tags => ArtifactTemplate.GetArtifactTemplate(Template).Tags;
        public string RTF => ArtifactTemplate.GetArtifactTemplate(Template).RTF[CurrentStage];
        public int NextStage => ArtifactTemplate.GetArtifactTemplate(Template).WorkNeededForNextStage[CurrentStage];
        public List<int> Buffs => ArtifactTemplate.GetArtifactTemplate(Template).Tech_Buffs[CurrentStage];
        public List<int> Techs => ArtifactTemplate.GetArtifactTemplate(Template).Technologies[CurrentStage];
        public List<string> Items => ArtifactTemplate.GetArtifactTemplate(Template).Items[CurrentStage];
        private List<int> visitedStages { get; set; }


        public bool HasNextStage()
        {
            switch (ArtifactTemplate.GetArtifactTemplate(Template).StageSelectionMode)
            {
                case "Random":
                    return visitedStages.Count < ArtifactTemplate.GetArtifactTemplate(Template).Stages;
                case "InOrder":
                default:
                    return CurrentStage < ArtifactTemplate.GetArtifactTemplate(Template).Stages;
            }
        }

        public int GetNextStage()
        {
            switch (ArtifactTemplate.GetArtifactTemplate(Template).StageSelectionMode)
            {
                case "Random":
                    List<int> possibleStages = new List<int>();
                    for(int s = 0; s < ArtifactTemplate.GetArtifactTemplate(Template).Stages; s++)
                    {
                        if(!visitedStages.Contains(s))
                        {
                            possibleStages.Add(s);
                        }
                    }
                    return possibleStages[RandomHelper.GetHelper().GetGenerator().Next(0, possibleStages.Count)];
                case "InOrder":
                default:
                    return CurrentStage++;
            }
        }

        public void SetToStage(int stage)
        {

        }


        /// <summary>
        /// Loads an Artifact from the given Path.
        /// Path needs to point to the Directory the Artifact lays in.
        /// </summary>
        /// <param name="path">The BaseDirectory of the Artifacts.</param>
        /// <param name="name">The Name of the Artifact to be loaded.</param>
        /// <returns></returns>
        public static Artifact LoadArtifact(string path, string name)
        {
            Artifact ReturnMe = new Artifact();
            XmlSerializer serializer = new XmlSerializer(typeof(Artifact));

            using (Stream file = File.OpenRead(path + "\\" + name + ".xml"))
            {
                ReturnMe = (Artifact)serializer.Deserialize(file);
            }
            return ReturnMe;
        }

        public static void SaveArtifact(string path, Artifact artifact)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Artifact));

            using (Stream file = File.OpenWrite(path + "//" + artifact.Name + ".xml"))
            {
                serializer.Serialize(file, artifact);
            }
        }

        public static List<string> GetArtifacts(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> Return = new List<string>();
            IEnumerator<string> enumerator = Directory.EnumerateFiles(path).GetEnumerator();
            while (enumerator.MoveNext())
            {
                Return.Add(Path.GetFileNameWithoutExtension(enumerator.Current));
            }
            return Return;
        }
    }
}
