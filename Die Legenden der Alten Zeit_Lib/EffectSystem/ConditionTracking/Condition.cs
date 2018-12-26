using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeus.Hermes;

namespace Die_Legenden_der_Alten_Zeit_Lib.EffectSystem.ConditionTracking
{
    /// <summary>
    /// Die Wurzelklasse des Condition-Trees.
    /// Hieraus entwickeln sich alle weitere Conditions.
    /// Via dem Typen der Condition, kann später nachvollzogen werden, welche Condition vorliegt
    /// und sie beim Einlesen des EffectNuggets in den EffectManager mit den gewünschten Werten initialisieren.
    /// </summary>
    public abstract class Condition : HermesLoggable
    {
        private string _Type = "Condition";

        public long ID => 1339;

        public string Type => _Type;

        /// <summary>
        /// Der tiefstliegende Konstruktor der Conditions kümmert sich darum,
        /// das es einen intialisierten Typen gibt.
        /// </summary>
        /// <param name="type">Der Typ der Condition, welcher auch für den Type-cast erforderlich ist.</param>
        public Condition(string type)
        {
            _Type = type;
        }


        /// <summary>
        /// Diese Methode überprüft, ob die gegebene Condition wahr ist.
        /// </summary>
        /// <returns>true, wenn die Condition erfüllt ist, false wenn sie nicht erfüllt ist.</returns>
        abstract public bool Validate();
    }
}
