using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevJobs.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(2000)", maxLength: 2000, nullable: false),
                    Company = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    IsRemote = table.Column<bool>(type: "bit", nullable: false),
                    SalaryRange = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantName = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    ApplicantEmail = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    JobVacancyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicants_Vacancies_JobVacancyId",
                        column: x => x.JobVacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_JobVacancyId",
                table: "Applicants",
                column: "JobVacancyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Vacancies");
        }
    }
}
