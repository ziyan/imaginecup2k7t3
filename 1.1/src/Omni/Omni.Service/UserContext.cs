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
                throw new ArgumentException("Captcha mismatch.");
            captcha = "";
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
