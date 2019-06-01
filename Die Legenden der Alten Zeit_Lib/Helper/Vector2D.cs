using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib
{
    [Serializable]
    public class Vector2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2D(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
