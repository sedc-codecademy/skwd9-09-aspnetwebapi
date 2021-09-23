using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SEDC.Orders.DAL.DomainModels
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string Address { get; set; }
        public bool IsDelievered { get; set; }
        public DateTime OrderCreationDate { get; set; }


        //navigation properties
        public User User { get; set; }
        public int UserId { get; set; } //fk


        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
