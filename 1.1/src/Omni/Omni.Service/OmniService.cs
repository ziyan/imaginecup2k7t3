using System;
using System.Collections;
using System.Web.Services;

namespace Omni.Service
{
    [WebService(Namespace = "http://service.omniproject.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class OmniService : System.Web.Services.WebService
    {
        public OmniService()
        {
        }

        #region Session
        /// <summary>
        /// Creates a new session
        /// </summary>
        /// <returns>the session id</returns>
        [WebMethod(Description = "Creates a new session, returns a session id.")]
        public Guid SessionNew()
        {
            return ServiceSession.Create().Id;
        }

        /// <summary>
        /// Check if the session exists
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>true for exists, false otherwise</returns>
        [WebMethod(Description = "Check if the session exists.")]
        public bool SessionExists(Guid session)
        {
            return ServiceSession.Exists(session);
        }

        /// <summary>
        /// Abandon session
        /// </summary>
        /// <param name="session">session id</param>
        [WebMethod(Description = "Abandon session.")]
        public void SessionAbandon(Guid session)
        {
            ServiceSession.Abandon(session);
        }

        /// <summary>
        /// Keep session alive
        /// </summary>
        /// <param name="session">session id</param>
        [WebMethod(Description = "Keep session alive.")]
        public void SessionKeepAlive(Guid session)
        {
            ServiceSession.Get(session);
        }
        #endregion

        #region User
        /// <summary>
        /// Get a captcha image
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>captcha image</returns>
        [WebMethod(Description = "Get a captcha image.")]
        public byte[] UserGetCaptcha(Guid session, int width, int height, string bgcolor, string frontcolor)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Session.UserContext.GetCaptcha(width, height, System.Drawing.ColorTranslator.FromHtml(bgcolor), System.Drawing.ColorTranslator.FromHtml(frontcolor));
        }

        /// <summary>
        /// Check if user has logged in
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>true if logged in, false otherwise</returns>
        [WebMethod(Description = "Check if user has logged in.")]
        public bool UserIsLoggedIn(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Session.UserContext.IsLoggedIn;
        }

        /// <summary>
        /// User login
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="md5password">md5 once password</param>
        /// <param name="captcha">captcha text</param>
        /// <param name="session">session id</param>
        /// <returns>true for success, false otherwise</returns>
        [WebMethod(Description = "User login.")]
        public bool UserLogin(string username, string md5password, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Session.UserContext.Login(username, md5password);
        }

        /// <summary>
        /// User logout
        /// </summary>
        /// <param name="session">session id</param>
        [WebMethod(Description = "User logout.")]
        public void UserLogout(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            Session.UserContext.Logout();
        }

        /// <summary>
        /// Register a new user account.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="md5password">md5 once password</param>
        /// <param name="name">name</param>
        /// <param name="email">email address</param>
        /// <param name="captcha">captcha text</param>
        /// <param name="session">session id</param>
        /// <returns>the id of the new user</returns>
        [WebMethod(Description = "Register a new user account.")]
        public int UserRegister(string username, string md5password, string name, string email, string captcha, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            Session.UserContext.CheckCaptcha(captcha);
            return Session.UserContext.Register(username, md5password, name, email);
        }

        /// <summary>
        /// Get current user information.
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>current user information, null for not logged in</returns>
        [WebMethod(Description = "Get current user information.")]
        public Data.User UserCurrent(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Session.UserContext.User;
        }
        #endregion

        #region Lookup service
        /// <summary>
        /// Dictionary definition lookup service.
        /// </summary>
        /// <param name="lang_id">Language id</param>
        /// <param name="word">Word</param>
        /// <returns>Definition for word</returns>
        [WebMethod(Description = "Dictionary definition lookup service.")]
        public string DefinitionLookup(string lang, string word)
        {
            return External.DictionaryService.Lookup(lang, word);
        }

        /// <summary>
        /// Translate a message.
        /// </summary>
        /// <param name="src_lang_id">Source language id</param>
        /// <param name="dst_lang_id">Destination language id</param>
        /// <param name="message">Message</param>
        /// <returns>Translated message</returns>
        [WebMethod(Description = "Translate a message.")]
        public string TranslationLookup(string src_lang, string dst_lang, string message)
        {
            return External.TranslationService.Lookup(src_lang, dst_lang, message);
        }
        #endregion


    }
}