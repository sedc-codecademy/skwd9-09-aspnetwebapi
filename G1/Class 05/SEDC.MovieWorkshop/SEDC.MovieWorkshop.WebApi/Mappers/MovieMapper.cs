using SEDC.MovieWorkshop.WebApi.Models.Domain;
using SEDC.MovieWorkshop.WebApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.MovieWorkshop.WebApi.Mappers
{
    public static class MovieMapper
    {
        public static List<MovieDTO> MoviesToMoviesDTOList(List<Movie> movies)
        {
            List<MovieDTO> movieDTOs = new List<MovieDTO>();
            foreach (var movie in movies)
            {
                movieDTOs.Add(
                    new MovieDTO
                    {
                        Id = movie.Id,
                        Description = movie.Description,
                        Title = movie.Title,
                        Year = movie.Year,
                        Genre = movie.Genre
                    });
            }
            return movieDTOs;
        }

        public static MovieDTO MovieToMovieDTO(Movie movie)
        {
            return new MovieDTO
            {
                Id = movie.Id,
                Description = movie.Description,
                Title = movie.Title,
                Year = movie.Year,
                Genre = movie.Genre
            };
        }

        public static Movie MovieDTOToMovie(MovieDTO movie)
        {
            return new Movie
            {
                Id = movie.Id,
                Description = movie.Description,
                Title = movie.Title,
                Year = movie.Year,
                Genre = movie.Genre
            };
        }
    }
}
