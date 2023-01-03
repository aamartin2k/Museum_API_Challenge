using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using MuseumAPI.Domain.Models;

namespace MuseumAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        // Declarations
        public DbSet<Museum> Museums { get; set; }

        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Overrides
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // create tables
            // MuseumTheme
            builder.Entity<MuseumTheme>().ToTable("MuseumThemes");
            builder.Entity<MuseumTheme>().HasKey(p => p.Id);
            builder.Entity<MuseumTheme>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<MuseumTheme>().Property(p => p.Description).IsRequired().HasMaxLength(30);
            // data
            builder.Entity<MuseumTheme>().HasData
            (
                new MuseumTheme { Id = 10, Description = "Art" },
                new MuseumTheme { Id = 11, Description = "Natural Science" },
                new MuseumTheme { Id = 12, Description = "History" }
            );
            // Museum
            builder.Entity<Museum>().ToTable("Museums");
            builder.Entity<Museum>().HasKey(p => p.Id);
            builder.Entity<Museum>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<Museum>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Museum>().Property(p => p.Address).IsRequired().HasMaxLength(50);

            builder.Entity<Museum>().HasMany(p => p.Articles).WithOne(p => p.Museum).HasForeignKey(p => p.MuseumId);

            builder.Entity<Museum>().HasData
            (
                new Museum { Id = 100, Name = "Modern Art Museum", Address = "25 Modern Art Plaza", ThemeId = 10 },
                new Museum { Id = 100, Name = "Natural Science Museum", Address = "3423 Third Avenue", ThemeId = 11 },
                new Museum { Id = 100, Name = "Ancient History Museum", Address = "875 45th Street", ThemeId = 12 }
            );



        }
    }
}
