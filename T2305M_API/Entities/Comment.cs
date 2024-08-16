namespace T2305M_API.Entities
{
    public class Comment
    {
        public int CommentId { get; set; } // Primary Key
        public int ArticleId { get; set; } // Foreign Key
        public Article Article { get; set; }
        public int UserId { get; set; } // Foreign Key
        public User User { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsActive { get; set; } // Active/Inactive status
    }

}
