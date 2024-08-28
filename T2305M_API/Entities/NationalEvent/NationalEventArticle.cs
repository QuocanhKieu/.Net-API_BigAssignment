using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class NationalEventArticle
    {
        [Key]
        public int NationalEventArticleId { get; set; }  // Primary Key
        public string Title { get; set; }  // Title of the article
        public string Content { get; set; }  // Content of the article
        public string ThumbnailImage { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey("NationalEvent")]
        public int? NationalEventID { get; set; }  // Foreign Key to NationalEvent
        public NationalEvent NationalEvent { get; set; }  // Navigation property

        [ForeignKey("Creator")]
        public int? CreatorId { get; set; }  // Foreign Key to Creator
        public Creator? Creator { get; set; }  // Navigation property

        public ICollection<NationalEventArticleImage>? NationalEventArticleImages { get; set; }  // List of images related to the article
    }
}
