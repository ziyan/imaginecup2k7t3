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
            return 1;
        }
        public static void SetPreferredLanguage(int lang_id)
        {
            HttpCookie cookie = new HttpCookie("omni_language");
            cookie.Value = lang_id.ToString();
            cookie.Expires = DateTime.Now.AddYears(10);
            cookie.Path = "/";
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
