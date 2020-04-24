using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanNeuro.DAL.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Complexity",
                table: "Cards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoneUserId",
                table: "Cards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DoneUserId",
                table: "Cards",
                column: "DoneUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_DoneUserId",
                table: "Cards",
                column: "DoneUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_DoneUserId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_DoneUserId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Complexity",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DoneUserId",
                table: "Cards");
        }
    }
}
