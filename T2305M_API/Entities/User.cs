using System;
using System.Collections.Generic;

namespace T2305M_API.Entities;

public class User
{
    public int UserId { get; set; } // Primary Key
    public string Thumbnail { get; set; } // Thumbnail image
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } // e.g., User, Admin
    public string ProfilePicture { get; set; }
    public string Bio { get; set; }
    public DateTime JoinedDate { get; set; }
    public bool IsActive { get; set; } // Active/Inactive status
    public ICollection<Article> Articles { get; set; }
    public ICollection<Comment> Comments { get; set; }
    //public ICollection<Submission> Submissions { get; set; }
}

