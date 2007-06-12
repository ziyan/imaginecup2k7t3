using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Omni.Web
{
    public static class Common
    {
        public static org.omniproject.WebService GetWebService()
        {
            if (HttpContext.Current.Session==null||HttpContext.Current.Session["WebService"] == null) throw new NullReferenceException("No session used.");
            return (org.omniproject.WebService)HttpContext.Current.Session["WebService"];
        }
        public static string GetMD5Hash(string message)
        {
            System.Security.Cryptography.MD5 hash = new System.Security.Cryptography.MD5CryptoServiceProvider();
            hash.Initialize();
            return BitConverter.ToString(hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(message))).Replace("-", "").ToLower();
        }
        public static int GetPreferredLanguage()
        {
            HttpCookie cookie = HttpContext.Current.Response.Cookies["omni_preferred_language"];
            if (cookie == null) return 0;
            return Convert.ToInt32(cookie.Value);
        }
        public static void SetPreferredLanguage(int lang_id)
        {
            HttpCookie cookie = new HttpCookie("omni_preferred_language");
            cookie.Value = lang_id.ToString();
            cookie.Expires = DateTime.Now.AddYears(10);
            cookie.Path = "/";
            cookie.Domain = HttpContext.Current.Request.Headers["Host"];
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
