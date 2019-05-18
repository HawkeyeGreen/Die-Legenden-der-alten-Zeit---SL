//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Zeus.Hermes;

//namespace Die_Legenden_der_Alten_Zeit_Lib.Nations.StorageMeans
//{
//    /// <summary>
//    /// Storages halten die Ressourcen, die zur Verfügung stehen.
//    /// Sie besitzen eine allgemeine Kapazität sowie spezialisierte Kapazitäten.
//    /// Benötigt ein Nutzer gewisse Ressourcen, so stellt er einen Request an sein lokales Storage.
//    /// Sollte dieser Storage nicht über die benötigten Ressourcen verfügen, so fragt er zuerst bei seinen boundStorages nach (von 0 bis x)
//    /// und sollten diese ebenfalls nicht über die Ressourcen verfügen, so pusht er eine Anfrage nach oben.
//    /// Der Request enthält einen Verweis auf den Storage und das benötigte Gut.
//    /// Der Storage behält seine Anfrage vor und wenn ein Storage das Gut hat, dann markiert es die Anfrage als befüllt.
//    /// </summary>
//    class Storage : HermesLoggable
//    {
//        private int _ID;

//        // Dies sind die verbundenen Storages
//        // Die bound sind all jene, deren parent dieser Storage ist (null, wenn Kachel-Storage)
//        // Der parent Storage ist der übergeordnete Storage dieses Storage (null, wenn CapitalStorage)
//        List<List<Storage>> boundStorages;
//        Storage parentStorage;

//        // Der Request-Bereich
//        // Die offenen Requests können von außen eingesehen werden (aber nicht bearbeitet).
//        // Wenn ein Storage ein Request zumindest teilweise erfüllen kann, dann nutzt es die passende Methode, um die Order zu erfüllen.
//        // Die runningRequests 
//        private static int highestRequestID = 0;
//        List<StorageRequest> openRequests = new List<StorageRequest>();
//        Dictionary<int, int> runningRequests = new Dictionary<int, int>(); // Der Key ist die RequestID, der Value ist die DeliveryID.

//        // Dieser Bereich deklariert alle nötigen Variablen für die 
//        private int generalStoragespace = 100;
//        private Dictionary<string, int> specializedStorage = new Dictionary<string, int>();
//        private Dictionary<string, int> respecificStorage = new Dictionary<string, int>();

//        public long ID => _ID;
//        public string Type => "Storage";

//        // Die tatsächlich in diesem Storage gespeicherten Waren und ihre Mengen
//        private Dictionary<string, int> storedItems = new Dictionary<string, int>();
//        // Alle in diesem Storage, seinem Parent oder seinen bondedStorages verfügbare Waren
//        // Im Katalog wird dazu vermerkt in welchem der genannten Storages sich die Waren finden lassen
//        private List<string> availableItems = new List<string>();
//        private Dictionary<string, List<int>> catalogue = new Dictionary<string, List<int>>();

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="itemKey"></param>
//        /// <param name="storageID"></param>
//        public void RegisterItemIsAvailable(string itemKey, int storageID)
//        {

//        }


//        /// <summary>
//        /// Fügt ein Item der available Items-Liste hinzu, wenn das Item dort nicht schon auftaucht.
//        /// </summary>
//        /// <param name="itemKey">Der ItemKey, der in der Liste auftauchen soll.</param>
//        private void InsertIntoAvailableItems(string itemKey)
//        {
//            if(!availableItems.Contains(itemKey))
//            {
//                availableItems.Add(itemKey);
//            }
//        }
//    }
//}
