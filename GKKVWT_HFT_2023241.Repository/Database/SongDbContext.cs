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
    }
}
