using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    public static class Utility
    {
        public static string ReplaceAt(this string Input, char NewChar, int Index)
        {
            if (Input == null)
            {
                throw new ArgumentNullException("input can't be null");
            }

            char[] Chars = Input.ToCharArray();
            Chars[Index] = NewChar;
            return new string(Chars);
        }

        public static string ReplaceAt(this string Input, string String, int Index)
        {
            if (Input == null || String == null)
                throw new ArgumentNullException("input can't be null");

            if (String.Length + Index >= Input.Length)
                throw new ArgumentException("Can't fit String at this index");


            char[] Chars = Input.ToCharArray();

            int InputChar = Index;
            int StringChar = 0;
            while(StringChar < String.Length)
            {
                Chars[InputChar] = String[StringChar];

                InputChar += 1;
                StringChar += 1;
            }

            return new string(Chars);
        }

    }
}
