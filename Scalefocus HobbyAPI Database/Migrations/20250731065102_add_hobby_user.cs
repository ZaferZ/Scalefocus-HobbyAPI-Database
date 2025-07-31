using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Scalefocus_HobbyAPI_Database.Migrations
{
    /// <inheritdoc />
    public partial class add_hobby_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HobbyUser",
                columns: table => new
                {
                    HobbiesId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyUser", x => new { x.HobbiesId, x.UserId });
                    table.ForeignKey(
                        name: "FK_HobbyUser_Hobbies_HobbiesId",
                        column: x => x.HobbiesId,
                        principalTable: "Hobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbyUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HobbyUser",
                columns: new[] { "HobbiesId", "UserId", "CreatedAt" },
                values: new object[,]
                {
                    { 1, new Guid("3bae1d94-7392-477e-922e-e656a8597661"), new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f"), new DateTime(2024, 1, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f"), new DateTime(2024, 2, 2, 11, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HobbyUser_UserId",
                table: "HobbyUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HobbyUser");
        }
    }
}
