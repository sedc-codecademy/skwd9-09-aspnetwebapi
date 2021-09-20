using SEDC.NotesApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEDC.NotesApp.Domain.Models
{
    [Table("Notes")] // the table will be called Notes
    public class Note
    {
        [Key] //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] //not null
        [MaxLength(100)]
        public string Text { get; set; }
        [MaxLength(30)]
        public string Color { get; set; }
        public TagEnum Tag { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
