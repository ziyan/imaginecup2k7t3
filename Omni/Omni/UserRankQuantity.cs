using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    public class UserRankQuantity
    {
         public UserRankQuantity()
        {
        }
        public UserRankQuantity(User user, int quantity)
        {
            this.user = user;
            this.quantity = quantity;
        }
        public User user;
        public int quantity;
    }
}
