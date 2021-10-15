using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotesApp.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {

        private ILogger<NotesController> _logger;

        public NotesController(ILogger<NotesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Note>> Get()
        {
            try
            {
                _logger.LogInformation("We got all notes");
                return StatusCode(StatusCodes.Status200OK, StaticDB.Notes);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/notes/5
        [HttpGet("{index}")]
        public ActionResult<Note> Get(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request!");
                }

                if (index >= StaticDB.Notes.Count)
                {
                    throw new Exception("Note is is not found");
                    //return StatusCode(StatusCodes.Status404NotFound, "Note does not exist!");
                }
                Note note = StaticDB.Notes[index];

                Log.Information("The note with index {index} has the following text: {text}", index, note.Text);
                //Log.Information("Note with index {index} was found {@note}", index, note);
                //_logger.LogInformation("We got the note with index {index}", index);
                return StatusCode(StatusCodes.Status200OK, note);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "The note with index {index} does not exist", index);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // POST api/notes
        [HttpPost]
        public IActionResult Post([FromBody] Note note)
        {
            try
            {
                StaticDB.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/notes/5
        [HttpPut("{noteIndex}")]
        public IActionResult Put(int noteIndex, [FromBody] Tag tag)
        {
            try
            {
                if (noteIndex < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request!");
                }

                if (noteIndex >= StaticDB.Notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note does not exist!");
                }

                Note note = StaticDB.Notes[noteIndex];
                if (note.Tags == null)
                {
                    note.Tags = new List<Tag>();
                }
                note.Tags.Add(tag);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/notes/5
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request!");
                }

                if (index >= StaticDB.Notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note does not exist!");
                }

                StaticDB.Notes.RemoveAt(index);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
