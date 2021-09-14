using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SEDC.NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesTagsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Note>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDB.Notes);
        }

        //[HttpPost]
        //public IActionResult Post()
        //{
        //    try
        //    {
        //        using (StreamReader reader = new StreamReader(Request.Body))
        //        {
        //            var jsonBody = reader.ReadToEndAsync();
        //            Note newNote = JsonConvert.DeserializeObject<Note>(jsonBody.Result);
        //            StaticDB.Notes.Add(newNote);
        //            return StatusCode(StatusCodes.Status201Created);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        [HttpPost("postNote")] //POST api/notes/postNote
        public IActionResult PostNote([FromBody] Note note)
        {
            try
            {
                StaticDB.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Note added!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }

        [HttpPost("postQuery")] // POST api/notes/postQuery?text=Write%20webAPI%20homework&color=red
        public ActionResult PostNoteWithQuery([FromQuery] Note note)
        {
            try
            {
                StaticDB.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Note added!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Note> Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
                }

                if (id >= StaticDB.Notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note not found");
                }
                return StatusCode(StatusCodes.Status200OK, StaticDB.Notes[id]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("queryString")]
        public ActionResult GetByQueryString(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
                }

                if (id >= StaticDB.Notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note not found");
                }
                return StatusCode(StatusCodes.Status200OK, StaticDB.Notes[id]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("multipleQuery")]
        public ActionResult<Note> GetMultipleQueryParams(string text, string color)
        {
            try
            {
                if (string.IsNullOrEmpty(text) && string.IsNullOrEmpty(color))
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                if (string.IsNullOrEmpty(text))
                {
                    Note note = StaticDB.Notes.FirstOrDefault(x => x.Color.Contains(color));
                    if (note == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "note not found");
                    }
                    return StatusCode(StatusCodes.Status200OK, note);
                }

                if (string.IsNullOrEmpty(color))
                {
                    Note note = StaticDB.Notes.FirstOrDefault(x => x.Text.Equals(text));
                    if (note == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "note not found");
                    }
                    return StatusCode(StatusCodes.Status200OK, note);
                }

                Note noteDb = StaticDB.Notes.FirstOrDefault(x => x.Text.Equals(text) && x.Color.Equals(color));

                if (noteDb == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "note not found");
                }
                return StatusCode(StatusCodes.Status200OK, noteDb);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        [HttpGet("headerData")]
        public IActionResult GetDataFromHeader([FromHeader(Name = "Accept-Language")] string lang)
        {
            if(lang == "mk")
            {
                return StatusCode(StatusCodes.Status200OK, "Super si bato!");
            }
            return StatusCode(StatusCodes.Status200OK, "Header sent successfully!");
        }

    }
}