namespace T2305M_API.DTO.UserEvent
{
    public class BookmarkDTO
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
    public class BookmarkResponseDTO
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string Message { get; set; }
    }
}
