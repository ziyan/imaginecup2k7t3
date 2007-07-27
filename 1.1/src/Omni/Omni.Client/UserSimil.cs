using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class UserSimil
    {
        internal UserSimil(org.omniproject.service.UserSimil us)
        {
            this.user = new User(us.user);
            this.self_rating = us.self_rating;
            this.net_rating = us.net_rating;
            this.simil = us.simil;
        }
        private User user;
        private int self_rating;
        private float net_rating;
        private double simil;
        public User User
        {
            get { return user; }
        }
        public int SelfRating
        {
            get { return self_rating; }
        }
        public float NetRating
        {
            get { return net_rating; }
        }
        public double Simil
        {
            get { return simil; }
        }
    }
}
