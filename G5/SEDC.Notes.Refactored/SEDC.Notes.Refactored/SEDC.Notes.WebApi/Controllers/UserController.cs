using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.Notes.RequestModels;
using SEDC.Notes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Notes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] LoginRequestModel requestModel) 
        {
            var user = _userService.Authenticate(requestModel);
            return Ok(user);        
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterRequestModel requestModel) 
        {
            _userService.Register(requestModel);
            return Ok();
        }
    }
}
