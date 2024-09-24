using Microsoft.CodeAnalysis.FlowAnalysis;
using T2305M_API.DTO.Culture;
using T2305M_API.DTO.Event;
using T2305M_API.Entities;
using T2305M_API.Models;
using T2305M_API.Repositories;
using T2305M_API.Repositories.Implements;
using T2305M_API.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly ICreatorRepository _creatorRepository;
    private readonly IWebHostEnvironment _env;

    public EventService(IEventRepository eventRepository, IWebHostEnvironment env, ICreatorRepository creatorRepository)
    {
        _eventRepository = eventRepository;
        _env = env;
        _creatorRepository = creatorRepository;
    }

    public async Task<PaginatedResult<GetBasicEventDTO>> GetBasicEventDTOsAsync(EventQueryParameters queryParameters)
    {
        var (data, totalItems) = await _eventRepository.GetEventsAsync(queryParameters);

        var basicEventDTOs = new List<GetBasicEventDTO>();
         
        foreach (var a in data)
        {
            var creator = await _creatorRepository.GetCreatorByIdAsync(a.CreatorId);

            basicEventDTOs.Add(new GetBasicEventDTO
            {
                EventId = a.EventId,
                Title = a.Title,
                ThumbnailImage = a.ThumbnailImage,
                Description = a.Description,
                IsHostOnline = a.IsHostOnline,
                Organizer = a.Organizer,    
                MaxAttendees = a.MaxAttendees,
                CurrentAttendees = a.CurrentAttendees,
                IsCanceled  = a.IsCanceled,
                IsPromoted = a.IsPromoted,
                TicketPrice = a.TicketPrice,
                Location = a.Location,
                Address = a.Address,
                SaleDueDate = a.SaleDueDate,
                StartDate = a.StartDate,
                StartTime = a.StartTime,
                TimeZone = a.TimeZone,
                CreatorName = creator.Name,
            });
        }
        // Calculate total pages
        int totalPages = (int)Math.Ceiling((double)totalItems / queryParameters.PageSize);

        return new PaginatedResult<GetBasicEventDTO>
        {
            TotalItems = totalItems,
            PageSize = queryParameters.PageSize,
            CurrentPage = queryParameters.Page,
            TotalPages = totalPages,
            HasNextPage = queryParameters.Page < totalPages,
            HasPreviousPage = queryParameters.Page > 1,
            Data = basicEventDTOs
        };
    }

    public async Task<GetDetailEventDTO> GetDetailEventDTOByIdAsync(int eventId)
    {
        var eventInstance = await _eventRepository.GetEventByIdAsync(eventId);

        if (eventInstance == null)
        {
            return null; // Or throw an appropriate exception
        }
        // Define the path to your HTML file
        var filePath = Path.Combine(_env.WebRootPath, "content/Event", eventInstance.FileName);

        string htmlContent = "";
        if (System.IO.File.Exists(filePath))
        {
            try
            {
                htmlContent = System.IO.File.ReadAllText(filePath);
            }
            catch (IOException ioEx)
            {
                // Handle file read error (e.g., log the error)
                // Optionally, you can set htmlContent to a default value or handle it differently
                // Example:
                htmlContent = "";
                // Log the exception
                Console.Error.WriteLine($"Error reading file {filePath}: {ioEx.Message}");
            }
        }

        var creator = await _creatorRepository.GetCreatorByIdAsync(eventInstance.CreatorId);

        var detailEventDTO = new GetDetailEventDTO
        {
            Address = eventInstance.Address,
            CurrentAttendees = eventInstance.CurrentAttendees,
            Description = eventInstance.Description,
            EndDate = eventInstance.EndDate,
            EndTime = eventInstance.EndTime,
            EventId = eventId,
            Location = eventInstance.Location,
            MaxAttendees = eventInstance.MaxAttendees,
            Organizer = eventInstance.Organizer,
            SaleDueDate = eventInstance.SaleDueDate,
            StartDate = eventInstance.StartDate,
            StartTime = eventInstance.StartTime,
            ThumbnailImage = eventInstance.ThumbnailImage,
            TicketPrice = eventInstance.TicketPrice,
            WebsiteUrl = eventInstance.WebsiteUrl,
            Title = eventInstance.Title,
            Content = htmlContent,
            CreatorName = creator.Name
        };

        return detailEventDTO;
    }

    public async Task<CreateEventResponseDTO> CreateEventAsync(CreateEventDTO createEventDTO)
    {
        CreateEventResponseDTO createEventResponseDTO = await _eventRepository.CreateEventAsync(createEventDTO);
        return createEventResponseDTO;
    }
}