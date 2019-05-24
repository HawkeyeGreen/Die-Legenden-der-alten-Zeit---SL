using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Helper
{
    public static class DepositSizes
    {
        public static readonly string VerySmall = "Very Small";
        public static readonly string Small = "Small";
        public static readonly string Medium = "Medium";
        public static readonly string Large = "Large";
        public static readonly string VeryLarge = "Very Large";
    }

    /// <summary>
    /// Provides a matching for DepositSize-BaseStrings to german translations.
    /// </summary>
    public class DepositSizeTranslator
    {
        public static Dictionary<string, string> Translator { get; protected set; }

        public static readonly string VerySmall_German = "Sehr klein";
        public static readonly string Small_German = "Klein";
        public static readonly string Medium_German = "Mittel";
        public static readonly string Large_German = "Groß";
        public static readonly string VeryLarge_German = "Sehr groß";

        /// <summary>
        /// Provides the german string for a given basestring.
        /// </summary>
        /// <param name="input">A BaseString from DepositSize-Helperclass.</param>
        /// <returns>In case of mismatch a mismatch-string will be returned.</returns>
        public static string GetTranslation(string input)
        {
            if (!Translator.ContainsKey(DepositSizes.VerySmall))
            {
                CreateTranslation();
            }

            if (Translator.ContainsKey(input))
            {
                return Translator[input];
            }
            else
            {
                return "Missing string: " + input;
            }
        }

        private static void CreateTranslation()
        {
            Translator = new Dictionary<string, string>
            {
                [DepositSizes.VerySmall] = VerySmall_German,
                [DepositSizes.Small] = Small_German,
                [DepositSizes.Medium] = Medium_German,
                [DepositSizes.Large] = Large_German,
                [DepositSizes.VeryLarge] = VeryLarge_German
            };
        }
    }
}
