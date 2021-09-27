using Microsoft.AspNetCore.Mvc;
using SEDC.MovieWorkshop.Models;
using SEDC.MovieWorkshop.Services.Interface;
using System;

namespace SEDC.MovieWorkshop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getUserMovies/{userId}")]
        public ActionResult<UserResultModel> GetUserMovies(int userId)
        {
            var userMovies = _userService.GetUserMoviesRented(userId);
            if (userMovies.Succeeded)
            {
                return Ok(userMovies);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
