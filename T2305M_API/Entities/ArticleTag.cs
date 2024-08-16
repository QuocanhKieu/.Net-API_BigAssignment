namespace T2305M_API.Entities
{
    public class ArticleTag
    {
        public int ArticleId { get; set; } // Foreign Key
        public Article Article { get; set; }
        public int TagId { get; set; } // Foreign Key
        public Tag Tag { get; set; }
    }

}
