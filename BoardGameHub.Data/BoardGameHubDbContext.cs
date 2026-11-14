using BoardGameHub.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameHub.Data
{
    public class BoardGameHubDbContext : IdentityDbContext
    {
        public BoardGameHubDbContext(DbContextOptions<BoardGameHubDbContext> options) 
            : base(options) 
        { 
        }

        public DbSet<Models.Category> Category { get; set; } = null!;
        public DbSet<Models.Game> Games { get; set; } = null!;
        public DbSet<Models.Shop> Shop { get; set; } = null!;
        public DbSet<Models.Tournament> Tournament { get; set; } = null!;
        public DbSet<Models.TournamentRegistration> TournamentRegistration { get; set;} = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new ShopConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
        }
    }
}
