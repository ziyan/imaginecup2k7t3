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
            if (HttpContext.Current.Session["ProtectedWebService"] == null)
            {
                org.omniproject.secure.ProtectedWebService protectedWebService = new org.omniproject.secure.ProtectedWebService();
                protectedWebService.CookieContainer = new System.Net.CookieContainer();
                HttpContext.Current.Session["ProtectedWebService"] = protectedWebService;
            }
            if (HttpContext.Current.Session["PublicWebService"] == null)
            {
                org.omniproject.service.PublicWebService publicWebService = new org.omniproject.service.PublicWebService();
                publicWebService.CookieContainer = new System.Net.CookieContainer();
                HttpContext.Current.Session["PublicWebService"] = publicWebService;
            }
        }

        public void Dispose()
        {
        }
    }
}
