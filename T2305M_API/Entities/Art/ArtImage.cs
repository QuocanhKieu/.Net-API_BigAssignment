using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class ArtImage
    {
        [Key]
        public int ArtImageId { get; set; }

        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }  // Full URL to the image

        [Required]
        [StringLength(255)]
        public string Thumbnail { get; set; }  // Thumbnail URL for the image

        [ForeignKey("Art")]
        public int ArtId { get; set; }  // Foreign Key to Art

        public Art Art { get; set; }  // Navigation property
    }
}
