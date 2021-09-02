using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = new List<User>();
            users.Add(new User() { Id = 1, Name = "Ljube" });
            users.Add(new User() { Id = 2, Name = "Petre" });

            return BadRequest(users);
        }

        [HttpPost]
        public List<User> AddNewUser(User user)
        {
            List<User> users = new List<User>();
            users.Add(new User() { Id = 1, Name = "Petre" });
            users.Add(user);

            return users;
        }
    }
}
