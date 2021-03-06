using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Translation
{
    public class AnswersGetByReqIDHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string reqid = context.Request["reqid"];
            int req_id = Convert.ToInt32(Util.Validator.IsInteger(reqid) ? reqid : "0");

            string status = "Unknown";
            Client.Translation[] trans = null;
            if (req_id > 0)
            {
                trans = Common.Client.TranslationAnswersGetByReqId(req_id);
                status = "OK";
            }
            else status = "Incomplete";

            JSONObjectCollection collection = new JSONObjectCollection();
            JSONArrayCollection objArray = new JSONArrayCollection();
            collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
            if (trans != null)
            {
                foreach (Client.Translation t in trans)
                {
                    objArray.Add(Common.getTranslationJSON(t));
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
