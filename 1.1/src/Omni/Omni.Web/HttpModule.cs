using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Omni.Web
{
    public class HttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PostAcquireRequestState += new EventHandler(context_PostAcquireRequestState);
        }

        void context_PostAcquireRequestState(object sender, EventArgs e)
        {
            //filter out web service requests
            if (HttpContext.Current.Request.FilePath.ToLower().EndsWith(".asmx"))
                return;
            //filter out non-session requests
            if (HttpContext.Current.Session == null) return;
            //initialize client
            if (HttpContext.Current.Session["Client"] == null)
            {
                Omni.Client.OmniClient client = new Omni.Client.OmniClient();
                HttpContext.Current.Session["Client"] = client;
            }

            /*
            if (HttpContext.Current.Request.Path.ToLower().StartsWith("/service/")) return;
            if (HttpContext.Current.Session == null) return;
            if (HttpContext.Current.Session["WebService"] == null)
            {
                org.omniproject.WebService webService = new org.omniproject.WebService();
                webService.CookieContainer = new System.Net.CookieContainer();
                webService.Initialize();
                HttpContext.Current.Session["WebService"] = webService;
            }
            //select preferred language
            if (HttpContext.Current.Request.Path.ToLower().EndsWith(".aspx") && !HttpContext.Current.Request.Path.ToLower().Contains("selectpreferredlanguage.aspx"))
            {
                if (Common.GetPreferredLanguage() <= 0)
                {
                    HttpContext.Current.Response.Redirect("SelectPreferredLanguage.aspx");
                    HttpContext.Current.Response.End();
                }
            }
            switch (Omni.Web.Common.GetPreferredLanguage())
            {
                case 2:
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");

                    break;
                default:
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    break;
            }
            */
        }

        public void Dispose()
        {
        }
    }
}
