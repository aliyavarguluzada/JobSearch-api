using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removedOpIdfromOperator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperatorCodeId",
                table: "Operators");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OperatorCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OperatorCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReqDate",
                table: "OperatorCode",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ReqUserId",
                table: "OperatorCode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "OperatorCode",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OperatorCode");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OperatorCode");

            migrationBuilder.DropColumn(
                name: "ReqDate",
                table: "OperatorCode");

            migrationBuilder.DropColumn(
                name: "ReqUserId",
                table: "OperatorCode");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "OperatorCode");

            migrationBuilder.AddColumn<int>(
                name: "OperatorCodeId",
                table: "Operators",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
