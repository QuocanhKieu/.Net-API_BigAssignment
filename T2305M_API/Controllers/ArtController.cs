using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2305M_API.Entities;

namespace T2305M_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtController : ControllerBase
    {
        private readonly T2305mApiContext _context;

        public ArtController(T2305mApiContext context)
        {
            _context = context;
        }

        // GET: api/Art
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Art>>> GetArt()
        {
            return Ok(await _context.Art.ToListAsync());
        }

        // GET: api/Art/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Art>> GetArt(int id)
        {
            var art = await _context.Art.FindAsync(id);

            if (art == null)
            {
                return NotFound();
            }

            return Ok(art);
        }

        // POST: api/Art
        [HttpPost]
        public async Task<ActionResult<Art>> PostArt(Art art)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Art.Add(art);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArt), new { id = art.ArtId }, art);
        }

        // PUT: api/Art/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArt(int id, Art art)
        {
            if (id != art.ArtId)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(art).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtExists(id))
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

        // DELETE: api/Art/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArt(int id)
        {
            var art = await _context.Art.FindAsync(id);
            if (art == null)
            {
                return NotFound();
            }

            _context.Art.Remove(art);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtExists(int id)
        {
            return _context.Art.Any(e => e.ArtId == id);
        }
    }
}
