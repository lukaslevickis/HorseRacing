using System;
using HorseRacingBackend.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HorseRacingBackend.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Better> Betters { get; set; }
        public DbSet<Horse> Horses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Horse>()
                .HasMany(c => c.Betters)
                .WithOne(e => e.Horse);
        }
    }
}
