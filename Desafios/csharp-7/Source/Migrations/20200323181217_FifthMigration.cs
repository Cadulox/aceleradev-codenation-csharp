using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Source.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidate_company_CompanyId1",
                table: "candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_submission_user_UserId1",
                table: "submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_submission",
                table: "submission");

            migrationBuilder.DropIndex(
                name: "IX_submission_UserId1",
                table: "submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidate",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_candidate_CompanyId1",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_candidate_user_id",
                table: "candidate");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "submission");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "candidate");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "submission",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "company_id",
                table: "candidate",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_submission",
                table: "submission",
                columns: new[] { "user_id", "challenge_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidate",
                table: "candidate",
                columns: new[] { "user_id", "acceleration_id", "company_id" });

            migrationBuilder.CreateIndex(
                name: "IX_candidate_company_id",
                table: "candidate",
                column: "company_id");

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_company_company_id",
                table: "candidate",
                column: "company_id",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_submission_user_user_id",
                table: "submission",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidate_company_company_id",
                table: "candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_submission_user_user_id",
                table: "submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_submission",
                table: "submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidate",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_candidate_company_id",
                table: "candidate");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "submission",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "submission",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "company_id",
                table: "candidate",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "candidate",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_submission",
                table: "submission",
                column: "user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidate",
                table: "candidate",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_submission_UserId1",
                table: "submission",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_CompanyId1",
                table: "candidate",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_user_id",
                table: "candidate",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_company_CompanyId1",
                table: "candidate",
                column: "CompanyId1",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_submission_user_UserId1",
                table: "submission",
                column: "UserId1",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
