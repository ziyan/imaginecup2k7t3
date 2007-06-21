using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Service
{
    public static class Common
    {
        public static Random Rand = new Random();
        public static string HexCharacterSet = "0123456789abcdef";
        public static int PasswordRandomTextLength = 10;
        public static string GetRandomString(string characters, int length)
        {
            if (length <= 0 || characters == null || characters.Length <= 0)
                throw new ArgumentOutOfRangeException();
            string s = "";
            for (int i = 0; i < length; i++)
            {
                s += characters[Rand.Next(characters.Length)];
            }
            return s;
        }

    }
}
