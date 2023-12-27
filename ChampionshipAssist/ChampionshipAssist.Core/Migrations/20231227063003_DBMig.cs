using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChampionshipAssist.Domain.Migrations
{
    /// <inheritdoc />
    public partial class DBMig : Migration
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
                    TournamentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "81c40b6d-807e-4781-a20a-8e3cfa311855", null, "Cybersportsman", "CYBERSPORTSMAN" },
                    { "a53c99fc-3478-43aa-9868-78031be30516", null, "Admin", "ADMIN" },
                    { "bb3c8ed4-2181-4bbd-b11c-7176a5a8c068", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BanCount", "BanDuration", "Bio", "ConcurrencyStamp", "Discriminator", "Documents", "Email", "EmailConfirmed", "IsBanned", "IsVACBanned", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "SteamLink", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1c8ac453-a106-4505-a91a-3994a69c2531", 0, 0, new DateTime(2023, 12, 27, 8, 30, 2, 568, DateTimeKind.Local).AddTicks(971), "This user haven't set up this thing yet.", "f75ac399-4e48-4656-a2b2-635326c2ffd4", "User", "", "cyber@example.com", true, false, false, false, null, "Gabe", "CYBER@EXAMPLE.COM", "GABE", "AQAAAAIAAYagAAAAENK32Z0ybZZjRFV8WYKGRaJR6It+WNStvMDR0T4LXWgaLTWQnAXeFMnnv/6jdK85Ug==", null, false, "Cybersportsman", "f531c818-c25f-451e-98eb-344477443a22", "https://steamcommunity.com/id/Gabe/", false, "Gabe" },
                    { "4c3e8446-b9f5-4678-b641-4bd70a101656", 0, 1, new DateTime(2023, 12, 27, 8, 30, 2, 568, DateTimeKind.Local).AddTicks(906), "This user haven't set up this thing yet.", "ac5d42e0-416c-4014-b617-2c2ff3e9d2bf", "User", "", "user@example.com", true, false, true, false, null, "Budding", "USER@EXAMPLE.COM", "BUDDING", "AQAAAAIAAYagAAAAEFedALHLm96v/CA6BCTvJmTDNSHfJhUA9FUIkGAosatR02ID2TYCBxwwsZ8kuTwAEQ==", null, false, "User", "abb4f05d-09cd-4c50-89f3-0555319c25c7", "https://steamcommunity.com/id/Budding/", false, "Budding" },
                    { "8cda2989-5039-4806-b4a9-bfb1ac6cdd9f", 0, 0, new DateTime(2023, 12, 27, 8, 30, 2, 568, DateTimeKind.Local).AddTicks(987), "This user haven't set up this thing yet.", "990163a4-ce93-4c07-8905-d82905a07718", "User", "", "admin@example.com", true, false, false, false, null, "zatebon", "ADMIN@EXAMPLE.COM", "ZATEBON", "AQAAAAIAAYagAAAAEJKR0v88p6OO7Q91peD5CPn8vDslIXWqsJsG8N+E13wYJY52sz5O86xFCGXi+KBasg==", null, false, "Admin", "d3e816d6-7a63-4253-a3eb-fd8db5d92839", "https://steamcommunity.com/id/zatebon/", false, "zatebon" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "EndDate", "Game", "IsOpenToCybersportsmen", "IsOpenToUsers", "IsPrivate", "LongDesc", "Name", "OrganizerId", "OrganizerName", "Rules", "ShortDesc", "StartDate", "VACBannedParticipantsAllowed" },
                values: new object[,]
                {
                    { "453ad7eb-9aa0-4af3-87d6-2dc04425fc0b", new DateTime(2025, 1, 10, 8, 30, 2, 827, DateTimeKind.Local).AddTicks(5310), "Counter-Strike: Global Offensive", true, false, false, "Long description.", "IEM Katowice 2024", "4c3e8446-b9f5-4678-b641-4bd70a101656", null, "Test1", "Big tournament for cybersportsmen only.", new DateTime(2024, 12, 27, 8, 30, 2, 827, DateTimeKind.Local).AddTicks(5304), false },
                    { "a44a5942-9f6a-4224-a718-2684c24a5619", new DateTime(2024, 1, 10, 8, 30, 2, 827, DateTimeKind.Local).AddTicks(5291), "Counter-Strike 1.6", true, true, false, "Long description.", "Winter Turnir 2023", "1c8ac453-a106-4505-a91a-3994a69c2531", null, "Test1", "Small tournament", new DateTime(2023, 12, 27, 8, 30, 2, 827, DateTimeKind.Local).AddTicks(5214), false },
                    { "e8686e75-f513-49b8-a1ee-b49df3e87f5b", new DateTime(2023, 12, 27, 8, 31, 2, 827, DateTimeKind.Local).AddTicks(5321), "Counter-Strike 1.6", false, true, false, "Long description.", "ChampionshipAssist test tournament", "4c3e8446-b9f5-4678-b641-4bd70a101656", null, "Test1", "Short description.", new DateTime(2023, 12, 27, 8, 30, 2, 827, DateTimeKind.Local).AddTicks(5318), true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "81c40b6d-807e-4781-a20a-8e3cfa311855", "1c8ac453-a106-4505-a91a-3994a69c2531" },
                    { "81c40b6d-807e-4781-a20a-8e3cfa311855", "4c3e8446-b9f5-4678-b641-4bd70a101656" },
                    { "bb3c8ed4-2181-4bbd-b11c-7176a5a8c068", "4c3e8446-b9f5-4678-b641-4bd70a101656" },
                    { "81c40b6d-807e-4781-a20a-8e3cfa311855", "8cda2989-5039-4806-b4a9-bfb1ac6cdd9f" },
                    { "a53c99fc-3478-43aa-9868-78031be30516", "8cda2989-5039-4806-b4a9-bfb1ac6cdd9f" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Commentary", "Rating", "TournamentId", "UserId" },
                values: new object[,]
                {
                    { "1ccd77b6-1e06-46ed-811a-6ce6937e96b1", "Worst one so far.", 1.0, "e8686e75-f513-49b8-a1ee-b49df3e87f5b", "1c8ac453-a106-4505-a91a-3994a69c2531" },
                    { "4783df8f-b513-4cc5-bb19-21da0ce2b88a", "Great tournament so far.", 5.0, "a44a5942-9f6a-4224-a718-2684c24a5619", "8cda2989-5039-4806-b4a9-bfb1ac6cdd9f" },
                    { "695ed085-f7bf-44bd-bc95-24b8f58989f5", "Could be better a bit.", 4.0, "453ad7eb-9aa0-4af3-87d6-2dc04425fc0b", "1c8ac453-a106-4505-a91a-3994a69c2531" },
                    { "6c0a6e78-eb97-431e-b0b4-770ef9adab0e", "Could be worse.", 3.0, "e8686e75-f513-49b8-a1ee-b49df3e87f5b", "4c3e8446-b9f5-4678-b641-4bd70a101656" }
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
