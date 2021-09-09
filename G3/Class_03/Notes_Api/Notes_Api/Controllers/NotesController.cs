using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes_Api.Controllers
{
    [Route("api/[controller]")] // api/notes
    [ApiController]
    public class NotesController : ControllerBase
    {
        public static List<Note> notes = new List<Note>()
        {
            new Note()
            {
                Id = 1,
                Text = "DO HOMEWORK",
                Color = "red"
            },
            new Note()
            {
                Id = 2,
                Text = "Go to gym",
                Color = "green"
            },
            new Note()
            {
                Id = 3,
                Text = "read book",
                Color = "yellow"
            }
        };
        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return notes;
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public ActionResult<Note> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        new { Message = "Id cant be lower than 1" });
                }
                if (id > notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        new { Message = $"No such note with id: { id }" });
                }

                return StatusCode(StatusCodes.Status200OK,
                    notes.SingleOrDefault(note => note.Id == id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
            
        }

        // POST api/<NotesController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Note note)
        {
            try
            {
                if (note.Text.Length == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        new { Message = "Text field is required" });
                }
                note.Id = notes.Count + 1;
                notes.Add(note);
                return StatusCode(StatusCodes.Status200OK,
                    new { id = note.Id });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
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
