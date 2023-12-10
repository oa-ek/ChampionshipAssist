using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChampionshipAssist.Domain.Migrations
{
    /// <inheritdoc />
    public partial class DBMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SteamLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBanned = table.Column<bool>(type: "bit", nullable: true),
                    IsVACBanned = table.Column<bool>(type: "bit", nullable: true),
                    BanDuration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BanCount = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinnerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Game = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOpenToUsers = table.Column<bool>(type: "bit", nullable: true),
                    IsOpenToCybersportsmen = table.Column<bool>(type: "bit", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: true),
                    VACBannedParticipantsAllowed = table.Column<bool>(type: "bit", nullable: true),
                    OrganizerId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TournamentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TournamentUser",
                columns: table => new
                {
                    ParticipantsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TournamentsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentUser", x => new { x.ParticipantsId, x.TournamentsId });
                    table.ForeignKey(
                        name: "FK_TournamentUser_AspNetUsers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentUser_Tournaments_TournamentsId",
                        column: x => x.TournamentsId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "101e856d-0608-411c-85fd-507f6253a2bf", null, "User", "USER" },
                    { "9bb1ba55-7bf2-45d5-bc2e-00147f0bdd52", null, "Cybersportsman", "CYBERSPORTSMAN" },
                    { "b717d7b0-02e7-44a2-b05c-4126e085e762", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BanCount", "BanDuration", "Bio", "ConcurrencyStamp", "Discriminator", "Documents", "Email", "EmailConfirmed", "IsBanned", "IsVACBanned", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SteamLink", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3dc4f82a-7647-4ea3-94a4-87ff8b9a8c93", 0, 0, new DateTime(2023, 12, 10, 23, 31, 3, 148, DateTimeKind.Local).AddTicks(9054), "This user haven't set up this thing yet.", "cd49eef7-3afc-4b70-9d1d-56e86b473663", "User", "", "cyber@example.com", true, false, false, false, null, "Gabe", "CYBER@EXAMPLE.COM", "GABE", "AQAAAAIAAYagAAAAEK/LMM9giSiEVAAplx/DcgzlHuqa1hYRPBLm1LpHFSsUjFrH/fNFrnIzY38v8VgBXA==", null, false, "d6e8a779-d3fb-431d-b6e7-560e03a5b25b", "https://steamcommunity.com/id/Gabe/", false, "Gabe" },
                    { "701dc543-0ea4-4d7f-bdf2-55484669b302", 0, 0, new DateTime(2023, 12, 10, 23, 31, 3, 148, DateTimeKind.Local).AddTicks(9062), "This user haven't set up this thing yet.", "7af54871-6a9e-4e82-8d48-9790fe0954ce", "User", "", "admin@example.com", true, false, false, false, null, "zatebon", "ADMIN@EXAMPLE.COM", "ZATEBON", "AQAAAAIAAYagAAAAENa9SSf2VUuvdUOmCVMRoduYcUXkUK9IJ5BwdLSF6KWXggONPRldlhsDD6N97KQnug==", null, false, "48b47159-1032-42df-afd1-2cbf8c2317e9", "https://steamcommunity.com/id/zatebon/", false, "zatebon" },
                    { "a0e55193-a65f-4cf3-a090-8f25b7c8ce97", 0, 1, new DateTime(2023, 12, 10, 23, 31, 3, 148, DateTimeKind.Local).AddTicks(9002), "This user haven't set up this thing yet.", "6787b79b-15b9-4eb3-88d1-58ebe67be132", "User", "", "user@example.com", true, false, true, false, null, "Budding", "USER@EXAMPLE.COM", "BUDDING", "AQAAAAIAAYagAAAAEORV+UuuFVJalpLjkQ9Xncu+pMY3QhImQEmplBtXhJA+FJXGNn7gY5nw9oyOqjfy/g==", null, false, "23dc5fad-5ae9-4686-8b19-fe1bd968ba29", "https://steamcommunity.com/id/Budding/", false, "Budding" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "EndDate", "Game", "IsOpenToCybersportsmen", "IsOpenToUsers", "IsPrivate", "LongDesc", "Name", "OrganizerId", "Rules", "ShortDesc", "StartDate", "VACBannedParticipantsAllowed", "WinnerId" },
                values: new object[,]
                {
                    { "6bd4a72d-b4b4-47f5-aa9b-067bb7303f46", new DateTime(2024, 12, 24, 23, 31, 3, 389, DateTimeKind.Local).AddTicks(6540), "Counter-Strike: Global Offensive", true, false, false, "Long description.", "IEM Katowice 2024", "a0e55193-a65f-4cf3-a090-8f25b7c8ce97", "Test1", "Big tournament for cybersportsmen only.", new DateTime(2024, 12, 10, 23, 31, 3, 389, DateTimeKind.Local).AddTicks(6532), false, null },
                    { "832596c8-5e74-483d-ae22-eac37fff332c", new DateTime(2023, 12, 24, 23, 31, 3, 389, DateTimeKind.Local).AddTicks(6522), "Counter-Strike 1.6", true, true, false, "Long description.", "Winter Turnir 2023", "3dc4f82a-7647-4ea3-94a4-87ff8b9a8c93", "Test1", "Small tournament", new DateTime(2023, 12, 10, 23, 31, 3, 389, DateTimeKind.Local).AddTicks(6469), false, null },
                    { "b47efd7e-5312-46da-81ac-2ff9d3676c87", new DateTime(2023, 12, 10, 23, 32, 3, 389, DateTimeKind.Local).AddTicks(6547), "Counter-Strike 1.6", false, true, false, "Long description.", "ChampionshipAssist test tournament", "a0e55193-a65f-4cf3-a090-8f25b7c8ce97", "Test1", "Short description.", new DateTime(2023, 12, 10, 23, 31, 3, 389, DateTimeKind.Local).AddTicks(6545), true, "a0e55193-a65f-4cf3-a090-8f25b7c8ce97" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9bb1ba55-7bf2-45d5-bc2e-00147f0bdd52", "3dc4f82a-7647-4ea3-94a4-87ff8b9a8c93" },
                    { "9bb1ba55-7bf2-45d5-bc2e-00147f0bdd52", "701dc543-0ea4-4d7f-bdf2-55484669b302" },
                    { "b717d7b0-02e7-44a2-b05c-4126e085e762", "701dc543-0ea4-4d7f-bdf2-55484669b302" },
                    { "101e856d-0608-411c-85fd-507f6253a2bf", "a0e55193-a65f-4cf3-a090-8f25b7c8ce97" },
                    { "9bb1ba55-7bf2-45d5-bc2e-00147f0bdd52", "a0e55193-a65f-4cf3-a090-8f25b7c8ce97" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Commentary", "Rating", "TournamentId", "UserId" },
                values: new object[,]
                {
                    { "8225d2ae-ba5b-46b7-be48-182e1f11b4f5", "Could be worse.", 3.0, "b47efd7e-5312-46da-81ac-2ff9d3676c87", "a0e55193-a65f-4cf3-a090-8f25b7c8ce97" },
                    { "ce540c75-9781-46e0-aef1-c37234a4d1cc", "Great tournament so far.", 5.0, "832596c8-5e74-483d-ae22-eac37fff332c", "701dc543-0ea4-4d7f-bdf2-55484669b302" },
                    { "d597e7e0-c52b-4092-92c6-fbddfbbdd243", "Worst one so far.", 1.0, "b47efd7e-5312-46da-81ac-2ff9d3676c87", "3dc4f82a-7647-4ea3-94a4-87ff8b9a8c93" },
                    { "fb596014-a95b-4073-aaf9-a55dda519043", "Could be better a bit.", 4.0, "6bd4a72d-b4b4-47f5-aa9b-067bb7303f46", "3dc4f82a-7647-4ea3-94a4-87ff8b9a8c93" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TournamentId",
                table: "Reviews",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentUser_TournamentsId",
                table: "TournamentUser",
                column: "TournamentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TournamentUser");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
