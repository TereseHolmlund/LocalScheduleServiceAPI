using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalScheduleServiceAPI.Models;

namespace LocalScheduleServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalBookingsController : ControllerBase
    {
        private readonly LocalContext _context;

        public LocalBookingsController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/LocalBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalBooking>>> GetLocalBookings()
        {
            return await _context.LocalBookings.ToListAsync();
        }

        // GET: api/LocalBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocalBooking>> GetLocalBooking(int id)
        {
            var localBooking = await _context.LocalBookings.FindAsync(id);

            if (localBooking == null)
            {
                return NotFound();
            }

            return localBooking;
        }

        // PUT: api/LocalBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalBooking(int id, LocalBooking localBooking)
        {
            if (id != localBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(localBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalBookingExists(id))
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

        // POST: api/LocalBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocalBooking>> PostLocalBooking(LocalBooking localBooking)
        {
            _context.LocalBookings.Add(localBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalBooking", new { id = localBooking.Id }, localBooking);
        }

        // DELETE: api/LocalBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalBooking(int id)
        {
            var localBooking = await _context.LocalBookings.FindAsync(id);
            if (localBooking == null)
            {
                return NotFound();
            }

            _context.LocalBookings.Remove(localBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocalBookingExists(int id)
        {
            return _context.LocalBookings.Any(e => e.Id == id);
        }
    }
}
