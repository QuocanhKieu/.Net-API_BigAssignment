using System;
using System.Collections.Generic;

namespace T2305M_API.Entities;

public class Category
{
    public int CategoryId { get; set; } // Primary Key
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public ICollection<Article> Articles { get; set; }
    public ICollection<Artifact> Artifacts { get; set; }
    public ICollection<Exhibition> Exhibitions { get; set; }
    public ICollection<NationalHistory> NationalHistories { get; set; }
    public ICollection<Sport> Sports { get; set; }
    public ICollection<Art> Arts { get; set; }
}

