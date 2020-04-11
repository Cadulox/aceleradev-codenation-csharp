using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Source.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_submission_challenge_challenge_id",
                table: "submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_submission",
                table: "submission");

            migrationBuilder.DropIndex(
                name: "IX_submission_challenge_id",
                table: "submission");

            migrationBuilder.DropColumn(
                name: "id",
                table: "submission");

            migrationBuilder.AlterColumn<int>(
                name: "challenge_id",
                table: "submission",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ChallengeId1",
                table: "submission",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_submission",
                table: "submission",
                column: "challenge_id");

            migrationBuilder.CreateIndex(
                name: "IX_submission_ChallengeId1",
                table: "submission",
                column: "ChallengeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_submission_challenge_ChallengeId1",
                table: "submission",
                column: "ChallengeId1",
                principalTable: "challenge",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_submission_challenge_ChallengeId1",
                table: "submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_submission",
                table: "submission");

            migrationBuilder.DropIndex(
                name: "IX_submission_ChallengeId1",
                table: "submission");

            migrationBuilder.DropColumn(
                name: "ChallengeId1",
                table: "submission");

            migrationBuilder.AlterColumn<int>(
                name: "challenge_id",
                table: "submission",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "submission",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_submission",
                table: "submission",
                column: "id");

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
        }
    }
}
