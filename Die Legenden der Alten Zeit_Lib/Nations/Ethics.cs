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

        private Vector2 side = new Vector2(0, 0); // Standard: X-Achse Gleichgewicht; Y-Achse Licht vs. Dunkelheit 0,0 Neutral
        #region side strings
        private const string LightInterested = "Dem Lichte zugeneigt";
        private const string Lightner = "Dem Lichte zugehörig";

        private const string DarkInterested = "Der Dunkelheit zugeneigt";
        private const string Darkner = "Der Dunkelheit zugehörig";

        private const string Balance = "Dem Gleichgewicht zugehörig";
        private const string BalanceInterested = "Dem Gleichgewicht zugeneigt";
        private const string BalanceAndDark = "Steht zwischen Dunkelheit und Gleichgewicht";
        private const string BalanceAndLight = "Steht zwischen Dunkelheit und Licht";
        #endregion

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
                switch (xenophilia)
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
        /// Gibt einen String zurück, welcher die derzeitige Ausrichtung der Nation widerspiegelt.
        /// </summary>
        public string Side
        {
            get
            {
                if (side.X < 1 && side.X > -1)
                {
                    if (side.Y > 1)
                    {
                        return Darkner;
                    }
                    else if (side.Y > 0 && side.Y <= 1)
                    {
                        return DarkInterested;
                    }
                    else if (side.Y < 0 && side.Y >= -1)
                    {
                        return LightInterested;
                    }
                    else if (side.Y < -1)
                    {
                        return Lightner;
                    }
                    else
                    {
                        return Neutral;
                    }
                }
                else if (side.X > 1 || side.X < -1)
                {
                    if (side.Y >= 1)
                    {
                        return BalanceAndDark;
                    }
                    else if (side.Y <= -1)
                    {
                        return BalanceAndLight;
                    }
                    else if (side.X < 2 && side.X > -2)
                    {
                        return BalanceInterested;
                    }
                    else if (side.X >= 2 || side.X <= -2)
                    {
                        return Balance;
                    }
                }
                return Neutral;
            }

            set
            {
                if(value == LightInterested)
                {
                    side = new Vector2(0, -1);
                }
                else if(value == Lightner)
                {
                    side = new Vector2(0, -2);
                }
                else if (value == DarkInterested)
                {
                    side = new Vector2(0, 1);
                }
                else if (value == Darkner)
                {
                    side = new Vector2(0, 2);
                }
                else if (value == BalanceInterested)
                {
                    side = new Vector2(1,0);
                }
                else if (value == BalanceAndDark)
                {
                    side = new Vector2(1, 1);
                }
                else if (value == BalanceAndLight)
                {
                    side = new Vector2(1, -1);
                }
                else if (value == Balance)
                {
                    side = new Vector2(2, 0);
                }
                else
                {
                    side = new Vector2(0, 0);
                }
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

        /// <summary>
        /// Mit Hilfe dieser Methode kann der Side-Rank über zwei Int-Parameter festgelegt werden.
        /// X => [2, 2]
        /// y => [2, 2]
        /// </summary>
        /// <param name="rankX">Spiegelt die Zugehörigkeit zum Gleichgewicht wider.</param>
        /// <param name="rankY">Die Zugehörigkeit zu Licht (Y niedriger 0) oder Dunkelheit (Y größer 0). </param>
        public void SetSide(int rankX, int rankY)
        {
            side = new Vector2(rankX, rankY);
        }
    }
}
