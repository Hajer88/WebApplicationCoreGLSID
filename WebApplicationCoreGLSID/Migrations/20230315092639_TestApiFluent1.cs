using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSID.Migrations
{
    /// <inheritdoc />
    public partial class TestApiFluent1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categs",
                keyColumn: "Id",
                keyValue: new Guid("8c3bdb73-0aac-4ed8-bf58-7b02706550c8"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categs",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "A",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldDefaultValue: "A");

            migrationBuilder.InsertData(
                table: "Categs",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8c3bdb73-0aac-4ed8-bf58-7b02706550c8"), "CatFromFluent" });
        }
    }
}
