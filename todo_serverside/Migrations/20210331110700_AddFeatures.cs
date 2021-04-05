using Microsoft.EntityFrameworkCore.Migrations;

namespace todo_serverside.Migrations
{
    public partial class AddFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Common",
                table: "TodoLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserIds",
                table: "TodoLists",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "TodoItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Friends",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrinedsRequest",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Common",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "UserIds",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Friends",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FrinedsRequest",
                table: "AspNetUsers");
        }
    }
}
