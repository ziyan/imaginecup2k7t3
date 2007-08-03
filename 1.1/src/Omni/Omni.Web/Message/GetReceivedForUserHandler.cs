using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Message
{
    public class GetReceivedForUserHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //string status = "Unknown";
            Client.Message[] msgs = null;
            msgs = Common.Client.MessageGetReceivedForUser();

            JSONObjectCollection collection = new JSONObjectCollection();
            JSONArrayCollection objArray = new JSONArrayCollection();
            //collection.Add(new JSONStringValue("status"), new JSONStringValue(msgs.ToString()));
            if (msgs != null)
            {
                foreach (Client.Message t in msgs)
                {
                    objArray.Add(Common.getMessageJSON(t));
                }
            }
            collection.Add(new JSONStringValue("results"), objArray);
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
