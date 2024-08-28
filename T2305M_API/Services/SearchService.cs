using Microsoft.EntityFrameworkCore;
using T2305M_API.Entities;
using System.Linq;
using System.Threading.Tasks;
using T2305M_API.Models;


namespace T2305M_API.Services
{
    public class SearchService
    {
        private readonly T2305mApiContext _context;

        public SearchService(T2305mApiContext context)
        {
            _context = context;
        }

        public async Task<object> SearchAsync(SearchParameters parameters)
        {
            // Queries for each entity type
            IQueryable<NationalEvent> nationalEvents = _context.NationalEvent.Include(ne => ne.Creator);
            IQueryable<Artifact> artifacts = _context.Artifact.Include(a => a.Creator);
            IQueryable<Culture> cultures = _context.Culture.Include(c => c.Creator);
            IQueryable<Exhibition> exhibitions = _context.Exhibition.Include(e => e.Creator);
            //IQueryable<Article> articles = _context.Article.Include(a => a.Creator);

            // Apply query filter
            if (!string.IsNullOrEmpty(parameters.Query))
            {
                var query = parameters.Query.ToLower();

                nationalEvents = nationalEvents.Where(ne => ne.Title.ToLower().Contains(query) ||
                                                           ne.Content.ToLower().Contains(query) ||
                                                           ne.Description.ToLower().Contains(query) ||
                                                           ne.Creator.Name.ToLower().Contains(query));

                artifacts = artifacts.Where(a => a.Title.ToLower().Contains(query) ||
                                                  a.Description.ToLower().Contains(query) ||
                                                  a.Creator.Name.ToLower().Contains(query));

                cultures = cultures.Where(c => c.Title.ToLower().Contains(query) ||
                                                c.Content.ToLower().Contains(query) ||
                                                c.Description.ToLower().Contains(query) ||
                                                c.Creator.Name.ToLower().Contains(query));

                exhibitions = exhibitions.Where(e => e.Title.ToLower().Contains(query) ||
                                                     e.Description.ToLower().Contains(query) ||
                                                     e.Creator.Name.ToLower().Contains(query));

            }

            // Apply date range filter
            if (parameters.StartDate.HasValue)
            {
                nationalEvents = nationalEvents.Where(ne => ne.StartDate >= parameters.StartDate.Value);
                artifacts = artifacts.Where(a => a.CreatedAt >= parameters.StartDate.Value);
                cultures = cultures.Where(c => c.CreatedAt >= parameters.StartDate.Value);
                exhibitions = exhibitions.Where(e => e.StartDate >= parameters.StartDate.Value);
            }

            if (parameters.EndDate.HasValue)
            {
                nationalEvents = nationalEvents.Where(ne => ne.EndDate <= parameters.EndDate.Value);
                artifacts = artifacts.Where(a => a.CreatedAt <= parameters.EndDate.Value);
                cultures = cultures.Where(c => c.CreatedAt <= parameters.EndDate.Value);
                exhibitions = exhibitions.Where(e => e.EndDate <= parameters.EndDate.Value);
            }

            // Apply sorting
            if (parameters.Sort == "newest")
            {
                nationalEvents = nationalEvents.OrderByDescending(ne => ne.StartDate);
                artifacts = artifacts.OrderByDescending(a => a.CreatedAt);
                cultures = cultures.OrderByDescending(c => c.CreatedAt);
                exhibitions = exhibitions.OrderByDescending(e => e.StartDate);
            }
            else if (parameters.Sort == "latest")
            {
                nationalEvents = nationalEvents.OrderBy(ne => ne.StartDate);
                artifacts = artifacts.OrderBy(a => a.CreatedAt);
                cultures = cultures.OrderBy(c => c.CreatedAt);
                exhibitions = exhibitions.OrderBy(e => e.StartDate);
                //articles = articles.OrderBy(a => a.CreatedAt);
            }

            // Apply section filtering
            object searchResults = new { };
            switch (parameters.Sections?.ToLower())
            {
                case "article":
                    searchResults = new
                    {
                        //Articles = await articles.ToListAsync()
                    };
                    break;
              
                case "culture":
                    searchResults = new
                    {
                        Cultures = await cultures.ToListAsync()
                    };
                    break;
                case "artifact":
                    searchResults = new
                    {
                        Artifacts = await artifacts.ToListAsync()
                    };
                    break;
                case "exhibition":
                    searchResults = new
                    {
                        Exhibitions = await exhibitions.ToListAsync()
                    };
                    break;
                case "all":
                default:
                    searchResults = new
                    {
                      
                        NationalEvents = await nationalEvents.ToListAsync(),
                        Artifacts = await artifacts.ToListAsync(),
                        Cultures = await cultures.ToListAsync(),
                        Exhibitions = await exhibitions.ToListAsync(),
                        
                        //Articles = await articles.ToListAsync()
                    };
                    break;
            }

            return searchResults;
        }
    }
}

