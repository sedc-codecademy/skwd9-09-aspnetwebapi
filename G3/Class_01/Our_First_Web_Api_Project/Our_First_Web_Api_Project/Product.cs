using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Our_First_Web_Api_Project
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int BarCode { get; set; }
    }
}
