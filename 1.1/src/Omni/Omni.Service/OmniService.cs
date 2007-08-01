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
        /// Update a user's interests. Any not in the provided list will be removed.
        /// </summary>
        /// <param name="ids">array of interest ids</param>
        /// <returns>0 for success</returns>
        [WebMethod(Description = "Update a user's interests. Any not in the provided list will be removed.")]
        public int UserUpdateInterests(int[] ids, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Session.UserContext.UpdateInterests(ids);
        }

        /// <summary>
        /// Update a user's languages. Any not in the provided list will be removed.
        /// The same index in both array should refer to the same language.
        /// </summary>
        /// <param name="ids">array of interest ids</param>
        /// <returns>0 for success</returns>
        [WebMethod(Description = "Update a user's languages. Any not in the provided list will be removed.")]
        public int UserUpdateLanguages(int[] ids, int[] skills, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Session.UserContext.UpdateLanguages(ids, skills);
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
        /// <returns>Array of interests</returns>
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
        /// <returns>User object</returns>
        [WebMethod(Description = "Get a user profile.")]
        public Data.User UserProfile(int id, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            if (id <= 0) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.UserProfile(Session.UserContext.User.id, id, Session.Connection);
        }

        // Helper method
        private string UserUsernameById(int id, Omni.Data.Connection connection)
        {
            return Data.StoredProcedure.UserUsernameById(id, connection);
        }

        /// <summary>
        /// Gets a user's languages.
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="session">session id</param>
        /// <returns>Array of UserLanguages</returns>
        [WebMethod(Description = "Gets a user's languages.")]
        public Data.UserLanguage[] UserLanguages(int id, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            if (id <= 0) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.UserLanguages(id, Session.Connection);
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
        /// Checks if this user has Friend on their friends list.
        /// </summary>
        /// <param name="friend_id">friend id</param>
        /// <param name="session">session id</param>
        /// <returns>1 if they do, 0 otherwise</returns>
        [WebMethod(Description = "Checks if this user has Friend on their friends list.")]
        public int FriendsCheckFriendPair(int friend_id, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            return Data.StoredProcedure.FriendsCheckFriendPair(Session.UserContext.User.id, friend_id, Session.Connection);
        }
        /// <summary>
        /// Adds a friend to this user's friend list.
        /// </summary>
        /// <param name="friend_id">friend id</param>
        /// <param name="session">session id</param>
        /// <returns>1 for success</returns>
        [WebMethod(Description = "Adds a friend to this user's friend list.")]
        public int FriendsAdd(int friend_id, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            return Data.StoredProcedure.FriendsAdd(Session.UserContext.User.id, friend_id, Session.Connection);
        }
        /// <summary>
        /// Removes a friend to this user's friend list.
        /// </summary>
        /// <param name="friend_id">friend id</param>
        /// <param name="session">session id</param>
        /// <returns>1 for success</returns>
        [WebMethod(Description = "Removes a friend from this user's friend list.")]
        public int FriendsRemove(int friend_id, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            return Data.StoredProcedure.FriendsRemove(Session.UserContext.User.id, friend_id, Session.Connection);
        }
        /// <summary>
        /// Search for Omni users by username, email, display name, or description.
        /// </summary>
        /// <param name="search">search criteria</param>
        /// <returns>Array of users (Max 10)</returns>
        [WebMethod(Description = "Search for Omni users by username, email, display name, or description.")]
        public Data.User[] FriendsSearchUsers(string search, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            return Data.StoredProcedure.FriendsSearchUsers(Session.UserContext.User.id, search, 10, Session.Connection);
        }
        /// <summary>
        /// Get introduced to other Omni users (by a specific lang, and common interests).
        /// </summary>
        /// <param name="lang_id">introduction language id</param>
        /// <returns>Array of UserSimil objects (users/ratings/similarities) (Max 10)</returns>
        [WebMethod(Description = "Get introduced to other Omni users (by a specific lang, and common interests).")]
        public Data.UserSimil[] FriendsGetIntroduced(int lang_id, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            return Data.StoredProcedure.FriendsGetIntroduced(Session.UserContext.User.id, lang_id, 10, Session.Connection);
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

        #region Translations

        /// <summary>
        /// Search for translations based on certain criteria.
        /// </summary>
        /// <param name="src_lang_id">Source (Search) Lang ID</param>
        /// <param name="dst_lang_id">Destination Lang ID</param>
        /// <param name="keyword">search keyword</param>
        /// <param name="session">session id</param>
        /// <returns>Array of Translations</returns>
        [WebMethod(Description = "Search for translations based on certain criteria.")]
        public Data.Translation[] TranslationSearch(string keyword, int src_lang_id, int dst_lang_id, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Data.StoredProcedure.TranslationSearch(keyword, src_lang_id, dst_lang_id, Session.Connection);
        }

        /// <summary>
        /// Get all unapproved translations for the current user.
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>Array of Translations</returns>
        [WebMethod(Description = "Get all unapproved translations for the current user.")]
        public Data.Translation[] TranslationGetUnapprovedForUser(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            Data.Translation[] trans = Data.StoredProcedure.TranslationGetUnapprovedForUser(Session.UserContext.User.id, Session.Connection);

            if (trans != null)
            {
                foreach (Data.Translation t in trans)
                {
                    t.username = UserUsernameById(t.user_id, Session.Connection);
                    if(t.dst_type == Omni.Data.TransDstType.User)
                        t.dst_username = UserUsernameById(t.dst_id, Session.Connection);

                }
            }

            return trans;
        }

        /// <summary>
        /// Get all translations owned by the current user, except those pending approval.
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>Array of Translations</returns>
        [WebMethod(Description = "Get all translations owned by the current user, except those pending approval.")]
        public Data.Translation[] TranslationGetNonPendingApprovalForUser(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            Data.Translation[] trans = Data.StoredProcedure.TranslationGetNonPendingApprovalForUser(Session.UserContext.User.id, Session.Connection);

            if (trans != null)
            {
                foreach (Data.Translation t in trans)
                {
                    t.username = UserUsernameById(t.user_id, Session.Connection);
                    if (t.dst_type == Omni.Data.TransDstType.User)
                        t.dst_username = UserUsernameById(t.dst_id, Session.Connection);

                }
            }

            return trans;
        }

        /// <summary>
        /// Get all open personal translation requests for a user.
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>Array of Translations</returns>
        [WebMethod(Description = "Get all open personal translation requests for a user.")]
        public Data.Translation[] TranslationGetRequestsForUser(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            Data.Translation[] trans = Data.StoredProcedure.TranslationGetRequestsForUser(Session.UserContext.User.id, Session.Connection);

            if (trans != null)
            {
                foreach (Data.Translation t in trans)
                {
                    t.username = UserUsernameById(t.user_id, Session.Connection);
                    if (t.dst_type == Omni.Data.TransDstType.User)
                        t.dst_username = UserUsernameById(t.dst_id, Session.Connection);

                }
            }

            return trans;
        }

        /// <summary>
        /// Find global translation requests for a user (based on their languages).
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>Array of Translations</returns>
        [WebMethod(Description = "Find global translation requests for a user (based on their languages).")]
        public Data.Translation[] TranslationFindGlobalRequestsForUser(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            Data.Translation[] trans = Data.StoredProcedure.TranslationFindGlobalRequestsForUser(Session.UserContext.User.id, Session.Connection);

            if (trans != null)
            {
                foreach (Data.Translation t in trans)
                {
                    t.username = UserUsernameById(t.user_id, Session.Connection);
                    if (t.dst_type == Omni.Data.TransDstType.User)
                        t.dst_username = UserUsernameById(t.dst_id, Session.Connection);

                }
            }

            return trans;
        }

        /// <summary>
        /// Get a translation request by ID.
        /// </summary>
        /// <param name="req_id">translation request id</param>
        /// <param name="session">session id</param>
        /// <returns>Translation (or null if none)</returns>
        [WebMethod(Description = "Get a translation request by ID.")]
        public Data.Translation TranslationRequestGetById(int req_id, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            Data.Translation trans = Data.StoredProcedure.TranslationRequestGetById(req_id, Session.Connection);

            if (trans != null)
            {
                trans.username = UserUsernameById(trans.user_id, Session.Connection);
                if (trans.dst_type == Omni.Data.TransDstType.User)
                    trans.dst_username = UserUsernameById(trans.dst_id, Session.Connection);
            }
            return trans;
        }

        /// <summary>
        /// Get all translation answers for a Request ID.
        /// </summary>
        /// <param name="req_id">translation request id</param>
        /// <param name="session">session id</param>
        /// <returns>Array of Translations (possibly empty)</returns>
        [WebMethod(Description = "Get all translation answers for a Request ID.")]
        public Data.Translation[] TranslationAnswersGetByReqId(int req_id, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            int user_id = 0;
            if (Session.UserContext.User != null) user_id = Session.UserContext.User.id;

            Data.Translation[] trans = Data.StoredProcedure.TranslationAnswersGetByReqId(user_id, req_id, Session.Connection);

            if (trans != null)
            {
                foreach (Data.Translation t in trans)
                {
                    t.username = UserUsernameById(t.user_id, Session.Connection);
                    if (t.dst_type == Omni.Data.TransDstType.User)
                        t.dst_username = UserUsernameById(t.dst_id, Session.Connection);
                    t.trans_username = UserUsernameById(t.trans_user, Session.Connection);
                }
            }
            return trans;
        }

        /// <summary>
        /// Request a translation from other users.
        /// </summary>
        /// <param name="src_lang_id">src_lang_id</param>
        /// <param name="dst_lang_id">dst_lang_id</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="dst_id">dst_id</param>
        /// <param name="dst_type">dst_type</param>
        /// <param name="session">session id</param>
        /// <returns>1 for success</returns>
        [WebMethod(Description = "Request a translation from other users.")]
        public int TranslationRequestAdd(int src_lang_id, int dst_lang_id, string subject, string message, int dst_id, Data.TransDstType dst_type, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            return Data.StoredProcedure.TranslationRequestAdd(Session.UserContext.User.id, src_lang_id, dst_lang_id, subject, message, dst_id, dst_type, Session.Connection);
        }

        /// <summary>
        /// Answer a translation request.
        /// </summary>
        /// <param name="req_id">request id</param>
        /// <param name="message">message to translate/param>
        /// <param name="session">session id</param>
        /// <returns>0 for success</returns>
        [WebMethod(Description = "Answer a translation request.")]
        public int TranslationAnswerAdd(int req_id, string message, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            return Data.StoredProcedure.TranslationAnswerAdd(Session.UserContext.User.id, req_id, message, Session.Connection);
        }

        /// <summary>
        /// Rate a translation answer.
        /// </summary>
        /// <param name="trans_ans_id">translation answer id</param>
        /// <param name="rating">answer rating</param>
        /// <param name="session">session id</param>
        /// <returns>0 for success</returns>
        [WebMethod(Description = "Rate a translation answer.")]
        public int TranslationAnswerRate(int trans_ans_id, int rating, Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            if (!Session.UserContext.IsLoggedIn) throw new UserNotLoggedInException();
            return Data.StoredProcedure.TranslationAnswerRate(Session.UserContext.User.id, trans_ans_id, rating, Session.Connection);
        }

        #endregion


        #region Hall of Fame
        /// <summary>
        /// Get the users in the Hall of Fame, for Most Active.
        /// </summary>>
        /// <returns>Array of UserRank objects (users/ranks) (Max 40)</returns>
        [WebMethod(Description = "Get the users in the Hall of Fame, for Most Active.")]
        public Data.UserRank[] HallOfFameByQuantity(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            int user_id = 0;
            if (Session.UserContext.User != null) user_id = Session.UserContext.User.id;
            return Data.StoredProcedure.HallOfFameByQuantity(user_id, 30, 40, Session.Connection);
        }
        /// <summary>
        /// Get the users in the Hall of Fame by highest User Score.
        /// </summary>>
        /// <returns>Array of UserRank objects (users/ranks) (Max 40)</returns>
        [WebMethod(Description = "Get the users in the Hall of Fame by highest User Score.")]
        public Data.UserRank[] HallOfFameByRating(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            int user_id = 0;
            if (Session.UserContext.User != null) user_id = Session.UserContext.User.id;
            return Data.StoredProcedure.HallOfFameByRating(user_id, 40, Session.Connection);
        }
        #endregion


        #region Lookup service
        /// <summary>
        /// Dictionary definition lookup service.
        /// </summary>
        /// <param name="lang_id">Language id</param>
        /// <param name="word">Word</param>
        /// <returns>Definition for word</returns>
        [WebMethod(Description = "Dictionary definition lookup service. (PUBLIC / SESSIONLESS)")]
        public string DefinitionLookup(string lang, string word)
        {
            return External.DictionaryService.Lookup(lang, word);
        }

        /// <summary>
        /// Translate a message automatically. (PUBLIC / SESSIONLESS)
        /// </summary>
        /// <param name="src_lang_id">Source language id</param>
        /// <param name="dst_lang_id">Destination language id</param>
        /// <param name="message">Message</param>
        /// <returns>Translated message</returns>
        [WebMethod(Description = "Translate a message automatically. (PUBLIC / SESSIONLESS)")]
        public string TranslationLookup(string src_lang, string dst_lang, string message)
        {
            return External.TranslationService.Lookup(src_lang, dst_lang, message);
        }
        #endregion


    }
}
