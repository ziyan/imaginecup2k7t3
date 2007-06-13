using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Omni.Service
{
    [WebService(Namespace = "http://omniproject.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebService : System.Web.Services.WebService
    {
        /// <summary>
        /// Initialize the sql connection and the session. (Session Required)
        /// </summary>
        [WebMethod(true)]
        public void Initialize()
        {
            HttpContext.Current.Session["SqlConnection"] = new Omni.Data.SqlConnection();
            HttpContext.Current.Session["Captcha"] = "";
            HttpContext.Current.Session["Initialized"] = true;
        }

        #region User Related Functions
        /// <summary>
        /// Get a random captcha. (Session Required)
        /// </summary>
        /// <param name="width">Captcha width</param>
        /// <param name="height">Captcha height</param>
        /// <param name="bgColor">Captcha background color</param>
        /// <param name="frontColor">Captcha front color</param>
        /// <returns>Binary for the captcha gif</returns>
        [WebMethod(true)]
        public byte[] UserCaptcha(int width, int height, string bgColor, string frontColor)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            HttpContext.Current.Session["Captcha"] = Common.GetRandomString(Common.HumanFriendlyCharacterSet, Common.CaptchaLength);
            return Common.GetCaptchaImage(HttpContext.Current.Session["Captcha"].ToString(), width, height, System.Drawing.Color.FromName(bgColor), System.Drawing.Color.FromName(frontColor));
        }
      
        /// <summary>
        /// Register a new user. (Session Required)
        /// </summary>
        /// <param name="username">User name</param>
        /// <param name="md5password">MD5ed-once password, should be hex and 32 in length</param>
        /// <param name="email">User Email</param>
        /// <param name="name">User name</param>
        /// <param name="description">User profile</param>
        /// <param name="captcha">Captcha</param>
        /// <returns>The user id, less than 0 means username duplication</returns>
        [WebMethod(true)]
        public int UserRegister(string username, string md5password, string email, string name, string description, string captcha)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (username == null || username == "" ||
                md5password == null || md5password.Length != 32 ||
                email == null || email == "" ||
                name == null || name == "" ||
                captcha == null || captcha.Length != Common.CaptchaLength)
                throw new ArgumentNullException();
            //if (!Common.ValidateEmail(email)) throw new ArgumentOutOfRangeException("Email is invalid.");
            if (HttpContext.Current.Session["Captcha"] == null || captcha.ToLower() != HttpContext.Current.Session["Captcha"].ToString().ToLower()) throw new ArgumentException("Invalid captcha.");
            string randomText = Common.GetRandomString(Common.HexCharacterSet, Common.PasswordRandomTextLength).ToLower();
            return Data.StoredProcedure.UserRegister(username, randomText + Common.GetMD5Hash(md5password.ToLower() + randomText), email, name, description, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        /// <summary>
        /// Authorize a user. (Session Required)
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="md5password">MD5ed-once password, should be hex and 32 in length</param>
        /// <returns>User information if succeed, null otherwise</returns>
        [WebMethod(true)]
        public User UserAuthorizeByUsername(string username, string md5password)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (username == null || username == "" ||
                md5password == null || md5password.Length != 32)
                throw new ArgumentNullException();
            if (HttpContext.Current.Session["User"] != null) throw new InvalidOperationException("User already logged in.");
            string password = Data.StoredProcedure.UserPasswordGetByUsername(username, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
            string randomText = password.Substring(0, Common.PasswordRandomTextLength).ToLower();
            if (password == randomText + Common.GetMD5Hash(md5password.ToLower() + randomText))
            {
                User user = Data.StoredProcedure.UserAuthorizeByUsername(username, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
                HttpContext.Current.Session["User"] = user;
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Check if user is logged in. (Session Required)
        /// </summary>
        /// <returns>True if user is logged in, False otherwise.</returns>
        [WebMethod(true)]
        public bool UserIsLoggedIn()
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            return HttpContext.Current.Session["User"]!=null;
        }

        /// <summary>
        /// Logout the current user. (Session Required)
        /// </summary>
        [WebMethod(true)]
        public void UserLogout()
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (HttpContext.Current.Session["User"] == null) throw new InvalidOperationException("User not logged in yet.");
            HttpContext.Current.Session["User"] = null;
        }

        /// <summary>
        /// Return the current user information. (Session Required)
        /// </summary>
        /// <returns>null if user not logged in.</returns>
        [WebMethod(true)]
        public User UserCurrent()
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            return HttpContext.Current.Session["User"] == null ? null : (User)HttpContext.Current.Session["User"];
        }

        [WebMethod(true)]
        public void UserUpdateById(int user_id, string email, string name, string description)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (HttpContext.Current.Session["User"] == null) throw new InvalidOperationException("User not logged in.");
            if (((User)HttpContext.Current.Session["User"]).id != user_id) throw new InvalidOperationException("Not authorized.");
            Data.StoredProcedure.UserUpdateById(user_id, email, name, description, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public bool UserPasswordUpdate(string oldmd5password, string newmd5password)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (HttpContext.Current.Session["User"] == null) throw new InvalidOperationException("User not logged in.");
            string password = Data.StoredProcedure.UserPasswordGetById(UserCurrent().id, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
            string randomText = password.Substring(0, Common.PasswordRandomTextLength).ToLower();
            if (password == randomText + Common.GetMD5Hash(oldmd5password.ToLower() + randomText))
            {
                randomText = Common.GetRandomString(Common.HexCharacterSet, Common.PasswordRandomTextLength).ToLower();
                Data.StoredProcedure.UserPasswordUpdateById(UserCurrent().id, randomText + Common.GetMD5Hash(newmd5password.ToLower() + randomText), (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod(true)]
        public int UserIdGetByUsername(string username)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            return Data.StoredProcedure.UserIdGetByUsername(username,(Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }
        #endregion

        #region External Services
        [WebMethod]
        public string DictionaryLookup(int LanguageID, string SearchWord)
        {
            return DictionaryService.Lookup(LanguageID, SearchWord);
        }

        [WebMethod]
        public string TranslationLookup(int OrigLanguage, int SearchLanguage, string SearchWord)
        {
            return TranslationService.Lookup(OrigLanguage, SearchLanguage, SearchWord);
        }
        #endregion

        #region Language

        [WebMethod(true)]
        public Language[] LanguageList()
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            return Data.StoredProcedure.LangList((Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public string LanguageNameQueryById(int lang_id, int dst_lang_id)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (lang_id < 1 || dst_lang_id < 1) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.LangLangQueryById(lang_id,dst_lang_id,(Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public UserLanguage[] UserLanguageListById(int user_id)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (user_id <= 0) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.UserLangListById(user_id, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public void UserLanguageSetById(int user_id, short lang_id, short self_rating )
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (HttpContext.Current.Session["User"] == null) throw new InvalidOperationException("User not logged in.");
            if (((User)HttpContext.Current.Session["User"]).id != user_id) throw new InvalidOperationException("Not authorized.");
            if (lang_id <= 0) throw new ArgumentOutOfRangeException();
            if (self_rating <= 0) throw new ArgumentOutOfRangeException();
            Data.StoredProcedure.UserLangSetById(user_id, lang_id,self_rating, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public void UserLanguageDeleteById(int user_id, short lang_id)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (HttpContext.Current.Session["User"] == null) throw new InvalidOperationException("User not logged in.");
            if (((User)HttpContext.Current.Session["User"]).id != user_id) throw new InvalidOperationException("Not authorized.");
            if (lang_id <= 0) throw new ArgumentOutOfRangeException();
            Data.StoredProcedure.UserLangDeleteById(user_id, lang_id, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        #endregion

        #region Interest
        [WebMethod(true)]
        public Interest[] InterestList(int parent_id)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (parent_id < 0) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.InterestList(parent_id,(Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public Interest[] InterestLangList(int parent_id, int lang_id)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (parent_id < 0) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.InterestLangList(parent_id, lang_id, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public string InterestNameQueryById(int interest_id, int lang_id)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (interest_id < 1 || lang_id < 1) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.InterestLangQueryById(interest_id, lang_id, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public Interest[] UserInterestList(int user_id)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (user_id <= 0) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.UserInterestListById(user_id, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public void UserInterestAddById(int user_id, int interest_id)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (HttpContext.Current.Session["User"] == null) throw new InvalidOperationException("User not logged in.");
            if (((User)HttpContext.Current.Session["User"]).id != user_id) throw new InvalidOperationException("Not authorized.");
            Data.StoredProcedure.UserInterestAddById(user_id, interest_id, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public void UserInterestDeleteById(int user_id, int interest_id)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (HttpContext.Current.Session["User"] == null) throw new InvalidOperationException("User not logged in.");
            if (((User)HttpContext.Current.Session["User"]).id != user_id) throw new InvalidOperationException("Not authorized.");
            if (interest_id <= 0) throw new ArgumentOutOfRangeException();
            Data.StoredProcedure.UserInterestDeleteById(user_id, interest_id, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }
        #endregion

        [WebMethod(true)]
        public void TransAnsRateById(int user_id, int trans_ans_id, short rating)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (HttpContext.Current.Session["User"] == null) throw new InvalidOperationException("User not logged in.");
            if (((User)HttpContext.Current.Session["User"]).id != user_id) throw new InvalidOperationException("Not authorized to rate as this user");
            if (trans_ans_id <= 0) throw new ArgumentOutOfRangeException();
            Data.StoredProcedure.TransAnsRateById(user_id, trans_ans_id, rating, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public void MessageSend( int user_id, int dst_id, MessageDestinationType dst_type, string subject, string body)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized. Restart your fucking browser!!!");
            if (HttpContext.Current.Session["User"] == null) throw new InvalidOperationException("User not logged in.");
            if (((User)HttpContext.Current.Session["User"]).id != user_id) throw new InvalidOperationException("Not authorized to send as this user");
            if (subject == null || body == null || subject == "") throw new ArgumentNullException();
            if (user_id <= 0 || dst_id <=0) throw new ArgumentOutOfRangeException();
            Data.StoredProcedure.MessageSend(user_id, dst_id, Convert.ToInt32(dst_type), subject, body, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public Message[] MessageRecvByUser(int dst_id, MessageDestinationType dst_type)
        {
            if (HttpContext.Current.Session["Initialized"] == null) throw new SystemException("Session not initialized.");
            if (HttpContext.Current.Session["User"] == null) throw new InvalidOperationException("User not logged in.");
            if (dst_id <= 0) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.MessageRecvByUser(dst_id, Convert.ToInt32(dst_type), (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }
    }
    
}
