using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.MovieWorkshop.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Subscription Subscription { get; set; }
    }
    public enum Subscription
    {
        Default = 1,
        Premium
    }
}
