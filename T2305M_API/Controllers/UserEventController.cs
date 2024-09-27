using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using T2305M_API.DTO.UserEvent;
using T2305M_API.Entities;
using T2305M_API.Models;
using T2305M_API.Repositories;
using T2305M_API.Services;

namespace T2305M_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUserEventController : ControllerBase
    {
        private readonly IUserEventRepository _iUserEventRepository;

        public UserUserEventController(IUserEventRepository iUserEventRepository)
        {
            _iUserEventRepository = iUserEventRepository;
        }

        // POST: api/UserUserEvents/bookmark
        [HttpPost("bookmark")]
        public async Task<IActionResult> BookmarkUserEvent([FromBody] BookmarkDTO bookmarkDTO)
        {
            try
            {
                var bookmarkResponseDTO = await _iUserEventRepository.CreateBookmark(bookmarkDTO);

                if (bookmarkResponseDTO.UserId > 0)
                {
                    return Ok(new APIResponse<BookmarkResponseDTO>(bookmarkResponseDTO, bookmarkResponseDTO.Message));
                }

                return StatusCode((int)HttpStatusCode.Conflict, new APIResponse<BookmarkResponseDTO>(
                    HttpStatusCode.Conflict, "Can not create UserEvent due to internal problems contact the backend."));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new APIResponse<BookmarkResponseDTO>(
                    HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message));
            }
        }




        // DELETE: api/UserUserEvents/unbookmark
        [HttpDelete("unbookmark")]
        public async Task<IActionResult> UnbookmarkUserEvent([FromBody] BookmarkDTO bookmarkDTO)
        {
            {
                try
                {
                    var bookmarkResponseDTO = await _iUserEventRepository.RemoveBookmark(bookmarkDTO);

                    if (bookmarkResponseDTO.UserId > 0)
                    {
                        return Ok(new APIResponse<BookmarkResponseDTO>(bookmarkResponseDTO, bookmarkResponseDTO.Message));
                    }

                    return StatusCode((int)HttpStatusCode.Conflict, new APIResponse<BookmarkResponseDTO>(
                        HttpStatusCode.Conflict, "Can not delete UserEvent due to internal problems contact the backend."));
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, new APIResponse<BookmarkResponseDTO>(
                        HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message));
                }
            }
        }
    }

    //// PUT: api/Article/{id}
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutArticle(int id, Article article)
    //{
    //    if (id != article.ArticleId)
    //    {
    //        return BadRequest("ID mismatch");
    //    }

    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    _context.Entry(article).State = EntityState.Modified;

    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!ArticleExists(id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return NoContent();
    //}

    //// DELETE: api/Article/{id}
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteArticle(int id)
    //{
    //    var article = await _context.Article.FindAsync(id);
    //    if (article == null)
    //    {
    //        return NotFound();
    //    }

    //    _context.Article.Remove(article);
    //    await _context.SaveChangesAsync();

    //    return NoContent();
    //}

    //private bool ArticleExists(int id)
    //{
    //    return _context.Article.Any(e => e.ArticleId == id);
    //}
}

