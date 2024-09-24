using System.ComponentModel.DataAnnotations;

namespace T2305M_API.DTO.Event
{
public class GetBasicEventDTO
{
    [Key]
    public int EventId { get; set; }
    public string Title { get; set; }
    public string ThumbnailImage { get; set; }
    public string Description { get; set; }
    public bool IsHostOnline { get; set; }
    public string Type { get; set; } = "Event";
    public string Organizer { get; set; }
    public int? MaxAttendees { get; set; }  
    public int? CurrentAttendees { get; set; }
    public bool IsCanceled { get; set; }
    public bool IsPromoted { get; set; }
    public decimal? TicketPrice { get; set; }
    public string? Location { get; set; }
    public string? Address { get; set; }
    public DateTime? SaleDueDate { get; set; }  // before StartDate at least one day
    public DateTime StartDate { get; set; }  // Start date of the event
    public TimeSpan StartTime { get; set; }
    public string TimeZone { get; set; }
    public string CreatorName { get; set; }
}


    public class GetDetailEventDTO
    {
        [Key]
        public int EventId { get; set; }
        public string ThumbnailImage { get; set; }
        public int? MaxAttendees { get; set; }
        public int? CurrentAttendees { get; set; }
        public DateTime? SaleDueDate { get; set; }  // before StartDate at least one day
        public DateTime StartDate { get; set; }  // Start date of the event
        public DateTime? EndDate { get; set; }   // End date of the event, can be null if it's a single-day event
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public string Content { get; set; }
        public string? WebsiteUrl { get; set; }
        public decimal? TicketPrice { get; set; }
        public string CreatorName { get; set; }
    }

    public class CreateEventDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string ThumbnailImage { get; set; }
        public bool IsHostOnline { get; set; }
        public decimal? TicketPrice { get; set; }
        public DateTime? SaleDueDate { get; set; }
        public int? MaxAttendees { get; set; }
        public int? CurrentAttendees { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsPromoted { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? FileName { get; set; }// content for the page detail of the event
        // Event Time
        public DateTime StartDate { get; set; }  // Start date of the event
        public DateTime? EndDate { get; set; }   // End date of the event, can be null if it's a single-day event
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string TimeZone { get; set; }
        // Location Fileds
        public string Continent { get; set; }
        public string Country { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        // Creator
        public int CreatorId { get; set; }

        public CreateEventDTO()
        {
            // Set default values if other fields are not provided
            MaxAttendees ??= 100;
            CurrentAttendees ??= 40;
            SaleDueDate ??= DateTime.Now.AddMonths(1);
            TimeZone = TimeZone ?? "GMT+7";
            IsCanceled = false;
            IsPromoted = false;
            IsHostOnline = false;
            CreatorId = 5;
        }
    }

    public class CreateEventResponseDTO
    {
        public int EventId { get; set; }
        public bool IsActive { get; set; }
        public string Message { get; set; }
    }

    public class UpdateEventDTO : CreateEventDTO
    {
        public int EventId { get; set; }
    }

    public class EventQueryParameters
    {
        const int maxPageSize = 50;
        public int Page { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPageSize ? maxPageSize : value; }
        }
        public bool isToday { get; set; }
        public bool isThisWeek { get; set; }
        public bool isNextWeek { get; set; }
        public bool IsHostOnline { get; set; }
        public string? Country { get; set; }
        public string? Continent { get; set; }
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; } = "asc";  // "asc" or "desc" for sorting order
    }
}
