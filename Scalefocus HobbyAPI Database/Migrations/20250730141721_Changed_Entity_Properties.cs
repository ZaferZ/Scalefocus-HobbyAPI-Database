using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scalefocus_HobbyAPI_Database.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Entity_Properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Hobbies",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Hobbies",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Hobbies",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "Hobbies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "Comments",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comments",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Hobbies",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Hobbies",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Hobbies",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hobbies",
                newName: "type_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Comments",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "ID");
        }
    }
}
