using Microsoft.AspNetCore.Mvc;
using SEDC.MovieWorkshop.Models;
using SEDC.MovieWorkshop.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.MovieWorkshop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("getall")]
        public ActionResult<IEnumerable<MovieModel>> GetAll()
        {
            var movies = _movieService.GetAllMovies();
            if (movies.Any())
            {
                return Ok(movies);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("getById/{id:int}")]
        public ActionResult<MovieModel> GetById(int id)
        {
            var movie = _movieService.GetMoviesById(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("addnew")]
        public ActionResult Create([FromBody] MovieModel movieDTO)
        {
            ResultModel result = _movieService.CreateMovie(movieDTO);

            if (result.Succeeded)
            {
                return Ok("Movie successfully added");
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
    }
}
