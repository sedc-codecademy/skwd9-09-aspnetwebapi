using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public List<NoteModel> Notes { get; set; }
    }
}
