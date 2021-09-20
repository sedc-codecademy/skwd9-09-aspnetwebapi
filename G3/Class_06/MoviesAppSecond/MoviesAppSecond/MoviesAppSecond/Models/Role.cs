using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MoviesAppSecond.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
