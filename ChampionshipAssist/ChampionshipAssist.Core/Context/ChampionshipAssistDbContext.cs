using ChampionshipAssist.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipAssist.Core.Context
{
    public class ChampionshipAssistDbContext : IdentityDbContext
    {
        public ChampionshipAssistDbContext() 
        {
        }
        public ChampionshipAssistDbContext(DbContextOptions<ChampionshipAssistDbContext> options)
            : base(options)
        {
        }

        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();
        new public DbSet<User> Users => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3E83AFL\\SQLEXPRESS;Database=ChampionshipAssistDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tournament>()
                .HasMany(x => x.Reviews)
                .WithOne(x => x.Tournament).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tournament>()
                .HasMany(x => x.Participants)
                .WithMany(x => x.Tournaments);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}