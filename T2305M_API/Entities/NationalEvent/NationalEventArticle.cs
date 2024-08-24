using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class NationalEventArticle
    {
        [Key]
        public int NationalEventArticleId { get; set; }  // Primary Key

        [Required]
        [StringLength(200, ErrorMessage = "Title length can't be more than 200 characters.")]
        public string Title { get; set; }  // Title of the article

        [Required]
        public string Content { get; set; }  // Content of the article

        [ForeignKey("NationalEvent")]
        public int NationalEventID { get; set; }  // Foreign Key to NationalEvent

        public NationalEvent NationalEvent { get; set; }  // Navigation property

        public ICollection<NationalEventArticleImage>? NationalEventArticleImages { get; set; }  // List of images related to the article
    }
}
