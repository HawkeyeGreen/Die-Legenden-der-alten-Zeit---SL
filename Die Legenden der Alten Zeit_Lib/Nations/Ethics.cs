using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Die_Legenden_der_Alten_Zeit_Lib.Nations
{
    /// <summary>
    /// Diese Klasse speichert die Ethiken einer Nation und kann sie auch in der DB ablegen und wieder auslesen.
    /// </summary>
    public class Ethics
    {
        private const string Neutral = "neutral";
        private int xenophilia = 0; // Standard: Neutral; -3 radikal Isolationist und +3 radikal Xenophil
        #region xenophilia strings
        private const string XenophiliaInterested = "Xenophilie zugeneigt";
        private const string Xenophile = "Xenophil";
        private const string RadicalXenophile = "Radikal Xenophil";

        private const string IsolationismInterested = "Isolationismus zugeneigt";
        private const string Isolationist = "Isolationist";
        private const string RadicalIsolationist = "Radikaler Isolationist";
        #endregion
        private int militarist = 0; // Standard: Neutral; -3 radikal Pazifist und +3 radikal Militarist
        #region militarist strings
        private const string MilitaristInterested = "Militarismus zugeneigt";
        private const string Militarist = "Militarist";
        private const string RadicalMilitarist = "Radikaler Militarist";

        private const string PacifismInterested = "Pazifismus zugeneigt";
        private const string Pacifist = "Pazifist";
        private const string RadicalPacifist = "Radikaler Pazifist";
        #endregion
        private int egalitarian = 0; // Standard: Neutral; -3 radikal Autoritär und +3 radikal Demokrat
        #region egalitarian strings
        private const string EgalitarismInterested = "Egalitarianismus zugeneigt";
        private const string Egalitarian = "Demokrat";
        private const string RadicalEgalitarian = "Radikaler Demokrat";

        private const string AuthorianismInterested = "Autoritarismus zugeneigt";
        private const string Authorian = "Autokrat";
        private const string RadicalAuthorian = "Radikaler Autokrat";
        #endregion
        private int side = 4; // Standard: Neutral; -3 Licht, +3 Dunkelheit und 0 Gleichgewicht
        private int collectivist = 0; // Standard: Neutral; -3 radikal Individualist und +3 radikal Kollektivist
        private int ecologist = 0; // Standard: Neutral; -3 radikal Ökonome und +3 radikal Ökologe
        private Vector3 knowledgeWay = new Vector3(0, 0, 0); // Standard: Neutral; (3,Y,Z) radikaler Arkanist, (X,3,Z) radikaler Spiritualist und bei (X, Y, 3) radikaler Materialist

        /// <summary>
        /// Wie Xenophil ist diese Nation?
        /// Die Skala reicht von -3 bis +3.
        /// Standard ist 0.
        /// </summary>
        public string Xenophilia
        {
            get
            {
                switch(xenophilia)
                {
                    case 0:
                        return Neutral;
                    case 1:
                        return XenophiliaInterested;
                    case 2:
                        return Xenophile;
                    case 3:
                        return RadicalXenophile;
                    case -1:
                        return IsolationismInterested;
                    case -2:
                        return Isolationist;
                    case -3:
                        return RadicalIsolationist;
                    default:
                        return Neutral;
                }
            }

            set
            {
                int placeholder;
                switch (value)
                {
                    case Neutral:
                        placeholder = 0;
                        break;
                    case XenophiliaInterested:
                        placeholder = 1;
                        break;
                    case Xenophile:
                        placeholder = 2;
                        break;
                    case RadicalXenophile:
                        placeholder = 2;
                        break;
                    case IsolationismInterested:
                        placeholder = -1;
                        break;
                    case Isolationist:
                        placeholder = -2;
                        break;
                    case RadicalIsolationist:
                        placeholder = -3;
                        break;
                    default:
                        placeholder = 0;
                        break;
                }
                xenophilia = placeholder;
            }
        }

        /// <summary>
        /// Wie stark militaristisch sind Diplomatie und Gesellschaft dieser Nation?
        /// [-3, 3]
        /// </summary>
        public string Militarism
        {
            get
            {
                switch (militarist)
                {
                    case 0:
                        return Neutral;
                    case 1:
                        return MilitaristInterested;
                    case 2:
                        return Militarist;
                    case 3:
                        return RadicalMilitarist;
                    case -1:
                        return PacifismInterested;
                    case -2:
                        return Pacifist;
                    case -3:
                        return RadicalPacifist;
                    default:
                        return Neutral;
                }
            }

            set
            {
                int placeholder;
                switch (value)
                {
                    case Neutral:
                        placeholder = 0;
                        break;
                    case MilitaristInterested:
                        placeholder = 1;
                        break;
                    case Militarist:
                        placeholder = 2;
                        break;
                    case RadicalMilitarist:
                        placeholder = 2;
                        break;
                    case PacifismInterested:
                        placeholder = -1;
                        break;
                    case Pacifist:
                        placeholder = -2;
                        break;
                    case RadicalPacifist:
                        placeholder = -3;
                        break;
                    default:
                        placeholder = 0;
                        break;
                }
                militarist = placeholder;
            }
        }

        /// <summary>
        /// Wie stark militaristisch sind Diplomatie und Gesellschaft dieser Nation?
        /// [-3, 3]
        /// </summary>
        public string Egalitarism
        {
            get
            {
                switch (egalitarian)
                {
                    case 0:
                        return Neutral;
                    case 1:
                        return EgalitarismInterested;
                    case 2:
                        return Egalitarian;
                    case 3:
                        return RadicalEgalitarian;
                    case -1:
                        return AuthorianismInterested;
                    case -2:
                        return Authorian;
                    case -3:
                        return RadicalAuthorian;
                    default:
                        return Neutral;
                }
            }

            set
            {
                int placeholder;
                switch (value)
                {
                    case Neutral:
                        placeholder = 0;
                        break;
                    case EgalitarismInterested:
                        placeholder = 1;
                        break;
                    case Egalitarian:
                        placeholder = 2;
                        break;
                    case RadicalEgalitarian:
                        placeholder = 2;
                        break;
                    case AuthorianismInterested:
                        placeholder = -1;
                        break;
                    case Authorian:
                        placeholder = -2;
                        break;
                    case RadicalAuthorian:
                        placeholder = -3;
                        break;
                    default:
                        placeholder = 0;
                        break;
                }
                egalitarian = placeholder;
            }
        }

        /// <summary>
        /// Durch diese Methode kann der Xenophilie-Rang auch mit einem Int-Wert gesetzt werden.
        /// Bei Verlassen des Grenzbereiches von -3 bis 3 wird der jeweils passende Höchstwert eingesetzt.
        /// </summary>
        /// <param name="rank">Der Rang, den die Xenophilie der Nation annehmen soll. [-3, 3]</param>
        public void SetXenophilia(int rank)
        {
            int placeholder;
            if(rank >= -3 && rank <= 3)
            {
                placeholder = rank;
            }
            else if(rank < -3)
            {
                placeholder = -3;
            }
            else if(rank > 3)
            {
                placeholder = 3;
            }
            else
            {
                placeholder = 0;
            }
            xenophilia = placeholder;
        }

        /// <summary>
        /// Durch diese Methode kann der Militarismus-Rang auch mit einem Int-Wert gesetzt werden.
        /// Bei Verlassen des Grenzbereiches von -3 bis 3 wird der jeweils passende Höchstwert eingesetzt.
        /// </summary>
        /// <param name="rank">Der Rang, den der Militarismus der Nation annehmen soll. [-3, 3]</param>
        public void SetMilitarism(int rank)
        {
            int placeholder;
            if (rank >= -3 && rank <= 3)
            {
                placeholder = rank;
            }
            else if (rank < -3)
            {
                placeholder = -3;
            }
            else if (rank > 3)
            {
                placeholder = 3;
            }
            else
            {
                placeholder = 0;
            }
            militarist = placeholder;
        }

        /// <summary>
        /// Durch diese Methode kann der Egalitarismus-Rang auch mit einem Int-Wert gesetzt werden.
        /// Bei Verlassen des Grenzbereiches von -3 bis 3 wird der jeweils passende Höchstwert eingesetzt.
        /// </summary>
        /// <param name="rank">Der Rang, den der Egalitarismus der Nation annehmen soll. [-3, 3]</param>
        public void SetEgalitarism(int rank)
        {
            int placeholder;
            if (rank >= -3 && rank <= 3)
            {
                placeholder = rank;
            }
            else if (rank < -3)
            {
                placeholder = -3;
            }
            else if (rank > 3)
            {
                placeholder = 3;
            }
            else
            {
                placeholder = 0;
            }
            egalitarian = placeholder;
        }
    }
}
