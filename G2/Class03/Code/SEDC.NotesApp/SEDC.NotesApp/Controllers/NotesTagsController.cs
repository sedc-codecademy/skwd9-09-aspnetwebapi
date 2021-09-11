using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SEDC.NotesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SEDC.NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesTagsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Note>> Get()
        {
            //return Ok(StaticDb.Notes);
            return StatusCode(StatusCodes.Status200OK, StaticDb.Notes);
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                using(StreamReader streamReader = new StreamReader(Request.Body))
                {
                    string jsonBody = streamReader.ReadToEnd();
                    Note newNote = JsonConvert.DeserializeObject<Note>(jsonBody);
                    StaticDb.Notes.Add(newNote);
                    return StatusCode(StatusCodes.Status201Created, "Note created!");
                }
            }
            catch(Exception e)
            {
                //log e.Message
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
    }
}
