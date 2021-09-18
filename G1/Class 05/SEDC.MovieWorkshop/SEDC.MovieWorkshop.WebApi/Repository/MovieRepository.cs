using SEDC.MovieWorkshop.WebApi.Db;
using SEDC.MovieWorkshop.WebApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.MovieWorkshop.WebApi.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        public void Add(Movie entity)
        {
            if(entity != null)
            {
                MovieDb.Movies.Add(entity);
            }
        }

        public List<Movie> GetAll()
        {
            return MovieDb.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return MovieDb.Movies.SingleOrDefault(x => x.Id == id);
        }
    }
}
