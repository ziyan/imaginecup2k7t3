using System;
using System.Web;

namespace Omni.Web.Session
{
    public class KeepAliveHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            Common.Client.KeepAlive();
            context.Response.Write(Common.Client.Session.ToString());
            context.Response.Flush();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
