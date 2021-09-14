using Class02.Homework_soluition.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class02.Homework_soluition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> StaticUsers = new List<User>() 
        { 
            new User { FirstName = "Viktor", LastName = "Jakovlev", Age = "32" },
            new User { FirstName = "Igor", LastName = "Petrov", Age = "12" },
            new User { FirstName = "Ana", LastName = "Petrova", Age = "22" },
            new User { FirstName = "Marija", LastName = "Ristovska", Age = "26" }
        };

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAllUsers() 
        {
            if (StaticUsers.Count < 1)
            {
                return NotFound("There are no users in the database!");
            }
            else
            {
                return Ok(StaticUsers);
            }
        }

        [HttpGet]
        [Route("getbyindex/{index}")]
        public IActionResult GetUserByIndex([FromRoute]int index) 
        {
            if (index > StaticUsers.Count - 1 || index < 0)
            {
                return NotFound("User not found! Please try again.");
            }
            else
            {
                return Ok(StaticUsers[index]);
            }
        }

        [HttpGet]
        [Route("checkifuserisadult/{index}")]
        public IActionResult CheckIfUserIsAdultByIndex([FromRoute] int index) 
        {
            if (index > StaticUsers.Count - 1 || index < 0)
            {
                return NotFound("User not found! Please try again.");
            }
            else 
            {
                var tempUser = StaticUsers[index];
                var message = CheckIfUserIsAdult(tempUser) == true ? $"{tempUser.FirstName} is adult!" 
                                                                   : $"{tempUser.FirstName} is NOT an adult!";
                return Ok(message);
            }
        }

        [HttpPost]
        [Route("createuser")]
        public IActionResult CreateUser([FromBody] User user)  
        {
            if (user != null)
            {
                StaticUsers.Add(user);
                return Ok("User is created!");
            }
            else 
            {
                return BadRequest("Bad request!");
            }
        }


        private bool CheckIfUserIsAdult(User user)
        {
            return int.Parse(user.Age) > 17 ? true : false;
        }
    }
}
