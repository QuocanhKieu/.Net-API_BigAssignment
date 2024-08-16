namespace T2305M_API.Entities
{
    public class Image
    {
        public int ImageId { get; set; } // Primary Key
        public string Url { get; set; } // URL or Path to the image
        public string Description { get; set; } // Optional description
        public int RecordId { get; set; } // Foreign Key to the related record
    }


}
