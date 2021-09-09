using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Class02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public static List<string> notes = new List<string>
        {
            "Don't forget to water plant",
            "Remember that you don't have plants",
            "Remember to buy new plant",
            "Make a break every 1h of coding",
            "Drink coffee"
        };

        //[Route("elements")]
        [HttpGet("elements")]
        public ActionResult<List<string>> Get()
        {
            return notes;
        }

        [HttpGet("element/{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return Ok(notes[id - 1]);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return NotFound($"Note with id:{id} is not found!.Exception:{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"There is problem with your request:{ex.Message}");
            }
        }
        //if we implement async call
        //[HttpGet]
        //public async Task<List<string>> Get()
        //{
        // here we need to use real database for making async calls, not fake data or data from in memory database
        //    return await notes;
        //}

        [HttpGet("{userId}/note/{noteId}")]
        public ActionResult<string> GetNotes(int userId, int noteId)
        {
            string note = notes[noteId - 1];

            return Ok($"User:{userId}. This user needs to {note}");
        }

        [HttpGet("info")]
        public ActionResult<string> Info()
        {
            var request = Request;

            return Ok($"This is a successfull request.Type of http request {request.Method}");
        }
    }
}
