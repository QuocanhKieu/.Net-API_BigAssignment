namespace T2305M_API.Entities
{
    public class Sport
    {
        public int SportId { get; set; } // Primary Key
        public string Thumbnail { get; set; } // Thumbnail image
        public string Name { get; set; }
        public string Origin { get; set; }
        public string HistoricalDevelopment { get; set; }
        public string ImportantFigures { get; set; }
        public int CategoryId { get; set; } // Foreign Key
        public Category Category { get; set; }
        public bool IsActive { get; set; } // Active/Inactive status
    }

}
