using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Orders.DAL.DomainModels
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string Address { get; set; }
        public bool IsDelievered { get; set; }
        public DateTime OrderCreationDate { get; set; }
    }
}
