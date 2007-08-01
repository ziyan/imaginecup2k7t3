using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Data
{
    public class UserRank
    {
        public UserRank()
        {
        }
        public UserRank(User user, float rank)
        {
            this.user = user;
            this.rank = rank;
        }
        public User user;
        public float rank;
    }
}
