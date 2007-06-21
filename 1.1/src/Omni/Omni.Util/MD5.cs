using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Util
{
    public static class MD5
    {
        public static string HashString(string message)
        {
            System.Security.Cryptography.MD5 hash = new System.Security.Cryptography.MD5CryptoServiceProvider();
            hash.Initialize();
            return BitConverter.ToString(hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(message))).Replace("-", "").ToLower();
        }
    }
}
