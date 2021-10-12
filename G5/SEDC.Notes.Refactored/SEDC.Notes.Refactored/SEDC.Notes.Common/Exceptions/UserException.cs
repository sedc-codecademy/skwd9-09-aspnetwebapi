using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Notes.Common.Exceptions
{
    public class UserException : Exception
    {
        public int? UserId { get; set; }
        public string Name { get; set; }


        public UserException() : base("There has been an inssue with a user!") {}

        public UserException(string message) : base(message) {}

        public UserException(int? userId, string name) : base("There has been an inssue with a user!")
        {
            UserId = userId;
            Name = name;
        }

        public UserException(int? userId, string name, string message) : base(message)
        {
            UserId = userId;
            Name = name;
        }

    }
}
