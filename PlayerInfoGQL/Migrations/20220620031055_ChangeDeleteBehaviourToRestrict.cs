using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerInfoGQL.Migrations
{
    public partial class ChangeDeleteBehaviourToRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Comment_CommentType",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Comment_Player",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Player_AnalysisResult",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Player_Team",
                table: "Players");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Comment_CommentType",
                table: "Comments",
                column: "Type",
                principalTable: "CommentTypes",
                principalColumn: "Description",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Comment_Player",
                table: "Comments",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Player_AnalysisResult",
                table: "Players",
                column: "AnalysisResult",
                principalTable: "AnalysisResults",
                principalColumn: "Description",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Player_Team",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Comment_CommentType",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Comment_Player",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Player_AnalysisResult",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Player_Team",
                table: "Players");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Comment_CommentType",
                table: "Comments",
                column: "Type",
                principalTable: "CommentTypes",
                principalColumn: "Description",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Comment_Player",
                table: "Comments",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Player_AnalysisResult",
                table: "Players",
                column: "AnalysisResult",
                principalTable: "AnalysisResults",
                principalColumn: "Description",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Player_Team",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
