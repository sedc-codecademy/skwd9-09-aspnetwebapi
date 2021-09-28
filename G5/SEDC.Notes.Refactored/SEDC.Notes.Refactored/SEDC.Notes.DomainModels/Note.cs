using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEDC.Notes.DomainModels
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public int Tag { get; set; }


        //navigation properties
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
