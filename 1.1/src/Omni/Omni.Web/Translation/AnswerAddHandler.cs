using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Translation
{
    public class AnswerAddHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            string message = context.Request["message"];
            string reqid = context.Request["reqid"];
            int req_id = Convert.ToInt32(Util.Validator.IsInteger(reqid) ? reqid : "0");

            int failure = 1;
            string status = "Unknown";
            if (message != null && message != "" && reqid != null && req_id > 0)
            {
                failure = Common.Client.TranslationAnswerAdd(req_id, message);
                if (failure != 0)
                {
                    status = "Failure";
                }
                else
                {
                    status = "OK";
                }
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
