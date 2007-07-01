using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Service
{
    class UserContext
    {
        private string captcha = "";
        
        public bool IsLoggedIn
        {
            get { return false; }
        }

        public UserContext()
        {
        }

        public byte[] GetCaptcha(int width, int height, System.Drawing.Color bgcolor, System.Drawing.Color frontcolor)
        {
            captcha = Captcha.GetCaptchaText();
            return Captcha.GetCaptchaImage(captcha, width, height, bgcolor, frontcolor);
        }

        public void CheckCaptcha(string text)
        {
            if (text.Length != Captcha.CaptchaLength || captcha.ToLower() != text.ToLower())
                throw new InvalidCaptchaException();
            captcha = "";
        }

        public bool Login(string username, string md5password)
        {
            if (!Util.Common.IsValidUsername(username))
                throw new InvalidUsernameException();

            return false;
        }

        public void Logout()
        {

        }

        private string encryptPassword(string prefix, string md5password)
        {
            if (md5password.Length != 32) throw new ArgumentOutOfRangeException();
            if (prefix.Length != passwordPrefixLength) throw new ArgumentOutOfRangeException();
            return prefix.ToLower() + Util.MD5.HashString(md5password.ToLower() + prefix.ToLower());
        }
        private string generatePasswordPrefix()
        {
            return Util.Common.GetRandomString(hexCharacterSet, passwordPrefixLength).ToLower(); ;
        }
        private string getPasswordPrefix(string password)
        {
            if (password.Length != 42) throw new ArgumentOutOfRangeException();
            return password.Substring(0, passwordPrefixLength).ToLower();
        }
        private static string hexCharacterSet = "0123456789abcdef";
        private static int passwordPrefixLength = 10;
    }
}
