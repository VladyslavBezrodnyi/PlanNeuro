using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanNeuro.DAL.Migrations
{
    public partial class FixAddConversationToBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationReplies_UserBoards_UserId_ConversationId",
                table: "ConversationReplies");

            migrationBuilder.RenameColumn(
                name: "ConversationId",
                table: "ConversationReplies",
                newName: "BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationReplies_UserId_ConversationId",
                table: "ConversationReplies",
                newName: "IX_ConversationReplies_UserId_BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationReplies_UserBoards_UserId_BoardId",
                table: "ConversationReplies",
                columns: new[] { "UserId", "BoardId" },
                principalTable: "UserBoards",
                principalColumns: new[] { "UserId", "BoardId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationReplies_UserBoards_UserId_BoardId",
                table: "ConversationReplies");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "ConversationReplies",
                newName: "ConversationId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationReplies_UserId_BoardId",
                table: "ConversationReplies",
                newName: "IX_ConversationReplies_UserId_ConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationReplies_UserBoards_UserId_ConversationId",
                table: "ConversationReplies",
                columns: new[] { "UserId", "ConversationId" },
                principalTable: "UserBoards",
                principalColumns: new[] { "UserId", "BoardId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
