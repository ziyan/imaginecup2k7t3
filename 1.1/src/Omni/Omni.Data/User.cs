using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Data
{
    public class User
    {
        public User()
        {
        }
        public User(int id, string username, string name, string email, string description, string sn_network, string sn_screenname, DateTime reg_date, DateTime log_date, float user_rating)
        {
            this.id = id;
            this.username = username;
            this.name = name;
            this.email = email;
            this.description = description;
            this.sn_network = sn_network;
            this.sn_screenname = sn_screenname;
            this.reg_date = reg_date;
            this.log_date = log_date;
            this.user_rating = user_rating;
        }
        public string name;
        public string username;
        public string email;
        public int id;
        public string description;
        public string sn_network;
        public string sn_screenname;
        public DateTime reg_date;
        public DateTime log_date;
        public float user_rating;
    }
}
