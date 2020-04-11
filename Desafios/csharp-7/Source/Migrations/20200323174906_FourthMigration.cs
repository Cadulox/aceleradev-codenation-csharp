using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Source.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_submission_challenge_ChallengeId1",
                table: "submission");

            migrationBuilder.DropForeignKey(
                name: "FK_submission_user_user_id",
                table: "submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_submission",
                table: "submission");

            migrationBuilder.DropIndex(
                name: "IX_submission_user_id",
                table: "submission");

            migrationBuilder.RenameColumn(
                name: "ChallengeId1",
                table: "submission",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_submission_ChallengeId1",
                table: "submission",
                newName: "IX_submission_UserId1");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "submission",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "challenge_id",
                table: "submission",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_submission",
                table: "submission",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_submission_challenge_id",
                table: "submission",
                column: "challenge_id");

            migrationBuilder.AddForeignKey(
                name: "FK_submission_challenge_challenge_id",
                table: "submission",
                column: "challenge_id",
                principalTable: "challenge",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_submission_user_UserId1",
                table: "submission",
                column: "UserId1",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_submission_challenge_challenge_id",
                table: "submission");

            migrationBuilder.DropForeignKey(
                name: "FK_submission_user_UserId1",
                table: "submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_submission",
                table: "submission");

            migrationBuilder.DropIndex(
                name: "IX_submission_challenge_id",
                table: "submission");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "submission",
                newName: "ChallengeId1");

            migrationBuilder.RenameIndex(
                name: "IX_submission_UserId1",
                table: "submission",
                newName: "IX_submission_ChallengeId1");

            migrationBuilder.AlterColumn<int>(
                name: "challenge_id",
                table: "submission",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "submission",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_submission",
                table: "submission",
                column: "challenge_id");

            migrationBuilder.CreateIndex(
                name: "IX_submission_user_id",
                table: "submission",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_submission_challenge_ChallengeId1",
                table: "submission",
                column: "ChallengeId1",
                principalTable: "challenge",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_submission_user_user_id",
                table: "submission",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
