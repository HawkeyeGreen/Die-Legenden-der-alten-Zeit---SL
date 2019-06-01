using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib
{
    public class RandomHelper
    {
        private static RandomHelper Instance = new RandomHelper();

        private readonly Random RNGesus = new Random();

        public static RandomHelper GetHelper() => Instance;

        public int D100()
        {
            return RNGesus.Next(1, 101);
        }

        public int D20()
        {
            return RNGesus.Next(1, 21);
        }

        public int D12()
        {
            return RNGesus.Next(1, 13);
        }

        public int D10()
        {
            return RNGesus.Next(1, 11);
        }

        public int D8()
        {
            return RNGesus.Next(1, 9);
        }

        public int D6()
        {
            return RNGesus.Next(1, 7);
        }

        public int D3()
        {
            return RNGesus.Next(1, 4);
        }

        /// <summary>
        /// 0 oder 1.
        /// </summary>
        /// <returns></returns>
        public int Fiftyfifty()
        {
            return RNGesus.Next(0, 2);
        }
    }
}
