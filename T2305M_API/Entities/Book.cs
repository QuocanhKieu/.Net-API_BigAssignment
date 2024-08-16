namespace T2305M_API.Entities
{
    public class Book
    {
        public int BookId { get; set; } // Primary Key
        public string Title { get; set; }
        public int AuthorId { get; set; } // Foreign Key
        public Author Author { get; set; }
        public int CategoryId { get; set; } // Foreign Key
        public Category Category { get; set; }
        public DateTime PublishedYear { get; set; }
        public string Summary { get; set; }
        public string ISBN { get; set; }
        public string CoverImage { get; set; }
        public bool IsActive { get; set; } // Active/Inactive status
    }

}
