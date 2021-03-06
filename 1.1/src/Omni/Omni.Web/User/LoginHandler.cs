using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.User
{
    public class LoginHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            string username = context.Request["username"];
            string md5password = context.Request["md5password"];
            string status = "Unknown";
            if (username != null && md5password != null && username != "" && md5password.Length == 32)
            {
                try
                {
                    if (!Common.Client.UserLogin(username, md5password))
                        status = "Mismatch";
                    else
                        status = "LoggedIn";
                }
                catch (Omni.InvalidUsernameException)
                {
                    status = "InvalidUsername";
                }
                catch (Omni.UserAlreadyLoggedInException)
                {
                    status = "AlreadyLoggedIn";
                }
                catch (Omni.TryLoginTooManyTimesException)
                {
                    status = "TooManyTrial";
                }
            }
            else
            {
                status = "Incomplete";
            }
            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
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
