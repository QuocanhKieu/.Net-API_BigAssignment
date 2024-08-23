using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2305M_API;
using T2305M_API.Entities;

namespace T2305M_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalEventController : ControllerBase
    {
        private readonly T2305mApiContext _context;

        public NationalEventController(T2305mApiContext context)
        {
            _context = context;
        }

        // GET: api/NationalEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NationalEvent>>> GetNationalEvent()
        {
            return await _context.NationalEvent.ToListAsync();
        }

        // GET: api/NationalEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NationalEvent>> GetNationalEvent(int id)
        {
            var nationalEvent = await _context.NationalEvent.FindAsync(id);

            if (nationalEvent == null)
            {
                return NotFound();
            }

            return nationalEvent;
        }

        // POST: api/NationalEvent
        [HttpPost]
        public async Task<ActionResult<NationalEvent>> PostNationalEvent(NationalEvent nationalEvent)
        {
            _context.NationalEvent.Add(nationalEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNationalEvent), new { id = nationalEvent.NationalEventID }, nationalEvent);
        }

        // PUT: api/NationalEvent/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNationalEvent(int id, NationalEvent nationalEvent)
        {
            if (id != nationalEvent.NationalEventID)
            {
                return BadRequest();
            }

            _context.Entry(nationalEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalEventExists(id))
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

        // DELETE: api/NationalEvent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNationalEvent(int id)
        {
            var nationalEvent = await _context.NationalEvent.FindAsync(id);
            if (nationalEvent == null)
            {
                return NotFound();
            }

            _context.NationalEvent.Remove(nationalEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NationalEventExists(int id)
        {
            return _context.NationalEvent.Any(e => e.NationalEventID == id);
        }
    }
}
