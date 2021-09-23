using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SEDC.Orders.DAL.DomainModels
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }


        //navigation properties
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
