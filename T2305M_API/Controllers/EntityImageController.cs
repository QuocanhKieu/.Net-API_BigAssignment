using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2305M_API.Entities;

namespace T2305M_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityImageController : ControllerBase
    {
        private readonly T2305mApiContext _context;

        public EntityImageController(T2305mApiContext context)
        {
            _context = context;
        }

        // GET: api/EntityImage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityImage>>> GetEntityImage()
        {
            return await _context.EntityImage
                                 .Include(e => e.Art)
                                 .Include(e => e.Book)
                                 .Include(e => e.Exhibition)
                                 .Include(e => e.Culture)
                                 .Include(e => e.Artifact)
                                 .Include(e => e.NationalEvent)
                                 .ToListAsync();
        }

        // GET: api/EntityImage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityImage>> GetEntityImage(int id)
        {
            var entityImage = await _context.EntityImage
                                            .Include(e => e.Art)
                                            .Include(e => e.Book)
                                            .Include(e => e.Exhibition)
                                            .Include(e => e.Culture)
                                            .Include(e => e.Artifact)
                                            .Include(e => e.NationalEvent)
                                            .FirstOrDefaultAsync(e => e.EntityImageId == id);

            if (entityImage == null)
            {
                return NotFound();
            }

            return entityImage;
        }

        // POST: api/EntityImage
        [HttpPost]
        public async Task<ActionResult<EntityImage>> PostEntityImage(EntityImage entityImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EntityImage.Add(entityImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEntityImage), new { id = entityImage.EntityImageId }, entityImage);
        }

        // PUT: api/EntityImage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityImage(int id, EntityImage entityImage)
        {
            if (id != entityImage.EntityImageId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(entityImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityImageExists(id))
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

        // DELETE: api/EntityImage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityImage(int id)
        {
            var entityImage = await _context.EntityImage.FindAsync(id);
            if (entityImage == null)
            {
                return NotFound();
            }

            _context.EntityImage.Remove(entityImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntityImageExists(int id)
        {
            return _context.EntityImage.Any(e => e.EntityImageId == id);
        }
    }
}
