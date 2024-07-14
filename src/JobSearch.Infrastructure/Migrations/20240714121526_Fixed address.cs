using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixedaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Adresses_AdressId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_AdressId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Vacancies");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_AddressId",
                table: "Vacancies",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Adresses_AddressId",
                table: "Vacancies",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Adresses_AddressId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_AddressId",
                table: "Vacancies");

            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_AdressId",
                table: "Vacancies",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Adresses_AdressId",
                table: "Vacancies",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
