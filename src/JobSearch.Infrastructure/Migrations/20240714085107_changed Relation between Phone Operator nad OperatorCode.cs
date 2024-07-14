using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedRelationbetweenPhoneOperatornadOperatorCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Operators_OperatorId",
                table: "Phones");

            migrationBuilder.RenameColumn(
                name: "OperatorId",
                table: "Phones",
                newName: "OperatorCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Phones_OperatorId",
                table: "Phones",
                newName: "IX_Phones_OperatorCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_OperatorCodes_OperatorCodeId",
                table: "Phones",
                column: "OperatorCodeId",
                principalTable: "OperatorCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_OperatorCodes_OperatorCodeId",
                table: "Phones");

            migrationBuilder.RenameColumn(
                name: "OperatorCodeId",
                table: "Phones",
                newName: "OperatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Phones_OperatorCodeId",
                table: "Phones",
                newName: "IX_Phones_OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Operators_OperatorId",
                table: "Phones",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
