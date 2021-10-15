using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesAPI.Models.Users;
using SEDC.NotesAPI.Services.Interfaces;
using SEDC.NotesAPI.Shared.Exceptions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.NotesAPI.Controllers
{
    [AllowAnonymous]  // this overrides attribute on route
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserModel registerUserModel)
        {
            try
            {
                _userService.Register(registerUserModel);
                return StatusCode(StatusCodes.Status201Created, "User successfully registered");
            }
            catch(UserException e)
            {
                Log.Warning("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch(Exception ex)
            {
                Log.Warning("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginUserModel loginUser)
        {
            try
            {
                string token = _userService.Login(loginUser);
                return StatusCode(StatusCodes.Status200OK, token);
            }
            catch (NotFoundException e)
            {
                Log.Warning("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                Log.Warning("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
