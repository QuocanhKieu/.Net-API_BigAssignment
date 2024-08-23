using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2305M_API.Entities;

namespace T2305M_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtifactController : ControllerBase
    {
        private readonly T2305mApiContext _context;

        public ArtifactController(T2305mApiContext context)
        {
            _context = context;
        }

        // GET: api/Artifact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artifact>>> GetArtifact()
        {
            return await _context.Artifact
                                 .Include(a => a.ArtifactImages)
                                 .Include(a => a.ArtifactArticles)
                                 .ToListAsync();
        }

        // GET: api/Artifact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artifact>> GetArtifact(int id)
        {
            var artifact = await _context.Artifact
                                         .Include(a => a.ArtifactImages)
                                         .Include(a => a.ArtifactArticles)
                                         .FirstOrDefaultAsync(a => a.ArtifactId == id);

            if (artifact == null)
            {
                return NotFound();
            }

            return artifact;
        }

        // POST: api/Artifact
        [HttpPost]
        public async Task<ActionResult<Artifact>> PostArtifact(Artifact artifact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Artifact.Add(artifact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArtifact), new { id = artifact.ArtifactId }, artifact);
        }

        // PUT: api/Artifact/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtifact(int id, Artifact artifact)
        {
            if (id != artifact.ArtifactId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(artifact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtifactExists(id))
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

        // DELETE: api/Artifact/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtifact(int id)
        {
            var artifact = await _context.Artifact.FindAsync(id);
            if (artifact == null)
            {
                return NotFound();
            }

            _context.Artifact.Remove(artifact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtifactExists(int id)
        {
            return _context.Artifact.Any(e => e.ArtifactId == id);
        }
    }
}
