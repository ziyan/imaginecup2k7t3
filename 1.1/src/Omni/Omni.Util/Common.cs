using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Util
{
    public static class Common
    {
        public static Random Rand = new Random();
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
