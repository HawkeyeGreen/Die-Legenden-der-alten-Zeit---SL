using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe
{
    public class WorldSpace
    {
        #region Management
        private static Dictionary<string, WorldSpace> Instances = new Dictionary<string, WorldSpace>();
        private static Dictionary<string, string> RegisteredPaths = null;
        private static WorldSpaceInstanceManagement manData;
        public static string PATH = "//Spaces//World//";
        #endregion

        #region WorldSpace
        private WorldSpaceData data;
        public GameSpace GameSpace { get; protected set; }
        public string Key { get; protected set; }
        #endregion

        private WorldSpace(string Key)
        {
            if (!File.Exists(RegisteredPaths[Key]))
            {
                throw new Exception("Path not valid!");
            }
            this.Key = Key;
            Load();
        }

        public WorldSpace(string key, string path, GameSpace gameSpace)
        {
            RegisterPath(key, path);
            Key = key;
            data = new WorldSpaceData()
            {
                GameSpace = gameSpace.Key
            };
        }

        #region WorldSpace
        public void Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WorldSpaceData));
            using (Stream file = File.OpenRead(RegisteredPaths[Key]))
            {
                data = (WorldSpaceData)serializer.Deserialize(file);
            }
        }

        public void Save()
        {

        }
        #endregion

        #region Management
        public static WorldSpace GetWorldSpace(string Key)
        {
            if (RegisteredPaths == null)
            {
                BuildPathCache();
                return null;
            }

            if (!Instances.ContainsKey(Key))
            {
                if (RegisteredPaths.ContainsKey(Key))
                {
                    Instances[Key] = new WorldSpace(Key);
                }
                else
                {
                    throw new Exception("Key not found. Is it registered?");
                }
            }

            return Instances[Key];
        }

        private static void BuildPathCache()
        {
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH))
            {
                // Directory Exists => Look for File
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH + "man.xml"))
                {
                    ReadManFile();
                }
                else
                {
                    CreateManFile();
                }
            }
            else
            {
                // Create Path
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + PATH);
                // Create Man-File
                CreateManFile();
            }
        }

        /// <summary>
        /// Creates the needed ManagementFile in the Path.
        /// </summary>
        private static void CreateManFile()
        {
            manData = new WorldSpaceInstanceManagement()
            {
                ListedKeys = new List<string>(),
                ListedPaths = new List<string>()
            };
            XmlSerializer serializer = new XmlSerializer(typeof(WorldSpaceInstanceManagement));
            using (Stream file = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + PATH + "man.xml"))
            {
                serializer.Serialize(file, manData);
            }
        }

        private static void ReadManFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WorldSpaceInstanceManagement));
            using (Stream file = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + PATH + "man.xml"))
            {
                manData = (WorldSpaceInstanceManagement)serializer.Deserialize(file);
            }
            LoadRegisteredPaths();
        }

        private static void LoadRegisteredPaths()
        {
            RegisteredPaths = new Dictionary<string, string>();
            for (int i = 0; i < manData.ListedKeys.Count; i++)
            {
                RegisteredPaths[manData.ListedKeys[i]] = manData.ListedPaths[i];
            }
        }

        private static void SaveRegisteredPaths()
        {
            manData.ListedKeys = RegisteredPaths.Keys.ToList();
            manData.ListedPaths = RegisteredPaths.Values.ToList();
        }

        public static void SaveManFile()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + PATH))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + PATH);
                CreateManFile();
            }
            else
            {
                SaveRegisteredPaths();
                XmlSerializer serializer = new XmlSerializer(typeof(WorldSpaceInstanceManagement));
                using (Stream file = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + PATH + "man.xml"))
                {
                    serializer.Serialize(file, manData);
                }
            }
        }

        public static void RegisterPath(string key, string path)
        {
            if (RegisteredPaths == null)
            {
                BuildPathCache();
            }
            RegisteredPaths[key] = path;
        }

        #endregion
    }

    [Serializable]
    public struct WorldSpaceData
    {
        public string GameSpace { get; set; }
    }

    [Serializable]
    public struct WorldSpaceInstanceManagement
    {
        public List<string> ListedKeys { get; set; }
        public List<string> ListedPaths { get; set; }
    }
}
