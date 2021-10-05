using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.Notes.RequestModels;
using SEDC.Notes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SEDC.Notes.WebApi.Controllers
{
    [Authorize]
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
            requestModel.UserId = GetAuthorziedUserId();
            _noteService.AddNote(requestModel);

            return Ok();
        }

        [HttpGet]
        [Route("GetNotes")]
        public IActionResult GetNotes() 
        {
            var userId = GetAuthorziedUserId();
            var response = _noteService.GetUserNotes(userId);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetNoteById")]
        public IActionResult GetNoteById([FromQuery] int id) 
        {
            var userId = GetAuthorziedUserId();
            var response = _noteService.GetUserNoteById(userId, id);

            return Ok(response);
        }


        [HttpDelete]
        [Route("DeleteNoteById")]
        public IActionResult DeleteNoteById([FromQuery] int id) 
        {
            var userId = GetAuthorziedUserId();
            _noteService.DeleteNoteById(userId, id);

            return Ok();
        }


        [HttpPut]
        [Route("UpdateNote")]
        public IActionResult UpdateNote([FromBody] NoteRequestModel requestModel) 
        {
            requestModel.UserId = GetAuthorziedUserId();
            _noteService.UpdateNote(requestModel);

            return Ok();
        }


        private int GetAuthorziedUserId() 
        {
            bool userIdExists = int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            if (!userIdExists) 
            {
                string name = User.FindFirst(ClaimTypes.Name)?.Value;
                throw new Exception("Name identifier claim does not exist!");
                
            }

            return userId;
        }

    }
}
