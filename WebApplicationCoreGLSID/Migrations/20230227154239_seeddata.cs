using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSID.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categs",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8c3bdb73-0aac-4ed8-bf58-7b02706550c8"), "CatFromFluent" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categs",
                keyColumn: "Id",
                keyValue: new Guid("8c3bdb73-0aac-4ed8-bf58-7b02706550c8"));
        }
    }
}
