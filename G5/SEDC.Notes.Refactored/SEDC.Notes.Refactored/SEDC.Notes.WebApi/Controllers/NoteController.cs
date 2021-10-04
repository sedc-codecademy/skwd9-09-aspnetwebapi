using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.Notes.RequestModels;
using SEDC.Notes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Notes.WebApi.Controllers
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

        [HttpPost]
        [Route("CreateNote")]
        public IActionResult CreateNote([FromBody] NoteRequestModel requestModel)
        {
            requestModel.UserId = 1;
            _noteService.AddNote(requestModel);

            return Ok();
        }

        [HttpGet]
        [Route("GetNotes")]
        public IActionResult GetNotes() 
        {
            var userId = 1;
            var response = _noteService.GetUserNotes(userId);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetNoteById")]
        public IActionResult GetNoteById([FromQuery] int id) 
        {
            var userId = 1;
            var response = _noteService.GetUserNoteById(userId, id);

            return Ok(response);
        }


        [HttpDelete]
        [Route("DeleteNoteById")]
        public IActionResult DeleteNoteById([FromQuery] int id) 
        {
            var userId = 1;
            _noteService.DeleteNoteById(userId, id);

            return Ok();
        }


        [HttpPut]
        [Route("UpdateNote")]
        public IActionResult UpdateNote([FromBody] NoteRequestModel requestModel) 
        {
            requestModel.UserId = 1;
            _noteService.UpdateNote(requestModel);

            return Ok();
        }

    }
}
