using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeus.Hermes;
using Die_Legenden_der_Alten_Zeit_Lib.DB_Management;

namespace Die_Legenden_der_Alten_Zeit_Lib.CharacterManagement.AttributeSystem
{
    /// <summary>
    /// Diese Klasse verpackt ein Standardattributnamen und alle auf dieses Attribut verweisende Referenzen.
    /// </summary>
    public class StandardAttribute : HermesLoggable
    {
        private int _ID;
        private string attributeKey;
        private List<string> linkedKeys;
        private int currentLookIndex = 0;

        /// <summary>
        /// Der Schlüssel des Attributs unter dem es primär angesprochen werden soll.
        /// </summary>
        public string Key
        {
            get => attributeKey;
            set => attributeKey = value;
        }

        /// <summary>
        /// Attributsnamen, die auf dieses Attribut verlinkt werden sollen.
        /// </summary>
        public List<string> LinkedKeys
        {
            get => linkedKeys;
            set => linkedKeys = value;
        }

        public long ID => Convert.ToInt64(_ID);

        public string Type => "StandardAttribute";

        /// <summary>
        /// Dieser Konstruktor ermöglicht es ausschließlich den Key festzulegen.
        /// Alle Referenzen müssen nachträglich hinzugefügt werden.
        /// </summary>
        /// <param name="key">Der Attributsschlüssel. Beispiele: "ST" für Stärke; "GE" für Geschicklichkeit</param>
        public StandardAttribute(string key)
        {
            attributeKey = key;
            linkedKeys = new List<string>();
        }

        /// <summary>
        /// In diesem Konstruktor wird die Liste der referenzierten Schlüsselnamen gemeinsam mit dem Attributsschlüssel übergeben.
        /// </summary>
        /// <param name="key">Der Attributsschlüssel. Beispiele: "ST" für Stärke; "GE" für Geschicklichkeit</param>
        /// <param name="referenced">Die verwiesenen Schlüssel.</param>
        public StandardAttribute(string key, List<string> referenced)
        {
            attributeKey = key;
            linkedKeys = referenced;
        }

        /// <summary>
        /// Fügt den referencedKeys dieses Standardattributes einen neuen Schlüssel hinzu.
        /// </summary>
        /// <param name="key">Dieser Schlüssel wird als referenzierter Schlüssel hinzugefügt.</param>
        public void AddReferencedKey(string key)
        {
            LinkedKeys.Add(key);
        }

        /// <summary>
        /// Liest einen Schlüssel aus der Liste der referenzierten Schlüssel und erhöht den Index um eins.
        /// </summary>
        /// <returns>
        /// Gibt ein Tupel zurück:
        /// 1) Wurde das Ende der Liste erreicht
        /// 2) Gelesener Schlüssel
        /// </returns>
        public Tuple<bool, string> ReadReferencedKey()
        {
            Tuple<bool, string> Return;

            if (currentLookIndex < linkedKeys.Count)
            {
                Return = new Tuple<bool, string>(true, linkedKeys[currentLookIndex]);
                currentLookIndex++;
            }
            else
            {
                Return = new Tuple<bool, string>(false, null);
                currentLookIndex = 0;
            }

            return Return;
        }

        /// <summary>
        /// Setzt den aktuellen LookIndex auf 0.
        /// </summary>
        public void ResetLookIndex() => currentLookIndex = 0;


        /// <summary>
        /// Sichert dieses Standardattribut in die Standardattributtabellen der MainDB.
        /// </summary>
        /// <param name="id">Wenn dieser Parameter auf -1 gesetzt wird, dann wird der Wert neu in die Tabelle eingeführt.</param>
        /// <returns>Die ID unter der das Attribut aktuell in der Tabelle zu finden ist.</returns>
        public int SaveStandardAttribute(int id)
        {
            if(id == -1)
            {

            }
            else
            {

            }

            return id;
        }
    }
}
