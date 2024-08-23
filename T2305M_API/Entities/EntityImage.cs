

using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class EntityImage
    {
        public int EntityImageId { get; set; }  // Primary Key

        [Required(ErrorMessage = "Image URL is required.")]
        [StringLength(255, ErrorMessage = "Image URL cannot exceed 255 characters.")]
        public string ImageUrl { get; set; }  // URL or binary data

        [StringLength(255, ErrorMessage = "Thumbnail URL cannot exceed 255 characters.")]
        public string Thumbnail { get; set; } // Thumbnail URL

        // Generic Foreign Key
        public int? RelatedEntityId { get; set; } // Nullable if the image might not relate to any entity
        public string? RelatedEntityType { get; set; }  // Nullable if the type might be unspecified

        // Optional Navigation Properties
        public Art? Art { get; set; }
        public Book? Book { get; set; }
        public Exhibition? Exhibition { get; set; }
        public Culture? Culture { get; set; }
        public Artifact? Artifact { get; set; }
        public NationalEvent? NationalEvent { get; set; }
    }

}
