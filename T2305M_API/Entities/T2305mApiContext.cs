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

    public virtual DbSet<Category> Categories { get; set; }
    public DbSet<Art> Art { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Creator> Creator { get; set; }
    //public DbSet<Article> Article { get; set; }
    //public DbSet<ArticleImage> ArticleImage { get; set; }
    public DbSet<Exhibition> Exhibition { get; set; }
    public DbSet<Culture> Culture { get; set; }
    public DbSet<Artifact> Artifact { get; set; }
    public DbSet<NationalEvent> NationalEvent { get; set; }
    //public DbSet<EntityImage> EntityImage { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //// Art to Creator Relationship (One-to-Many)
        //modelBuilder.Entity<Art>()
        //    .HasOne(a => a.Creator)
        //    .WithMany(c => c.Arts)
        //    .HasForeignKey(a => a.CreatorId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //// Artifact to Creator Relationship (One-to-Many)
        //modelBuilder.Entity<Artifact>()
        //    .HasOne(a => a.Creator)
        //    .WithMany(c => c.Artifacts)
        //    .HasForeignKey(a => a.CreatorId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //// Book to Creator Relationship (One-to-Many)
        //modelBuilder.Entity<Book>()
        //    .HasOne(b => b.Creator)
        //    .WithMany(c => c.Books)
        //    .HasForeignKey(b => b.CreatorId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //// Culture to Creator Relationship (One-to-Many)
        //modelBuilder.Entity<Culture>()
        //    .HasOne(c => c.Creator)
        //    .WithMany(cr => cr.Cultures)
        //    .HasForeignKey(c => c.CreatorId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //// Exhibition to Creator Relationship (One-to-Many)
        //modelBuilder.Entity<Exhibition>()
        //    .HasOne(e => e.Creator)
        //    .WithMany(c => c.Exhibitions)
        //    .HasForeignKey(e => e.CreatorId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //// NationalEvent to Creator Relationship (One-to-Many)
        //modelBuilder.Entity<NationalEvent>()
        //    .HasOne(ne => ne.Creator)
        //    .WithMany(c => c.NationalEvents)
        //    .HasForeignKey(ne => ne.CreatorId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //// Article to Creator Relationship (One-to-Many)
        //modelBuilder.Entity<Article>()
        //    .HasOne(a => a.Creator)
        //    .WithMany(c => c.Articles)
        //    .HasForeignKey(a => a.CreatorId)
        //    .OnDelete(DeleteBehavior.Cascade);


        //// EntityImage to Various Entities Relationship (One-to-Many)
        //modelBuilder.Entity<EntityImage>()
        //    .HasOne(ei => ei.Art)
        //    .WithMany(a => a.ArtImages)
        //    .HasForeignKey(ei => ei.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_EntityImage_Art_RelatedEntityId");

        //modelBuilder.Entity<EntityImage>()
        //    .HasOne(ei => ei.Artifact)
        //    .WithMany(a => a.ArtifactImages)
        //    .HasForeignKey(ei => ei.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_EntityImage_Artifact_RelatedEntityId");

        //modelBuilder.Entity<EntityImage>()
        //    .HasOne(ei => ei.Book)
        //    .WithMany(b => b.BookImages)
        //    .HasForeignKey(ei => ei.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_EntityImage_Book_RelatedEntityId");

        //modelBuilder.Entity<EntityImage>()
        //    .HasOne(ei => ei.Culture)
        //    .WithMany(c => c.CultureImages)
        //    .HasForeignKey(ei => ei.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_EntityImage_Culture_RelatedEntityId");

        //modelBuilder.Entity<EntityImage>()
        //    .HasOne(ei => ei.Exhibition)
        //    .WithMany(e => e.ExhibitionImages)
        //    .HasForeignKey(ei => ei.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_EntityImage_Exhibition_RelatedEntityId");

        //modelBuilder.Entity<EntityImage>()
        //    .HasOne(ei => ei.NationalEvent)
        //    .WithMany(ne => ne.NationalEventImages)
        //    .HasForeignKey(ei => ei.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_EntityImage_NationalEvent_RelatedEntityId");

        //// Article Relationships
        //modelBuilder.Entity<Article>()
        //    .HasOne(a => a.Art)
        //    .WithMany(a => a.ArtArticles)
        //    .HasForeignKey(a => a.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_Article_Art_RelatedEntityId");

        //modelBuilder.Entity<Article>()
        //    .HasOne(a => a.Artifact)
        //    .WithMany(a => a.ArtifactArticles)
        //    .HasForeignKey(a => a.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_Article_Artifact_RelatedEntityId");

        //modelBuilder.Entity<Article>()
        //    .HasOne(a => a.Book)
        //    .WithMany(b => b.BookArticles)
        //    .HasForeignKey(a => a.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_Article_Book_RelatedEntityId");

        //modelBuilder.Entity<Article>()
        //    .HasOne(a => a.Culture)
        //    .WithMany(c => c.CultureArticles)
        //    .HasForeignKey(a => a.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_Article_Culture_RelatedEntityId");

        //modelBuilder.Entity<Article>()
        //    .HasOne(a => a.Exhibition)
        //    .WithMany(e => e.ExhibitionArticles)
        //    .HasForeignKey(a => a.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_Article_Exhibition_RelatedEntityId");

        //modelBuilder.Entity<Article>()
        //    .HasOne(a => a.NationalEvent)
        //    .WithMany(ne => ne.NationalEventArticles)
        //    .HasForeignKey(a => a.RelatedEntityId)
        //    .OnDelete(DeleteBehavior.Restrict)
        //    .HasConstraintName("FK_Article_NationalEvent_RelatedEntityId");

        //// Article Images
        //modelBuilder.Entity<Article>()
        //    .HasMany(a => a.ArticleImages)
        //    .WithOne(ai => ai.Article)
        //    .HasForeignKey(ai => ai.ArticleId)
        //    .OnDelete(DeleteBehavior.Cascade);


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}