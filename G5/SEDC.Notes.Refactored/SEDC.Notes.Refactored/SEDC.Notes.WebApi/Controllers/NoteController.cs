using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.Notes.Common.Exceptions;
using SEDC.Notes.RequestModels;
using SEDC.Notes.Services.Interfaces;
using Serilog;
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
            try
            {
                requestModel.UserId = GetAuthorziedUserId();
                _noteService.AddNote(requestModel);

                Log.Information($"Note succesffuly created date: {DateTime.UtcNow}");
                return Ok();
            }
            catch (UserException ex)
            {
                Log.Error("USER {userId}.{name}: {message}", ex.UserId, ex.Name, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (NoteException ex) 
            {
                Log.Error("NOTE {noteId} for user {userId}: {message}", ex.NoteId, ex.UserId, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error("UNKNOWN Error: {message}", ex.Message);
                return BadRequest("Something went wrong. Please contact support!");
            }
        }

        [HttpGet]
        [Route("GetNotes")]
        public IActionResult GetNotes() 
        {
            try
            {
                var userId = GetAuthorziedUserId();
                var response = _noteService.GetUserNotes(userId);

                Log.Information($"Note succesffuly retrieved notes on {DateTime.UtcNow}");
                return Ok(response);
            }
            catch (UserException ex)
            {
                Log.Error("USER {userId}.{name}: {message}", ex.UserId, ex.Name, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (NoteException ex)
            {
                Log.Error("NOTE {noteId} for user {userId}: {message}", ex.NoteId, ex.UserId, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error("UNKNOWN Error: {message}", ex.Message);
                return BadRequest("Something went wrong. Please contact support!");
            }
        }

        [HttpGet]
        [Route("GetNoteById")]
        public IActionResult GetNoteById([FromQuery] int id) 
        {
            try
            {
                var userId = GetAuthorziedUserId();
                var response = _noteService.GetUserNoteById(userId, id);
                return Ok(response);
            }
            catch (UserException ex)
            {
                Log.Error("USER {userId}.{name}: {message}", ex.UserId, ex.Name, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (NoteException ex)
            {
                Log.Error("NOTE {noteId} for user {userId}: {message}", ex.NoteId, ex.UserId, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error("UNKNOWN Error: {message}", ex.Message);
                return BadRequest("Something went wrong. Please contact support!");
            }
        }


        [HttpDelete]
        [Route("DeleteNoteById")]
        public IActionResult DeleteNoteById([FromQuery] int id) 
        {
            try
            {
                var userId = GetAuthorziedUserId();
                _noteService.DeleteNoteById(userId, id);
                return Ok();
            }
            catch (UserException ex)
            {
                Log.Error("USER {userId}.{name}: {message}", ex.UserId, ex.Name, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (NoteException ex)
            {
                Log.Error("NOTE {noteId} for user {userId}: {message}", ex.NoteId, ex.UserId, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error("UNKNOWN Error: {message}", ex.Message);
                return BadRequest("Something went wrong. Please contact support!");
            }
        }


        [HttpPut]
        [Route("UpdateNote")]
        public IActionResult UpdateNote([FromBody] NoteRequestModel requestModel) 
        {
            try
            {
                requestModel.UserId = GetAuthorziedUserId();
                _noteService.UpdateNote(requestModel);
                return Ok();
            }
            catch (UserException ex)
            {
                Log.Error("USER {userId}.{name}: {message}", ex.UserId, ex.Name, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (NoteException ex)
            {
                Log.Error("NOTE {noteId} for user {userId}: {message}", ex.NoteId, ex.UserId, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error("UNKNOWN Error: {message}", ex.Message);
                return BadRequest("Something went wrong. Please contact support!");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("testLogger")]
        public IActionResult TestLogger()
        {
            Log.Information("text about infgormation log!");

            Log.Warning("text about warning log!");

            Log.Error("text about ERROR log!");

            return Ok();
        }


        private int GetAuthorziedUserId() 
        {
            bool userIdExists = int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            if (!userIdExists) 
            {
                string name = User.FindFirst(ClaimTypes.Name)?.Value;
                throw new UserException(userId, name, "Name identifier claim does not exist!");
            }

            return userId;
        }

    }
}
