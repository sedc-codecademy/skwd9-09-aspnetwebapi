using SEDC.MovieWorkshop.Models;
using System.Collections.Generic;

namespace SEDC.MovieWorkshop.Services.Interface
{
    public interface IMovieService
    {
        ResultModel CreateMovie(MovieModel movie);
        List<MovieModel> GetAllMovies();
        List<MovieModel> GetMoviesById(int id);
    }
}
