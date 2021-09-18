using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.Notes.Models.Dto;
using SEDC.Notes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Notes.Controllers
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

        [HttpGet]
        [Route("getallnotes/{userId}")]
        public ActionResult<List<NoteDto>> GetAllNotes([FromRoute]int userId)
        {
            try
            {
                var response = _noteService.GetUserNotes(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getnotedetails/{noteId}/{userId}")]
        public ActionResult<NoteDto> GetNoteDetails([FromRoute]int noteId, [FromRoute]int userId)
        {
            try
            {
                var response = _noteService.GetNoteDetails(noteId, userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpPost]
        [Route("addnote")]
        public ActionResult<string> AddNote([FromBody]NoteDto note)
        {
            try
            {
                var response = _noteService.AddNote(note);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deletenote/{noteId}/{userId}")]
        public ActionResult<string> DeleteNote([FromRoute] int noteId, [FromRoute] int userId) 
        {
            try
            {
                var response = _noteService.DeleteNote(noteId, userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("updatenote")]
        public ActionResult<string> UpdateNote([FromBody] NoteDto note) 
        {
            try
            {
                var response = _noteService.UpdateNote(note);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
