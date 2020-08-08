
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;

namespace ConsoleGame
{
    public class Vector2i
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2i() { }

        public Vector2i(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Vector2i(Vector2i Other)
        {
            this.X = Other.X;
            this.Y = Other.Y;
        }

        public bool CompareTo(Vector2i Other)
        {
            return (this.X == Other.X && this.Y == Other.Y);
        }

        public static Vector2i operator + (Vector2i Lhs, Vector2i Rhs)
        {
            return new Vector2i(Lhs.X + Rhs.X, Lhs.Y + Rhs.Y);
        }

        public static Vector2i operator - (Vector2i Lhs, Vector2i Rhs)
        {
            return new Vector2i(Lhs.X - Rhs.X, Lhs.Y - Rhs.Y);
        }
    }


}
