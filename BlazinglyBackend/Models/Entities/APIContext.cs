using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIBackend.Models.Entities;

public partial class APIContext : DbContext
{
    public APIContext(DbContextOptions<APIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TagItem> TagItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasIndex(e => e.TagItemId, "IX_Tags_TagItemId");

            entity.Property(e => e.TagName).IsRequired();
        });

        modelBuilder.Entity<TagItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TagItems__3214EC07010D67BF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MetaDescription).IsRequired();
            entity.Property(e => e.Selection).IsRequired();
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Url).IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
