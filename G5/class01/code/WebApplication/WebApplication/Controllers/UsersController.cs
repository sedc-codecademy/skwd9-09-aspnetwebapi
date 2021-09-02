using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsersAsync() 
        {
            var user1 = new User()
            {
                Name = "Viktor",
                Age = 32
            };

            var user2 = new User()
            {
                Name = "Petar",
                Age = 18
            };

            var user3 = new User()
            {
                Name = "Ana",
                Age = 42
            };

            var users = new List<User>();
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);

            return Ok(users);
        }

        [HttpGet]
        [Route("GetUserByIndex")]
        public async Task<IActionResult> GetUserByIndexAsync([FromQuery]int index) 
        {
            var user1 = new User()
            {
                Name = "Viktor",
                Age = 32
            };

            var user2 = new User()
            {
                Name = "Petar",
                Age = 18
            };

            var user3 = new User()
            {
                Name = "Ana",
                Age = 42
            };

            var users = new List<User>();
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);

            if (index > users.Count - 1) 
            {
                //return BadRequest();
                return NotFound("User not found");
            }

            return Ok(users[index]);
        }

    }
}
