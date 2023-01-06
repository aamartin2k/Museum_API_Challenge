using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using MuseumAPI.Common;
using MuseumAPI.Domain.Models;

namespace MuseumAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        // Declarations
        public DbSet<Museum> Museums { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<MuseumTheme> Themes { get; set; }
        public DbSet<ArticleStatus> Status { get; set; }

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
            builder.Entity<MuseumTheme>().Property(p => p.Description).IsRequired().HasMaxLength(Constants.CHAR_LENGTH_30);
            // data
            builder.Entity<MuseumTheme>().HasData
            (
                new MuseumTheme { Id = 100, Description = "Art" },
                new MuseumTheme { Id = 101, Description = "Natural Science" },
                new MuseumTheme { Id = 102, Description = "History" }
            );

            // ArticleStatus
            // OnDisplay, Stored, Damaged, OnLoan
            builder.Entity<ArticleStatus>().ToTable("ArticleStatus");
            builder.Entity<ArticleStatus>().HasKey(p => p.Id);
            builder.Entity<ArticleStatus>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<ArticleStatus>().Property(p => p.Description).IsRequired().HasMaxLength(Constants.CHAR_LENGTH_30);
            // data
            builder.Entity<ArticleStatus>().HasData
            (
                new ArticleStatus { Id = 100, Description = "On Display" },
                new ArticleStatus { Id = 101, Description = "Stored" },
                new ArticleStatus { Id = 102, Description = "Damaged" },
                new ArticleStatus { Id = 103, Description = "On Loan" }
            );

            // Museum
            builder.Entity<Museum>().ToTable("Museums");
            builder.Entity<Museum>().HasKey(p => p.Id);
            builder.Entity<Museum>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<Museum>().Property(p => p.Name).IsRequired().HasMaxLength(Constants.CHAR_LENGTH_50);
            builder.Entity<Museum>().Property(p => p.Address).IsRequired().HasMaxLength(Constants.CHAR_LENGTH_50);
            builder.Entity<Museum>().Property(p => p.ThemeId).IsRequired();

            builder.Entity<Museum>().HasMany(p => p.Articles).WithOne(p => p.Museum).HasForeignKey(p => p.MuseumId);

            builder.Entity<Museum>().HasData
            (
                new Museum { Id = 100, Name = "Modern Art Museum", Address = "25 Modern Art Plaza", ThemeId = 100 },
                new Museum { Id = 101, Name = "Natural Science Museum", Address = "3423 Third Avenue", ThemeId = 101 },
                new Museum { Id = 102, Name = "Ancient History Museum", Address = "875 45th Street", ThemeId = 102 },
                new Museum { Id = 103, Name = "Post Modern Art Museum", Address = "445 Fifth Avenue", ThemeId = 100 }
            );

            // Article
            builder.Entity<Article>().ToTable("Articles");
            builder.Entity<Article>().HasKey(p => p.Id);
            builder.Entity<Article>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<Article>().Property(p => p.Name).IsRequired().HasMaxLength(Constants.CHAR_LENGTH_50);
            builder.Entity<Article>().Property(p => p.StatusId).IsRequired();

            builder.Entity<Article>().HasData
            (
                new Article { Id = 101, Name = "Magic Tablet", StatusId = 100, MuseumId = 100 },
                new Article { Id = 102, Name = "Miniature Cowboy", StatusId = 100, MuseumId = 101 },
                new Article { Id = 103, Name = "Neanderthal", StatusId = 100, MuseumId = 101 },
                new Article { Id = 104, Name = "Big Dinosaur", StatusId = 100, MuseumId = 102 },
                new Article { Id = 105, Name = "Pharaoh", StatusId = 102, MuseumId = 102 },
                new Article { Id = 106, Name = "Small Dinosaur", StatusId = 103 },
                new Article { Id = 107, Name = "Stuffed Monkey", StatusId = 100, MuseumId = 100 }
            );
        }
    }
}
