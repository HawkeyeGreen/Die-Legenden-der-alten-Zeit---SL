using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Zeus.Hermes;

using Die_Legenden_der_Alten_Zeit_Lib.DB_Management;

namespace Die_Legenden_der_Alten_Zeit_Lib.Nations.YieldbasedRessources
{
    /// <summary>
    /// Das YieldRegister verwaltet alle Vorkommen von ertrags-basierten, speicherbaren Ressourcen.
    /// Solche umfassen: Kultur, Weisheit und Einheit.
    /// Forschung, Produktion o.ä. werden separat behandelt, da bei ihnen andere Regeln Anwendung finden.
    /// </summary>
    class YieldRegister : HermesLoggable
    {
        private static Dictionary<string, YieldRegister> instancedRegisters = new Dictionary<string, YieldRegister>();

        private int _ID;
        private Dictionary<string, int> currentBalances;

        public long ID => throw new NotImplementedException();
        public string Type => throw new NotImplementedException();

        /// <summary>
        /// Initialisiert das YieldRegister für die angegebene Nation.
        /// </summary>
        /// <param name="nation">Die Nation, für die das Register geladen werden soll.</param>
        private YieldRegister(string nation)
        {
            DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM YieldRegisters WHERE Nation='" + nation + "';").CreateDataReader();
            reader.Read();
            _ID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("id")));
            currentBalances = new Dictionary<string, int>();
            currentBalances.Add("Kultur", Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Culture"))));
            currentBalances.Add("Weisheit", Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Wisdom"))));
            currentBalances.Add("Einheit", Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Unity"))));

        }

        /// <summary>
        /// Gibt die gültige Instanz des YieldRegisters für die gegebene Nation zurück.
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        public static YieldRegister GetRegister(string nation)
        {
            if(!instancedRegisters.ContainsKey(nation))
            {
                instancedRegisters.Add(nation, new YieldRegister(nation));
            }
            return instancedRegisters[nation];
        }
    }
}
