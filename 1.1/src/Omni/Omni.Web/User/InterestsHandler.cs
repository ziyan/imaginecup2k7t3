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

            string status = "Unknown";

            int user_id = Convert.ToInt32(Util.Validator.IsInteger(context.Request["user_id"]) ? context.Request["user_id"] : "0");
            Client.Interest[] interests = null;
            if (user_id > 0)
            {
                try
                {
                    interests = Common.Client.UserInterests(user_id);
                    if (interests != null)
                        status = "OK";
                    else
                        status = "Error";
                }
                catch
                {
                    status = "Error";
                }
            }
            else
            {
                status = "Incomplete";
            }

            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
            JSONArrayCollection jsonInterests = new JSONArrayCollection();
            if (interests != null)
            {
                for (int i = 0; i < interests.Length; i++)
                {
                    /*
                     // Uncomment this block to send over full interests.
                     // Unnecessary right now, since interests are loaded at startup.
                    JSONObjectCollection obj = new JSONObjectCollection();
                    obj.Add(new JSONStringValue("id"), new JSONStringValue(interests[i].ID.ToString()));
                    obj.Add(new JSONStringValue("parent_id"), new JSONStringValue(interests[i].ParentID.ToString()));
                    obj.Add(new JSONStringValue("name"), new JSONStringValue(interests[i].Name));
                    jsonInterests.Add(obj);*/
                    jsonInterests.Add(new JSONNumberValue(interests[i].ID));
                }
            }
            collection.Add(new JSONStringValue("interests"), jsonInterests);
            context.Response.Write(collection.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
