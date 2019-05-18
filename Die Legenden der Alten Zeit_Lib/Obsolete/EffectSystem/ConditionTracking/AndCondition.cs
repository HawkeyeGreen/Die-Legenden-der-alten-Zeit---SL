//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Zeus.Hermes;

//namespace Die_Legenden_der_Alten_Zeit_Lib.EffectSystem.ConditionTracking
//{
//    public class AndCondition : Condition, HermesLoggable
//    {
//        private Condition Cond1;
//        private Condition Cond2;

//        public Condition Condition1
//        {
//            get => Cond1;
//            set => Cond1 = value;
//        }

//        public Condition Condition2
//        {
//            get => Cond2;
//            set => Cond2 = value;
//        }

//        /// <summary>
//        /// Initialisierte eine leere AndCondition ohne die beiden verknüpften Conditions.
//        /// </summary>
//        public AndCondition() : base("AndCondition")
//        {

//        }

//        /// <summary>
//        /// Initialisiert die AndCondition mit den vorgegebenen Conditions.
//        /// </summary>
//        /// <param name="cond1">Die linke Condition.</param>
//        /// <param name="cond2">Die rechte Condition.</param>
//        public AndCondition(Condition cond1, Condition cond2) : base("AndCondition")
//        {
//            Cond1 = cond1;
//            Cond2 = cond2;
//        }

//        /// <summary>
//        /// Validiert, ob die Condition erfüllt ist oder nicht. Bildet dabei ein logisches & ab.
//        /// </summary>
//        /// <returns>Wertet die Condition aus.</returns>
//        public override bool Validate()
//        {
//            if(Cond1.Validate() && Cond2.Validate())
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//    }
//}
