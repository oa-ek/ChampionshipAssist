using ChampionshipAssist.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipAssist.Core.Context
{
    public static class ChampionsshipAssistDbInitializerExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            string reviewId1 = Guid.NewGuid().ToString();
            string reviewId2 = Guid.NewGuid().ToString();
            string reviewId3 = Guid.NewGuid().ToString();

            string tournamentId1 = Guid.NewGuid().ToString();
            string tournamentId2 = Guid.NewGuid().ToString();
            string tournamentId3 = Guid.NewGuid().ToString();

            (string adminId, string cybersportsmanId, string userId) = seedUsersAndRoles(builder);
            seedTournaments(builder, tournamentId1, tournamentId2, tournamentId3);
            seedReviews(builder, tournamentId1, tournamentId2, tournamentId3, reviewId1, reviewId2, reviewId3, adminId, cybersportsmanId, userId);
        }

        private static void seedReviews(ModelBuilder builder, string tID1, string tID2, string tID3, string rID1, string rID2, string rID3, string uID1, string uID2, string uID3)
        {
            builder.Entity<Review>().HasData(
                new Review
                {
                    Id = rID1,
                    TournamentId = tID1,
                    UserId = uID1,
                    Commentary = "Test1",
                    Rating = 5.0
                },
                new Review
                {
                    Id = rID2,
                    TournamentId = tID2,
                    UserId = uID2,
                    Commentary = "Test2",
                    Rating = 4.0
                },
                new Review
                {
                    Id = rID3,
                    TournamentId = tID3,
                    UserId = uID3,
                    Commentary = "Test3",
                    Rating = 3.0
                }
                );
        }

        private static void seedTournaments(ModelBuilder builder, string tID1, string tID2, string tID3)
        {
            builder.Entity<Tournament>().HasData(
                new Tournament
                {
                    Id = tID1,
                    Name = "Test1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    ShortDesc = "Short description.",
                    LongDesc = "Long description.",
                    Rules = "Test1",
                    IsOpenToUsers = true,
                    IsOpenToCybersportsmen = true,
                    IsPrivate = false
                },
                new Tournament
                {
                    Id = tID2,
                    Name = "Test2",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    ShortDesc = "Short description.",
                    LongDesc = "Long description.",
                    Rules = "Test1",
                    IsOpenToUsers = false,
                    IsOpenToCybersportsmen = true,
                    IsPrivate = false
                },
                new Tournament
                {
                    Id = tID3,
                    Name = "Test3",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    ShortDesc = "Short description.",
                    LongDesc = "Long description.",
                    Rules = "Test1",
                    IsOpenToUsers = true,
                    IsOpenToCybersportsmen = false,
                    IsPrivate = false
                }
                );
        }

        static (string, string, string) seedUsersAndRoles(ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string CYBERSPORTSMAN_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = ADMIN_ROLE_ID, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = CYBERSPORTSMAN_ROLE_ID, Name = "Cybersportsman", NormalizedName = "CYBERSPORTSMAN" },
                new IdentityRole { Id = USER_ROLE_ID, Name = "User", NormalizedName = "USER" }
                );

            string ADMIN_ID = Guid.NewGuid().ToString();
            string CYBERSPORTSMAN_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();

            var user = new User
            {
                Id = USER_ID,
                UserName = "Budding",
                Email = "user@example.com",
                SteamLink = "https://steamcommunity.com/id/Budding/",
                Documents = "",
                IsBanned = false,
                IsVACBanned = true,
                BanDuration = DateTime.Now,
                BanCount = 1,
                EmailConfirmed = true,
                NormalizedEmail = "USER@EXAMPLE.COM",
                NormalizedUserName = "BUDDING"
            };
            var cybersportsman = new User
            {
                Id = CYBERSPORTSMAN_ID,
                Name = "Gabe",
                SteamLink = "https://steamcommunity.com/id/Gabe/",
                Email = "cyber@example.com",
                Documents = "",
                IsBanned = false,
                IsVACBanned = false,
                BanDuration = DateTime.Now,
                BanCount = 0,
                EmailConfirmed = true,
                NormalizedEmail = "CYBER@EXAMPLE.COM",
                NormalizedUserName = "GABE"
            };
            var admin = new User
            {
                Id = ADMIN_ID,
                Name = "zatebon",
                SteamLink = "https://steamcommunity.com/id/zatebon/",
                Email = "admin@example.com",
                Documents = "",
                IsBanned = false,
                IsVACBanned = false,
                BanDuration = DateTime.Now,
                BanCount = 0,
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                NormalizedUserName = "ZATEBON"
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin$pass");
            cybersportsman.PasswordHash = hasher.HashPassword(cybersportsman, "cybersportsman$pass");
            user.PasswordHash = hasher.HashPassword(user, "user$pass");

            builder.Entity<User>().HasData(admin, cybersportsman, user);

            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = CYBERSPORTSMAN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = CYBERSPORTSMAN_ROLE_ID,
                    UserId = CYBERSPORTSMAN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = CYBERSPORTSMAN_ROLE_ID,
                    UserId = USER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });
            return (ADMIN_ID, CYBERSPORTSMAN_ID, USER_ID);
        }
    }
}
