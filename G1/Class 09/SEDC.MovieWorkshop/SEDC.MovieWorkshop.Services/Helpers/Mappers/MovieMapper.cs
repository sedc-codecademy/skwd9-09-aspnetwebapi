using SEDC.MovieWorkshop.DataModels;
using SEDC.MovieWorkshop.Models;
using System.Collections.Generic;

namespace SEDC.MovieWorkshop.Services.Helpers.Mappers
{
    public static class MovieMapper
    {
        public static List<MovieModel> MoviesToMoviesDTOList(List<Movie> movies)
        {
            List<MovieModel> movieDTOs = new List<MovieModel>();
            foreach (var movie in movies)
            {
                movieDTOs.Add(
                    new MovieModel
                    {
                        Id = movie.Id,
                        Description = movie.Description,
                        Title = movie.Title,
                        Year = movie.Year,
                        Genre = (Models.Genre)movie.Genre
                    });
            }
            return movieDTOs;
        }

        public static MovieModel MovieToMovieDTO(Movie movie)
        {
            return new MovieModel
            {
                Id = movie.Id,
                Description = movie.Description,
                Title = movie.Title,
                Year = movie.Year,
                Genre = (Models.Genre)movie.Genre
            };
        }

        public static Movie MovieDTOToMovie(MovieModel movie)
        {
            return new Movie
            {
                Id = movie.Id,
                Description = movie.Description,
                Title = movie.Title,
                Year = movie.Year,
                Genre = (DataModels.Genre)movie.Genre
            };
        }
    }
}
