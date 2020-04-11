using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Source.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidate_company_company_id",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_submission_challenge_id",
                table: "submission");

            migrationBuilder.DropIndex(
                name: "IX_submission_user_id",
                table: "submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidate",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_candidate_acceleration_id",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_candidate_company_id",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_candidate_user_id",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_acceleration_challenge_id",
                table: "acceleration");

            migrationBuilder.DropColumn(
                name: "id",
                table: "candidate");

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
                name: "PK_candidate",
                table: "candidate",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_submission_challenge_id",
                table: "submission",
                column: "challenge_id");

            migrationBuilder.CreateIndex(
                name: "IX_submission_user_id",
                table: "submission",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_acceleration_id",
                table: "candidate",
                column: "acceleration_id");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_CompanyId1",
                table: "candidate",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_user_id",
                table: "candidate",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_acceleration_challenge_id",
                table: "acceleration",
                column: "challenge_id");

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_company_CompanyId1",
                table: "candidate",
                column: "CompanyId1",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidate_company_CompanyId1",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_submission_challenge_id",
                table: "submission");

            migrationBuilder.DropIndex(
                name: "IX_submission_user_id",
                table: "submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidate",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_candidate_acceleration_id",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_candidate_CompanyId1",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_candidate_user_id",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "IX_acceleration_challenge_id",
                table: "acceleration");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "candidate");

            migrationBuilder.AlterColumn<int>(
                name: "company_id",
                table: "candidate",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "candidate",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidate",
                table: "candidate",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_submission_challenge_id",
                table: "submission",
                column: "challenge_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_submission_user_id",
                table: "submission",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_candidate_acceleration_id",
                table: "candidate",
                column: "acceleration_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_candidate_company_id",
                table: "candidate",
                column: "company_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_candidate_user_id",
                table: "candidate",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_acceleration_challenge_id",
                table: "acceleration",
                column: "challenge_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_company_company_id",
                table: "candidate",
                column: "company_id",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
