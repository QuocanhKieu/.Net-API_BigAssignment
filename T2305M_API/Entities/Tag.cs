namespace T2305M_API.Entities
{
    public class Tag
    {
        public int TagId { get; set; } // Primary Key
        public string TagName { get; set; }
        public ICollection<Article> Articles { get; set; } // Many-to-Many Relationship
    }

}
