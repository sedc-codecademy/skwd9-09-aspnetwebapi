using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SEDC.Orders.DAL.DomainModels
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string FavouriteFood { get; set; }
        public int NumberOfOrders { get; set; }


        //navigation properties
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
