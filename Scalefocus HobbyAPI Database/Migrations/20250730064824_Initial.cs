using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Scalefocus_HobbyAPI_Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HobbyId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParticipantIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { new Guid("3bae1d94-7392-477e-922e-e656a8597661"), "alice.smith@example.com", "Alice", "Smith", "hash1", "salt1" },
                    { new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f"), "bob.johnson@example.com", "Bob", "Johnson", "hash2", "salt2" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Capacity", "CreatedAt", "CreatedBy", "Description", "EndDate", "HobbyId", "Location", "ModifiedAt", "ModifiedBy", "OwnerId", "ParticipantIds", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 20, new DateTime(2024, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3bae1d94-7392-477e-922e-e656a8597661"), "A friendly chess tournament.", new DateTime(2024, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, "Community Center", null, null, new Guid("3bae1d94-7392-477e-922e-e656a8597661"), null, new DateTime(2024, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 0, "Chess Tournament" },
                    { 2, 15, new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f"), "Learn to paint with watercolors.", new DateTime(2024, 8, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, "Art Studio", null, null, new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f"), null, new DateTime(2024, 8, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 0, "Painting Workshop" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatedBy",
                table: "Events",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ModifiedBy",
                table: "Events",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OwnerId",
                table: "Events",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
