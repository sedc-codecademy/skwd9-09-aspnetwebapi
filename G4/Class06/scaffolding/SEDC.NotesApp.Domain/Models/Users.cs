using System;
using System.Collections.Generic;

namespace SEDC.NotesApp.Domain.Models
{
    public partial class Users
    {
        public Users()
        {
            Notes = new HashSet<Notes>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Notes> Notes { get; set; }
    }
}
