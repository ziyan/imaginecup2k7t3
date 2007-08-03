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
                collection.Add(new JSONStringValue("user_rating"), new JSONStringValue(user.UserRating.ToString()));
                collection.Add(new JSONStringValue("description"), new JSONStringValue(user.Description == null ? "" : user.Description));
                collection.Add(new JSONStringValue("sn_network"), new JSONStringValue(user.SnNetwork == null ? "" : user.SnNetwork));
                collection.Add(new JSONStringValue("sn_screenname"), new JSONStringValue(user.SnScreenname == null ? "" : user.SnScreenname));
                collection.Add(new JSONStringValue("reg_date"), new JSONStringValue(user.RegDate.ToString()));
                collection.Add(new JSONStringValue("log_date"), new JSONStringValue(user.LogDate.ToString()));
            }
            return collection;
        }

        public static JSONObjectCollection getUserSummaryJSON(Client.UserSummary user)
        {
            JSONObjectCollection collection = new JSONObjectCollection();
            if (user != null)
            {
                collection.Add(new JSONStringValue("id"), new JSONStringValue(user.ID.ToString()));
                collection.Add(new JSONStringValue("has_updated_profile"), new JSONNumberValue(user.HasUpdatedProfile));
                collection.Add(new JSONStringValue("unread_msgs"), new JSONNumberValue(user.UnreadMsgs));
                collection.Add(new JSONStringValue("open_personal_trans_req"), new JSONNumberValue(user.OpenPersonalTransReq));
                collection.Add(new JSONStringValue("trans_req_to_approve"), new JSONNumberValue(user.TransReqToApprove));
                collection.Add(new JSONStringValue("open_global_trans_req"), new JSONNumberValue(user.OpenGlobalTransReq));
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

        public static JSONObjectCollection getUserRankJSON(Client.UserRank us)
        {
            JSONObjectCollection collection = new JSONObjectCollection();
            if (us != null)
            {
                collection.Add(new JSONStringValue("user"), getUserJSON(us.User));
                collection.Add(new JSONStringValue("rank"), new JSONStringValue(us.Rank.ToString()));
            }
            return collection;
        }

        public static JSONObjectCollection getTranslationJSON(Client.Translation t)
        {

            JSONObjectCollection collection = new JSONObjectCollection();
            if (t != null)
            {
                collection.Add(new JSONStringValue("type"), new JSONStringValue(t.Type.ToString()));

                collection.Add(new JSONStringValue("request_id"), new JSONStringValue(t.RequestID.ToString()));
                collection.Add(new JSONStringValue("src_lang_id"), new JSONStringValue(t.SrcLangID.ToString()));
                collection.Add(new JSONStringValue("dst_lang_id"), new JSONStringValue(t.DstLangID.ToString()));
                collection.Add(new JSONStringValue("user_id"), new JSONStringValue(t.UserID.ToString()));
                collection.Add(new JSONStringValue("username"), new JSONStringValue(t.Username.ToString()));
                collection.Add(new JSONStringValue("dst_id"), new JSONStringValue(t.DstID.ToString()));
                collection.Add(new JSONStringValue("dst_type"), new JSONStringValue(t.DstType.ToString()));
                collection.Add(new JSONStringValue("dst_username"), new JSONStringValue(t.DstUsername.ToString()));
                collection.Add(new JSONStringValue("subject"), new JSONStringValue(t.Subject.ToString()));
                collection.Add(new JSONStringValue("orig_body"), new JSONStringValue(t.OrigBody.ToString()));
                collection.Add(new JSONStringValue("date"), new JSONStringValue(t.Date.ToString()));
                collection.Add(new JSONStringValue("completed"), new JSONStringValue(t.Completed.ToString()));

                if (t.Type == Omni.Client.TransType.Full)
                {
                    collection.Add(new JSONStringValue("trans_id"), new JSONStringValue(t.TransID.ToString()));
                    collection.Add(new JSONStringValue("trans_body"), new JSONStringValue(t.TransBody.ToString()));
                    collection.Add(new JSONStringValue("trans_rating"), new JSONStringValue(t.TransRating.ToString()));
                    collection.Add(new JSONStringValue("trans_date"), new JSONStringValue(t.TransDate.ToString()));
                    collection.Add(new JSONStringValue("trans_user"), new JSONStringValue(t.TransUser.ToString()));
                    collection.Add(new JSONStringValue("trans_username"), new JSONStringValue(t.TransUsername.ToString()));
                    collection.Add(new JSONStringValue("user_rating"), new JSONStringValue(t.UserRating.ToString()));
                }
            }
            return collection;
        }

        public static JSONObjectCollection getMessageJSON(Client.Message t)
        {

            JSONObjectCollection collection = new JSONObjectCollection();
            if (t != null)
            {
                collection.Add(new JSONStringValue("id"), new JSONStringValue(t.ID.ToString()));
                collection.Add(new JSONStringValue("src_id"), new JSONStringValue(t.SrcID.ToString()));
                collection.Add(new JSONStringValue("dst_id"), new JSONStringValue(t.DstID.ToString()));
                collection.Add(new JSONStringValue("subject"), new JSONStringValue(t.Subject));
                collection.Add(new JSONStringValue("body"), new JSONStringValue(t.Body));
                collection.Add(new JSONStringValue("date"), new JSONStringValue(t.Date.ToString()));
                collection.Add(new JSONStringValue("unread"), new JSONStringValue(t.Unread.ToString()));
                collection.Add(new JSONStringValue("dst_type"), new JSONStringValue(t.DstType.ToString()));
                collection.Add(new JSONStringValue("src_username"), new JSONStringValue(t.SrcUsername.ToString()));
                collection.Add(new JSONStringValue("dst_username"), new JSONStringValue(t.DstUsername.ToString()));
            }
            return collection;
        }

        public static JSONObjectCollection getUserLanguageJSON(Client.UserLanguage us)
        {
            JSONObjectCollection collection = new JSONObjectCollection();
            if (us != null)
            {
                collection.Add(new JSONStringValue("user_id"), new JSONStringValue(us.UserId.ToString()));
                collection.Add(new JSONStringValue("lang_id"), new JSONStringValue(us.LangId.ToString()));
                collection.Add(new JSONStringValue("self_rating"), new JSONStringValue(us.SelfRating.ToString()));
                collection.Add(new JSONStringValue("net_rating"), new JSONStringValue(us.NetRating.ToString()));
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
