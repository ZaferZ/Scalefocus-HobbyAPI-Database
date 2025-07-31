using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Scalefocus_HobbyAPI_Database.Migrations
{
    /// <inheritdoc />
    public partial class added_task_and_eventTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTasks",
                columns: table => new
                {
                    TasksId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTasks", x => new { x.EventId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_EventTasks_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTasks_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "IsCompleted", "ModifiedAt", "Title" },
                values: new object[,]
                {
                    { 1, "Arrange all chess boards and pieces before the tournament starts.", false, new DateTime(2024, 6, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), "Set up chess boards" },
                    { 2, "Print and distribute score sheets for all matches.", false, new DateTime(2024, 6, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), "Prepare score sheets" },
                    { 3, "Purchase watercolors, brushes, and paper for the workshop.", false, new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Buy painting supplies" },
                    { 4, "Arrange easels and workspaces for participants.", false, new DateTime(2024, 8, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), "Set up easels" }
                });

            migrationBuilder.InsertData(
                table: "EventTasks",
                columns: new[] { "EventId", "TasksId", "AddedAt", "ModifiedAt", "ModifiedBy", "Role" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 },
                    { 1, 2, new DateTime(2024, 6, 15, 9, 5, 0, 0, DateTimeKind.Unspecified), null, null, 0 },
                    { 2, 3, new DateTime(2024, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2 },
                    { 2, 4, new DateTime(2024, 8, 14, 17, 5, 0, 0, DateTimeKind.Unspecified), null, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTasks_TasksId",
                table: "EventTasks",
                column: "TasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTasks");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
