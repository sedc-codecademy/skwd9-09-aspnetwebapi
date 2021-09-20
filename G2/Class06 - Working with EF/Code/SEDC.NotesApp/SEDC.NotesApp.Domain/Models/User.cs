using System.Collections.Generic;

namespace SEDC.NotesApp.Domain.Models
{
    public class User : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public List<Note> Notes { get; set; }
        public int Age { get; set; }
    }
}
