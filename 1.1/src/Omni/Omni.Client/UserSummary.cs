using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class UserSummary
    {
        internal UserSummary(org.omniproject.service.UserSummary us)
        {
            this.id = us.id;
            this.has_updated_profile = us.has_updated_profile;
            this.unread_msgs = us.unread_msgs;
            this.open_personal_trans_req = us.open_personal_trans_req;
            this.open_global_trans_req = us.open_global_trans_req;
            this.trans_req_to_approve = us.trans_req_to_approve;
        }
        private int id;
        private int has_updated_profile;
        private int unread_msgs;
        private int open_personal_trans_req;
        private int trans_req_to_approve;
        private int open_global_trans_req;

        public int ID
        {
            get { return id; }
        }
        public int HasUpdatedProfile
        {
            get { return has_updated_profile; }
        }
        public int UnreadMsgs
        {
            get { return unread_msgs; }
        }
        public int OpenPersonalTransReq
        {
            get { return open_personal_trans_req; }
        }
        public int TransReqToApprove
        {
            get { return trans_req_to_approve; }
        }
        public int OpenGlobalTransReq
        {
            get { return open_global_trans_req; }
        }

    }
}
