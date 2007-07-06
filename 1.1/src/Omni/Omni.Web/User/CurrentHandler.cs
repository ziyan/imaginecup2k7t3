using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.User
{
    public class CurrentHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            Client.User user = Common.Client.UserCurrent;
            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("loggedin"), new JSONBoolValue(user != null));
            if (user != null)
            {
                collection.Add(new JSONStringValue("id"), new JSONNumberValue(user.ID));
                collection.Add(new JSONStringValue("username"), new JSONStringValue(user.Username));                
                collection.Add(new JSONStringValue("email"), new JSONStringValue(user.Email));
                collection.Add(new JSONStringValue("name"), new JSONStringValue(user.Name));
                collection.Add(new JSONStringValue("description"), new JSONStringValue(user.Description==null?"":user.Description));
                collection.Add(new JSONStringValue("reg_date"), new JSONStringValue(user.RegDate.ToString()));
                collection.Add(new JSONStringValue("log_date"), new JSONStringValue(user.LogDate.ToString()));
                

            }
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
