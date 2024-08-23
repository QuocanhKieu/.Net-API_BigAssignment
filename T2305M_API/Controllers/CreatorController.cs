using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2305M_API.Entities;

namespace T2305M_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorController : ControllerBase
    {
        private readonly T2305mApiContext _context;

        public CreatorController(T2305mApiContext context)
        {
            _context = context;
        }

        // GET: api/Creator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Creator>>> GetCreator()
        {
            return await _context.Creator
                                 .Include(c => c.Arts)
                                 .Include(c => c.Cultures)
                                 .Include(c => c.Books)
                                 .Include(c => c.Artifacts)
                                 .Include(c => c.NationalEvents)
                                 .Include(c => c.Exhibitions)
                                 .Include(c => c.Articles)
                                 .ToListAsync();
        }

        // GET: api/Creator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Creator>> GetCreator(int id)
        {
            var creator = await _context.Creator
                                        .Include(c => c.Arts)
                                        .Include(c => c.Cultures)
                                        .Include(c => c.Books)
                                        .Include(c => c.Artifacts)
                                        .Include(c => c.NationalEvents)
                                        .Include(c => c.Exhibitions)
                                        .Include(c => c.Articles)
                                        .FirstOrDefaultAsync(c => c.CreatorId == id);

            if (creator == null)
            {
                return NotFound();
            }

            return creator;
        }

        // POST: api/Creator
        [HttpPost]
        public async Task<ActionResult<Creator>> PostCreator(Creator creator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Creator.Add(creator);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCreator), new { id = creator.CreatorId }, creator);
        }

        // PUT: api/Creator/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreator(int id, Creator creator)
        {
            if (id != creator.CreatorId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(creator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreatorExists(id))
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

        // DELETE: api/Creator/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreator(int id)
        {
            var creator = await _context.Creator.FindAsync(id);
            if (creator == null)
            {
                return NotFound();
            }

            _context.Creator.Remove(creator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreatorExists(int id)
        {
            return _context.Creator.Any(e => e.CreatorId == id);
        }
    }
}
