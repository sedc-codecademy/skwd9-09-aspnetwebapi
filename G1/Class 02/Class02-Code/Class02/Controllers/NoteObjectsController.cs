using Class02.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Class02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteObjectsController : ControllerBase
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
            },
            new Note(){ Text="Some dummy note",Color="Blue"}
        };

        //mapping on action method can be done with Route attribute where we type the name of the route ex.[Route("nameOfRoute")] or
        // we can map directy when we assign what type of action we have ex.. [HttpGet("nameOfRoute")]
        //[Route("noteElements")]
        [HttpGet("noteElements")]
        public ActionResult<List<Note>> Get()
        {
            return notes;
        }

        [HttpGet("noteDetails/{id}")]
        public ActionResult<Note> Get(int id)
        {
            try
            {
                return notes[id - 1];
            }
            catch (ArgumentOutOfRangeException exception)
            {
                return NotFound($"Note with id {id} does not exist. Exception message {exception.Message}");
            }
        }

        [HttpGet("{noteId}/tags")]
        public ActionResult<List<Tag>> Tags(int noteId)
        {
            try
            {
                return notes[noteId - 1].Tags;
            }
            catch (ArgumentOutOfRangeException exception)
            {
                return NotFound($"There are no tags for note id {noteId}.Exception message: {exception.Message}");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{noteId}/tags/{tagId}")]
        public ActionResult<Tag> NoteTag(int noteId, int tagId)
        {
            try
            {
                return notes[noteId - 1].Tags[tagId - 1];
            }
            catch (ArgumentOutOfRangeException exception)
            {
                return NotFound($"There are no tags for note id {noteId}.Exception message: {exception.Message}");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
