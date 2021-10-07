using SEDC.NotesAPI.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SEDC.NotesAPI.Domain.Models
{
    public class Note : BaseEntity
    {
        public string Text { get; set; }

        public string Color { get; set; }

        public TagType Tag { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
