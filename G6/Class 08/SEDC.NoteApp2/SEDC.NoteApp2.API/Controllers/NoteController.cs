﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NoteApp2.Dto.Models;
using SEDC.NoteApp2.Services.Interfaces;
using System.Collections.Generic;

namespace SEDC.NoteApp2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("")]
        public ActionResult<List<NoteDto>> GetAllNotes()
        {
            List<NoteDto> notes = _noteService.GetAllNotes();
            return StatusCode(StatusCodes.Status200OK, notes);
        }

        [HttpGet("user/{id}")]
        public ActionResult<List<NoteDto>> GetNoteUserById(int id)
        {
            List<NoteDto> note = _noteService.GetAllNotesByUserId(id);
            return StatusCode(StatusCodes.Status200OK, note);
        }

        [HttpGet("{id}")]
        public ActionResult<List<NoteDto>> GetNoteById(int id)
        {
            NoteDto note = _noteService.GetNoteById(id);
            return StatusCode(StatusCodes.Status200OK, note);
        }

        [HttpPost("")]
        public ActionResult AddNote(NoteDto noteDto)
        {
            _noteService.AddNote(noteDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("update")]
        public ActionResult UpdateNote(NoteDto noteDto)
        {
            _noteService.UpdateNote(noteDto);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpDelete("{id}/delete")]
        public ActionResult DeleteNote(int id)
        {
            _noteService.DeleteNote(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
