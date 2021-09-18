using SEDC.MovieWorkshop.WebApi.Models.Domain;
using SEDC.MovieWorkshop.WebApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.MovieWorkshop.WebApi.Services.Interfaces
{
    public interface IMovieService
    {
        ResultDTO CreateMovie(MovieDTO movie);
        List<MovieDTO> GetAllMovies();
        List<MovieDTO> GetMoviesById(int id);
    }
}
