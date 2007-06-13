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
        public Message(int id, int src_id, int dst_id, MessageDestinationType dst_type, string subject, string body, DateTime date, bool unread)
        {
            this.id = id;
            this.src_id = src_id;
            this.dst_id = dst_id;
            this.subject = subject;
            this.body = body;
            this.date = date;
            this.unread = unread;
            this.dst_type = dst_type;
        }
        public int id;
        public int src_id;
        public int dst_id;
        public string subject;
        public string body;
        public DateTime date;
        public bool unread;
        public MessageDestinationType dst_type;
    }
}
