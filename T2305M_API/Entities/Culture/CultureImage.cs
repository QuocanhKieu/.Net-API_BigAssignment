using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class CultureImage
    {
        [Key]
        public int CultureImageId { get; set; }  // Primary Key

        [Required]
        [StringLength(255, ErrorMessage = "Image URL length can't be more than 255 characters.")]
        public string ImageUrl { get; set; }  // URL to the image

        [ForeignKey("Culture")]
        public int CultureId { get; set; }  // Foreign Key to Culture

        public Culture Culture { get; set; }  // Navigation property
    }
}
