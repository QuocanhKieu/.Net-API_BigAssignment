//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using T2305M_API.Entities;

//namespace T2305M_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ArticleImageController : ControllerBase
//    {
//        private readonly T2305mApiContext _context;

//        public ArticleImageController(T2305mApiContext context)
//        {
//            _context = context;
//        }

//        // GET: api/ArticleImage
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ArticleImage>>> GetArticleImage()
//        {
//            return await _context.ArticleImage.ToListAsync();
//        }

//        // GET: api/ArticleImage/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<ArticleImage>> GetArticleImage(int id)
//        {
//            var articleImage = await _context.ArticleImage.FindAsync(id);

//            if (articleImage == null)
//            {
//                return NotFound();
//            }

//            return articleImage;
//        }

//        // POST: api/ArticleImage
//        [HttpPost]
//        public async Task<ActionResult<ArticleImage>> PostArticleImage(ArticleImage articleImage)
//        {
//            if (articleImage == null || !ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.ArticleImage.Add(articleImage);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetArticleImage", new { id = articleImage.ArticleImageId }, articleImage);
//        }

//        // PUT: api/ArticleImage/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutArticleImage(int id, ArticleImage articleImage)
//        {
//            if (id != articleImage.ArticleImageId)
//            {
//                return BadRequest();
//            }

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Entry(articleImage).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ArticleImageExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // DELETE: api/ArticleImage/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteArticleImage(int id)
//        {
//            var articleImage = await _context.ArticleImage.FindAsync(id);
//            if (articleImage == null)
//            {
//                return NotFound();
//            }

//            _context.ArticleImage.Remove(articleImage);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool ArticleImageExists(int id)
//        {
//            return _context.ArticleImage.Any(e => e.ArticleImageId == id);
//        }
//    }
//}
