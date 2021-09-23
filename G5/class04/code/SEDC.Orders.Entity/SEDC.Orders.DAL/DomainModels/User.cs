using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SEDC.Orders.DAL.DomainModels
{
    //[Table("Korisink")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        //[MaxLength(30)]
        //[Required]
        //[Column("order-number")]
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        //navigation properties 
        public virtual ICollection<Order> Orders { get; set; }


        public UserInfo UserInfo { get; set; }
    }
}
