using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Translation
{
    public class AnswerRateHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            string transansid = context.Request["transansid"];
            string _rating = context.Request["rating"];
            int trans_ans_id = Convert.ToInt32(Util.Validator.IsInteger(transansid) ? transansid : "0");
            int rating = Convert.ToInt32(Util.Validator.IsInteger(_rating) ? _rating : "0");

            string status = "Unknown";
            if (trans_ans_id > 0 && rating > 0)
            {
                int result = Common.Client.TranslationAnswerRate(trans_ans_id, rating);
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
                return true;
            }
        }
    }
}
