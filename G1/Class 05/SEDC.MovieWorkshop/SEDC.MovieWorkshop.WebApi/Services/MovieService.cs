using SEDC.MovieWorkshop.WebApi.Mappers;
using SEDC.MovieWorkshop.WebApi.Models.Domain;
using SEDC.MovieWorkshop.WebApi.Models.DTOs;
using SEDC.MovieWorkshop.WebApi.Repository;
using SEDC.MovieWorkshop.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.MovieWorkshop.WebApi.Services
{
    public class MovieService : IMovieService
    {
        private IRepository<Movie> _movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }


        public ResultDTO CreateMovie(MovieDTO movieDTO)
        {
            ResultDTO result = new ResultDTO { Succeeded = true, ErrorMessage = string.Empty };

            if(movieDTO.Title != null && movieDTO.Title != string.Empty)
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

        public List<MovieDTO> GetAllMovies()
        {
            return MovieMapper.MoviesToMoviesDTOList(_movieRepository.GetAll());
        }

        public List<MovieDTO> GetMoviesById(int id)
        {
            List<Movie> movies = new List<Movie> { _movieRepository.GetById(id) };

            return MovieMapper.MoviesToMoviesDTOList(movies);
        }
    }
}
