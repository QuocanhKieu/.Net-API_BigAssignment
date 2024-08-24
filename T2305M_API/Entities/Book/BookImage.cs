using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class BookImage
    {
        [Key]
        public int BookImageId { get; set; }  // Primary Key

        [Required]
        [StringLength(255, ErrorMessage = "Image URL length can't be more than 255 characters.")]
        public string ImageUrl { get; set; }  // URL to the image

        [ForeignKey("Book")]
        public int BookId { get; set; }  // Foreign Key to Book

        public Book Book { get; set; }  // Navigation property
    }
}
