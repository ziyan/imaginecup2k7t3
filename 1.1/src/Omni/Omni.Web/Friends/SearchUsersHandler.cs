using System;
using System.Web;
using System.Web.SessionState;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Friends
{
    public class SearchUsersHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string search = context.Request["search"];
            if (search == null) search = "";

            Client.User[] results;
            results = Common.Client.FriendsSearchUsers(search);

            JSONArrayCollection jsonUsers = new JSONArrayCollection();
            if (results != null)
            {
                for (int i = 0; i < results.Length; i++)
                {
                    jsonUsers.Add(Common.getUserJSON(results[i]));
                }
            }
            context.Response.Write(jsonUsers.ToString());
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
