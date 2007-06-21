using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Service
{
    class UserContext
    {
        public bool IsLoggedIn
        {
            get { return false; }
        }

        public UserContext()
        {
        }

        public bool Login(string username, string md5password)
        {
            return false;
        }

        private string encryptPassword(string prefix, string md5password)
        {
            return prefix.ToLower() + Util.MD5.HashString(md5password.ToLower() + prefix.ToLower());
        }
    }
}
