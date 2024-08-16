namespace T2305M_API.Entities
{
    public class Author
    {
        public int AuthorId { get; set; } // Primary Key
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Nationality { get; set; }
        public string Image { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Artifact> Artifacts { get; set; }
        public ICollection<Sport> Sports { get; set; }
        public ICollection<NationalHistory> NationalHistories { get; set; }
        public ICollection<Art> Arts { get; set; }
    }

}
