using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.User
{
    public class RegisterHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            string username = context.Request["username"];
            string md5password = context.Request["md5password"];
            string email = context.Request["email"];
            string name = context.Request["name"];
            string captcha = context.Request["captcha"];
            int user_id = 0;
            string status = "Unknown";
            if (username != null && md5password != null && email != null && name != null && captcha != null &&
                username != "" && md5password.Length == 32 && email != "" && name != "" && captcha != "")
            {
                try
                {
                    user_id = Common.Client.UserRegister(username, md5password, name, email, captcha);
                    if (user_id <= 0)
                    {
                        status = "Failure";
                    }
                    else
                    {
                        status = "Registered";
                    }
                }
                catch (Omni.InvalidUsernameException)
                {
                    status = "InvalidUsername";
                }
                catch (Omni.InvalidEmailException)
                {
                    status = "InvalidEmail";
                }
                catch (Omni.InvalidCaptchaException)
                {
                    status = "InvalidCaptcha";
                }
                catch (Omni.UserAlreadyLoggedInException)
                {
                    status = "AlreadyLoggedIn";
                }
                catch (Omni.DuplicateUsernameException)
                {
                    status = "DuplicateUsername";
                }
                catch (Omni.DuplicateEmailException)
                {
                    status = "DuplicateEmail";
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
