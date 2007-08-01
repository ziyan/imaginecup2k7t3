using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class Translation
    {
        internal Translation(org.omniproject.service.Translation t)
        {
            this.type = (TransType)t.type;

            this.request_id = t.request_id;
            this.src_lang_id = t.src_lang_id;
            this.dst_lang_id = t.dst_lang_id;
            this.user_id = t.user_id;
            this.username = t.username;
            this.dst_id = t.dst_id;
            this.dst_type = (TransDstType)t.dst_type;
            this.dst_username = t.dst_username;
            this.subject = t.subject;
            this.orig_body = t.orig_body;
            this.date = t.date;
            this.completed = t.completed;

            if (this.type == TransType.Full)
            {
                this.trans_id = t.trans_id;
                this.trans_body = t.trans_body;
                this.trans_rating = t.trans_rating;
                this.trans_date = t.trans_date;
                this.trans_user = t.trans_user;
                this.trans_username = t.trans_username;
                this.user_rating = t.user_rating;
            }
        }
        private TransType type;
        // Request Stuff
        private int request_id;
        private int user_id;
        private string username;
        private int src_lang_id;
        private int dst_lang_id;
        private int dst_id;
        private TransDstType dst_type;
        private string dst_username;
        private string subject;
        private string orig_body;
        private DateTime date;
        private bool completed;
        // Answer Stuff
        private int trans_id;
        private string trans_body;
        private int trans_rating;
        private DateTime trans_date;
        private int trans_user;
        private string trans_username;
        private int user_rating;

        public TransType Type
        {
            get { return type; }
        }
        // Request Stuff
        public int RequestID
        {
            get { return request_id; }
        }
        public int UserID
        {
            get { return user_id; }
        }
        public string Username
        {
            get { return username; }
        }
        public int SrcLangID
        {
            get { return src_lang_id; }
        }
        public int DstLangID
        {
            get { return dst_lang_id; }
        }
        public int DstID
        {
            get { return dst_id; }
        }
        public TransDstType DstType
        {
            get { return dst_type; }
        }
        public string DstUsername
        {
            get { return dst_username; }
        }
        public string Subject
        {
            get { return subject; }
        }
        public string OrigBody
        {
            get { return orig_body; }
        }
        public DateTime Date
        {
            get { return date; }
        }
        public bool Completed
        {
            get { return completed; }
        }
        // Answer Stuff
        public int TransID
        {
            get { return trans_id; }
        }
        public string TransBody
        {
            get { return trans_body; }
        }
        public int TransRating
        {
            get { return trans_rating; }
        }
        public DateTime TransDate
        {
            get { return trans_date; }
        }
        public int TransUser
        {
            get { return trans_user; }
        }
        public string TransUsername
        {
            get { return trans_username; }
        }
        public int UserRating
        {
            get { return user_rating; }
        }

    }
}
