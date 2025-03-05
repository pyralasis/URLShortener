using Microsoft.EntityFrameworkCore;

namespace ShortenerAPI.Models;

public class ShortenerContext : DbContext
{
    public ShortenerContext(DbContextOptions<ShortenerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShortenedURL>()
            .HasKey(su => new { su.ShortURLId});


    }

    public DbSet<ShortenedURL> ShortenedURLs { get; set; } = null!;
}