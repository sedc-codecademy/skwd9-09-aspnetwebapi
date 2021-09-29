using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.Interface;
using System;
using System.Collections.Generic;

namespace SEDC.NotesApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("getAllNotes/{userId}")]
        [Authorize]
        public ActionResult<List<NoteModel>> GetAllNotes(int userId)
        {
            return _noteService.GetUserNotes(userId);
        }

        [HttpPost("getNoteDetails")]
        public ActionResult<NoteModel> GetNoteDetails(int noteId, int userId)
        {
            try
            {
                return _noteService.GetNoteDetails(noteId, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addNote")]
        public ActionResult<string> AddNote([FromBody] NoteModel note)
        {
            try
            {
                return _noteService.AddNote(note);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("deleteNote")]
        public ActionResult<string> DeleteNote(int noteId, int userId)
        {
            try
            {
                return _noteService.DeleteNote(noteId, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
