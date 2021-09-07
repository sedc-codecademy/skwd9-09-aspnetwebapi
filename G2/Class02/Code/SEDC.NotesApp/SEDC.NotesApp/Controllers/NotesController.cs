using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace SEDC.NotesApp.Controllers
{
    [Route("api/[controller]")]     //http//:localhost:[port]/api/notes
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            //return Ok(StaticDb.SimpleNotes);
            return StatusCode(StatusCodes.Status200OK, StaticDb.SimpleNotes);
        }

        [HttpGet("{index}")]
        public ActionResult<string> Get(int index)
        {
            try
            {
                if (index < 0)
                {
                    // return BadRequest("The index has negative value!");
                    return StatusCode(StatusCodes.Status400BadRequest, "The index has negative value!");
                }
                if (index >= StaticDb.SimpleNotes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"There is no note with index {index}");
                }
                return StatusCode(StatusCodes.Status200OK, StaticDb.SimpleNotes[index]); // == return StaticDb.SimpleNotes[index];
            }
            catch (Exception e)
            {
                //to-do log e
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("{noteId}/user/{userId}")] //http://localhost:34209/api/notes/1/user/2
        public ActionResult<string> Get(int noteId, int userId)
        {
            return Ok($"Returning note with id {noteId} for user with id {userId}");
        }

        [HttpGet("info")]
        public ActionResult<string> Info()
        {
            return Ok("Your request was succesful");
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                // Request -> the HttpRequest that was sent to the action
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                    string note = reader.ReadToEnd();
                    StaticDb.SimpleNotes.Add(note);
                    return StatusCode(StatusCodes.Status201Created, "The note was created");
                }
            }
            catch (Exception e)
            {
                //to-do log e
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                using(StreamReader streamReader = new StreamReader(Request.Body))
                {
                    string requestBody = streamReader.ReadToEnd();
                    int index = Int32.Parse(requestBody);
                    if (index < 0)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "The index has negative value!");
                    }
                    if (index >= StaticDb.SimpleNotes.Count)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, $"There is no note with index {index}");
                    }
                    StaticDb.SimpleNotes.RemoveAt(index);
                    return StatusCode(StatusCodes.Status204NoContent, "The note was deleted");
                }
            }
            catch (Exception e)
            {
                //to-do log e
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
    }
}
