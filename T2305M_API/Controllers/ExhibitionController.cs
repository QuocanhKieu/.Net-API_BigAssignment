using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2305M_API;
using T2305M_API.Entities;

namespace T2305M_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExhibitionController : ControllerBase
    {
        private readonly T2305mApiContext _context;

        public ExhibitionController(T2305mApiContext context)
        {
            _context = context;
        }

        // GET: api/Exhibition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exhibition>>> GetExhibition()
        {
            return await _context.Exhibition.ToListAsync();
        }

        // GET: api/Exhibition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exhibition>> GetExhibition(int id)
        {
            var exhibition = await _context.Exhibition.FindAsync(id);

            if (exhibition == null)
            {
                return NotFound();
            }

            return exhibition;
        }

        // POST: api/Exhibition
        [HttpPost]
        public async Task<ActionResult<Exhibition>> PostExhibition(Exhibition exhibition)
        {
            _context.Exhibition.Add(exhibition);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExhibition), new { id = exhibition.ExhibitionId }, exhibition);
        }

        // PUT: api/Exhibition/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExhibition(int id, Exhibition exhibition)
        {
            if (id != exhibition.ExhibitionId)
            {
                return BadRequest();
            }

            _context.Entry(exhibition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExhibitionExists(id))
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

        // DELETE: api/Exhibition/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExhibition(int id)
        {
            var exhibition = await _context.Exhibition.FindAsync(id);
            if (exhibition == null)
            {
                return NotFound();
            }

            _context.Exhibition.Remove(exhibition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExhibitionExists(int id)
        {
            return _context.Exhibition.Any(e => e.ExhibitionId == id);
        }
    }
}
