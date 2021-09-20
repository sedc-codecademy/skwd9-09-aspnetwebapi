using System;
using System.Collections.Generic;

namespace Class06.EntityFramework.DataModels.CreatedFromDb
{
    public partial class Notes
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }

        public string Color { get; set; }
        public bool IsCompleted { get; set; }

        public int PriorityLevel { get; set; }
    }
}
