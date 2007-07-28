using System;
using System.Web;
using System.Web.SessionState;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Friends
{
    public class AddHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string friendid = context.Request["friendid"];
            int friend_id = Convert.ToInt32(Util.Validator.IsInteger(friendid) ? friendid : "0");

            int result = 0;

            if (friend_id > 0)
            {
                result = Common.Client.FriendsAdd(friend_id);
            }
            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("result"), new JSONNumberValue(result));
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
