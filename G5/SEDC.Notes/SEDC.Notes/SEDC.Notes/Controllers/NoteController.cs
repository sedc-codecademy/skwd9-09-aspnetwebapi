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
            var response = _noteService.GetUserNotes(userId);
            return Ok(response);
        }

        [HttpGet]
        [Route("getnotedetails/{noteId}/{userId}")]
        public ActionResult<NoteDto> GetNoteDetails([FromRoute]int noteId, [FromRoute]int userId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("addnote")]
        public ActionResult AddNote([FromBody]NoteDto note)
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
        public ActionResult DeleteNote([FromRoute] int noteId, [FromRoute] int userId) 
        {
            return Ok();
        }


    }
}
