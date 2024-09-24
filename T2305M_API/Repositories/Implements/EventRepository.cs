using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using T2305M_API.DTO.Event;
using T2305M_API.Entities;
using T2305M_API.Repositories;

public class EventRepository : IEventRepository
{
    private readonly T2305mApiContext _context;
    private readonly IWebHostEnvironment _env;

    public EventRepository(T2305mApiContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public async Task<(IEnumerable<Event> Data, int TotalItems)> GetEventsAsync(EventQueryParameters queryParameters)
    {
        IQueryable<Event> query = _context.Event;

        // Apply filters
        if (!string.IsNullOrEmpty(queryParameters.Country))
        {
            query = query.Where(a => a.Country == queryParameters.Country);
        }

        if (!string.IsNullOrEmpty(queryParameters.Continent))
        {
            query = query.Where(a => a.Continent == queryParameters.Continent);
        }

        if (queryParameters.IsHostOnline)
        {
            query = query.Where(a => a.IsHostOnline);
        }

        if (queryParameters.isToday)
        {
            var today = DateTime.Today;
            query = query.Where(e => e.StartDate.Date == today);
        }

        if (queryParameters.isThisWeek)
        {
            var today = DateTime.Today;
            // Calculate the start and end of the current week (assuming week starts on Monday and ends on Sunday)
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
            var endOfWeek = startOfWeek.AddDays(6);  // End of the week is Sunday
            // Filter events that have StartDate from today onwards, within this week
            query = query.Where(e => e.StartDate.Date >= today && e.StartDate.Date <= endOfWeek);
        }

        if (queryParameters.isNextWeek)
        {
            var today = DateTime.Today;
            // Calculate the start and end of next week (assuming week starts on Monday and ends on Sunday)
            var startOfNextWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday + 7);
            var endOfNextWeek = startOfNextWeek.AddDays(6);  // End of next week is the upcoming Sunday
            // Filter events with StartDate within the next week
            query = query.Where(e => e.StartDate.Date >= startOfNextWeek && e.StartDate.Date <= endOfNextWeek);
        }

        if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
        {
            query = query.Where(a =>
                a.Title.Contains(queryParameters.SearchTerm) ||
                a.Description.Contains(queryParameters.SearchTerm) ||
                a.Organizer.Contains(queryParameters.SearchTerm) ||
                a.Creator.Name.Contains(queryParameters.SearchTerm) ||
                a.Location.Contains(queryParameters.SearchTerm) ||
                a.Address.Contains(queryParameters.SearchTerm) ||
                a.Country.Contains(queryParameters.SearchTerm) ||
                a.Continent.Contains(queryParameters.SearchTerm));
        }

        // Apply sorting
        if (!string.IsNullOrEmpty(queryParameters.SortColumn))
        {
            bool isDescending = queryParameters.SortOrder?.ToLower() == "desc";
            switch (queryParameters.SortColumn.ToLower())
            {
                case "title":
                    query = isDescending ? query.OrderByDescending(a => a.Title) : query.OrderBy(a => a.Title);
                    break;
                case "price":
                    query = isDescending ? query.OrderByDescending(a => a.TicketPrice) : query.OrderBy(a => a.TicketPrice);
                    break;
                default:
                    query = isDescending ? query.OrderByDescending(a => a.StartDate) : query.OrderBy(a => a.StartDate);
                    break;
            }
        }

        // Pagination
        int totalItems = await query.CountAsync();
        var pagedData = await query
            .Skip((queryParameters.Page - 1) * queryParameters.PageSize)
            .Take(queryParameters.PageSize)
            .ToListAsync();

        return (pagedData, totalItems);
    }
    private bool FileContainsSearchTerm(string fileName, string searchTerm)
    {
        if(fileName.IsNullOrEmpty()) return false;
        var filePath = Path.Combine(_env.WebRootPath, "content/Event", fileName);

        if (System.IO.File.Exists(filePath))
        {
            try
            {
                var htmlContent = System.IO.File.ReadAllText(filePath);
                return htmlContent.Contains(searchTerm, StringComparison.OrdinalIgnoreCase); // Case-insensitive search
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                Console.WriteLine($"Error reading file: {ex.Message}");
                return false;
            }
        }

        return false; // If file doesn't exist or couldn't be read, return false
    }

    public async Task<Event> GetEventByIdAsync(int eventId)
    {
        return await _context.Event
            .FirstOrDefaultAsync(aa => aa.EventId == eventId);
    }
    public async Task<CreateEventResponseDTO> CreateEventAsync(CreateEventDTO createEventDTO)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var newEvent = new Event
                {
                    Title = createEventDTO.Title,
                    Continent = createEventDTO.Continent,
                    Country = createEventDTO.Country,
                    Description = createEventDTO.Description,
                    ThumbnailImage = createEventDTO.ThumbnailImage,
                    FileName = createEventDTO.FileName + ".html",
                    CreatorId = createEventDTO.CreatorId,
                    IsPromoted = createEventDTO.IsPromoted,
                    IsHostOnline = createEventDTO.IsHostOnline,
                    Organizer = createEventDTO.Organizer,
                    Address = createEventDTO.Address,
                    CreatedAt = DateTime.Now,
                    CurrentAttendees = createEventDTO.CurrentAttendees,
                    EndDate = createEventDTO.EndDate,
                    EndTime = createEventDTO.EndTime,
                    IsCanceled = createEventDTO.IsCanceled,
                    Location = createEventDTO.Location,
                    MaxAttendees = createEventDTO.MaxAttendees,
                    SaleDueDate = createEventDTO.SaleDueDate,
                    IsActive = true,
                    StartDate = createEventDTO.StartDate,
                    StartTime = createEventDTO.StartTime,
                    TicketPrice = createEventDTO.TicketPrice,
                    TimeZone = createEventDTO.TimeZone,
                    WebsiteUrl = createEventDTO.WebsiteUrl,
                };

                _context.Event.Add(newEvent);
                await _context.SaveChangesAsync();

                // Commit the transaction if all is successful
                await transaction.CommitAsync();

                // Return the response DTO with the new OrderId

                return new CreateEventResponseDTO
                {
                    EventId = newEvent.EventId,
                    IsActive = newEvent.IsActive,
                    Message = "Event created successfully"
                };
            }
            catch (DbUpdateException dbEx) // Catch database-specific errors
            {
                await transaction.RollbackAsync(); // Rollback the transaction
                return new CreateEventResponseDTO
                {
                    Message = "Database update failed during event creation: " + dbEx.Message,
                };
            }
            catch (Exception ex) // Catch other exceptions
            {
                await transaction.RollbackAsync(); // Rollback the transaction
                throw ex;
            }
        }
    }

}