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
        public User(int id, string username, string name, string email, string description, DateTime reg_date, DateTime log_date)
        {
            this.id = id;
            this.username = username;
            this.name = name;
            this.email = email;
            this.description = description;
            this.reg_date = reg_date;
            this.log_date = log_date;
        }
        public string name;
        public string username;
        public string email;
        public int id;
        public string description;
        public DateTime reg_date;
        public DateTime log_date;
    }
}
