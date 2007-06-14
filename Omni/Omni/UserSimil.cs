using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    public class UserSimil
    {
        public UserSimil()
        {
        }
        public UserSimil(User user, int self_rating, int net_rating, double simil)
        {
            this.user = user;
            this.self_rating = self_rating;
            this.simil = simil;
            this.net_rating = net_rating;
        }
        public User user;
        public int self_rating;
        public int net_rating;
        public double simil;
        
    }
}
