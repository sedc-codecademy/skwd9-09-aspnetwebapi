using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> users = new List<User>()
        {
            new User
            {
                Id = 1,
                Name = "Ljube",
                CreatedOn = DateTime.UtcNow
            }
        };

        [HttpGet("all")]
        public ActionResult<List<User>> GetAll()
        {
            if (users.Count() == 1)
            {
                throw new Exception("Exception on purpose.");
            }

            if (users.Count() == 2)
            {
                throw new NotImplementedException("NotImplementedException on purpose.");
            }

            if (users.Count() == 3)
            {
                return StatusCode(StatusCodes.Status501NotImplemented);
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            User user = users.FirstOrDefault(q => q.Id.Equals(id));

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("add")]
        public IActionResult AddUser(User user)
        {
            users.Add(user);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public IActionResult SerializeDeserializeExample()
        {
            User user = new User
            {
                Id = 1,
                Name = "Ljube",
                CreatedOn = DateTime.UtcNow
            };

            string json = JsonSerializer.Serialize(user);

            User user2 = JsonSerializer.Deserialize<User>(json);

            return Ok();
        }
    }
}
