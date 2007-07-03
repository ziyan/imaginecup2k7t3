using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Util
{
    public static class Common
    {
        public static bool IsInteger(string integer)
        {
            return integer != null && integer != "" && System.Text.RegularExpressions.Regex.Replace(integer, Util.Configuration.LocalSettings["Omni.Util.Common.IntegerPattern"], "") == "";
        }
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
        public static bool IsValidUsername(string username)
        {
            return username != null && username != "" && System.Text.RegularExpressions.Regex.Replace(username, Util.Configuration.LocalSettings["Omni.Util.Common.UsernamePattern"], "") == "";
        }
        public static bool IsValidEmail(string email)
        {
            return email != null && email != "" && System.Text.RegularExpressions.Regex.Replace(email, Util.Configuration.LocalSettings["Omni.Util.Common.EmailPattern"], "") == "";
        }
    }
}
