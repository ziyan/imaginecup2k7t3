using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class User
    {
        internal User(org.omniproject.service.User user)
        {
            this.id = user.id;
            this.username = user.username;
            this.name = user.name;
            this.email = user.email;
            this.description = user.description;
            this.sn_network = user.sn_network;
            this.sn_screenname = user.sn_screenname;
            this.reg_date = user.reg_date;
            this.log_date = user.log_date;
            this.user_rating = user.user_rating;
        }
        private string name;
        private string username;
        private string email;
        private string description;
        private string sn_network;
        private string sn_screenname;
        private DateTime reg_date;
        private DateTime log_date;
        private int id;
        private float user_rating;
        public int ID
        {
            get { return id; }
        }
        public string Username
        {
            get { return username; }
        }
        public string Email
        {
            get { return email; }
        }
        public string Description
        {
            get { return description; }
        }
        public string SnNetwork
        {
            get { return sn_network; }
        }
        public string SnScreenname
        {
            get { return sn_screenname; }
        }
        public string Name
        {
            get { return name; }
        }
        public DateTime RegDate
        {
            get { return reg_date; }
        }
        public DateTime LogDate
        {
            get { return log_date; }
        }
        public float UserRating
        {
            get { return user_rating; }
        }
    }
}
