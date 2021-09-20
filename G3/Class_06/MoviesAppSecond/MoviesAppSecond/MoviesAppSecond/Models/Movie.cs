using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MoviesAppSecond.Models
{
    public partial class Movie
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
