using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication3.Domain
{
    public partial class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int ReadCount { get; set; }
    }
}
