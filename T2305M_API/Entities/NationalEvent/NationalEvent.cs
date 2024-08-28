using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class NationalEvent
    {
        [Key]
        public int NationalEventID { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        public string Title { get; set; }
        public string ThumbnailImage { get; set; }  
        public string Content { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true; // Default to active
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Location { get; set; }
        public string? Continent { get; set; }
        public string? Country { get; set; }  // E.g., "USA", "China", etc.
        // Collections
        public ICollection<NationalEventImage>? NationalEventImages { get; set; }  // List of images related to the NationalEvent

        public ICollection<NationalEventArticle>? NationalEventArticles { get; set; } // Related articles

        // Foreign Key to Creator
        public int? CreatorId { get; set; }

        public Creator? Creator { get; set; }  // Navigation property
    }
}
