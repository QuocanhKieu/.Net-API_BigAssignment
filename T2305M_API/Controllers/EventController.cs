using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using T2305M_API.DTO.Event;
using T2305M_API.Entities;
using T2305M_API.Models;
using T2305M_API.Services;

namespace T2305M_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult> GetBasicEventDTOs([FromQuery] EventQueryParameters queryParameters)
        {
            try
            {
                var paginatedResult = await _eventService.GetBasicEventDTOsAsync(queryParameters);
                return Ok(new APIResponse<PaginatedResult<GetBasicEventDTO>>(paginatedResult, "Retrieved paginated basic Events successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse<PaginatedResult<GetBasicEventDTO>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message));
            }
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<GetDetailEventDTO>> GetDetailEventDTOById(int eventId)
        {
            try
            {
                var detailEventDTO = await _eventService.GetDetailEventDTOByIdAsync(eventId);
                if (detailEventDTO == null)
                {
                    return NotFound(new APIResponse<GetDetailEventDTO>(HttpStatusCode.NotFound, "DetailEvent not found.")); // Return 404 if not found
                }
                return Ok(detailEventDTO); // Return the DTO
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse<GetDetailEventDTO>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDTO createEventDTO)
        {
            try
            {
                var createEventResponse = await _eventService.CreateEventAsync(createEventDTO);

                if (createEventResponse.EventId > 0)
                {
                    return Ok(new APIResponse<CreateEventResponseDTO>(createEventResponse, createEventResponse.Message));
                }

                return StatusCode((int)HttpStatusCode.Conflict, new APIResponse<CreateEventResponseDTO>(
                    HttpStatusCode.Conflict, "Can not create Event due to internal problems contact the backend."));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new APIResponse<CreateEventResponseDTO>(
                    HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message));
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
}
