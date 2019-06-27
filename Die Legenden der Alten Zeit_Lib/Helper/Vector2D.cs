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

        public Vector2D()
        {
            X = 0;
            Y = 0;
        }

        public Vector2D(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Vector2D operator +(Vector2D a, Vector2D b) => new Vector2D(a.X + b.X, a.Y + b.Y);

        public static Vector2D operator -(Vector2D a, Vector2D b) => new Vector2D(b.X - a.X, b.Y - a.Y);

        /// <summary>
        /// Checks if the represented coordinates are fitting.
        /// Does not check for obj-equality.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vector2D a, Vector2D b)
        {
            if(a.X == b.X && a.Y == b.Y)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Vector2D a, Vector2D b)
        {
            if(a.X != b.X || a.Y != b.Y)
            {
                return true;
            }
            return false;
        }
    }
}
