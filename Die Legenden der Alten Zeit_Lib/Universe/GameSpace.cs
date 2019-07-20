using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe
{
    public class GameSpace
    {
        public static string PATH = "//Spaces//Game//";

        private GameSpaceData data;
        public int Round
        {
            get => data.Round;
            set
            {
                Step = 1;
                data.Round = value;
            }
        }
        public int Step
        {
            get => data.Step;
            set
            {
                if (value > StepMax)
                {
                    data.Step = 1;
                }
                else
                {
                    data.Step = value;
                }
            }
        }
        public int StepMax
        {
            get => data.StepMax;
            set => data.StepMax = value;
        }
        public string Key { get; set; }
    }

    [Serializable]
    public struct GameSpaceData
    {
        public int Round { get; set; }
        public int Step { get; set; }
        public int StepMax { get; set; }
    }
}
