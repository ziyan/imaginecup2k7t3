using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Translation
{
    public class RequestAddHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            string srclangid = context.Request["srclangid"];
            string dstlangid = context.Request["dstlangid"];
            string subject = context.Request["subject"];
            string message = context.Request["message"];
            string dstid = context.Request["dstid"];
            string dsttype = context.Request["dsttype"];
            int src_lang_id = Convert.ToInt32(Util.Validator.IsInteger(srclangid) ? srclangid : "0");
            int dst_lang_id = Convert.ToInt32(Util.Validator.IsInteger(dstlangid) ? dstlangid : "0");
            int dst_id = Convert.ToInt32(Util.Validator.IsInteger(dstid) ? dstid : "0");
            int dst_type = Convert.ToInt32(Util.Validator.IsInteger(dsttype) ? dsttype : "-1");

            int reqid = 0;
            string status = "Unknown";
            if (subject != null && subject != "" && message != null && message != "" && src_lang_id > 0 && dst_lang_id > 0 && dst_type >= 0 && dst_type <= 1)
            {
                reqid = Common.Client.TranslationRequestAdd(src_lang_id, dst_lang_id, subject, message, dst_id, dst_type);
                if (reqid <= 0)
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
            collection.Add(new JSONStringValue("reqid"), new JSONNumberValue(reqid));
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
