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
                    OrganizerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOpenToUsers = table.Column<bool>(type: "bit", nullable: true),
                    IsOpenToCybersportsmen = table.Column<bool>(type: "bit", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: true),
                    VACBannedParticipantsAllowed = table.Column<bool>(type: "bit", nullable: true)
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
                    { "09d4bd83-f958-48eb-a51f-5012296fe2e5", null, "Cybersportsman", "CYBERSPORTSMAN" },
                    { "4e645d52-5d6b-4ba9-a74b-0b1a9910c5c5", null, "User", "USER" },
                    { "97e4db8a-728b-4428-9f30-5cd2a1ad86f5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BanCount", "BanDuration", "ConcurrencyStamp", "Discriminator", "Documents", "Email", "EmailConfirmed", "IsBanned", "IsVACBanned", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SteamLink", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3be42d94-1e2e-432d-971a-cae597376fa8", 0, 1, new DateTime(2023, 12, 10, 10, 1, 18, 612, DateTimeKind.Local).AddTicks(8119), "1c9df006-e3bc-40f6-8fee-a8a29f320a4a", "User", "", null, true, false, true, false, null, null, "USER@EXAMPLE.COM", "BUDDING", "AQAAAAIAAYagAAAAEA+XyhK7MiBkSdXGaQnlEnlwj7yUSBUH7dV7/5u34PdVZdIb4goenEPlTZR75T3/LQ==", null, false, "ebdbb16e-88dd-47b7-a6d5-46818a7971ee", "https://steamcommunity.com/id/Budding/", false, "Budding" },
                    { "aa2d7dc4-76e9-41a2-badb-1d2c1bc1c38b", 0, 0, new DateTime(2023, 12, 10, 10, 1, 18, 612, DateTimeKind.Local).AddTicks(8138), "a7ce060d-78a7-4a7d-a3ab-75135396390a", "User", "", null, true, false, false, false, null, "Gabe", "CYBER@EXAMPLE.COM", "GABE", "AQAAAAIAAYagAAAAEEVW2cPF173qN4DBMsEXQZpaggW6VlgxUkLSYOaIG/ssrQhHimmqZD0c8eBEGORqvA==", null, false, "b01e8fd1-a79b-4345-8ae3-2b64d0f9eab0", "https://steamcommunity.com/id/Gabe/", false, null },
                    { "e0f01b43-de9a-4b1f-bea5-9880c56090d5", 0, 0, new DateTime(2023, 12, 10, 10, 1, 18, 612, DateTimeKind.Local).AddTicks(8145), "ba879292-c4bf-4e5f-a69b-cca1352e1d3a", "User", "", null, true, false, false, false, null, "zatebon", "ADMIN@EXAMPLE.COM", "ZATEBON", "AQAAAAIAAYagAAAAEMc6Rwz6n86D3Jnbuq2ekH3HvmHHhNrtU0OontC/t3eHefxQy6gk5+Vz2Lk9CRX00w==", null, false, "387f29fd-c6a9-4c11-840e-0510a15e616f", "https://steamcommunity.com/id/zatebon/", false, null }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "EndDate", "IsOpenToCybersportsmen", "IsOpenToUsers", "IsPrivate", "LongDesc", "Name", "OrganizerId", "Rules", "ShortDesc", "StartDate", "VACBannedParticipantsAllowed" },
                values: new object[,]
                {
                    { "43e0540a-b10d-447b-92f6-cc665ff8ae14", new DateTime(2023, 12, 10, 10, 1, 18, 872, DateTimeKind.Local).AddTicks(5016), true, false, false, "Long description.", "Test2", null, "Test1", "Short description.", new DateTime(2023, 12, 10, 10, 1, 18, 872, DateTimeKind.Local).AddTicks(5015), null },
                    { "7d4b5a3a-0ada-4db8-b43c-99e81aefbe56", new DateTime(2023, 12, 10, 10, 1, 18, 872, DateTimeKind.Local).AddTicks(5019), false, true, false, "Long description.", "Test3", null, "Test1", "Short description.", new DateTime(2023, 12, 10, 10, 1, 18, 872, DateTimeKind.Local).AddTicks(5019), null },
                    { "9c7272cb-b425-4a3a-8b26-49964ea20b81", new DateTime(2023, 12, 10, 10, 1, 18, 872, DateTimeKind.Local).AddTicks(5011), true, true, false, "Long description.", "Test1", null, "Test1", "Short description.", new DateTime(2023, 12, 10, 10, 1, 18, 872, DateTimeKind.Local).AddTicks(4979), null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "09d4bd83-f958-48eb-a51f-5012296fe2e5", "3be42d94-1e2e-432d-971a-cae597376fa8" },
                    { "4e645d52-5d6b-4ba9-a74b-0b1a9910c5c5", "3be42d94-1e2e-432d-971a-cae597376fa8" },
                    { "09d4bd83-f958-48eb-a51f-5012296fe2e5", "aa2d7dc4-76e9-41a2-badb-1d2c1bc1c38b" },
                    { "09d4bd83-f958-48eb-a51f-5012296fe2e5", "e0f01b43-de9a-4b1f-bea5-9880c56090d5" },
                    { "97e4db8a-728b-4428-9f30-5cd2a1ad86f5", "e0f01b43-de9a-4b1f-bea5-9880c56090d5" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Commentary", "Rating", "TournamentId", "UserId" },
                values: new object[,]
                {
                    { "1ee17889-a012-407a-89bc-a4c8e8547dac", "Test2", 4.0, "43e0540a-b10d-447b-92f6-cc665ff8ae14", "aa2d7dc4-76e9-41a2-badb-1d2c1bc1c38b" },
                    { "433a3cbd-8e83-402b-baf6-48c8c876c458", "Test3", 3.0, "7d4b5a3a-0ada-4db8-b43c-99e81aefbe56", "3be42d94-1e2e-432d-971a-cae597376fa8" },
                    { "5347ce16-4dc5-4674-bbbc-5d908f9b8686", "Test1", 5.0, "9c7272cb-b425-4a3a-8b26-49964ea20b81", "e0f01b43-de9a-4b1f-bea5-9880c56090d5" }
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
