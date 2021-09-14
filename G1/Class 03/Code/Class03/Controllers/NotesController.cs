using Class03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public static List<Note> notes = new List<Note>()
        {
            new Note(){ Text = "Don't forget to water the plant", Color = "blue", Tags = new List<Tag>()
                {
                    new Tag(){ Name = "Home", Color = "cyan"},
                    new Tag(){ Name = "Priority Low", Color = "green"}
                }
            },
            new Note(){ Text = "Drink more Tea", Color = "blue", Tags = new List<Tag>()
            {
                    new Tag(){ Name = "Misc", Color = "orange"},
                    new Tag(){ Name = "Priority Low", Color = "green"}
                }
            },
            new Note(){ Text = "Make a break every 1h of coding", Color = "blue", Tags = new List<Tag>()
            {
                    new Tag(){ Name = "work", Color = "blue"},
                    new Tag(){ Name = "Priority Medium", Color = "yellow"}
                }
            }
        };

        [HttpGet("noteById/{noteId}")]
        public ActionResult<Note> GetNoteById(int noteId)
        {
            try
            {
                return notes[noteId - 1];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return NotFound($"Note with id: {noteId} not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad request: {ex.Message}");
            }
        }

        [HttpPost("noteCreatedFromParams")]
        public ActionResult CreateNoteFromParams(string text, string color)
        {
            Note note = new Note
            {
                Text = text,
                Color = color
            };
            notes.Add(note);

            return Ok("Note has been created");
        }

        [HttpPost("queryParams")]
        public ActionResult CreatedNoteFromQueryParams([FromQuery] Note note)
        {
            if (note != null)
            {
                notes.Add(note);

                return Ok("Note successfully added");
            }

            return BadRequest("Note creation faild");
        }


        //when we want to send multiple query parameters we can use FromBody and send them as body in the request
        //[HttpPost("multipleQueryParams")]
        //public ActionResult MultipleQueryParamsAction([FromBody]NoteObjects note)
        //{
        //    return Ok("Note object proceeded");
        //}

        [HttpPost("query3")]
        public ActionResult QueryParams3([FromQuery] Note note, [FromQuery] Tag tag)
        {
            note.Tags = new List<Tag> { tag };

            if (note != null)
            {
                notes.Add(note);

                return Ok("Note successfully created");
            }

            return BadRequest("Bad request");
        }

        [HttpPost("insertFromBody")]
        public ActionResult ReadingFromBody([FromBody] Note note)
        {
            if (note != null)
            {
                notes.Add(note);

                return Ok("Note successfully added");
            }

            return BadRequest("Bad request");
        }


        //if we want to send some complex object etc.. object in object in object
        //[HttpPost("comlplexBodyObject")]
        //public ActionResult ReadingComplexObjectFromBody([FromBody]NoteObject noteObject)
        //{
        //    return Ok();
        //}

        //reading host name from header
        [HttpGet("getHostName")]
        public ActionResult GetHostName([FromHeader] string host)
        {
            return Ok($"You are accessing {host}");
        }

        [HttpGet("getLanguageFromHeader")]
        public ActionResult GetLanguageFromHeader([FromHeader] string host, [FromHeader(Name ="Accept-Language")] string language)
        {
            if (language == "mk-Mk")
            {
                return Ok($"Пристапувате од {host}");
            }
            return Ok($"You are accessing from {host}");
        }
    }
}
