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
        /// <returns>the id of the new user, or -1 for duplicate email in system</returns>
        [WebMethod(Description = "Register a new user account.")]
        public int UserRegister(string username, string md5password, string name, string email, string captcha, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            Session.UserContext.CheckCaptcha(captcha);
            return Session.UserContext.Register(username, md5password, name, email);
        }

        /// <summary>
        /// Update an existing user account.
        /// </summary>
        /// <param name="name">display name</param>
        /// <param name="email">email</param>
        /// <param name="description">description</param>
        /// <param name="sn_network">IM network</param>
        /// <param name="sn_screenname">IM screenname</param>
        /// <param name="session">session id</param>
        /// <returns>0 for success, -1 for duplicate email in system</returns>
        [WebMethod(Description = "Update an existing user account.")]
        public int UserUpdate(string name, string email, string description, string sn_network, string sn_screenname, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Session.UserContext.Update(name, email, description, sn_network, sn_screenname);
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

        /// <summary>
        /// Get interests for a user.
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="session">session id</param>
        /// <returns>Array of interest ids</returns>
        [WebMethod(Description = "Get interests for a user.")]
        public Data.Interest[] UserInterests(int id, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            if (id <= 0) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.UserInterests(id, Session.Connection);
        }

        /// <summary>
        /// Get a user profile. E-mail and IM info are not available
        /// unless the profiled user has the requesting user as a
        /// friend.
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="session">session id</param>
        /// <returns>Array of interest ids</returns>
        [WebMethod(Description = "Get a user profile.")]
        public Data.User UserProfile(int id, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            if (id <= 0) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.UserProfile(Session.UserContext.User.id, id, Session.Connection);
        }
        #endregion

        #region Friends
        /// <summary>
        /// Get all friends for the current user.
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>Array of users</returns>
        [WebMethod(Description = "Get all friends for a user.")]
        public Data.User[] FriendsList(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            return Data.StoredProcedure.FriendsList(Session.UserContext.User.id, Session.Connection);
        }
        /// <summary>
        /// Search for Omni users by username, email, display name, or description.
        /// </summary>
        /// <param name="search">search criteria</param>
        /// <returns>Array of users</returns>
        [WebMethod(Description = "Search for Omni users by username, email, display name, or description.")]
        public Data.User[] FriendsSearchUsers(string search, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            return Data.StoredProcedure.FriendsSearchUsers(Session.UserContext.User.id, search, Session.Connection);
        }
        #endregion

        #region Interest

        /// <summary>
        /// Get all interests in the system.
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>Array of interests (id/ parentid/ name)</returns>
        [WebMethod(Description = "Get all interests in the system.")]
        public Data.Interest[] InterestList(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Data.StoredProcedure.InterestList(Session.Connection);
        }

        #endregion

        #region Language

        /// <summary>
        /// Get all languages in the system.
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>Array of languages (id & culture code)</returns>
        [WebMethod(Description = "Get all languages in the system.")]
        public Data.Language[] LanguageList(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Data.StoredProcedure.LanguageList(Session.Connection);
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
