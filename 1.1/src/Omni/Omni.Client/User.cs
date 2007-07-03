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
            this.reg_date = user.reg_date;
            this.log_date = user.log_date;
        }
        private string name;
        private string username;
        private string email;
        private string description;
        private DateTime reg_date;
        private DateTime log_date;
        private int id;
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
	
    }
}
