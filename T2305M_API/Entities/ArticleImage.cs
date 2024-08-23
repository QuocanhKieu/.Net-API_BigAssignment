using System.ComponentModel.DataAnnotations;
namespace T2305M_API.Entities
{
    public class ArticleImage
    {
        public int ArticleImageId { get; set; }  // Primary Key

        [Required]  // Ensure that ImageUrl is provided
        public string ImageUrl { get; set; }  // URL or binary data

        public int? ArticleId { get; set; }  // Foreign Key to Article

        public Article? Article { get; set; }  // Navigation property
    }

}
