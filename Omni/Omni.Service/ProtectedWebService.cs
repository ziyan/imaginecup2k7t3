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
        private User user = new User();
        private string captcha = "";

        public ProtectedWebService()
        {

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
            this.captcha = Common.GetRandomString(Common.HumanFriendlyCharacterSet, 5);
            return Common.GetCaptchaImage(captcha, width, height, System.Drawing.Color.FromName(bgColor), System.Drawing.Color.FromName(frontColor));
        }
      
        [WebMethod]
        public bool UserRegister(string email, string md5password, string name, byte timezone, string captcha)
        {
            if (email == null || email == "" || md5password == null || md5password.Length != 32 || name == null || name == "" || captcha == null || captcha.Length != 4)
                throw new ArgumentNullException();
            if (captcha != this.captcha) throw new ArgumentException("Invalid captcha.");
            return true;
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
