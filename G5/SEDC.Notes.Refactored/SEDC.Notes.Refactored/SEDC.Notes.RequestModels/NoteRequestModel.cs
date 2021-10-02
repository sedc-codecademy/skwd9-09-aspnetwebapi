using SEDC.Notes.RequestModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Notes.RequestModels
{
    public class NoteRequestModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public TagType Tag { get; set; }
        public int UserId { get; set; }
    }
}
