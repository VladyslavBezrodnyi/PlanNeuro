using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanNeuro.DAL.Migrations
{
    public partial class FixRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_DoneUserId",
                table: "Cards");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_DoneUserId",
                table: "Cards",
                column: "DoneUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_DoneUserId",
                table: "Cards");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_DoneUserId",
                table: "Cards",
                column: "DoneUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
