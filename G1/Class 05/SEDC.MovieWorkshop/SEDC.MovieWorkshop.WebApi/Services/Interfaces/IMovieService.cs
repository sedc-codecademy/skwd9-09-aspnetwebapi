using SEDC.MovieWorkshop.WebApi.Models.Domain;
using SEDC.MovieWorkshop.WebApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.MovieWorkshop.WebApi.Services.Interfaces
{
    interface IMovieService
    {
        ResultDTO CreateMovie(Movie movie);
        List<MovieDTO> GetAllMovies();
        MovieDTO GetMovieById(int id);
    }
}
