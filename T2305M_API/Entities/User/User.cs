using System;
using System.Collections.Generic;

namespace T2305M_API.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public string Role { get; set; } = null!;
    public int Age { get; set; } = 0!;
    public ICollection<UserEvent>? UserEvents { get; set; }  // Navigation property for many-to-many

}
