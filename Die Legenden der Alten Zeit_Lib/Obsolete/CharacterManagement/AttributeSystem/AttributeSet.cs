//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Zeus.Hermes;

//namespace Die_Legenden_der_Alten_Zeit_Lib.CharacterManagement.AttributeSystem
//{
//    /// <summary>
//    /// Diese Klasse enthält eine Menge von Attributen. Es können manuell Attribute registriert werden oder
//    /// via eines Standardattributs.
//    /// </summary>
//    public class AttributeSet : HermesLoggable
//    {
//        private int _ID;
//        private string name;
//        private Dictionary<string, int> attributes = new Dictionary<string, int>();
//        private Dictionary<string, string> attributeLinking = new Dictionary<string, string>();
//        private bool locked = false;

//        public long ID => _ID;

//        public string Type => "AttributeSet";

//        /// <summary>
//        /// Initialisiert das AttributSet mit Hilfe einer Liste von Standardattributen und Werten.
//        /// </summary>
//        /// <param name="standardAttributes">Eine Liste von Standardattribute-Attributwert-Paaren.</param> 
//        /// <param name="lockSet">Ermöglicht es das AttributeSet direkt zu schließen. Standard: offen.</param>
//        public AttributeSet(List<Tuple<StandardAttribute, int>> standardAttributes, bool lockSet = false)
//        {
//            foreach(Tuple<StandardAttribute, int> attribute in standardAttributes)
//            {
//                ImportStandardAttribute(attribute.Item1, attribute.Item2);
//            }
//            locked = lockSet;
//        }

//        /// <summary>
//        /// Importiert ein Standardattribut in dieses AttributeSet und intialisiert es mit dem gegebenen Wert.
//        /// Sollte das Attribut bereits im Set sein, dann wird sein aktueller Wert mit dem Initialwert überschrieben,
//        /// außer wenn das AttributeSet 'gelocked' ist, dann wird 'False' zurückgegeben.
//        /// </summary>
//        /// <param name="attribute">Das Standardattribute - es enthält sowohl die korrekte Definition des Attributs als auch alle Verlinkungen.</param>
//        /// <param name="value">Der Initialwert des Attributs.</param>
//        /// <returns></returns>
//        public void ImportStandardAttribute(StandardAttribute attribute, int value)
//        {
//            if(ContainsAttribute(attribute.Key))
//            {
//                // Offenbar ist das Attribut bereits vorhanden
//                // Setze es regulär auf den neuen Wert
//                SetAttributeValue(attribute.Key, value);
//            }
//            else
//            {
//                // Attribut existiert noch nicht -> lege es an
//                attributes.Add(attribute.Key, value);
//            }

//            // Fügt jeden referenzierten Schlüssel des Standardattributs in das Dictionary der attributeLinks ein.
//            // Wenn ein Schlüssel bereits verlinkt, dann wird der Link überschrieben.
//            attribute.ResetLookIndex();
//            Tuple<bool, string> refStringTuple = attribute.ReadReferencedKey();
//            while (refStringTuple.Item1)
//            {
//                if (!attributeLinking.ContainsKey(refStringTuple.Item2))
//                {
//                    attributeLinking.Add(refStringTuple.Item2, attribute.Key);
//                }
//                else
//                {
//                    attributeLinking[refStringTuple.Item2] = attribute.Key;
//                }
//            }
//        }

//        /// <summary>
//        /// Gibt true zurück, sollte das AttributeSet das angegebene Attribut oder ein verlinktes Äquivalent enthalten.
//        /// </summary>
//        /// <param name="attributeKey">Der Key, nachdem gesucht werden soll.</param>
//        /// <returns></returns>
//        public bool ContainsAttribute(string attributeKey)
//        {
//            if(attributes.ContainsKey(attributeKey))
//            {
//                return true;
//            }
//            else if(attributeLinking.ContainsKey(attributeKey))
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// Setzt das angebene Attribut auf den angegebenen Wert.
//        /// Diese Methode macht nichts, sollte das Set kein Attribut unter dem gegebenen Schlüssel enthalten.
//        /// </summary>
//        /// <param name="key"></param>
//        /// <param name="value"></param>
//        public void SetAttributeValue(string attributeKey, int value)
//        {
//            if (attributes.ContainsKey(attributeKey))
//            {
//                attributes[attributeKey] = value;
//            }
//            else if (attributeLinking.ContainsKey(attributeKey))
//            {
//                attributes[attributeLinking[attributeKey]] = value;
//            }
//        }
//    }
//}
