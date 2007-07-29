using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Data
{
    public class Translation
    {
        public Translation()
        {
        }
        public Translation( int request_id,
                            int user_id,
                            string username,
                            int src_lang_id,
                            int dst_lang_id,
                            int dst_id,
                            TransDstType dst_type,
                            string dst_username,
                            string subject,
                            string orig_body,
                            DateTime date,
                            bool completed)
        {
            type = TransType.Request;

            this.request_id = request_id;
            this.src_lang_id = src_lang_id;
            this.dst_lang_id = dst_lang_id;
            this.user_id = user_id;
            this.username = username;
            this.dst_id = dst_id;
            this.dst_type = dst_type;
            this.dst_username = dst_username;
            this.subject = subject;
            this.orig_body = orig_body;
            this.date = date;
            this.completed = completed;
        }
        public Translation(int request_id,
                            int user_id,
                            string username,
                            int src_lang_id,
                            int dst_lang_id,
                            int dst_id,
                            TransDstType dst_type,
                            string dst_username,
                            string subject,
                            string orig_body,
                            DateTime date,
                            bool completed,
                            int trans_id,
                            string trans_body,
                            int trans_rating,
                            DateTime trans_date,
                            int trans_user)
        {
            type = TransType.Full;

            this.request_id = request_id;
            this.src_lang_id = src_lang_id;
            this.dst_lang_id = dst_lang_id;
            this.user_id = user_id;
            this.username = username;
            this.dst_id = dst_id;
            this.dst_type = dst_type;
            this.dst_username = dst_username;
            this.subject = subject;
            this.orig_body = orig_body;
            this.date = date;
            this.completed = completed;

            this.trans_id = trans_id;
            this.trans_body = trans_body;
            this.trans_rating = trans_rating;
            this.trans_date = trans_date;
            this.trans_user = trans_user;
        }
       
        public TransType type;

        // Request Stuff
        public int request_id;
        public int user_id;
        public string username;
        public int src_lang_id;
        public int dst_lang_id;
        public int dst_id;
        public TransDstType dst_type;
        public string dst_username;
        public string subject;
        public string orig_body;
        public DateTime date;
        public bool completed;

        // Answer Stuff
        public int trans_id;
        public string trans_body;
        public int trans_rating;
        public DateTime trans_date;
        public int trans_user;
    }
}
