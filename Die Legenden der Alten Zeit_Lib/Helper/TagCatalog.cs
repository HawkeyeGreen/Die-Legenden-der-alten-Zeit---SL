using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Die_Legenden_der_Alten_Zeit_Lib.Helper
{
    public class TagCatalog
    {
        public static string PATH = "//Tags//";
        private static TagCatalog Instance;
        private TagDataDump data;

        private HashSet<string> ArtifactTags;

        private TagCatalog()
        {
            ArtifactTags = new HashSet<string>();
            if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + PATH);
            }
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH + "DataDump.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TagDataDump));
                using(Stream stream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + PATH + "DataDump.xml"))
                {
                    data = (TagDataDump)serializer.Deserialize(stream);
                }
                foreach(string tag in data.ArtifactTags)
                {
                    ArtifactTags.Add(tag);
                }
            }
            else
            {
                data.Initialize();
                Save();
            }
        }

        public static TagCatalog GetCatalog()
        {
            if(Instance == null)
            {
                Instance = new TagCatalog();
            }
            return Instance;
        }

        public void AddArtifactTag(string tag) => ArtifactTags.Add(tag);

        public void RemoveArtifactTag(string tag) => ArtifactTags.Remove(tag);

        public List<string> GetArtifactTags() => ArtifactTags.ToList();

        public void Save()
        {
            data.ArtifactTags = ArtifactTags.ToList();
            XmlSerializer serializer = new XmlSerializer(typeof(TagDataDump));
            using (Stream stream = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + PATH + "DataDump.xml"))
            {
                serializer.Serialize(stream, data);
            }
        }
    }

    [Serializable]
    public struct TagDataDump
    {
        public List<string> ArtifactTags { get; set; }

        public void Initialize()
        {
            ArtifactTags = new List<string>();
        }
    }
}
