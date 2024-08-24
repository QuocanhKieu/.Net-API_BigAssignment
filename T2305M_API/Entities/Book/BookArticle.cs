using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class BookArticle
    {
        [Key]
        public int BookArticleId { get; set; }  // Primary Key

        [Required]
        [StringLength(200, ErrorMessage = "Title length can't be more than 200 characters.")]
        public string Title { get; set; }  // Title of the article

        [Required]
        public string Content { get; set; }  // Content of the article

        [ForeignKey("Book")]
        public int BookId { get; set; }  // Foreign Key to Book

        public Book Book { get; set; }  // Navigation property

        public ICollection<BookArticleImage>? BookArticleImages { get; set; }  // List of images related to the article
    }
}
