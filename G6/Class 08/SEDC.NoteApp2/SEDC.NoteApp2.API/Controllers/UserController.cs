using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NoteApp2.Dto.Models;
using SEDC.NoteApp2.Dto.ValidationModels;
using SEDC.NoteApp2.Services.Interfaces;
using System.Collections.Generic;

namespace SEDC.NoteApp2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IEntityValidationService _entityValidationService;

        public UserController(IUserService userService, IEntityValidationService entityValidationService)
        {
            _userService = userService;
            _entityValidationService = entityValidationService;
        }

        [HttpGet("")]
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            List<UserDto> users = _userService.GetAllUsers();
            return StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpGet("all/notes")]
        public ActionResult<List<UserDto>> GetAllUsersIncludeProperties()
        {
            List<UserDto> users = _userService.GetAllUsersIncludeNotes();
            return StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpGet("{id}")]
        public ActionResult<List<UserDto>> GetUserById(int id)
        {
            UserDto user = _userService.GetUserById(id);
            return StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpGet("{id}/notes")]
        public ActionResult<List<UserDto>> GetUserByIdIncludeProperties(int id)
        {
            UserDto user = _userService.GetUserByIdIncludeNotes(id);
            return StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpPost("")]
        public ActionResult AddUser(UserDto userDto)
        {
            ValidationResponse validationResponse = _entityValidationService.ValidateUser(userDto);

            if (validationResponse.HasError)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validationResponse);
            }

            _userService.AddUser(userDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("update")]
        public ActionResult UpdateUser(UserDto userDto)
        {
            _userService.UpdateUser(userDto);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpDelete("{id}/delete")]
        public ActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
