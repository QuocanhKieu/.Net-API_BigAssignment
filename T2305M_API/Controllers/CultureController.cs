using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2305M_API.Entities;

namespace T2305M_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultureController : ControllerBase
    {
        private readonly T2305mApiContext _context;

        public CultureController(T2305mApiContext context)
        {
            _context = context;
        }

        // GET: api/Culture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Culture>>> GetCulture()
        {
            return await _context.Culture
                                 .Include(c => c.CultureImages)
                                 .Include(c => c.CultureArticles)
                                 .Include(c => c.Creator)
                                 .ToListAsync();
        }

        // GET: api/Culture/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Culture>> GetCulture(int id)
        {
            var culture = await _context.Culture
                                        .Include(c => c.CultureImages)
                                        .Include(c => c.CultureArticles)
                                        .Include(c => c.Creator)
                                        .FirstOrDefaultAsync(c => c.CultureId == id);

            if (culture == null)
            {
                return NotFound();
            }

            return culture;
        }

        // POST: api/Culture
        [HttpPost]
        public async Task<ActionResult<Culture>> PostCulture(Culture culture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Culture.Add(culture);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCulture), new { id = culture.CultureId }, culture);
        }

        // PUT: api/Culture/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCulture(int id, Culture culture)
        {
            if (id != culture.CultureId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(culture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CultureExists(id))
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

        // DELETE: api/Culture/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCulture(int id)
        {
            var culture = await _context.Culture.FindAsync(id);
            if (culture == null)
            {
                return NotFound();
            }

            _context.Culture.Remove(culture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CultureExists(int id)
        {
            return _context.Culture.Any(e => e.CultureId == id);
        }
    }
}
