using Azure;

namespace T2305M_API.Entities
{
    public class Article
    {
        public int ArticleId { get; set; } // Primary Key
        public string Thumbnail { get; set; } // Thumbnail image
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; } // Foreign Key
        public User Author { get; set; }
        public int CategoryId { get; set; } // Foreign Key
        public Category Category { get; set; }
        public string Status { get; set; } // e.g., Draft, Submitted, Approved, Rejected
        public DateTime CreatedDate { get; set; }
        public DateTime? PublishedDate { get; set; } // Nullable
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

}
