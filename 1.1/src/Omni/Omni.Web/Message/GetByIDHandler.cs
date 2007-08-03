using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Message
{
    public class GetByIDHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string msgid = context.Request["msgid"];
            int msg_id = Convert.ToInt32(Util.Validator.IsInteger(msgid) ? msgid : "0");

            string status = "Unknown";
            Client.Message trans = null;
            if (msg_id > 0)
            {
                trans = Common.Client.MessageGetById(msg_id);
                status = "OK";
            }
            else status = "Incomplete";

            JSONObjectCollection collection = new JSONObjectCollection();
            JSONArrayCollection objArray = new JSONArrayCollection();
            collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
            collection.Add(new JSONStringValue("result"), Common.getMessageJSON(trans));
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
