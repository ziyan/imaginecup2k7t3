using System;
using System.Web;
using System.Web.SessionState;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Friends
{
    public class GetIntroducedHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            string langid = context.Request["langid"];
            int lang_id = Convert.ToInt32(Util.Validator.IsInteger(langid) ? langid : "0");

            string status = "Unknown";
            Client.UserSimil[] simil = null;
            if (lang_id > 0)
            {
                simil = Common.Client.FriendsGetIntroduced(lang_id);
                status = "OK";
            }
            else status = "Incomplete";

            JSONObjectCollection collection = new JSONObjectCollection();
            JSONArrayCollection similArray = new JSONArrayCollection();
            collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
            if (simil != null)
            {
                foreach (Client.UserSimil us in simil)
                {
                    similArray.Add(Common.getUserSimilJSON(us));
                }
            }
            collection.Add(new JSONStringValue("matches"), similArray);
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
