using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class NationalEventImage
    {
        [Key]
        public int NationalEventImageId { get; set; }  // Primary Key

        [Required]
        [StringLength(255, ErrorMessage = "Image URL length can't be more than 255 characters.")]
        public string ImageUrl { get; set; }  // URL to the image

        [ForeignKey("NationalEvent")]
        public int NationalEventID { get; set; }  // Foreign Key to NationalEvent

        public NationalEvent NationalEvent { get; set; }  // Navigation property
    }
}
