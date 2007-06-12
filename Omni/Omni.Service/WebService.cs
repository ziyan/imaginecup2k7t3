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
        [WebMethod(true)]
        public byte[] UserCaptcha(int width, int height, string bgColor, string frontColor)
        {
            if (HttpContext.Current.Session["Initialized"] != null) throw new SystemException("Session not initiliated.");
            HttpContext.Current.Session["Captcha"] = Common.GetRandomString(Common.HumanFriendlyCharacterSet, Common.CaptchaLength);
            return Common.GetCaptchaImage(HttpContext.Current.Session["Captcha"].ToString(), width, height, System.Drawing.Color.FromName(bgColor), System.Drawing.Color.FromName(frontColor));
        }
      
        [WebMethod(true)]
        public int UserRegister(string username, string md5password, string email, string name, string description, string captcha)
        {
            if (HttpContext.Current.Session["Initialized"] != null) throw new SystemException("Session not initiliated.");
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

        [WebMethod(true)]
        public User UserAuthorizeByUsername(string username, string md5password)
        {
            if (HttpContext.Current.Session["Initialized"] != null) throw new SystemException("Session not initiliated.");
            if (username == null || username == "" ||
                md5password == null || md5password.Length != 32)
                throw new ArgumentNullException();
            if (HttpContext.Current.Session["User"] != null) throw new ArgumentException("User already logged in.");
            string password = Data.StoredProcedure.UserAuthorizeByUsername(username, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
            string randomText = password.Substring(0, Common.PasswordRandomTextLength).ToLower();
            if (password == randomText + Common.GetMD5Hash(md5password.ToLower() + randomText))
            {
                User user = Data.StoredProcedure.UserPostAuthorizeByUsername(username, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
                HttpContext.Current.Session["User"] = user;
                return user;
            }
            else
            {
                return null;
            }
        }

        [WebMethod(true)]
        public bool UserIsLoggedIn()
        {
            if (HttpContext.Current.Session["Initialized"] != null) throw new SystemException("Session not initiliated.");
            return HttpContext.Current.Session["User"]!=null;
        }

        [WebMethod(true)]
        public void UserLogout()
        {
            if (HttpContext.Current.Session["Initialized"] != null) throw new SystemException("Session not initiliated.");
            HttpContext.Current.Session["User"] = null;
        }
        [WebMethod(true)]
        public User UserCurrent()
        {
            if (HttpContext.Current.Session["Initialized"] != null) throw new SystemException("Session not initiliated.");
            return HttpContext.Current.Session["User"] == null ? null : (User)HttpContext.Current.Session["User"];
        }
        #endregion


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

        #region Language

        [WebMethod(true)]
        public Language[] LanguageList()
        {
            if (HttpContext.Current.Session["Initialized"] != null) throw new SystemException("Session not initiliated.");
            return Data.StoredProcedure.LangList((Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public string LanguageNameQueryById(int lang_id, int dst_lang_id)
        {
            if (HttpContext.Current.Session["Initialized"] != null) throw new SystemException("Session not initiliated.");
            if (lang_id < 1 || dst_lang_id < 1) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.LangLangQueryById(lang_id,dst_lang_id,(Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        #endregion


        #region Interest
        [WebMethod(true)]
        public Interest[] InterestList(int parent_id)
        {
            if (HttpContext.Current.Session["Initialized"] != null) throw new SystemException("Session not initiliated.");
            if (parent_id < 0) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.InterestList(parent_id,(Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public string InterestNameQueryById(int interest_id, int lang_id)
        {
            if (HttpContext.Current.Session["Initialized"] != null) throw new SystemException("Session not initiliated.");
            if (interest_id < 1 || lang_id < 1) throw new ArgumentOutOfRangeException();
            return Data.StoredProcedure.InterestLangQueryById(interest_id, lang_id, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }
        #endregion
    }
    
}
