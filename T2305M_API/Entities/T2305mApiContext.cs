using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace T2305M_API.Entities;

public partial class T2305mApiContext : DbContext
{
    public static string ConnectionString;
    public T2305mApiContext()
    {
    }

    public T2305mApiContext(DbContextOptions<T2305mApiContext> options)
        : base(options)
    {
    }
    // Define DbSets for each entity
    public virtual DbSet<Category> Categories { get; set; }
    //public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Artifact> Artifacts { get; set; }
    public virtual DbSet<Sport> Sports { get; set; }
    public virtual DbSet<NationalHistory> NationalHistories { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId)
                  .HasName("PK_Comments");

            entity.ToTable("Comments");

            entity.Property(e => e.CommentId).HasColumnName("CommentId");
            entity.Property(e => e.ArticleId).HasColumnName("ArticleId");
            entity.Property(e => e.UserId).HasColumnName("UserId");
            entity.Property(e => e.Content)
                  .HasColumnType("nvarchar(max)")
                  .HasColumnName("Content");
            entity.Property(e => e.CommentDate)
                  .HasColumnType("datetime2")
                  .HasColumnName("CommentDate");
            entity.Property(e => e.IsActive)
                  .HasColumnType("bit")
                  .HasColumnName("IsActive");

            // Configure foreign key relationships with NO ACTION
            entity.HasOne(d => d.Article)
                  .WithMany(p => p.Comments)
                  .HasForeignKey(d => d.ArticleId)
                  .OnDelete(DeleteBehavior.Restrict) // Prevents cascade delete
                  .HasConstraintName("FK_Comments_Article_ArticleId");

            entity.HasOne(d => d.User)
                  .WithMany(p => p.Comments)
                  .HasForeignKey(d => d.UserId)
                  .OnDelete(DeleteBehavior.Restrict) // Prevents cascade delete
                  .HasConstraintName("FK_Comments_Users_UserId");
        });

        // Other entity configurations...
    }
}
