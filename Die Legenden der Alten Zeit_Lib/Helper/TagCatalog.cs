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
        public static string PATH = AppDomain.CurrentDomain.BaseDirectory + "//Tags//";
        private static TagCatalog Instance;
        private TagDataDump data;

        private HashSet<string> ArtifactTags;

        private TagCatalog()
        {
            ArtifactTags = new HashSet<string>();
            if(!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }
            if(File.Exists(PATH + "DataDump.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TagDataDump));
                using(Stream stream = File.OpenRead(PATH + "DataDump.xml"))
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
            XmlSerializer serializer = new XmlSerializer(typeof(TagDataDump));
            using (Stream stream = File.OpenWrite(PATH + "DataDump.xml"))
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
