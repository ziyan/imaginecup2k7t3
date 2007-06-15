using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    [Serializable]
    public class Translation
    {
        public Translation()
        {
        }
        public Translation( int request_id,
                            int src_lang_id,
                            int dst_lang_id,
                            int dst_id,
                            TranslationDestinationType dst_type,
                            string subject,
                            string orig_body,
                            DateTime date,
                            bool completed,
                            int msg_id,
                            int req_user)
        {
            type = TranslationDataType.Request;

            this.request_id = request_id;
            this.src_lang_id = src_lang_id;
            this.dst_lang_id = dst_lang_id;
            this.dst_id = dst_id;
            this.dst_type = dst_type;
            this.subject = subject;
            this.orig_body = orig_body;
            this.date = date;
            this.completed = completed;
            this.msg_id = msg_id;
            this.req_user = req_user;
        }
        public Translation(int request_id,
                            int src_lang_id,
                            int dst_lang_id,
                            int dst_id,
                            TranslationDestinationType dst_type,
                            string subject,
                            string orig_body,
                            DateTime date,
                            bool completed,
                            int msg_id,
                            int req_user,
                            int trans_id,
                            string trans_body,
                            int trans_rating,
                            DateTime trans_date,
                            int trans_user)
        {
            type = TranslationDataType.Full;

            this.request_id = request_id;
            this.src_lang_id = src_lang_id;
            this.dst_lang_id = dst_lang_id;
            this.dst_id = dst_id;
            this.dst_type = dst_type;
            this.subject = subject;
            this.orig_body = orig_body;
            this.date = date;
            this.completed = completed;
            this.msg_id = msg_id;

            this.trans_id = trans_id;
            this.trans_body = trans_body;
            this.trans_rating = trans_rating;
            this.trans_date = trans_date;
        }
       
        public TranslationDataType type;

        // Request Stuff
        public int request_id;
        public int src_lang_id;
        public int dst_lang_id;
        public int dst_id;
        public TranslationDestinationType dst_type;
        public string subject;
        public string orig_body;
        public DateTime date;
        public bool completed;
        public int msg_id;
        public int req_user;

        // Answer Stuff
        public int trans_id;
        public string trans_body;
        public int trans_rating;
        public DateTime trans_date;
        public int trans_user;
    }
}
