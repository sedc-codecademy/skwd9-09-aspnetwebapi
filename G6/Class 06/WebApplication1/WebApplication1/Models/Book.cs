namespace WebApplication1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int ReadCount { get; set; }
    }
}
