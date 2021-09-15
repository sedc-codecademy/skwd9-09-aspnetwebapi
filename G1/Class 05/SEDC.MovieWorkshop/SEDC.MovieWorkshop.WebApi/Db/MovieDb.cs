using SEDC.MovieWorkshop.WebApi.Models.Domain;
using SEDC.MovieWorkshop.WebApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.MovieWorkshop.WebApi.Db
{
    public static class MovieDb
    {
        public static List<Movie> Movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Gone in 60 seconds",
                Description = "Test description",
                Genre = Genre.Action,
                Year = 2000,
            },
            new Movie
            {
                Id = 2,
                Title = "Rambo 1",
                Description = "Test description",
                Genre = Genre.Action,
                Year = 1982,
            },
            new Movie
            {
                Id = 3,
                Title = "Rambo 2",
                Description = "Test description",
                Genre = Genre.Action,
                Year = 1985,
            },
            new Movie
            {
                Id = 4,
                Title = "Rambo 3",
                Description = "Test description",
                Genre = Genre.Action,
                Year = 1988,
            },
            new Movie
            {
                Id = 5,
                Title = "Harry Potter and the Philosopher's Stone",
                Description = "Test description",
                Genre = Genre.SciFi,
                Year = 2001,
            },
            new Movie
            {
                Id = 6,
                Title = "Grown Ups",
                Description = "Test description",
                Genre = Genre.Action,
                Year = 2010,
            }
        };
    }
}
