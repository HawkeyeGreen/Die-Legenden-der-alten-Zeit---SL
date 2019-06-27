using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Zeus.Hermes;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe.Aspects
{
    [Serializable]
    public class Aspect
    {
        [NonSerialized]
        public static string PATH = AppDomain.CurrentDomain.BaseDirectory + "//Aspects";
        [NonSerialized]
        private static Dictionary<string, Aspect> Instances = new Dictionary<string, Aspect>();

        public string Name { get; set; }

        public string[] RankNames { get; set; }

        /// <summary>
        /// Providing access to the names of the different aspects strength names.
        /// Only allowed index range is from 1 to 3 (inclusive).
        /// Internal representation is array based.
        /// </summary>
        /// <param name="i">R=[1,3]</param>
        /// <returns>Rankname as string.</returns>
        public string this[int i]
        {
            get
            {
                if(i >= 1 || i <= 3)
                {
                    return RankNames[i - 1];
                }
                throw new IndexOutOfRangeException("Aspects only provide the index range from 1 to 3 (incl.).");
            }
            set
            {
                if (i >= 1 || i <= 3)
                {
                    RankNames[i - 1] = value;
                }
                throw new IndexOutOfRangeException("Aspects only provide the index range from 1 to 3 (incl.).");
            }
        }

        public Aspect()
        {
            Name = "TBD";
            RankNames = new string[3] { "Schwach", "Mittel", "Stark" };
        }

        public Aspect(string name)
        {
            Name = name;
            RankNames = new string[3] { "Schwach", "Mittel", "Stark" };            
        }

        public Aspect (string name, string[] rankedName)
        {
            Name = name;
            RankNames = new string[3];
            int i;

            for (i = 0; i < rankedName.Length; i++)
            {
                if(i > 2)
                {
                    break;
                }
                RankNames[i] = rankedName[i];
            }

            if(i < 3)
            {
                while(i < 3)
                {
                    RankNames[i] = "Undefined!";
                    i++;
                }
            }
        }

        public static Aspect GetAspect(string name)
        {
            if(!Instances.ContainsKey(name))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Aspect));

                    using (Stream file = File.OpenRead(PATH + "\\" + name + ".xml"))
                    {
                        Instances[name] = (Aspect)serializer.Deserialize(file);
                        Hermes.getInstance().log("Loaded aspect: " + Instances[name].ToString(), "AspectLoader", 4);
                    }
                }
                catch(Exception e)
                {
                    Hermes.getInstance().log(e.Message, "AspectLoader", 0);
                    AddAspect(new Aspect(name));
                }
            }

            return Instances[name];
        }

        public static void AddAspect(Aspect aspect)
        {
            Instances[aspect.Name] = aspect;
            Hermes.getInstance().log("Added aspect: " + aspect.ToString(), "Aspects", 3);
        }

        public static void Save()
        {
            if(!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Aspect));
            foreach(Aspect aspect in Instances.Values)
            {
                try
                {
                    using (Stream file = File.OpenWrite(PATH + "\\" + aspect.Name + ".xml"))
                    {
                        serializer.Serialize(file, aspect);
                    }
                }
                catch(Exception e)
                {

                }
            }
        }

        public static List<string> GetAspectNames()
        {
            List<string> Return = new List<string>();
            IEnumerator<string> enumerator = Directory.EnumerateFiles(PATH).GetEnumerator();
            while(enumerator.MoveNext())
            {
                Return.Add(Path.GetFileNameWithoutExtension(enumerator.Current));
            }
            return Return;
        }

        public override string ToString()
        {
            return "Aspect: " + Name + "\n [1]: " + RankNames[0] + "\n [2]: " + RankNames[1] + "\n [3]: " + RankNames[2];
        }

    }
}
