using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Session
{
    public class KeepAliveHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            Common.Client.KeepAlive();
            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("session"), new JSONStringValue(Common.Client.Session.ToString()));
            context.Response.Write(collection.ToString());
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
