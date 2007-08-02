using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Translation
{
    public class RequestCloseHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            string reqid = context.Request["reqid"];
            string ansid = context.Request["ansid"];
            int req_id = Convert.ToInt32(Util.Validator.IsInteger(reqid) ? reqid : "0");
            int ans_id = Convert.ToInt32(Util.Validator.IsInteger(ansid) ? ansid : "0");

            string status = "Unknown";
            if (req_id > 0 && ans_id > 0)
            {
                int result = Common.Client.TranslationRequestClose(req_id, ans_id);
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
