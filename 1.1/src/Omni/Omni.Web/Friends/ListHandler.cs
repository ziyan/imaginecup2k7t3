using System;
using System.Web;
using System.Web.SessionState;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Friends
{
    public class ListHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            Client.User[] friends;
            friends = Common.Client.FriendsList();

            JSONArrayCollection jsonFriends = new JSONArrayCollection();
            if (friends != null)
            {
                for (int i = 0; i < friends.Length; i++)
                {
                    jsonFriends.Add(Common.getUserJSON(friends[i]));
                }
            }
            context.Response.Write(jsonFriends.ToString());
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
