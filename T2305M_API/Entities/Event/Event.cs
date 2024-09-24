using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class Event
    {
        // Event Details
        [Key]
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string ThumbnailImage { get; set; }
        public bool IsHostOnline { get; set; }
        public decimal? TicketPrice { get; set; }
        public DateTime? SaleDueDate { get; set; }  // before StartDate at least one day
        public int? MaxAttendees { get; set; }
        public int? CurrentAttendees { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsPromoted { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? FileName { get; set; }// content for the page detail of the event
        // Event Time
        public DateTime StartDate { get; set; }  // Start date of the event // sort by default
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
        public Creator? Creator { get; set; }  // for include or eagerly load
        // System Fields
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
