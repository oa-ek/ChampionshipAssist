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
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    IsOpenToUsers = table.Column<bool>(type: "bit", nullable: false),
                    IsOpenToCybersportsmen = table.Column<bool>(type: "bit", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    VACBannedParticipantsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    OrganizerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    { "1e7602df-355b-4c15-bb7b-68cd965e44be", null, "Cybersportsman", "CYBERSPORTSMAN" },
                    { "3ab5abbb-f7dc-42ee-a8f7-1677b0eca325", null, "User", "USER" },
                    { "cdfc76d1-f3a3-410f-9419-47b45a63909c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BanCount", "BanDuration", "Bio", "ConcurrencyStamp", "Discriminator", "Documents", "Email", "EmailConfirmed", "IsBanned", "IsVACBanned", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "SteamLink", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "039f297a-9281-4aaf-bcdb-b20a8a8fdda1", 0, 1, new DateTime(2023, 12, 18, 0, 31, 31, 512, DateTimeKind.Local).AddTicks(6279), "This user haven't set up this thing yet.", "7af73542-fab9-43bf-b435-64beb8223932", "User", "", "user@example.com", true, false, true, false, null, "Budding", "USER@EXAMPLE.COM", "BUDDING", "AQAAAAIAAYagAAAAEGbyCYiIQELQMfpYD+YQ7sJH6V78/qUeqx7zLVZlgL4OfmX9e/gN2JjECpNECnFBXw==", null, false, "User", "2d6a00b1-b911-469b-8449-824236ef5589", "https://steamcommunity.com/id/Budding/", false, "Budding" },
                    { "3981bd44-b8a0-4d6e-b349-cda4721c1650", 0, 0, new DateTime(2023, 12, 18, 0, 31, 31, 512, DateTimeKind.Local).AddTicks(6334), "This user haven't set up this thing yet.", "3321a813-a4ac-4aee-9cc3-22b4d4531c56", "User", "", "cyber@example.com", true, false, false, false, null, "Gabe", "CYBER@EXAMPLE.COM", "GABE", "AQAAAAIAAYagAAAAEGZGo/EBx8RdTLQChx8pXTNXHFr2unEB7yCxnusAjVuUOKAFFKtYFk7S5A0Ja443RQ==", null, false, "Cybersportsman", "aa66cf33-cda8-46f4-bd2f-ef7daadee350", "https://steamcommunity.com/id/Gabe/", false, "Gabe" },
                    { "555ca63b-26ba-4e5b-8eda-53f7b7a381fc", 0, 0, new DateTime(2023, 12, 18, 0, 31, 31, 512, DateTimeKind.Local).AddTicks(6343), "This user haven't set up this thing yet.", "5e8a4086-6edc-4a1f-8177-9267121b4c83", "User", "", "admin@example.com", true, false, false, false, null, "zatebon", "ADMIN@EXAMPLE.COM", "ZATEBON", "AQAAAAIAAYagAAAAEKLuMf8KtgZfMyQeCLLDy5Tek+YzJFNtPpKWlCwOTaAi01oqgV7z6t5lAcBaDZZabA==", null, false, "Admin", "dafbb2e6-888b-456d-809d-93b1ea2550a0", "https://steamcommunity.com/id/zatebon/", false, "zatebon" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "EndDate", "Game", "IsOpenToCybersportsmen", "IsOpenToUsers", "IsPrivate", "LongDesc", "Name", "OrganizerId", "OrganizerName", "Rules", "ShortDesc", "StartDate", "VACBannedParticipantsAllowed", "WinnerId" },
                values: new object[,]
                {
                    { "0b03cdb5-cccf-4c10-bac0-b8f5dbdfc09a", new DateTime(2024, 1, 1, 0, 31, 31, 783, DateTimeKind.Local).AddTicks(3873), "Counter-Strike 1.6", true, true, false, "Long description.", "Winter Turnir 2023", "3981bd44-b8a0-4d6e-b349-cda4721c1650", null, "Test1", "Small tournament", new DateTime(2023, 12, 18, 0, 31, 31, 783, DateTimeKind.Local).AddTicks(3809), false, null },
                    { "8b472c53-c9e2-4538-a2e7-e7382696ef51", new DateTime(2023, 12, 18, 0, 32, 31, 783, DateTimeKind.Local).AddTicks(3893), "Counter-Strike 1.6", false, true, false, "Long description.", "ChampionshipAssist test tournament", "039f297a-9281-4aaf-bcdb-b20a8a8fdda1", null, "Test1", "Short description.", new DateTime(2023, 12, 18, 0, 31, 31, 783, DateTimeKind.Local).AddTicks(3891), true, "039f297a-9281-4aaf-bcdb-b20a8a8fdda1" },
                    { "f97c9551-4638-455e-bb1b-4701646905fb", new DateTime(2025, 1, 1, 0, 31, 31, 783, DateTimeKind.Local).AddTicks(3886), "Counter-Strike: Global Offensive", true, false, false, "Long description.", "IEM Katowice 2024", "039f297a-9281-4aaf-bcdb-b20a8a8fdda1", null, "Test1", "Big tournament for cybersportsmen only.", new DateTime(2024, 12, 18, 0, 31, 31, 783, DateTimeKind.Local).AddTicks(3881), false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1e7602df-355b-4c15-bb7b-68cd965e44be", "039f297a-9281-4aaf-bcdb-b20a8a8fdda1" },
                    { "3ab5abbb-f7dc-42ee-a8f7-1677b0eca325", "039f297a-9281-4aaf-bcdb-b20a8a8fdda1" },
                    { "1e7602df-355b-4c15-bb7b-68cd965e44be", "3981bd44-b8a0-4d6e-b349-cda4721c1650" },
                    { "1e7602df-355b-4c15-bb7b-68cd965e44be", "555ca63b-26ba-4e5b-8eda-53f7b7a381fc" },
                    { "cdfc76d1-f3a3-410f-9419-47b45a63909c", "555ca63b-26ba-4e5b-8eda-53f7b7a381fc" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Commentary", "Rating", "TournamentId", "UserId" },
                values: new object[,]
                {
                    { "425dc403-71c2-4e00-bce3-4832030b8290", "Could be better a bit.", 4.0, "f97c9551-4638-455e-bb1b-4701646905fb", "3981bd44-b8a0-4d6e-b349-cda4721c1650" },
                    { "538e993f-a29b-41aa-965d-a2020bb46289", "Could be worse.", 3.0, "8b472c53-c9e2-4538-a2e7-e7382696ef51", "039f297a-9281-4aaf-bcdb-b20a8a8fdda1" },
                    { "c1fe16ee-c13d-4a80-822f-161d1887c360", "Worst one so far.", 1.0, "8b472c53-c9e2-4538-a2e7-e7382696ef51", "3981bd44-b8a0-4d6e-b349-cda4721c1650" },
                    { "e8bbd55c-21c7-44b6-8d22-e7473499ce55", "Great tournament so far.", 5.0, "0b03cdb5-cccf-4c10-bac0-b8f5dbdfc09a", "555ca63b-26ba-4e5b-8eda-53f7b7a381fc" }
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
