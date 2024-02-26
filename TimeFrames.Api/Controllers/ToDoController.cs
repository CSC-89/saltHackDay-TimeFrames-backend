using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeFrames.Api.Models;

namespace TimeFrames.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly TimeFrameContext _context;

        public ToDoController(TimeFrameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDo()
        {
            if (_context.ToDo == null)
            {
                return NotFound();
            }

            return await _context.ToDo.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> PostToDo(ToDo toDo)
        {
            if (_context.ToDo == null)
            {
                return Problem("Entity set 'TimeFrameContext.ToDo'  is null.");
            }

            _context.ToDo.Add(toDo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDo", new { id = toDo.Id }, toDo);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            if (!ToDoExists(id))
            {
                return NotFound();
            }

            var toDo = await _context.ToDo!.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            _context.ToDo.Remove(toDo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoExists(int id)
        {
            return (_context.ToDo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}