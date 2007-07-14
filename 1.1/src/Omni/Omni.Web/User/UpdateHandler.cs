using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.User
{
    public class UpdateHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            string name = context.Request["name"];
            string email = context.Request["email"];
            string description = context.Request["description"];
            string sn_network = context.Request["snnetwork"];
            string sn_screenname = context.Request["snscreenname"];

            int failure = 1;
            string status = "Unknown";
            if (name != null && name != "" && email != null && email != "")
            {
                if (description == null) description = "";
                if (sn_network == null) sn_network = "";
                if (sn_screenname == null) sn_screenname = "";

                try
                {
                    failure = Common.Client.UserUpdate(name, email, description, sn_network, sn_screenname);
                    if (failure != 0)
                    {
                        status = "Failure";
                    }
                    else
                    {
                        status = "Updated";
                    }
                }
                catch (Omni.InvalidEmailException)
                {
                    status = "InvalidEmail";
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
