using GKKVWT_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GKKVWT_HFT_2023241.Repository.Database
{
    public class SongDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Label> Labels { get; set; }

        public SongDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("musicdb").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
            .HasOne(s => s.Artist)
            .WithMany(a => a.Songs)
            .HasForeignKey(s => s.ArtistId);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Label)
                .WithMany(l => l.Songs)
                .HasForeignKey(s => s.LabelId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
