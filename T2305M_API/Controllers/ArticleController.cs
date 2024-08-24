//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using T2305M_API.Entities;

//namespace T2305M_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ArticleController : ControllerBase
//    {
//        private readonly T2305mApiContext _context;

//        public ArticleController(T2305mApiContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Article
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Article>>> GetArticle()
//        {
//            return await _context.Article
//                                 .Include(a => a.Creator)
//                                 .Include(a => a.ArticleImages)
//                                 .ToListAsync();
//        }

//        // GET: api/Article/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Article>> GetArticle(int id)
//        {
//            var article = await _context.Article
//                                        .Include(a => a.Creator)
//                                        .Include(a => a.ArticleImages)
//                                        .FirstOrDefaultAsync(a => a.ArticleId == id);

//            if (article == null)
//            {
//                return NotFound();
//            }

//            return article;
//        }

//        // POST: api/Article
//        [HttpPost]
//        public async Task<ActionResult<Article>> PostArticle(Article article)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Article.Add(article);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetArticle), new { id = article.ArticleId }, article);
//        }

//        // PUT: api/Article/{id}
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutArticle(int id, Article article)
//        {
//            if (id != article.ArticleId)
//            {
//                return BadRequest("ID mismatch");
//            }

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Entry(article).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ArticleExists(id))
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

//        // DELETE: api/Article/{id}
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteArticle(int id)
//        {
//            var article = await _context.Article.FindAsync(id);
//            if (article == null)
//            {
//                return NotFound();
//            }

//            _context.Article.Remove(article);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool ArticleExists(int id)
//        {
//            return _context.Article.Any(e => e.ArticleId == id);
//        }
//    }
//}
