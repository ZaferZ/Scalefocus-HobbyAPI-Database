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
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "EventParticipants",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_EventParticipants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "EventId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Looking forward to this event!", new DateTime(2024, 6, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new Guid("3bae1d94-7392-477e-922e-e656a8597661") },
                    { 2, "Count me in!", new DateTime(2024, 6, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f") },
                    { 3, "Excited to learn painting.", new DateTime(2024, 7, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f") }
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Date", "Title", "Updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chess", 20240101 },
                    { 2, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Painting", 20240201 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("3bae1d94-7392-477e-922e-e656a8597661"), "alice.smith@example.com", "Alice", "Smith", "hash1", "alice123" },
                    { new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f"), "bob.johnson@example.com", "Bob", "Johnson", "hash2", "bob456" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Capacity", "CreatedAt", "CreatedBy", "Description", "EndDate", "HobbyId", "Location", "ModifiedAt", "ModifiedBy", "OwnerId", "ParticipantIds", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 20, new DateTime(2024, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3bae1d94-7392-477e-922e-e656a8597661"), "A friendly chess tournament.", new DateTime(2024, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, "Community Center", null, null, new Guid("3bae1d94-7392-477e-922e-e656a8597661"), null, new DateTime(2024, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 0, "Chess Tournament" },
                    { 2, 15, new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f"), "Learn to paint with watercolors.", new DateTime(2024, 8, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, "Art Studio", null, null, new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f"), null, new DateTime(2024, 8, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 0, "Painting Workshop" }
                });

            migrationBuilder.InsertData(
                table: "EventParticipants",
                columns: new[] { "EventId", "UserId", "JoinedAt", "ModifiedAt", "ModifiedBy", "Role" },
                values: new object[,]
                {
                    { 1, new Guid("3bae1d94-7392-477e-922e-e656a8597661"), new DateTime(2024, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 },
                    { 1, new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f"), new DateTime(2024, 6, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 },
                    { 2, new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f"), new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_UserId",
                table: "EventParticipants",
                column: "UserId");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EventParticipants");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
