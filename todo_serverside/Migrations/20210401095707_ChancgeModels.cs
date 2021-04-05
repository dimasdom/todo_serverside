using Microsoft.EntityFrameworkCore.Migrations;

namespace todo_serverside.Migrations
{
    public partial class ChancgeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TodoLists",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "FrinedsRequest",
                table: "AspNetUsers",
                newName: "TodoListsIds");

            migrationBuilder.AddColumn<string>(
                name: "FriendsRequest",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendsRequest",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "TodoLists",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TodoListsIds",
                table: "AspNetUsers",
                newName: "FrinedsRequest");
        }
    }
}
