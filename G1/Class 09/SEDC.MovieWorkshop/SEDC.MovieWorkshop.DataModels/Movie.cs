namespace SEDC.MovieWorkshop.DataModels
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
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
