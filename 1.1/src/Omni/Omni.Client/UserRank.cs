using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class UserRank
    {
        internal UserRank(org.omniproject.service.UserRank us)
        {
            this.user = new User(us.user);
            this.rank = us.rank;
        }
        private User user;
        private float rank;
        public User User
        {
            get { return user; }
        }
        public float Rank
        {
            get { return rank; }
        }
    }
}
