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
        [WebMethod(true)]
        public void Initialize()
        {
            HttpContext.Current.Session["SqlConnection"] = new Omni.Data.SqlConnection();
            HttpContext.Current.Session["Captcha"] = "";
        }


        #region User Related Functions
        [WebMethod(true)]
        public byte[] UserCaptcha(int width, int height, string bgColor, string frontColor)
        {
            HttpContext.Current.Session["Captcha"] = Common.GetRandomString(Common.HumanFriendlyCharacterSet, Common.CaptchaLength);
            return Common.GetCaptchaImage(HttpContext.Current.Session["Captcha"].ToString(), width, height, System.Drawing.Color.FromName(bgColor), System.Drawing.Color.FromName(frontColor));
        }
      
        [WebMethod(true)]
        public int UserRegister(string username, string md5password, string email, string name, string description, string captcha)
        {
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
            return HttpContext.Current.Session["User"]!=null;
        }

        [WebMethod(true)]
        public void UserLogout()
        {
            HttpContext.Current.Session["User"] = null;
        }
        [WebMethod(true)]
        public User UserCurrent()
        {
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

        [WebMethod(true)]
        public Language[] LanguageList()
        {
            return Data.StoredProcedure.LangList((Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public string LanuageNameQueryById(int lang_id, int dst_lang_id)
        {
            return Data.StoredProcedure.LangLangQueryById(lang_id,dst_lang_id,(Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }
    }
    
}
