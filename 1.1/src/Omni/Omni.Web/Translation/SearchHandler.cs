using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Translation
{
    public class SearchHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string srclangid = context.Request["srclangid"];
            int src_lang_id = Convert.ToInt32(Util.Validator.IsInteger(srclangid) ? srclangid : "0");
            string dstlangid = context.Request["dstlangid"];
            int dst_lang_id = Convert.ToInt32(Util.Validator.IsInteger(dstlangid) ? dstlangid : "0");
            string keyword = context.Request["keyword"];
            if (keyword == null) keyword = "";

            string status = "Unknown";
            Client.Translation[] trans = null;
            if (src_lang_id > 0 && dst_lang_id > 0)
            {
                trans = Common.Client.TranslationSearch(keyword, src_lang_id, dst_lang_id);
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
