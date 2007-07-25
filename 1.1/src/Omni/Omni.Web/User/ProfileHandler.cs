using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.User
{
    public class ProfileHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;

            string status = "Unknown";

            int user_id = Convert.ToInt32(Util.Validator.IsInteger(context.Request["user_id"]) ? context.Request["user_id"] : "0");
            Client.User user = null;
            if (user_id > 0)
            {
                try
                {
                    user = Common.Client.UserProfile(user_id);
                    if (user != null)
                        status = "OK";
                    else
                        status = "Error";//Null";
                }
                catch(System.Exception e)
                {
                    status = "Error";// +e.Message;
                }
            }
            else
            {
                status = "Incomplete";
            }


            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
            collection.Add(new JSONStringValue("user"), Common.getUserJSON(user));
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
