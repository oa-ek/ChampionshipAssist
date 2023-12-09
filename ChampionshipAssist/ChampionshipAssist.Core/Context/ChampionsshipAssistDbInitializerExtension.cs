using ChampionshipAssist.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipAssist.Core.Context
{
    public static class ChampionsshipAssistDbInitializerExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            seedReviews(builder);
            seedTournaments(builder);
            (string admId, string stdId, string teachId) = seedUsersAndRoles(builder);
        }

        private static void seedReviews(ModelBuilder builder)
        {
            builder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    TournamentId = "1",
                    UserId = "1",
                    Commentary = "Test1",
                    Rating = 5.0
                },
                new Review
                {
                    Id = 2,
                    TournamentId = "2",
                    UserId = "1",
                    Commentary = "Test2",
                    Rating = 4.0
                },
                new Review
                {
                    Id = 3,
                    TournamentId = "3",
                    UserId = "1",
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
                    Id = 1,
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
                    Id = 2,
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
                    Id = 3,
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
