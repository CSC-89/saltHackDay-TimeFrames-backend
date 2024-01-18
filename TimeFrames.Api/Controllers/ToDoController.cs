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

        // GET: api/ToDo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDo()
        {
          if (_context.ToDo == null)
          {
              return NotFound();
          }
            return await _context.ToDo.ToListAsync();
        }

        // GET: api/ToDo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetToDo(int id)
        {
          if (_context.ToDo == null)
          {
              return NotFound();
          }
            var toDo = await _context.ToDo.FindAsync(id);

            if (toDo == null)
            {
                return NotFound();
            }

            return toDo;
        }

        // PUT: api/ToDo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDo(int id, ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // DELETE: api/ToDo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            if (_context.ToDo == null)
            {
                return NotFound();
            }
            var toDo = await _context.ToDo.FindAsync(id);
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
