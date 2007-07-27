using System;
using System.Collections.Generic;
using System.Text;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web
{
    public static class Common
    {
        public static Omni.Client.OmniClient Client
        {
            get
            {
                return (Omni.Client.OmniClient)System.Web.HttpContext.Current.Session["Client"];
            }
        }

        public static JSONObjectCollection getUserJSON(Client.User user)
        {
            JSONObjectCollection collection = new JSONObjectCollection();
            if (user != null)
            {
                collection.Add(new JSONStringValue("id"), new JSONStringValue(user.ID.ToString()));
                collection.Add(new JSONStringValue("username"), new JSONStringValue(user.Username));
                collection.Add(new JSONStringValue("email"), new JSONStringValue(user.Email));
                collection.Add(new JSONStringValue("name"), new JSONStringValue(user.Name));
                collection.Add(new JSONStringValue("description"), new JSONStringValue(user.Description == null ? "" : user.Description));
                collection.Add(new JSONStringValue("sn_network"), new JSONStringValue(user.SnNetwork == null ? "" : user.SnNetwork));
                collection.Add(new JSONStringValue("sn_screenname"), new JSONStringValue(user.SnScreenname == null ? "" : user.SnScreenname));
                collection.Add(new JSONStringValue("reg_date"), new JSONStringValue(user.RegDate.ToString()));
                collection.Add(new JSONStringValue("log_date"), new JSONStringValue(user.LogDate.ToString()));
            }
            return collection;
        }

        public static JSONObjectCollection getUserSimilJSON(Client.UserSimil us)
        {
            JSONObjectCollection collection = new JSONObjectCollection();
            if (us != null)
            {
                collection.Add(new JSONStringValue("user"), getUserJSON(us.User));
                collection.Add(new JSONStringValue("self_rating"), new JSONStringValue(us.SelfRating.ToString()));
                collection.Add(new JSONStringValue("net_rating"), new JSONStringValue(us.NetRating.ToString()));
                collection.Add(new JSONStringValue("simil"), new JSONStringValue(us.Simil.ToString()));
            }
            return collection;
        }

        public static JSONObjectCollection getInterestJSON(Client.Interest interest)
        {
            JSONObjectCollection obj = new JSONObjectCollection();
            if (interest != null)
            {
                obj.Add(new JSONStringValue("id"), new JSONNumberValue(interest.ID));
                obj.Add(new JSONStringValue("parent_id"), new JSONNumberValue(interest.ParentID));
                obj.Add(new JSONStringValue("name"), new JSONStringValue(interest.Name));
            }
            return obj;
        }
    }
}
