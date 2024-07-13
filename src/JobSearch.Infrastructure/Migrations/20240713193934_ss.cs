using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatorCode_Operators_OperatorId",
                table: "OperatorCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperatorCode",
                table: "OperatorCode");

            migrationBuilder.RenameTable(
                name: "OperatorCode",
                newName: "OperatorCodes");

            migrationBuilder.RenameIndex(
                name: "IX_OperatorCode_OperatorId",
                table: "OperatorCodes",
                newName: "IX_OperatorCodes_OperatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperatorCodes",
                table: "OperatorCodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorCodes_Operators_OperatorId",
                table: "OperatorCodes",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatorCodes_Operators_OperatorId",
                table: "OperatorCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperatorCodes",
                table: "OperatorCodes");

            migrationBuilder.RenameTable(
                name: "OperatorCodes",
                newName: "OperatorCode");

            migrationBuilder.RenameIndex(
                name: "IX_OperatorCodes_OperatorId",
                table: "OperatorCode",
                newName: "IX_OperatorCode_OperatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperatorCode",
                table: "OperatorCode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorCode_Operators_OperatorId",
                table: "OperatorCode",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
