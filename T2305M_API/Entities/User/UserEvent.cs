using T2305M_API.Entities;

public class UserEvent
{
    public int UserId { get; set; }
    public User? User { get; set; }  // Navigation property to User

    public int EventId { get; set; }
    public Event? Event { get; set; }  // Navigation property to Event
}