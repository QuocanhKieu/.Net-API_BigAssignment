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
            IQueryable<Art> arts = _context.Art.Include(a => a.Creator);
            IQueryable<NationalEvent> nationalEvents = _context.NationalEvent.Include(ne => ne.Creator);
            IQueryable<Artifact> artifacts = _context.Artifact.Include(a => a.Creator);
            IQueryable<Culture> cultures = _context.Culture.Include(c => c.Creator);
            IQueryable<Exhibition> exhibitions = _context.Exhibition.Include(e => e.Creator);
            IQueryable<Book> books = _context.Book.Include(b => b.Creator);
            //IQueryable<Article> articles = _context.Article.Include(a => a.Creator);

            // Apply query filter
            if (!string.IsNullOrEmpty(parameters.Query))
            {
                var query = parameters.Query.ToLower();

                arts = arts.Where(a => a.Title.ToLower().Contains(query) ||
                                       a.Content.ToLower().Contains(query) ||
                                       a.Description.ToLower().Contains(query) ||
                                       a.Creator.Name.ToLower().Contains(query));

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

                books = books.Where(b => b.Title.ToLower().Contains(query) ||
                                          b.Description.ToLower().Contains(query) ||
                                          b.Creator.Name.ToLower().Contains(query));

                //articles = articles.Where(a => a.Title.ToLower().Contains(query) ||
                //                                a.Content.ToLower().Contains(query) ||
                //                                a.Description.ToLower().Contains(query) ||
                //                                a.Creator.Name.ToLower().Contains(query));
            }

            // Apply date range filter
            if (parameters.StartDate.HasValue)
            {
                arts = arts.Where(a => a.CreatedAt >= parameters.StartDate.Value);
                nationalEvents = nationalEvents.Where(ne => ne.StartDate >= parameters.StartDate.Value);
                artifacts = artifacts.Where(a => a.CreatedAt >= parameters.StartDate.Value);
                cultures = cultures.Where(c => c.CreatedAt >= parameters.StartDate.Value);
                exhibitions = exhibitions.Where(e => e.StartDate >= parameters.StartDate.Value);
                books = books.Where(b => b.CreatedAt >= parameters.StartDate.Value);
                //articles = articles.Where(a => a.CreatedAt >= parameters.StartDate.Value);
            }

            if (parameters.EndDate.HasValue)
            {
                arts = arts.Where(a => a.CreatedAt <= parameters.EndDate.Value);
                nationalEvents = nationalEvents.Where(ne => ne.EndDate <= parameters.EndDate.Value);
                artifacts = artifacts.Where(a => a.CreatedAt <= parameters.EndDate.Value);
                cultures = cultures.Where(c => c.CreatedAt <= parameters.EndDate.Value);
                exhibitions = exhibitions.Where(e => e.EndDate <= parameters.EndDate.Value);
                books = books.Where(b => b.CreatedAt <= parameters.EndDate.Value);
                //articles = articles.Where(a => a.CreatedAt <= parameters.EndDate.Value);
            }

            // Apply sorting
            if (parameters.Sort == "newest")
            {
                arts = arts.OrderByDescending(a => a.CreatedAt);
                nationalEvents = nationalEvents.OrderByDescending(ne => ne.StartDate);
                artifacts = artifacts.OrderByDescending(a => a.CreatedAt);
                cultures = cultures.OrderByDescending(c => c.CreatedAt);
                exhibitions = exhibitions.OrderByDescending(e => e.StartDate);
                books = books.OrderByDescending(b => b.CreatedAt);
                //articles = articles.OrderByDescending(a => a.CreatedAt);
            }
            else if (parameters.Sort == "latest")
            {
                arts = arts.OrderBy(a => a.CreatedAt);
                nationalEvents = nationalEvents.OrderBy(ne => ne.StartDate);
                artifacts = artifacts.OrderBy(a => a.CreatedAt);
                cultures = cultures.OrderBy(c => c.CreatedAt);
                exhibitions = exhibitions.OrderBy(e => e.StartDate);
                books = books.OrderBy(b => b.CreatedAt);
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
                case "art":
                    searchResults = new
                    {
                        Arts = await arts.ToListAsync()
                    };
                    break;
                case "book":
                    searchResults = new
                    {
                        Books = await books.ToListAsync()
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
                        Arts = await arts.ToListAsync(),
                        NationalEvents = await nationalEvents.ToListAsync(),
                        Artifacts = await artifacts.ToListAsync(),
                        Cultures = await cultures.ToListAsync(),
                        Exhibitions = await exhibitions.ToListAsync(),
                        Books = await books.ToListAsync(),
                        //Articles = await articles.ToListAsync()
                    };
                    break;
            }

            return searchResults;
        }
    }
}

