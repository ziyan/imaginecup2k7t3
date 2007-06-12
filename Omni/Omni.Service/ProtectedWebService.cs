using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Omni.Service
{
    [WebService(Namespace = "http://omniproject.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProtectedWebService : System.Web.Services.WebService, System.Web.SessionState.IRequiresSessionState
    {
        private Omni.Data.SqlConnection cn = new Omni.Data.SqlConnection();
        private User user = new User();
        private string captcha = "";

        public ProtectedWebService()
        {
            //cn.Open();
        }
        
        [WebMethod]
        public User GetCurrentUser()
        {
            return user;
        }

        #region User Related Functions
        [WebMethod]
        public byte[] UserCaptcha(int width, int height, string bgColor, string frontColor)
        {
            this.captcha = Common.GetRandomString(Common.HumanFriendlyCharacterSet, Common.CaptchaLength);
            return Common.GetCaptchaImage(captcha, width, height, System.Drawing.Color.FromName(bgColor), System.Drawing.Color.FromName(frontColor));
        }
      
        [WebMethod]
        public int UserRegister(string username, string md5password, string email, string name, string description, short timezone, string captcha)
        {
            if (username == null || username == "" ||
                md5password == null || md5password.Length != 32 ||
                email == null || email == "" ||
                name == null || name == "" ||
                captcha == null || captcha.Length != Common.CaptchaLength)
                throw new ArgumentNullException();
            if (timezone < -12 || timezone > 13) throw new ArgumentOutOfRangeException("Timezone out of range.");
            if (!Common.ValidateEmail(email)) throw new ArgumentOutOfRangeException("Email is invalid.");
            if (captcha != this.captcha) throw new ArgumentException("Invalid captcha.");
            string randomText = Common.GetRandomString(Common.HexCharacterSet, 10).ToLower();

            return Data.StoredProcedure.UserRegister(username, randomText+Common.GetMD5Hash(md5password.ToLower()+randomText), email, name, description, timezone, cn);
        }

        [WebMethod]
        public bool UserLogin(string email, string md5password, string captcha)
        {
            return false;
        }

        [WebMethod]
        public bool UserIsLoggedIn()
        {
            return user != null;
        }
        #endregion
    }
    
}
