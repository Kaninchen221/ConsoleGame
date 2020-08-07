using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    public class String2D : ICloneable
    {
        public string Data { get; private set; } = new string ("");
        public Vector2i Size { get; private set; } = new Vector2i();
        public char DefaultChar { get; set; }

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

        static public bool IsSizeValid(Vector2i Size)
        {
            return (Size.X > 0 && Size.Y > 0);
        }

        public void Clear()
        {
            Data = string.Empty;
            Size = new Vector2i(0, 0);
        }

        public void ReplaceAt(char Char, Vector2i Position)
        {
            if (!IsPositionValid(Position))
                throw new System.ArgumentException("Position is invalid");

            Data = Data.ReplaceAt(Char, GetIndex(Position));
        }
        
        public void ReplaceAt(string String, Vector2i Position)
        {
            int DataIndex = GetIndex(Position);

            if (DataIndex + String.Length > Data.Length)
                throw new System.ArgumentException("Can't fit String in this String2D");

            Data = Data.ReplaceAt(String, DataIndex);
        }

        public char At(Vector2i Position)
        {
            if (!IsPositionValid(Position))
                throw new System.ArgumentException("Position is invalid");

            return Data[GetIndex(Position)];
        }

        public int GetIndex(Vector2i Position)
        {
            return (Size.X * Position.Y) + Position.X;
        }

        public bool IsPositionValid(Vector2i Position)
        {
            return (Position.X >= 0 && Position.X < Size.X &&
                    Position.Y >= 0 && Position.Y < Size.Y);
        }

        public string GetLine(int LineNumber)
        {
            if (!IsLineValid(LineNumber))
                throw new System.ArgumentException($"LineNumber must be greater than 0 and less than {Size.Y}");

            int CharNumber = LineNumber * Size.X;
            var result = Data.Substring(CharNumber, Size.X);

            return result;
        }

        public bool IsLineValid(int LineNumber)
        {
            return (LineNumber >= 0 && LineNumber < Size.Y);
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

        public void Foreach(Action<Char, Vector2i> Callable)
        {
            var Position = new Vector2i(0, 0);

            foreach (var Char in Data)
            {
                Callable(Char, Position);

                if (Position.X == Size.X - 1)
                {
                    Position.X = 0;
                    Position.Y += 1;
                }
                else
                    Position.X += 1;
            }
        }
    }
}
