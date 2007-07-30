using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;
using Newtonsoft.Json;

namespace Omni.Web.User
{
    public class UpdateLanguagesHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;

            String status = "Unknown";
            
            String arrayStr = context.Request["languages"];
            int[] ids = null;
            String arrayStr2 = context.Request["skills"];
            int[] skills = null;
            if (arrayStr != null && arrayStr != "" && arrayStr2 != null && arrayStr2 != "")
            {
                try
                {
                    ids = (int[])JavaScriptConvert.DeserializeObject(arrayStr, typeof(int[]));
                    skills = (int[])JavaScriptConvert.DeserializeObject(arrayStr2, typeof(int[]));
                    status = "Pending";
                }
                catch (System.Exception e1)
                {
                    status = "InvalidData";
                    Exception.Rethrow(e1);
                }

                try
                {
                    int val = Common.Client.UserUpdateLanguages(ids, skills);
                    status = "OK";
                }
                catch (System.Exception ex)
                {
                    status += " : " + ex.Message;
                    Exception.Rethrow(ex);
                }
            }
            else status = "Incomplete";

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
