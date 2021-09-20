﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAppFirst.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
        public int Year { get; set; }
        public List<Role> Roles { get; set; }
    }
}
