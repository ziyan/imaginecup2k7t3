using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class OmniClient : IDisposable
    {
        private org.omniproject.service.OmniService service = new Omni.Client.org.omniproject.service.OmniService();
        /// <summary>
        /// The OmniService object
        /// </summary>
        public org.omniproject.service.OmniService Service
        {
            get { return service; }
        }

       

        #region Session related
        private Guid session = Guid.Empty;
        /// <summary>
        /// Session ID
        /// </summary>
        public Guid Session
        {
            get { return session; }
        }
        /// <summary>
        /// Construct a new connection to OmniService
        /// </summary>
        public OmniClient()
        {
            session = service.SessionNew();
        }
        /// <summary>
        /// Dispose session
        /// </summary>
        public void Dispose()
        {
            service.SessionAbandon(session);
        }
        /// <summary>
        /// Check for session validity
        /// </summary>
        private void CheckSession()
        {
            if (!service.SessionExists(session))
                session = service.SessionNew();
        }
        /// <summary>
        /// Keep session alive
        /// </summary>
        public void KeepAlive()
        {
            CheckSession();
            service.SessionKeepAlive(session);
        }
        #endregion

        #region User
        /// <summary>
        /// Get a captcha image for login and register
        /// </summary>
        /// <param name="width">width of the image</param>
        /// <param name="height">height of the image</param>
        /// <param name="bgcolor">background color</param>
        /// <param name="frontcolor">text color</param>
        /// <returns>a byte array for captcha in jpeg format</returns>
        public byte[] UserGetCaptcha(int width, int height, string bgcolor, string frontcolor)
        {
            CheckSession();
            return service.UserGetCaptcha(session, width, height, bgcolor, frontcolor);
        }

        /// <summary>
        /// Check see if user has logged in
        /// </summary>
        public bool UserIsLoggedIn
        {
            get
            {
                CheckSession();
                return service.UserIsLoggedIn(session);
            }
        }

        /// <summary>
        /// User login.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="md5password">md5 once password</param>
        /// <param name="captcha">captcha text</param>
        /// <returns>true for success, false otherwise</returns>
        public bool UserLogin(string username, string md5password)
        {
            CheckSession();
            try
            {
                return service.UserLogin(username, md5password, session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return false;
        }

        /// <summary>
        /// User logout.
        /// </summary>
        public void UserLogout()
        {
            CheckSession();
            service.UserLogout(session);
        }

        /// <summary>
        /// Register a new user account.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="md5password">md5 once password</param>
        /// <param name="name">name</param>
        /// <param name="email">email</param>
        /// <param name="captcha">captcha text</param>
        /// <returns>id of the new user</returns>
        public int UserRegister(string username, string md5password, string name, string email, string captcha)
        {
            CheckSession();
            try
            {
                return service.UserRegister(username, md5password, name, email, captcha, session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return 0;
        }

        /// <summary>
        /// Update an existing user account.
        /// </summary>
        /// <param name="name">display name</param>
        /// <param name="email">email</param>
        /// <param name="description">description</param>
        /// <param name="sn_network">IM network</param>
        /// <param name="sn_screenname">IM screenname</param>
        /// <returns>0 for success</returns>
        public int UserUpdate(string name, string email, string description, string sn_network, string sn_screenname)
        {
            CheckSession();
            try
            {
                return service.UserUpdate(name, email, description, sn_network, sn_screenname, session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return -1;
        }

        /// <summary>
        /// Currently logged in user.
        /// </summary>
        public User UserCurrent
        {
            get
            {
                CheckSession();
                org.omniproject.service.User user = service.UserCurrent(session);
                if (user == null) return null;
                return new User(user);
            }
        }
        #endregion

        #region Lookup service
        /// <summary>
        /// Dictionary definition lookup service.
        /// </summary>
        /// <param name="lang_id">Language id</param>
        /// <param name="word">Word</param>
        /// <returns>Definition for word</returns>
        public static string DefinitionLookup(string lang, string word)
        {
            org.omniproject.service.OmniService service = new Omni.Client.org.omniproject.service.OmniService();
            return service.DefinitionLookup(lang, word);
        }

        /// <summary>
        /// Translate a message.
        /// </summary>
        /// <param name="src_lang_id">Source language id</param>
        /// <param name="dst_lang_id">Destination language id</param>
        /// <param name="message">Message</param>
        /// <returns>Translated message</returns>
        public static string TranslationLookup(string src_lang, string dst_lang, string message)
        {
            org.omniproject.service.OmniService service = new Omni.Client.org.omniproject.service.OmniService();
            return service.TranslationLookup(src_lang, dst_lang, message);
        }
        #endregion
    }
}
