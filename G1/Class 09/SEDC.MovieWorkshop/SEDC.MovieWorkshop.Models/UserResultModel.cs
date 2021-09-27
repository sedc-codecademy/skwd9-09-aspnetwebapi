using System.Collections.Generic;

namespace SEDC.MovieWorkshop.Models
{
    public class UserResultModel
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
        public List<MovieModel> UserMovies { get; set; }
    }
}
