using Microsoft.AspNetCore.Mvc;
using Notes.Models.Dto;
using Notes.Services.Interface;
using System;
using System.Collections.Generic;

namespace Notes.Controllers
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
        public ActionResult<List<NoteDto>> GetAllNotes(int userId)
        {
            return _noteService.GetUserNotes(userId);
        }

        [HttpPost("getNoteDetails")]
        public ActionResult<NoteDto> GetNoteDetails(int noteId, int userId)
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
        public ActionResult<string> AddNote([FromBody] NoteDto note)
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
