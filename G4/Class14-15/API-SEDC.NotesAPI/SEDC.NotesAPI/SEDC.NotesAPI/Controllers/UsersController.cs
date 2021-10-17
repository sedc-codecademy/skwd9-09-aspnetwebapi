﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesAPI.Models.Users;
using SEDC.NotesAPI.Services.Interfaces;
using SEDC.NotesAPI.Shared.Exceptions;
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
            catch(UserException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
