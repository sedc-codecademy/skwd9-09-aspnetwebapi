using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")] // api/users
    [ApiController]
    public class UsersController : ControllerBase
    {
        private List<User> users = new List<User>()
        {
                new User()
                {
                    Id = 1,
                    UserName = "Bob_Bobsky",
                    Age = 30
                },
                new User()
                {
                    Id = 2,
                    UserName = "John_Doe",
                    Age = 32
                }
        };

        [HttpGet("all")]
        // [Route("all")]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        // [Route("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            if (id == 0)
            {
                // return NotFound(new { message = "No such User with id 0", suggestion = 1 });
                return StatusCode(StatusCodes.Status404NotFound,
                    new { message = "No such User with id 0", suggestion = 1 }
                );
            }
            return users.SingleOrDefault(user => user.Id == id);
            // User user = users.SingleOrDefault(user => user.Id == id);
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //return Ok(user);
        }

        [HttpGet("{userId}/class/{classId}")] // /api/users/2/class/545
        public string GetSomething(int userId, int classId)
        {
            return $"User: {userId}, class: {classId}";
        }


        //[HttpPost]
        //public ActionResult<string> PostSomething()
        //{
        //    using StreamReader reader = new StreamReader(Request.Body);
        //    string bodyRequest = reader.ReadToEnd();
        //    return bodyRequest;
        //}

        //[HttpPost]
        //public async Task<ActionResult<string>> PostSomething()
        //{
        //    using StreamReader reader = new StreamReader(Request.Body);
        //    string bodyRequest = await reader.ReadLineAsync();
        //    return bodyRequest;
        //}

        [HttpPost]
        public ActionResult<User> PostSomething([FromBody] User user)
        {
            int id = users.Count + 1;
            user.Id = id;
            return StatusCode(StatusCodes.Status201Created, user);
        }
    }
}
