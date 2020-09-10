using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Models;

namespace Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private NotesContext _context;

        public NotesController(NotesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> Get()
        {
            return await _context.Notes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> Get(int id)
        {
            Note note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);
            if (note == null)
                return NotFound();
            return new ObjectResult(note);
        }
        
        [HttpGet("s/{searchString}")]
        public async Task<ActionResult<IEnumerable<Note>>> Get(string searchString)
        {
            var notes = _context.Notes.Where(note => note.Content.ToLower().Contains(searchString.ToLower()));
            if (!notes.Any())
                return NotFound();
            return await notes.ToListAsync();
        }
 
        [HttpPost]
        public async Task<ActionResult<Note>> Post(Note note)
        {
            if (note == null)
            {
                return BadRequest();
            }
 
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return Ok(note);
        }
 
        [HttpPut]
        public async Task<ActionResult<Note>> Put(Note note)
        {
            if (note == null)
            {
                return BadRequest();
            }
            if (!_context.Notes.Any(x => x.Id ==note.Id))
            {
                return NotFound();
            }
 
            _context.Update(note);
            await _context.SaveChangesAsync();
            return Ok(note);
        }
 
        [HttpDelete("{id}")]
        public async Task<ActionResult<Note>> Delete(int id)
        {
            Note note = _context.Notes.FirstOrDefault(x => x.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return Ok(note);
        }
    }
}
