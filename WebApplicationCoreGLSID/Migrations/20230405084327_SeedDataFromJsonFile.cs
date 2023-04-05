using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSID.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataFromJsonFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categs",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("19081e90-a19f-42d0-a6d4-be095dac327e"), "TestFromSeedDataJson" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categs",
                keyColumn: "Id",
                keyValue: new Guid("19081e90-a19f-42d0-a6d4-be095dac327e"));
        }
    }
}
