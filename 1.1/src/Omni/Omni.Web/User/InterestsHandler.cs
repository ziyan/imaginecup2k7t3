using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.User
{
    public class InterestsHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;

            String status = "Unknown";

            String idStr = context.Request["id"];
            int userid = -1;
            Client.Interest[] interests = null;
            if (idStr != null && idStr != "")
            {
                try
                {
                    userid = Convert.ToInt32(idStr);
                    status = "Complete";
                }
                catch (System.Exception)
                {
                    status = "InvalidID";
                }
                if (userid >= 0)
                {
                    interests = Common.Client.UserInterests(userid);
                }
                else status = "InvalidID";
            }
            else status = "Incomplete";

            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
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
            collection.Add(new JSONStringValue("interests"), jsonInterests);
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
