using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesAndTagsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.NotesAndTagsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet] //api/notes
        public ActionResult<List<Note>> Get()
        {
            try
            {
                return Ok(StaticDb.Notes);
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("{index}")] //api/notes/2
        public ActionResult<Note> Get(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the index can not be negative!");
                }
                if (index >= StaticDb.Notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Resource with index {index} does not exist!");
                }
                return Ok(StaticDb.Notes[index]);
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("queryString")] //api/notes/queryString?index=1
        public ActionResult<Note> GetByIndex(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the index can not be negative!");
                }
                if (index >= StaticDb.Notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Resource with index {index} does not exist!");
                }
                return Ok(StaticDb.Notes[index]);
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("{textFilter}/{colorFilter}")] //api/notes/homework/red
        public ActionResult<List<Note>> FilterNotes(string textFilter, string colorFilter)
        {
            try
            {
                List<Note> filteredNotes = StaticDb.Notes.Where(x => x.Text.ToLower().Contains(textFilter.ToLower())
                                                         && x.Color == colorFilter).ToList();
                return Ok(filteredNotes);
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("filter")]   //api/notes/filter?color=red&text=gym  == api/notes/filter?text=gym&color=red
        public ActionResult<List<Note>> FilterNotesFromQuery(string text, string color)
        {
            try
            {
                if (string.IsNullOrEmpty(text) && string.IsNullOrEmpty(color))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "You have to send at least one filter parameter!");
                }
                if (string.IsNullOrEmpty(text))
                {
                    List<Note> notesDb = StaticDb.Notes.Where(x => x.Color == color).ToList();
                    return Ok(notesDb);
                }
                if (string.IsNullOrEmpty(color))
                {
                    List<Note> notesDb = StaticDb.Notes.Where(x => x.Text.ToLower().Contains(text.ToLower())).ToList();
                    return Ok(notesDb);
                }
                List<Note> filteredNotes = StaticDb.Notes.Where(x => x.Text.ToLower().Contains(text.ToLower())
                                                             && x.Color == color).ToList();
                return Ok(filteredNotes);
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("postNote")] //api/notes/postNote?text=gym&color=red&name=test
        public IActionResult PostNote([FromQuery] Note note, [FromQuery] Tag tag)
        {
            return Ok();
        }
        
        [HttpPost("postNoteWithoutTags")] //api/notes/postNoteWithoutTags
        public IActionResult PostNoteWithoutTags([FromBody] Note note)
        {
            try
            {
                StaticDb.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Note was added");
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpPost("postNoteWithTag")]
        public IActionResult PostNoteWithTags([FromBody] Note note)
        {
            try
            {
                StaticDb.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Note was added");
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpPut("addTag/{noteIndex}")] //api/notes/addTag/1
        public IActionResult AddTagToNote(int noteIndex, [FromBody]Tag tag)
        {
            try
            {
                if(noteIndex < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Index must not be negative!");
                }
                if(noteIndex >= StaticDb.Notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Note with index {noteIndex} can not be found! ");
                }
                Note noteDb = StaticDb.Notes[noteIndex];
                if(noteDb.Tags == null)
                {
                    noteDb.Tags = new List<Tag>();
                }
                noteDb.Tags.Add(tag);
                return StatusCode(StatusCodes.Status204NoContent, "Note updated!");
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

    }
}
