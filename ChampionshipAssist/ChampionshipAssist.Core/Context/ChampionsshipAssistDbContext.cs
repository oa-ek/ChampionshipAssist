using ChampionshipAssist.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipAssist.Core.Context
{
    public class ChampionsshipAssistDbContext : IdentityDbContext
    {
        public ChampionsshipAssistDbContext() { }
        public ChampionsshipAssistDbContext(DbContextOptions<ChampionsshipAssistDbContext> options)
            : base(options)
        {
        }

        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();
        new public DbSet<User> Users => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3E83AFL\\SQLEXPRESS;Database=JetEduDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}