using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Data
{
    public class UserSimil
    {
        public UserSimil()
        {
        }
        public UserSimil(User user, int self_rating, float net_rating, double simil)
        {
            this.user = user;
            this.self_rating = self_rating;
            this.net_rating = net_rating;
            this.simil = simil;
        }
        public User user;
        public int self_rating;
        public float net_rating;
        public double simil;
    }
}
