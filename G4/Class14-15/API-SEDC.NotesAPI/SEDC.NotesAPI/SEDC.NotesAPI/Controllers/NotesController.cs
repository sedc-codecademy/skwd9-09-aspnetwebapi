using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesAPI.Models.Notes;
using SEDC.NotesAPI.Services.Interfaces;
using SEDC.NotesAPI.Shared.Exceptions;
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
                return StatusCode(StatusCodes.Status200OK, _noteService.GetAllNotes());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<NoteModel> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _noteService.GetNoteById(id));
            }
            catch (NotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddNoteModel noteModel)
        {
            try
            {
                _noteService.AddNote(noteModel);
                return StatusCode(StatusCodes.Status201Created, "Note Created");
            }
            catch (NotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (NoteException e)
            {
                //log
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                //log
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
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (NoteException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception ex)
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}

