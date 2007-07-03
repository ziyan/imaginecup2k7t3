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
        }

        public void Dispose()
        {
        }
    }
}
