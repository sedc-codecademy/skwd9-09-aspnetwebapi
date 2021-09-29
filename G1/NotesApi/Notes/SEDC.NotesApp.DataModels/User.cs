using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEDC.NotesApp.DataModels
{
    [Dapper.Contrib.Extensions.Table("Users")]
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [Computed]
        public ICollection<Note> Notes { get; set; }
    }
}
