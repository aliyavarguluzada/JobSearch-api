using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Favorites_VacancyId",
                table: "Favorites",
                column: "VacancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Vacancies_VacancyId",
                table: "Favorites",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Vacancies_VacancyId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_VacancyId",
                table: "Favorites");
        }
    }
}
