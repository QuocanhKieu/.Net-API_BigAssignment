using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using T2305M_API.Models;
using T2305M_API.Services;

namespace T2305M_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchService;

        public SearchController(SearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SearchParameters parameters)
        {
            var results = await _searchService.SearchAsync(parameters);
            return Ok(results);
        }
    }
}
