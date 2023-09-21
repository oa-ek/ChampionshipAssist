using ChampionshipAssist.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipAssist.Core.Context
{
    public static class ChampionsshipAssistDbInitializerExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            seedReviews(builder);
            seedTournaments(builder);
            seedUsers(builder);
        }

        private static void seedReviews(ModelBuilder builder)
        {
            builder.Entity<Review>().HasData(
                new Review
                {
                    ReviewId = 1,
                    Commentary = "Test1",
                    Rating = 5.0
                },
                new Review
                {
                    ReviewId = 2,
                    Commentary = "Test2",
                    Rating = 4.0
                },
                new Review
                {
                    ReviewId = 3,
                    Commentary = "Test3",
                    Rating = 3.0
                }
                );
        }

        private static void seedTournaments(ModelBuilder builder)
        {
            builder.Entity<Tournament>().HasData(
                new Tournament
                {
                    TournamentId = 1,
                    Name = "Test1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Rules = "Test1",
                    IsOpenToAll = true
                },
                new Tournament
                {
                    TournamentId = 2,
                    Name = "Test2",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Rules = "Test1",
                    IsOpenToAll = true
                },
                new Tournament
                {
                    TournamentId = 3,
                    Name = "Test3",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Rules = "Test1",
                    IsOpenToAll = true
                }
                );
        }

        static void seedUsers(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username = "Test1",
                    Password = "Test2",
                    SteamLink = "Test3",
                    Documents = "Test4",
                    IsAdmin = false
                }
                );
        }
    }
}
