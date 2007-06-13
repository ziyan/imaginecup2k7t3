using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    [Serializable]
    public class Message
    {
        public Message()
        {
        }
        public Message(int src_id, int dst_id, string subject, string body, DateTime date, bool unread)
        {
            this.src_id = src_id;
            this.dst_id = dst_id;
            this.subject = subject;
            this.body = body;
            this.date = date;
            this.unread = unread;
        }
        public int src_id;
        public int dst_id;
        public string subject;
        public string body;
        public DateTime date;
        public bool unread;
    }
}
