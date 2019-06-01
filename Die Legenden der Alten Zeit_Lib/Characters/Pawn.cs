using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Characters
{
    /// <summary>
    /// Represents any type of actual person in the game.
    /// Collects data and methods for operating with checks as well as 
    /// descriptions and map movement.
    /// </summary>
    public class Pawn
    {
        private PawnData data;

        public int ID => data.GlobalID;

        public string Race => data.Race;
        public string Culture => data.Culture;
        public string Class => data.Class;

        /// <summary>
        /// Firstname, Surname
        /// </summary>
        public string Frontname
        {
            get => data.Frontname;
            set => data.Frontname = value;
        }

        public string Lastname
        {
            get => data.Lastname;
            set => data.Lastname = value;
        }

        public string Fullname
        {
            get => data.Fullname;
            set => data.Fullname = value;
        }

        public string Owner
        {
            get => data.Owner;
            set => data.Owner = value;
        }

        private Dictionary<string, int> Attributes
        {
            get => data.Attributes;
            set => data.Attributes = value;
        }

        private Dictionary<string, int> Talents
        {
            get => data.Talents;
            set => data.Talents = value;
        }

        /// <summary>
        /// Loads a Pawn from the specified File.
        /// </summary>
        /// <param name="Path">The Path to the Pawn-File.</param>
        public Pawn(string Path)
        {

        }

        /// <summary>
        /// Erstellt einen neuen Pawn. Er ist leer und sollte vom Pawn-Generator verwendet werden,
        /// um ihn mit Eigenschaften zu füllen.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Owner"></param>
        public Pawn(string Name, string Owner)
        {

        }

        public bool SimpleCheck(string Attribute, int Handicap, bool CheckForEffects = true)
        {
            int rValue = ComplexCheck(Attribute, Handicap, CheckForEffects);

            if (rValue <= 0)
            {
                return true;
            }

            return false; // Not found or failed check
        }

        public int ComplexCheck(string Attribute, int Handicap, bool CheckForEffects = true)
        {
            if (Attributes.ContainsKey(Attribute))
            {
                return Attributes[Attribute] - RandomHelper.GetHelper().D20() + Handicap;
            }
            else
            {
                return 404;
            }
        }

    }

    [Serializable]
    public struct PawnData
    {
        public int GlobalID { get; set; }
        public string Owner { get; set; }

        public string Frontname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get; set; }

        public string Race { get; set; }
        public string Culture { get; set; }
        public string Class { get; set; }

        public Dictionary<string, int> Attributes { get; set; }
        public Dictionary<string, int> Talents { get; set; }
    }
}
