using System;
using System.Web;
using System.Web.SessionState;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.HallOfFame
{
    public class ByQuantityHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;

            Client.UserRank[] simil = null;
            simil = Common.Client.HallOfFameByQuantity();

            //JSONObjectCollection collection = new JSONObjectCollection();
            JSONArrayCollection similArray = new JSONArrayCollection();
            //collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
            if (simil != null)
            {
                foreach (Client.UserRank us in simil)
                {
                    similArray.Add(Common.getUserRankJSON(us));
                }
            }
            //collection.Add(new JSONStringValue("matches"), similArray);
            //context.Response.Write(collection.ToString());
            context.Response.Write(similArray.ToString());
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
