using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Domain;
using NotesApp.Services.Implementations;
using NotesApp.Services.Interfaces;

namespace SEDC.NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INoteService _noteService;
        public NotesController()
        {
            _noteService = new NoteService();
        }

        [HttpGet]
        public ActionResult<List<NoteModel>> Get()
        {
            return _noteService.GetAllNotes();
        }

        [HttpGet("{id}")]
        public ActionResult<NoteModel> Get(int id)
        {
            return _noteService.GetNoteById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NoteModel note)
        {
            _noteService.AddNote(note);
            return StatusCode(StatusCodes.Status201Created, "Note created!");
        }

        [HttpPut]
        public IActionResult Put([FromBody] NoteModel note)
        {
            _noteService.UpdateNote(note);
            return StatusCode(StatusCodes.Status204NoContent, "Note updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.DeleteNote(id);
            return StatusCode(StatusCodes.Status204NoContent, "Note deleted!");
        }
    }
}
