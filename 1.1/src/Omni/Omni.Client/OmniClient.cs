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
            return 1;
        }

        /// <summary>
        /// Update interests for a user. Any user interests not
        /// in this list will be removed from the user's interests.
        /// </summary>
        /// <param name="ids">array of interest ids</param>
        /// <returns>0 for success</returns>
        public int UserUpdateInterests(int[] ids)
        {
            CheckSession();
            try
            {
                return service.UserUpdateInterests(ids, session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return -1;
        }

        /// <summary>
        /// Update languages for a user. Any user languages not
        /// in this list will be removed from the user's languages.
        /// </summary>
        /// <param name="ids">array of interest ids</param>
        /// <returns>0 for success</returns>
        public int UserUpdateLanguages(int[] ids, int[] skills)
        {
            CheckSession();
            try
            {
                return service.UserUpdateLanguages(ids, skills, session);
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

        /// <summary>
        /// Get interests for a user.
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Array of Interests</returns>
        public Interest[] UserInterests(int id)
        {
            CheckSession();
            try
            {
                org.omniproject.service.Interest[] svcInterests = service.UserInterests(id, session);
                if (svcInterests == null) return null;
                Interest[] interests = new Interest[svcInterests.Length];
                for (int i = 0; i < interests.Length; i++)
                {
                    interests[i] = new Interest(svcInterests[i]);
                }
                return interests;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }
        /// <summary>
        /// Get a user's profile.
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>User object</returns>
        public User UserProfile(int id)
        {
            CheckSession();
            try
            {
                org.omniproject.service.User svcUser = service.UserProfile(id, session);
                if (svcUser == null) return null;
                return new User(svcUser);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }
        /// <summary>
        /// Get languages for a user.
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Array of UserLanguages</returns>
        public UserLanguage[] UserLanguages(int id)
        {
            CheckSession();
            try
            {
                org.omniproject.service.UserLanguage[] svcLanguages = service.UserLanguages(id, session);
                if (svcLanguages == null) return null;
                UserLanguage[] languages = new UserLanguage[svcLanguages.Length];
                for (int i = 0; i < languages.Length; i++)
                {
                    languages[i] = new UserLanguage(svcLanguages[i]);
                }
                return languages;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }
        /// <summary>
        /// Get a user's summary.
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>UserSummary object</returns>
        public UserSummary UserSummary(int id)
        {
            CheckSession();
            try
            {
                org.omniproject.service.UserSummary svcUser = service.UserSummary(id, session);
                if (svcUser == null) return null;
                return new UserSummary(svcUser);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }
        #endregion

        #region Friends
        /// <summary>
        /// Get all friends for the current user.
        /// </summary>
        /// <returns>Array of Users</returns>
        public User[] FriendsList()
        {
            CheckSession();
            try
            {
                org.omniproject.service.User[] svcUsers = service.FriendsList(session);
                if (svcUsers == null) return null;
                User[] users = new User[svcUsers.Length];
                for (int i = 0; i < users.Length; i++)
                {
                    users[i] = new User(svcUsers[i]);
                }
                return users;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }
        /// <summary>
        /// Checks if this user has Friend on their friends list.
        /// </summary>
        /// <param name="friend_id">friend id</param>
        /// <returns>1 if they do, 0 otherwise</returns>
        public int FriendsCheckFriendPair(int friend_id)
        {
            CheckSession();
            try
            {
                return service.FriendsCheckFriendPair(friend_id, session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return 0;
        }
        /// <summary>
        /// Adds a friend to this user's friend list.
        /// </summary>
        /// <param name="friend_id">friend id</param>
        /// <returns>1 for success</returns>
        public int FriendsAdd(int friend_id)
        {
            CheckSession();
            try
            {
                return service.FriendsAdd(friend_id, session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return 0;
        }
        /// <summary>
        /// Removes a friend to this user's friend list.
        /// </summary>
        /// <param name="friend_id">friend id</param>
        /// <param name="session">session id</param>
        /// <returns>1 for success</returns>
        public int FriendsRemove(int friend_id)
        {
            CheckSession();
            try
            {
                return service.FriendsRemove(friend_id, session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return 0;
        }
        /// <summary>
        /// Search for a user in Omni by username, display name, email, or description.
        /// </summary>
        /// <returns>Array of Users</returns>
        public User[] FriendsSearchUsers(string search)
        {
            CheckSession();
            try
            {
                org.omniproject.service.User[] svcUsers = service.FriendsSearchUsers(search, session);
                if (svcUsers == null) return null;
                User[] users = new User[svcUsers.Length];
                for (int i = 0; i < users.Length; i++)
                {
                    users[i] = new User(svcUsers[i]);
                }
                return users;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }
        /// <summary>
        /// Get introduced to other Omni users (by a specific lang, and common interests).
        /// </summary>
        /// <returns>Array of UserSimil</returns>
        public UserSimil[] FriendsGetIntroduced(int lang_id)
        {
            CheckSession();
            try
            {
                org.omniproject.service.UserSimil[] svcUsers = service.FriendsGetIntroduced(lang_id, session);
                if (svcUsers == null) return null;
                UserSimil[] users = new UserSimil[svcUsers.Length];
                for (int i = 0; i < users.Length; i++)
                {
                    users[i] = new UserSimil(svcUsers[i]);
                }
                return users;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }
        #endregion

        #region Interest
        /// <summary>
        /// Get all interests in the system.
        /// </summary>
        /// <returns>Interests (array of interest ids)</returns>
        public Interest[] InterestList()
        {
            CheckSession();
            try
            {
                org.omniproject.service.Interest[] svcInterests = service.InterestList(session);
                if (svcInterests == null) return null;
                Interest[] interests = new Interest[svcInterests.Length];
                for (int i = 0; i < interests.Length; i++)
                {
                    interests[i] = new Interest(svcInterests[i]);
                }
                return interests;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }
        
        #endregion

        #region Language
        /// <summary>
        /// Get all languages in the system.
        /// </summary>
        /// <returns>Array of Languages (id & culture code)</returns>
        public Language[] LanguageList()
        {
            CheckSession();
            try
            {
                org.omniproject.service.Language[] svcLanguages = service.LanguageList(session);
                if (svcLanguages == null) return null;
                Language[] languages = new Language[svcLanguages.Length];
                for (int i = 0; i < languages.Length; i++)
                {
                    languages[i] = new Language(svcLanguages[i]);
                }
                return languages;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        #endregion

        #region Translation

        /// <summary>
        /// Search for translations based on certain criteria.
        /// </summary>
        /// <param name="src_lang_id">Source (Search) Lang ID</param>
        /// <param name="dst_lang_id">Destination Lang ID</param>
        /// <param name="keyword">search keyword</param>
        /// <returns>Array of Translations</returns>
        public Translation[] TranslationSearch(string keyword, int src_lang_id, int dst_lang_id)
        {
            CheckSession();
            try
            {
                org.omniproject.service.Translation[] svcObj = service.TranslationSearch(keyword, src_lang_id, dst_lang_id, session);
                if (svcObj == null) return null;
                Translation[] objArray = new Translation[svcObj.Length];
                for (int i = 0; i < objArray.Length; i++)
                {
                    objArray[i] = new Translation(svcObj[i]);
                }
                return objArray;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        /// <summary>
        /// Get all unapproved translations for the current user.
        /// </summary>
        /// <returns>Array of Translations</returns>
        public Translation[] TranslationGetUnapprovedForUser()
        {
            CheckSession();
            try
            {
                org.omniproject.service.Translation[] svcObj = service.TranslationGetUnapprovedForUser(session);
                if (svcObj == null) return null;
                Translation[] objArray = new Translation[svcObj.Length];
                for (int i = 0; i < objArray.Length; i++)
                {
                    objArray[i] = new Translation(svcObj[i]);
                }
                return objArray;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        /// <summary>
        /// Get all translations owned by the current user, except those pending approval.
        /// </summary>
        /// <returns>Array of Translations</returns>
        public Translation[] TranslationGetNonPendingApprovalForUser()
        {
            CheckSession();
            try
            {
                org.omniproject.service.Translation[] svcObj = service.TranslationGetNonPendingApprovalForUser(session);
                if (svcObj == null) return null;
                Translation[] objArray = new Translation[svcObj.Length];
                for (int i = 0; i < objArray.Length; i++)
                {
                    objArray[i] = new Translation(svcObj[i]);
                }
                return objArray;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        /// <summary>
        /// Get all open personal translation requests for a user.
        /// </summary>
        /// <returns>Array of Translations</returns>
        public Translation[] TranslationGetRequestsForUser()
        {
            CheckSession();
            try
            {
                org.omniproject.service.Translation[] svcObj = service.TranslationGetRequestsForUser(session);
                if (svcObj == null) return null;
                Translation[] objArray = new Translation[svcObj.Length];
                for (int i = 0; i < objArray.Length; i++)
                {
                    objArray[i] = new Translation(svcObj[i]);
                }
                return objArray;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        /// <summary>
        /// Find global translation requests for a user (based on their languages).
        /// </summary>
        /// <returns>Array of Translations</returns>
        public Translation[] TranslationFindGlobalRequestsForUser()
        {
            CheckSession();
            try
            {
                org.omniproject.service.Translation[] svcObj = service.TranslationFindGlobalRequestsForUser(session);
                if (svcObj == null) return null;
                Translation[] objArray = new Translation[svcObj.Length];
                for (int i = 0; i < objArray.Length; i++)
                {
                    objArray[i] = new Translation(svcObj[i]);
                }
                return objArray;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        /// <summary>
        /// Get a translation request by ID.
        /// </summary>
        /// <param name="req_id">translation request id</param>
        /// <returns>Translation (or null if none)</returns>
        public Translation TranslationRequestGetById(int req_id)
        {
            CheckSession();
            try
            {
                org.omniproject.service.Translation svcObj = service.TranslationRequestGetById(req_id, session);
                if (svcObj == null) return null;
                Translation outObj = new Translation(svcObj);
                return outObj;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        /// <summary>
        /// Get all translation answers for a Request ID.
        /// </summary>
        /// <param name="req_id">translation request id</param>
        /// <param name="session">session id</param>
        /// <returns>Array of Translations (possibly empty)</returns>
        public Translation[] TranslationAnswersGetByReqId(int req_id)
        {
            CheckSession();
            try
            {
                org.omniproject.service.Translation[] svcObj = service.TranslationAnswersGetByReqId(req_id, session);
                if (svcObj == null) return null;
                Translation[] objArray = new Translation[svcObj.Length];
                for (int i = 0; i < objArray.Length; i++)
                {
                    objArray[i] = new Translation(svcObj[i]);
                }
                return objArray;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        /// <summary>
        /// Add a translation request.
        /// </summary>
        /// <returns>0 for success</returns>
        public int TranslationRequestAdd(int src_lang_id, int dst_lang_id, string subject, string message, int dst_id, int dst_type)
        {
            CheckSession();
            try
            {
                return service.TranslationRequestAdd(src_lang_id, dst_lang_id, subject, message, dst_id, (org.omniproject.service.TransDstType)dst_type,  session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return 1;
        }

        /// <summary>
        /// Answer an existing translation request.
        /// </summary>
        /// <returns>0 for success</returns>
        public int TranslationAnswerAdd(int req_id, string message)
        {
            CheckSession();
            try
            {
                return service.TranslationAnswerAdd(req_id, message, session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return 1;
        }

        /// <summary>
        /// Rate an existing translation answer.
        /// </summary>
        /// <returns>0 for success</returns>
        public int TranslationAnswerRate(int trans_ans_id, int rating)
        {
            CheckSession();
            try
            {
                return service.TranslationAnswerRate(trans_ans_id, rating, session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return 1;
        }

        /// <summary>
        /// Close a translation request (opened by the current user) by approving a specific answer.
        /// </summary>
        /// <param name="req_id">req_id</param>
        /// <param name="ans_id">ans_id</param>
        /// <returns>0 for success</returns>
        public int TranslationRequestClose(int req_id, int ans_id)
        {
            CheckSession();
            try
            {
                return service.TranslationRequestClose(req_id, ans_id, session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return 1;
        }

        #endregion

        #region Message

        /// <summary>
        /// Get received messages for a user.
        /// </summary>
        /// <returns>Array of Messages</returns>
        public Message[] MessageGetReceivedForUser()
        {
            CheckSession();
            try
            {
                org.omniproject.service.Message[] svcObj = service.MessageGetReceivedForUser(session);
                if (svcObj == null) return null;
                Message[] objArray = new Message[svcObj.Length];
                for (int i = 0; i < objArray.Length; i++)
                {
                    objArray[i] = new Message(svcObj[i]);
                }
                return objArray;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        /// <summary>
        /// Get received messages for a user.
        /// </summary>
        /// <returns>Array of Messages</returns>
        public Message[] MessageGetSentForUser()
        {
            CheckSession();
            try
            {
                org.omniproject.service.Message[] svcObj = service.MessageGetSentForUser(session);
                if (svcObj == null) return null;
                Message[] objArray = new Message[svcObj.Length];
                for (int i = 0; i < objArray.Length; i++)
                {
                    objArray[i] = new Message(svcObj[i]);
                }
                return objArray;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        /// <summary>
        /// Get a message by ID.
        /// </summary>
        /// <returns>Message</returns>
        public Message MessageGetById(int msg_id)
        {
            CheckSession();
            try
            {
                org.omniproject.service.Message svcObj = service.MessageGetById(msg_id, session);
                if (svcObj == null) return null;
                return new Message(svcObj);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        /// <summary>
        /// Send a message to an Omni member.
        /// </summary>
        /// <returns></returns>
        public int MessageSend(int dst_id, int dst_type, string subject, string message)
        {
            CheckSession();
            try
            {
                return service.MessageSend(dst_id, (org.omniproject.service.MsgDstType)dst_type, subject, message, session);
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return 1;
        }

        #endregion


        #region Hall of Fame

        /// <summary>
        /// Get the users in the Hall of Fame, for Most Active.
        /// </summary>
        /// <returns>Array of UserRank</returns>
        public UserRank[] HallOfFameByQuantity()
        {
            CheckSession();
            try
            {
                org.omniproject.service.UserRank[] svcUsers = service.HallOfFameByQuantity(session);
                if (svcUsers == null) return null;
                UserRank[] users = new UserRank[svcUsers.Length];
                for (int i = 0; i < users.Length; i++)
                {
                    users[i] = new UserRank(svcUsers[i]);
                }
                return users;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
        }

        /// <summary>
        /// Get the users in the Hall of Fame, by highest User Score.
        /// </summary>
        /// <returns>Array of UserRank</returns>
        public UserRank[] HallOfFameByRating()
        {
            CheckSession();
            try
            {
                org.omniproject.service.UserRank[] svcUsers = service.HallOfFameByRating(session);
                if (svcUsers == null) return null;
                UserRank[] users = new UserRank[svcUsers.Length];
                for (int i = 0; i < users.Length; i++)
                {
                    users[i] = new UserRank(svcUsers[i]);
                }
                return users;
            }
            catch (System.Exception e)
            {
                Exception.Rethrow(e);
            }
            return null;
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
