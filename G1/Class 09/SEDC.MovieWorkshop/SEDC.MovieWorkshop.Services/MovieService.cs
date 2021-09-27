using SEDC.MovieWorkshop.DataAccess;
using SEDC.MovieWorkshop.DataModels;
using SEDC.MovieWorkshop.Models;
using SEDC.MovieWorkshop.Services.Helpers.Mappers;
using SEDC.MovieWorkshop.Services.Interface;
using System.Collections.Generic;

namespace SEDC.MovieWorkshop.Services
{
    public class MovieService : IMovieService
    {
        private IRepository<Movie> _movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }


        public ResultModel CreateMovie(MovieModel movieDTO)
        {
            ResultModel result = new ResultModel { Succeeded = true, ErrorMessage = string.Empty };

            if (movieDTO.Title != null && movieDTO.Title != string.Empty)
            {
                Movie movie = MovieMapper.MovieDTOToMovie(movieDTO);
                _movieRepository.Add(movie);
            }
            else
            {
                result.Succeeded = false;
                result.ErrorMessage = "The movie cannot be null object.";
            }
            return result;
        }

        public List<MovieModel> GetAllMovies()
        {
            return MovieMapper.MoviesToMoviesDTOList(_movieRepository.GetAll());
        }

        public List<MovieModel> GetMoviesById(int id)
        {
            List<Movie> movies = new List<Movie> { _movieRepository.GetById(id) };

            return MovieMapper.MoviesToMoviesDTOList(movies);
        }
    }
}
