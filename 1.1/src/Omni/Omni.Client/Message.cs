using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class Message
    {
        internal Message(org.omniproject.service.Message m)
        {
            this.id = m.id;
            this.src_id = m.src_id;
            this.dst_id = m.dst_id;
            this.subject = m.subject;
            this.body = m.body;
            this.date = m.date;
            this.unread = m.unread;
            this.dst_type = (MsgDstType)m.dst_type;
            this.src_username = m.src_username;
            this.dst_username = m.dst_username;
        }
        private int id;
        private int src_id;
        private int dst_id;
        private string subject;
        private string body;
        private DateTime date;
        private bool unread;
        private MsgDstType dst_type;
        private string src_username;
        private string dst_username;
        
        public int ID
        {
            get { return id; }
        }
        public int SrcID
        {
            get { return src_id; }
        }
        public int DstID
        {
            get { return dst_id; }
        }
        public string Subject
        {
            get { return subject; }
        }
        public string Body
        {
            get { return body; }
        }
        public DateTime Date
        {
            get { return date; }
        }
        public bool Unread
        {
            get { return unread; }
        }
        public MsgDstType DstType
        {
            get { return dst_type; }
        }
        public string SrcUsername
        {
            get { return src_username; }
        }
        public string DstUsername
        {
            get { return dst_username; }
        }
    }
}
