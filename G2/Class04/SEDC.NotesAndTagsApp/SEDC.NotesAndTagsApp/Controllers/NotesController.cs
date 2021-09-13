using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesAndTagsApp.Dtos;
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

        [HttpGet("headers")]
        //get the value for the accept header
        public IActionResult GetAcceptHeader([FromHeader(Name = "Accept")] string acceptHeaderValue)
        {
            var request = Request;
            return Ok(acceptHeaderValue);
        }

        [HttpPut] //api/notes
        public IActionResult UpdateNote([FromBody] Note note)
        {
            try
            {
                if(note.Id <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Id can not be less than zero!");
                }
                if (string.IsNullOrEmpty(note.Text) || string.IsNullOrEmpty(note.Color))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Text and color must not be empty!");
                }
                Note noteDb = StaticDb.Notes.FirstOrDefault(x => x.Id == note.Id);
                if(noteDb == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Resource with id {note.Id} was not found!");
                }
                int index = StaticDb.Notes.IndexOf(noteDb);
                StaticDb.Notes[index] = note;
                //noteDb.Text = note.Text;
                //noteDb.Color = note.Color;
                

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch(Exception e)
            {
                //log e.Message, error details
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred, contact the administrator");
            }
        }

        [HttpDelete("{id}")] //api/notes/1
        public IActionResult DeleteNote(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Id can not be less than zero");
                }
                Note noteDb = StaticDb.Notes.FirstOrDefault(x => x.Id == id);
                if(noteDb == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"The resource with id {id} was not found!");
                }
                StaticDb.Notes.Remove(noteDb);
                return StatusCode(StatusCodes.Status204NoContent);
                //return Ok("Note deleted!");
            }
            catch (Exception e)
            {
                //log e.Message, error details
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred, contact the administrator");
            }
        }

        [HttpDelete] //api/notes
        //in the body of the request, we just send a number. For example: 1
        public IActionResult DeleteNoteById([FromBody] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Id can not be less than zero");
                }
                Note noteDb = StaticDb.Notes.FirstOrDefault(x => x.Id == id);
                if (noteDb == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"The resource with id {id} was not found!");
                }
                StaticDb.Notes.Remove(noteDb);
                return StatusCode(StatusCodes.Status204NoContent);
                //return Ok("Note deleted!");
            }
            catch (Exception e)
            {
                //log e.Message, error details
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred, contact the administrator");
            }
        }

        [HttpDelete("deleteWithDto")] 
        public IActionResult DeleteNote([FromBody] DeleteNoteDto deleteNoteDto)
        {
            try
            {
                if (deleteNoteDto.Id <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Id can not be less than zero");
                }
                Note noteDb = StaticDb.Notes.FirstOrDefault(x => x.Id == deleteNoteDto.Id);
                if (noteDb == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"The resource with id {deleteNoteDto.Id} was not found!");
                }
                StaticDb.Notes.Remove(noteDb);
                return StatusCode(StatusCodes.Status204NoContent);
                //return Ok("Note deleted!");
            }
            catch (Exception e)
            {
                //log e.Message, error details
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred, contact the administrator");
            }
        }

        [HttpGet("filterByTag")] //api/notes/filterByTag?tagId=7, //api/notes/filterByTag?tagName=sedc
        //filter notes with given tag
        public ActionResult<List<Note>> FilterNotesByTag(int tagId, string tagName)
        {
            try
            {
                if(tagId <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "You must send a tag Id");
                }
                bool exists = StaticDb.Notes.Any(x => x.Tags.Any(y => y.Id == tagId));
                if (!exists)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"There is no tag with id {tagId}");
                }
                return Ok(StaticDb.Notes.Where(x => x.Tags.Any(y => y.Id == tagId)));
                //return StatusCode(StatusCodes.Status200OK, StaticDb.Notes.Where(x => x.Tags.Any(y => y.Id == tagId)));
            }
            catch (Exception e)
            {
                //log e.Message, error details
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred, contact the administrator");
            }
        }
        [HttpGet("tag/{tagId}")] //api/notes/tag/7
        public ActionResult<List<Note>> FilterNotesByTagFromRoute(int tagId)
        {
            try
            {
                if (tagId <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "You must send a tag Id");
                }
                bool exists = StaticDb.Notes.Any(x => x.Tags.Any(y => y.Id == tagId));
                if (!exists)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"There is no tag with id {tagId}");
                }
                return Ok(StaticDb.Notes.Where(x => x.Tags.Any(y => y.Id == tagId)));
                //return StatusCode(StatusCodes.Status200OK, StaticDb.Notes.Where(x => x.Tags.Any(y => y.Id == tagId)));
            }
            catch (Exception e)
            {
                //log e.Message, error details
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred, contact the administrator");
            }
        }

        [HttpGet("user/{userId?}")] //api/notes/user/1 or api/notes/user ===> userId is optional
        //get the notes for a given user
        public ActionResult<List<Note>> FilterNotesByUser(int userId)
        {
            try
            {
                if(userId < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "User id can not be less than zero");
                }
                //userId is not required
                if (userId == 0)
                {
                    return StaticDb.Notes;
                }
                User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == userId);
                if(userDb == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"User with id {userId} was not found!");
                }
                return Ok(StaticDb.Notes.Where(x => x.User.Id == userId));
            }
            catch (Exception e)
            {
                //log e.Message, error details
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred, contact the administrator");
            }
        }

        [HttpPost("addNote/user/{userId}")] //api/notes/addNote/user/1
        public IActionResult AddNoteForUser(int userId, [FromBody] Note note)
        {
            try
            {
                User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == userId);
                if(userDb == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"User with id {userId} was not found!");
                }
                if(string.IsNullOrEmpty(note.Text) || string.IsNullOrEmpty(note.Color))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Text and color are required fields!");
                }
                note.Id = StaticDb.Notes.Last().Id + 1;
                note.User = userDb;
                //add to db
                StaticDb.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created, $"Note was created for user with id {userId}");
            }
            catch (Exception e)
            {
                //log e.Message, error details
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred, contact the administrator");
            }
        }

        [HttpPost("addNote")] //api/notes/addNote
        public IActionResult AddNote([FromBody] AddNoteDto addNoteDto)
        {
            try
            {
                User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == addNoteDto.UserId);
                if (userDb == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"User with id {addNoteDto.UserId} was not found!");
                }
                if (string.IsNullOrEmpty(addNoteDto.Text) || string.IsNullOrEmpty(addNoteDto.Color))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Text and color are required fields!");
                }
                Note newNote = new Note
                {
                    Id = StaticDb.Notes.Last().Id + 1,
                    Text = addNoteDto.Text,
                    Color = addNoteDto.Color,
                    User = userDb
                };
                if(addNoteDto.Tags != null)
                {
                    newNote.Tags = new List<Tag>();
                    foreach(TagDto tagDto in addNoteDto.Tags)
                    {
                        newNote.Tags.Add(new Tag
                        {
                            Name = tagDto.Name,
                            Color = tagDto.Color
                        });
                    }
                }
                //add to db
                StaticDb.Notes.Add(newNote);
                return StatusCode(StatusCodes.Status201Created, $"Note was created for user with id {addNoteDto.UserId}");
            }
            catch (Exception e)
            {
                //log e.Message, error details
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred, contact the administrator");
            }
        }
    }
}
