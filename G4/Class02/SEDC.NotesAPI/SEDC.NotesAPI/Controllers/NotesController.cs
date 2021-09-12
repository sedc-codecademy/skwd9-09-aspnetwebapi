using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC.NotesAPI.Controllers
{
    // http://localhost:12538/api/notes (default route)
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        // GET: api/notes
        // Routing is the only way to call the action
        // ENDPOINT is the address that connects us with the action
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //return StaticDB.SimpleNotes; // we do not need to have ActionResult as return type

            // this is one way to return status code with data
            //return Ok(StaticDB.SimpleNotes);

            // this is another way of returning status code and data
            return StatusCode(StatusCodes.Status200OK, StaticDB.SimpleNotes);

        }

        // GET api/notes/2
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                // 400 if the request is wrong (example there is no chance to have a book with index -56)
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "ID cannot be lower than zero.");
                }

                // 404 if the request is OK but the resource cannot be found
                if (id >= StaticDB.SimpleNotes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return StatusCode(200, StaticDB.SimpleNotes[id]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        // Multiple parameters in url

        // api/organizations/454/9869578jdsh342/876 // bad routing
        // api/organizations/454/users/9869578jdsh342/notes/876 // good routing

        [HttpGet("{id}/users/{userId}")]
        public ActionResult<string> Get(int id, int userId)
        {
            string text = $"Your note {StaticDB.SimpleNotes[id]} is used by user {userId}";
            return StatusCode(200, text);
        }

        // GET api/notes/info
        [HttpGet("info")]
        public ActionResult RandomAction()
        {
            var request = Request; //http request
            return StatusCode(StatusCodes.Status200OK);
        }


        // POST api/<NotesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
