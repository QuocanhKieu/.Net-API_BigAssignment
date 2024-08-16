namespace T2305M_API.Entities
{
    public class NationalHistory
    {
        public int Id { get; set; } // Primary Key
        public string Thumbnail { get; set; } // Thumbnail image
        public string Country { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Period { get; set; }
        public string ImportantEvents { get; set; }
        public bool IsActive { get; set; } // Active/Inactive status

    }


}
