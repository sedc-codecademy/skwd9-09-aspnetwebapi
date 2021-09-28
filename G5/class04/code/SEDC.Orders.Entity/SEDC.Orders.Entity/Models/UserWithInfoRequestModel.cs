using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Orders.Entity.Models
{
    public class UserWithInfoRequestModel
    {
        //user
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //user info
        public string FavouriteFood { get; set; }
        public int NumberOfOrders { get; set; }
    }
}
