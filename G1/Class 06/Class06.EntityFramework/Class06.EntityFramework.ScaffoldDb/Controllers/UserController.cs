using Class06.EntityFramework.DataModels.CreatedFromDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Class06.EntityFramework.ScaffoldDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly NotesExampleContext _db;
        public UserController(NotesExampleContext db)
        {
            _db = db;
        }


        // **** JUSTO FOR DEMO (DO NOT EVER OPEN DB CONTEXT IN THE API CONTROLLER) ***


        [HttpGet("getall")]
        public ActionResult<List<Users>> Get()
        {
            var users = _db.Users
                            .Include(x => x.Notes)
                            .ToList();
            return Ok(users);
        }


        [HttpGet("getuser/{id:int}")]
        public ActionResult<Users> Get(int id)
        {
            var user = _db.Users
                            .Include(x => x.Notes)
                            .SingleOrDefault(x => x.Id == id);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound($"User with Id: {id} not exists!");
            }
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] Users user)
        {
            if(user != null)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return Ok("User added successfully!");
            }
            return BadRequest("The user creation failed!");
        }

        [HttpGet("usercompletednotes/{id:int}")]
        public ActionResult<List<Notes>> GetCompleted(int id)
        {
            var completedNotes = _db.Users
                                    .Where(x => x.Id == id)
                                    .SelectMany(x => x.Notes)
                                    .Where(x => x.IsCompleted);
            if(completedNotes.Any())
            {
                return Ok(completedNotes);
            }
            return NotFound($"No completed notes for user with Id: {id}");
        }
    }
}
