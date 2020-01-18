using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanNeuro.DAL.Migrations
{
    public partial class ItemNumberNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ItemNumber",
                table: "Cards",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Cards",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ItemNumber",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
