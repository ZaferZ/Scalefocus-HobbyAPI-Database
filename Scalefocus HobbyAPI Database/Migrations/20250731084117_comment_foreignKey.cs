using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scalefocus_HobbyAPI_Database.Migrations
{
    /// <inheritdoc />
    public partial class comment_foreignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comments_EventId",
                table: "Comments",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Events_EventId",
                table: "Comments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Events_EventId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EventId",
                table: "Comments");
        }
    }
}
