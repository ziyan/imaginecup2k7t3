using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Users
{
    public class InterestsHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;

            Client.Interest[] interests = Common.Client.Interests();

            JSONArrayCollection jsonInterests = new JSONArrayCollection();
            if (interests != null)
            {
                for (int i = 0; i < interests.Length; i++)
                {
                    JSONObjectCollection obj = new JSONObjectCollection();
                    obj.Add(new JSONStringValue("id"), new JSONStringValue(interests[i].ID.ToString()));
                    obj.Add(new JSONStringValue("parent_id"), new JSONStringValue(interests[i].ParentID.ToString()));
                    obj.Add(new JSONStringValue("name"), new JSONStringValue(interests[i].Name));
                    jsonInterests.Add(obj);
                }
            }
            context.Response.Write(jsonInterests.ToString());
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
