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
        //protected override void OnModelCreating(ModelBuilder builder)
    }
}
