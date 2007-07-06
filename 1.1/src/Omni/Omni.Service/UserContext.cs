using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Service
{
    class UserContext
    {
        private string captcha = "";
        private Data.User user = null;
        private ServiceSession session = null;
        private int trial = 0;
        private DateTime last_trial = DateTime.Now;
        
        public bool IsLoggedIn
        {
            get { return user != null; }
        }

        public Data.User User
        {
            get { return user; }
        }

        public UserContext(ServiceSession session)
        {
            this.user = null;
            this.session = session;
        }

        public byte[] GetCaptcha(int width, int height, System.Drawing.Color bgcolor, System.Drawing.Color frontcolor)
        {
            captcha = Captcha.GetCaptchaText();
            return Captcha.GetCaptchaImage(captcha, width, height, bgcolor, frontcolor);
        }

        public void CheckCaptcha(string text)
        {
            if (text.Length <= 0 || captcha.ToLower() != text.ToLower())
                throw new InvalidCaptchaException();
            captcha = "";
        }

        public bool Login(string username, string md5password)
        {
            if (this.user != null) throw new UserAlreadyLoggedInException();
            if (!Util.Validator.IsUsername(username))
                throw new InvalidUsernameException();
            if (trial >= Convert.ToInt32(Data.Configuration.LocalSettings["Omni.Service.UserContext.MaxTrial"]))
            {
                TimeSpan lock_interval = DateTime.Now - last_trial;
                if (lock_interval.TotalMinutes >= Convert.ToInt32(Data.Configuration.LocalSettings["Omni.Service.UserContext.TrialLockInterval"]))
                {
                    trial = 0;
                }
                else
                {
                    last_trial = DateTime.Now;
                    throw new TryLoginTooManyTimesException();
                }
            }
            
            string password = Data.StoredProcedure.UserPasswordGetByUsername(username.ToLower(), session.Connection).ToLower();
            if (encryptPassword(getPasswordPrefix(password), md5password) == password)
            {
                this.user = Data.StoredProcedure.UserAuthorizeByUsername(username, session.Connection);
                if (!IsLoggedIn)
                {
                    trial++;
                    last_trial = DateTime.Now;
                }
                else
                {
                    trial = 0;
                }
                return IsLoggedIn;
            }
            else
            {
                this.user = null;
                return false;
            }
        }

        public void Logout()
        {
            if (this.user == null) throw new UserNotLoggedInException();
            this.user = null;
        }

        public int Register(string username, string md5password, string name, string email)
        {
            if (this.user != null) throw new UserAlreadyLoggedInException();
            if (username == null || md5password == null || name == null || email == null ||
                username == "" || md5password.Length != 32 || name == "" || email == "")
                throw new ArgumentNullException();
            if (!Util.Validator.IsUsername(username))
                throw new InvalidUsernameException();
            if (!Util.Validator.IsEmail(email))
                throw new InvalidEmailException();
            if (name.Length > 100) throw new ArgumentOutOfRangeException();
            string password = encryptPassword(generatePasswordPrefix(), md5password);
            int id = Data.StoredProcedure.UserRegister(username, password, email, name, session.Connection);
            if (id > 0)
                return id;
            else if (id == -1)
                throw new DuplicateUsernameException();
            else if (id == -2)
                throw new DuplicateEmailException();
            else
                throw new SystemException();
        }

        #region Password
        private string encryptPassword(string prefix, string md5password)
        {
            if (md5password.Length != 32) throw new ArgumentOutOfRangeException();
            if (prefix.Length != passwordPrefixLength) throw new ArgumentOutOfRangeException();
            return prefix.ToLower() + MD5.HashString(md5password.ToLower() + prefix.ToLower());
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
        #endregion
    }
}
