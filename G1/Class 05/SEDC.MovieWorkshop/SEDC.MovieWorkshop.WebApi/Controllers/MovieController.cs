using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.MovieWorkshop.WebApi.Mappers;
using SEDC.MovieWorkshop.WebApi.Models.DTOs;
using SEDC.MovieWorkshop.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult<IEnumerable<MovieDTO>> GetAll()
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
        public ActionResult<MovieDTO> GetById(int id)
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
        public ActionResult Create([FromBody] MovieDTO movieDTO)
        {
            ResultDTO result = _movieService.CreateMovie(movieDTO);

            if(result.Succeeded)
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
