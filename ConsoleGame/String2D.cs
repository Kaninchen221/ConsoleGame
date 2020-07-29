using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    public class String2D : ICloneable
    {
        public string Data { get; private set; }
        public Vector2i Size { get; private set; }
        public char DefaultChar { get; set; }

        public String2D()
        {
            Data = new string("");
            Size = new Vector2i();
        }

        public void Resize(Vector2i Size)
        {
            if (!IsSizeValid(Size))
                throw new System.ArgumentException("Size is invalid");
            
            Clear();

            var Count = Size.X * Size.Y;
            var Builder = new StringBuilder();

            for(int i = 0; i < Count; ++i)
            {
                Builder.Append(DefaultChar);
            }

            this.Size = Size;
            Data = Builder.ToString();
        }

        public void Clear()
        {
            Data = string.Empty;
            Size = new Vector2i(0, 0);
        }

        static public bool IsSizeValid(Vector2i Size)
        {
            return (Size.X > 0 && Size.Y > 0);
        }

        public void ReplaceAt(char Char, Vector2i Position)
        {
            if (!IsPositionValid(Position))
                throw new System.ArgumentException("Position is invalid");

            Data = Data.ReplaceAt(Char, Size.X * Position.Y + Position.X);
        }

        public char At(Vector2i Position)
        {
            if (!IsPositionValid(Position))
                throw new System.ArgumentException("Position is invalid");

            return Data[Size.X * Position.Y + Position.X];
        }

        public bool IsPositionValid(Vector2i Position)
        {
            return (Position.X >= 0 && Position.X < Size.X &&
                    Position.Y >= 0 && Position.Y < Size.Y);
        }

        public void FromString(string String, char SplitChar)
        {
            var Builder = new StringBuilder();

            foreach(char Char in String)
            {
                if (Char != SplitChar)
                {
                    Builder.Append(Char);
                    if (Size.Y == 0)
                        Size.X += 1;
                }
                else
                {
                    Size.Y += 1;
                }
            }

            Data = Builder.ToString();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
