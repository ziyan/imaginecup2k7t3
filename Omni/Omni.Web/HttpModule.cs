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
            if (!HttpContext.Current.Request.Path.ToLower().StartsWith("/selectpreferredlanguage.aspx"))
            {
                if (Common.GetPreferredLanguage() <= 0)
                {
                    HttpContext.Current.Response.Redirect("/SelectPreferredLanguage.aspx");
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                }
            }

        }

        public void Dispose()
        {
        }
    }
}
