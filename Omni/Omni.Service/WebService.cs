using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Omni.Service
{
    [WebService(Namespace = "http://omniproject.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebService : System.Web.Services.WebService, System.Web.SessionState.IRequiresSessionState
    {
        [WebMethod(true)]
        public void Initialize()
        {
            Omni.Data.SqlConnection cn = new Omni.Data.SqlConnection();
            cn.Open();
            HttpContext.Current.Session["SqlConnection"] = cn;
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
            string randomText = Common.GetRandomString(Common.HexCharacterSet, 10).ToLower();
            return Data.StoredProcedure.UserRegister(username, randomText + Common.GetMD5Hash(md5password.ToLower() + randomText), email, name, description, (Data.SqlConnection)HttpContext.Current.Session["SqlConnection"]);
        }

        [WebMethod(true)]
        public bool UserLogin(string email, string md5password, string captcha)
        {
            return false;
        }

        [WebMethod(true)]
        public bool UserIsLoggedIn()
        {
            return false;
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
    }
    
}
