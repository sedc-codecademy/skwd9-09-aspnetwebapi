﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAppFirst.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
