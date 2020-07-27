using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    public static class Utility
    {
        public static string ReplaceAt(this string input, char newChar, int index)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input can't be null");
            }
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }

    }
}
