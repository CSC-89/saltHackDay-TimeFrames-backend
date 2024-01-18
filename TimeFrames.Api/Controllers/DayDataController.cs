using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeFrames.Api.Models;

namespace TimeFrames.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayDataController : ControllerBase
    {
        private readonly TimeFrameContext _context;

        public DayDataController(TimeFrameContext context)
        {
            _context = context;
        }

        // GET: api/DayData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayData>>> GetDayData()
        {
          if (_context.DayData == null)
          {
              return NotFound();
          }
            return await _context.DayData.ToListAsync();
        }

        // GET: api/DayData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayData>> GetDayData(int id)
        {
          if (_context.DayData == null)
          {
              return NotFound();
          }
            var dayData = await _context.DayData.FindAsync(id);

            if (dayData == null)
            {
                return NotFound();
            }

            return dayData;
        }

        // PUT: api/DayData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayData(int id, DayData dayData)
        {
            if (id != dayData.Id)
            {
                return BadRequest();
            }

            _context.Entry(dayData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayDataExists(id))
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

        // POST: api/DayData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayData>> PostDayData(DayData dayData)
        {
          if (_context.DayData == null)
          {
              return Problem("Entity set 'TimeFrameContext.DayData'  is null.");
          }
            _context.DayData.Add(dayData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayData", new { id = dayData.Id }, dayData);
        }

        // DELETE: api/DayData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayData(int id)
        {
            if (_context.DayData == null)
            {
                return NotFound();
            }
            var dayData = await _context.DayData.FindAsync(id);
            if (dayData == null)
            {
                return NotFound();
            }

            _context.DayData.Remove(dayData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayDataExists(int id)
        {
            return (_context.DayData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
