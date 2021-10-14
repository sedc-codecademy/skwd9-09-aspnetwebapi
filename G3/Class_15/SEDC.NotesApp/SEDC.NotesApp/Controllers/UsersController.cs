using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesApp.DtoModels;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC.NotesApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet] // api/users
        [Authorize(Roles = "Admin")]
        public ActionResult<List<UserDto>> Get()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
            
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int id)
        {
            try
            {
                return Ok(_userService.GetById(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody] LogInModel model)
        {
            try
            {
                var user = _userService.Authenticate(model);
                if (user == null)
                {
                    return BadRequest("UserName or Password is incorrect");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = ex.Message
                });
            }
        }

        [AllowAnonymous]
        // POST api/users
        [HttpPost]
        public ActionResult SignUp([FromBody] RegisterModel newUser)
        {
            try
            {
                _userService.Create(newUser);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (BadRequestException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        // PUT api/users
        [HttpPut]
        public ActionResult Put([FromBody] UserDto user)
        {
            try
            {
                _userService.Update(user);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (UserException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Message = ex.Message,
                    UserId = ex.UserId
                });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (UserException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Message = ex.Message,
                    UserId = ex.UserId
                });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
