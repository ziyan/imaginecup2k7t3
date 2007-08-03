using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Data
{
    public class UserSummary
    {
        public UserSummary()
        {
        }
        public UserSummary(int id, int has_updated_profile, int unread_msgs, int open_personal_trans_req, int trans_req_to_approve, int open_global_trans_req)
        {
            this.id = id;
            this.has_updated_profile = has_updated_profile;
            this.unread_msgs = unread_msgs;
            this.open_personal_trans_req = open_personal_trans_req;
            this.open_global_trans_req = open_global_trans_req;
            this.trans_req_to_approve = trans_req_to_approve;
        }
        public int id;
        public int has_updated_profile;
        public int unread_msgs;
        public int open_personal_trans_req;
        public int trans_req_to_approve;
        public int open_global_trans_req;
    }
}
