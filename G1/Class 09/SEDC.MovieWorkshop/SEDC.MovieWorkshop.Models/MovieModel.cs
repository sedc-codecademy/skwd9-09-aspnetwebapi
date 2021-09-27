namespace SEDC.MovieWorkshop.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
    public enum Genre
    {
        Action = 1,
        Comedy,
        Thriller,
        Drama,
        SciFi,
        Adventure
    }
}
