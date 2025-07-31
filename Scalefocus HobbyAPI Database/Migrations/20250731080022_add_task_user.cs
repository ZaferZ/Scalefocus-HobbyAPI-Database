using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Scalefocus_HobbyAPI_Database.Migrations
{
    /// <inheritdoc />
    public partial class add_task_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskUser",
                columns: table => new
                {
                    TasksId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUser", x => new { x.TasksId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TaskUser_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TaskUser",
                columns: new[] { "TasksId", "UserId", "CreatedAt", "IsCompleted", "ModifiedAt", "ModifiedBy" },
                values: new object[,]
                {
                    { 1, new Guid("3bae1d94-7392-477e-922e-e656a8597661"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), false, null, null },
                    { 2, new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f"), new DateTime(2024, 6, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), false, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskUser_UserId",
                table: "TaskUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskUser");
        }
    }
}
