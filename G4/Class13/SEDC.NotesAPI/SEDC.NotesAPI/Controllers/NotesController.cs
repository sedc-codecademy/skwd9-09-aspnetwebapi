using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesAPI.Models.Notes;
using SEDC.NotesAPI.Services.Interfaces;
using SEDC.NotesAPI.Shared.Exceptions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC.NotesAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public ActionResult<List<NoteModel>> Get()
        {
            try
            {
                List<NoteModel> notes = _noteService.GetAllNotes();
                //foreach (var note in notes)
                //{
                //    Log.Information("{@note}", note);
                //}
                return StatusCode(StatusCodes.Status200OK, notes);
            }
            catch (Exception e)
            {
                Log.Error("{error}", e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<NoteModel> GetById(int id)
        {
            try
            {
                NoteModel note = _noteService.GetNoteById(id);

                //Log.Information("We got the note with id {id} : {@note}", id, note);
                return StatusCode(StatusCodes.Status200OK, note);
            }
            catch (NotFoundException e)
            {
                Log.Warning("{exeptionMsg} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                Log.Error("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] NoteModel noteModel)
        {
            try
            {
                _noteService.AddNote(noteModel);
                return StatusCode(StatusCodes.Status201Created, "Note Created");
            }
            catch (NotFoundException e)
            {
                Log.Warning("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (NoteException e)
            {
                Log.Error("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception e)
            {
                Log.Warning("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] NoteModel noteModel)
        {
            try
            {
                _noteService.UpdateNote(noteModel);
                return StatusCode(StatusCodes.Status204NoContent, "Note updated");
            }
            catch (NotFoundException e)
            {
                Log.Warning("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (NoteException e)
            {
                Log.Warning("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception e)
            {
                Log.Warning("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _noteService.DeleteNote(id);
                return StatusCode(StatusCodes.Status204NoContent, "Note Deleted");
            }
            catch (NotFoundException e)
            {
                Log.Warning("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                Log.Warning("{Exception} {Source} {StackTrace}", e.Message, e.Source, e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}

