using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanNeuro.DAL.Migrations
{
    public partial class CardFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "End",
                table: "Cards",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "ItemNumber",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Start",
                table: "Cards",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Cards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Boards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ItemNumber",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Boards");
        }
    }
}
