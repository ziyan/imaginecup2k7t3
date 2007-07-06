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
            string md5password = context.Request["password"];
            bool loggedin = false;
            string error = "None";
            if (username != null && md5password != null && username != "" && md5password.Length == 32)
            {
                try
                {
                    loggedin = Common.Client.UserLogin(username, md5password);
                    if (!loggedin)
                    {
                        error = "Mismatch";
                    }
                }
                catch (Omni.InvalidUsernameException)
                {
                    error = "InvalidUsername";
                }
                catch (Omni.UserAlreadyLoggedInException)
                {
                    error = "AlreadyLoggedIn";
                }
                catch (Omni.TryLoginTooManyTimesException)
                {
                    error = "TooManyTrial";
                }
            }
            else
            {
                error = "Incomplete";
            }
            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("loggedin"), new JSONBoolValue(loggedin));
            collection.Add(new JSONStringValue("error"), new JSONStringValue(error));
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
