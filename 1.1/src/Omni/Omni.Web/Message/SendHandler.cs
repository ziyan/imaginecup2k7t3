using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Message
{
    public class SendHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            string subject = context.Request["subject"];
            string message = context.Request["message"];
            string dstid = context.Request["dstid"];
            int dst_id = Convert.ToInt32(Util.Validator.IsInteger(dstid) ? dstid : "0");

            string status = "Unknown";
            if (subject != null && subject != "" && message != null && message != "" && dst_id > 0)
            {
                int result = Common.Client.MessageSend(dst_id, 1, subject, message);
                status = "OK";
            }
            else
            {
                status = "Incomplete";
            }
            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
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
