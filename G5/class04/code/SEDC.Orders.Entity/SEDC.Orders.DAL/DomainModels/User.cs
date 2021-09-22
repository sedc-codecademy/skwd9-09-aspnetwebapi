using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Orders.DAL.DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
