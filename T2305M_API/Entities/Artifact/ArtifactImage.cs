using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class ArtifactImage
    {
        [Key]
        public int ArtifactImageId { get; set; }  // Primary Key

        [Required]
        [StringLength(255, ErrorMessage = "ImageUrl length can't be more than 255 characters.")]
        public string ImageUrl { get; set; }  // URL to the image

        [StringLength(255, ErrorMessage = "Thumbnail length can't be more than 255 characters.")]
        public string? Thumbnail { get; set; }  // Optional Thumbnail URL

        [ForeignKey("Artifact")]
        public int ArtifactId { get; set; }  // Foreign Key to Artifact

        public Artifact Artifact { get; set; }  // Navigation property
    }
}
